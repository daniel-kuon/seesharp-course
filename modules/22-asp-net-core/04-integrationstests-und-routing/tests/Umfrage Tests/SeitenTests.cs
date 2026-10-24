using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

public class SeitenTests
{
    // Startet die echte Anwendung (Program.cs) im Speicher. Mit einem Dienst wird die Registrierung ersetzt.
    private sealed class TestAnwendung(IUmfrageDienst? ersatz = null) : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (ersatz is not null)
                builder.ConfigureTestServices(s => s.AddSingleton(ersatz));
        }

        public HttpClient Klient() => CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
    }

    private sealed class FakeDienst(int stimmenFuerSonnenpartei = 0) : IUmfrageDienst
    {
        public List<Stimme> Gespeichert { get; } = Enumerable.Range(0, stimmenFuerSonnenpartei).Select(_ => new Stimme { Partei = "Sonnenpartei" }).ToList();
        public IReadOnlyList<Stimme> Stimmen() => Gespeichert.ToList();
        public void Abgeben(Stimme stimme) => Gespeichert.Add(stimme);
    }

    // Ein POST an eine Razor Page braucht das Antiforgery-Token aus dem Formular; das zugehörige Cookie verwaltet der Klient selbst.
    private static async Task<HttpResponseMessage> Abstimmen(HttpClient klient, string partei, string name = "")
    {
        var formular = await klient.GetStringAsync("/Umfrage");
        var token = Regex.Match(formular, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        Assert.NotEmpty(token);
        var daten = new Dictionary<string, string>
        {
            ["Eingabe.Partei"] = partei,
            ["Eingabe.Name"] = name,
            ["__RequestVerificationToken"] = token,
        };
        return await klient.PostAsync("/Umfrage", new FormUrlEncodedContent(daten));
    }

    [Fact]
    public async Task Startseite_zeigt_alle_Parteien()
    {
        using var app = new TestAnwendung();

        var antwort = await app.Klient().GetAsync("/");
        var html = await antwort.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, antwort.StatusCode);
        foreach (var partei in Parteien.Alle)
            Assert.Contains(partei.Name, html);
    }

    [Fact]
    public async Task Detailseite_zeigt_die_gewaehlte_Partei()
    {
        using var app = new TestAnwendung();

        var antwort = await app.Klient().GetAsync("/Detail/2");
        var html = await antwort.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, antwort.StatusCode);
        Assert.Contains("Mondbund", html);
        Assert.DoesNotContain("Sonnenpartei", html);
    }

    [Fact]
    public async Task Detailseite_mit_Text_statt_Zahl_gibt_404()
    {
        using var app = new TestAnwendung();

        var antwort = await app.Klient().GetAsync("/Detail/abc");

        Assert.Equal(HttpStatusCode.NotFound, antwort.StatusCode);
    }

    [Fact]
    public async Task Detailseite_mit_unbekannter_Id_gibt_404()
    {
        using var app = new TestAnwendung();

        var antwort = await app.Klient().GetAsync("/Detail/99");

        Assert.Equal(HttpStatusCode.NotFound, antwort.StatusCode);
    }

    [Fact]
    public async Task Gueltige_Abstimmung_leitet_zur_Danke_Seite_weiter()
    {
        using var app = new TestAnwendung();

        var antwort = await Abstimmen(app.Klient(), "Mondbund", "Lena");

        Assert.Equal(HttpStatusCode.Redirect, antwort.StatusCode);
        Assert.Equal("/Danke?partei=Mondbund", antwort.Headers.Location!.OriginalString);
    }

    [Fact]
    public async Task Danke_Seite_nennt_die_Partei()
    {
        using var app = new TestAnwendung();

        var antwort = await app.Klient().GetAsync("/Danke?partei=Mondbund");
        var html = await antwort.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, antwort.StatusCode);
        Assert.Contains("Mondbund", html);
    }

    [Fact]
    public async Task Ungueltige_Abstimmung_zeigt_die_Fehlermeldung_wieder_an()
    {
        using var app = new TestAnwendung();

        var antwort = await Abstimmen(app.Klient(), "");
        var html = await antwort.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, antwort.StatusCode);
        Assert.Contains("Bitte eine Partei angeben", html);
    }

    [Fact]
    public async Task Die_Seiten_benutzen_den_registrierten_Dienst()
    {
        var fake = new FakeDienst(stimmenFuerSonnenpartei: 37);
        using var app = new TestAnwendung(fake);
        var klient = app.Klient();

        var detail = await klient.GetStringAsync("/Detail/1");
        await Abstimmen(klient, "Mondbund");

        Assert.Contains("37", detail);
        Assert.Equal("Mondbund", fake.Gespeichert[^1].Partei);
    }

    [Fact]
    public async Task Der_Dienst_ist_ein_Singleton_und_behaelt_Stimmen_zwischen_Anforderungen()
    {
        using var app = new TestAnwendung();
        var klient = app.Klient();
        var vorher = await klient.GetStringAsync("/Detail/2");

        for (var i = 0; i < 3; i++)
            await Abstimmen(klient, "Mondbund");
        var nachher = await klient.GetStringAsync("/Detail/2");

        Assert.DoesNotContain("3", vorher);
        Assert.Contains("3", nachher);
    }
}
