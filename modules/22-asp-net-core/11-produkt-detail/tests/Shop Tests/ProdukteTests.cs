using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

public class ProdukteTests
{
    // Startet die echte Anwendung (Program.cs) im Speicher; mit einem Katalog wird die Registrierung ersetzt.
    private sealed class TestAnwendung(IProduktkatalog? ersatz = null) : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (ersatz is not null)
                builder.ConfigureTestServices(s => s.AddSingleton(ersatz));
        }
    }

    private sealed class FakeKatalog : IProduktkatalog
    {
        private readonly Produkt _produkt = new(7, "Testprodukt", "Nur im Test");
        public IReadOnlyList<Produkt> Alle() => [_produkt];
        public Produkt? Finde(int id) => id == 7 ? _produkt : null;
    }

    [Fact]
    public async Task Liste_zeigt_alle_Produktnamen()
    {
        using var app = new TestAnwendung();

        var antwort = await app.CreateClient().GetAsync("/Produkte");
        var html = await antwort.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, antwort.StatusCode);
        Assert.Contains("Kaffeemuehle", html);
        Assert.Contains("Teekanne", html);
        Assert.Contains("Wasserkessel", html);
    }

    [Fact]
    public async Task Liste_verlinkt_jedes_Produkt_auf_seine_Detailseite()
    {
        using var app = new TestAnwendung();

        var html = await app.CreateClient().GetStringAsync("/Produkte");

        Assert.Contains("href=\"/Produkte/Detail/1\"", html);
        Assert.Contains("href=\"/Produkte/Detail/2\"", html);
        Assert.Contains("href=\"/Produkte/Detail/3\"", html);
    }

    [Fact]
    public async Task Detailseite_zeigt_Name_und_Beschreibung()
    {
        using var app = new TestAnwendung();

        var antwort = await app.CreateClient().GetAsync("/Produkte/Detail/2");
        var html = await antwort.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, antwort.StatusCode);
        Assert.Contains("Teekanne", html);
        Assert.Contains("Kanne aus Porzellan mit Sieb", html);
        Assert.DoesNotContain("Kaffeemuehle", html);
    }

    [Theory]
    [InlineData("/Produkte/Detail/99")]
    [InlineData("/Produkte/Detail/-1")]
    [InlineData("/Produkte/Detail/abc")]
    [InlineData("/Produkte/Detail")]
    public async Task Unbekanntes_Produkt_gibt_404(string pfad)
    {
        using var app = new TestAnwendung();

        var antwort = await app.CreateClient().GetAsync(pfad);

        Assert.Equal(HttpStatusCode.NotFound, antwort.StatusCode);
    }

    [Fact]
    public async Task Die_Seiten_benutzen_den_registrierten_Katalog()
    {
        using var app = new TestAnwendung(new FakeKatalog());
        var klient = app.CreateClient();

        var liste = await klient.GetStringAsync("/Produkte");
        var detail = await klient.GetAsync("/Produkte/Detail/7");

        Assert.Contains("Testprodukt", liste);
        Assert.DoesNotContain("Teekanne", liste);
        Assert.Equal(HttpStatusCode.OK, detail.StatusCode);
        Assert.Contains("Nur im Test", await detail.Content.ReadAsStringAsync());
    }
}
