using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;

public class UmfrageModelTests
{
    private sealed class FakeDienst(params string[] parteien) : IUmfrageDienst
    {
        public List<Stimme> Gespeichert { get; } = parteien.Select(p => new Stimme { Partei = p }).ToList();
        public int Abrufe { get; private set; }

        public IReadOnlyList<Stimme> Stimmen()
        {
            Abrufe++;
            return Gespeichert.ToList();
        }

        public void Abgeben(Stimme stimme) => Gespeichert.Add(stimme);
    }

    // Ein PageModel braucht für ModelState einen PageContext; einen Webserver braucht es nicht.
    private static UmfrageModel Modell(IUmfrageDienst dienst) => new(dienst)
    {
        PageContext = new PageContext(new ActionContext(new DefaultHttpContext(), new RouteData(), new PageActionDescriptor())),
    };

    [Fact]
    public void Eingabe_ist_ein_BindProperty()
    {
        var eigenschaft = typeof(UmfrageModel).GetProperty(nameof(UmfrageModel.Eingabe))!;

        Assert.NotNull(eigenschaft.GetCustomAttribute<BindPropertyAttribute>());
    }

    [Fact]
    public void Eingabe_ist_nach_dem_Erzeugen_nicht_null()
    {
        var modell = Modell(new FakeDienst());

        Assert.NotNull(modell.Eingabe);
    }

    [Fact]
    public void OnGet_zaehlt_Stimmen_je_Partei_und_sortiert_absteigend()
    {
        var modell = Modell(new FakeDienst("Mondbund", "Sonnenpartei", "Sonnenpartei", "Sternenliste", "Sonnenpartei", "Mondbund"));

        modell.OnGet();

        Assert.Equal(
            [new ParteiErgebnis("Sonnenpartei", 3), new ParteiErgebnis("Mondbund", 2), new ParteiErgebnis("Sternenliste", 1)],
            modell.Ergebnisse);
    }

    [Fact]
    public void OnGet_sortiert_bei_Gleichstand_nach_Partei()
    {
        var modell = Modell(new FakeDienst("Zebra", "Adler", "Mondbund"));

        modell.OnGet();

        Assert.Equal(["Adler", "Mondbund", "Zebra"], modell.Ergebnisse.Select(e => e.Partei));
    }

    [Fact]
    public void OnGet_ohne_Stimmen_liefert_leere_Ergebnisse()
    {
        var modell = Modell(new FakeDienst());

        modell.OnGet();

        Assert.Empty(modell.Ergebnisse);
    }

    [Fact]
    public void OnPost_gueltig_speichert_genau_eine_Stimme()
    {
        var dienst = new FakeDienst();
        var modell = Modell(dienst);
        modell.Eingabe = new Stimme { Partei = "Mondbund", Name = "Lena" };

        modell.OnPost();

        var gespeichert = Assert.Single(dienst.Gespeichert);
        Assert.Equal("Mondbund", gespeichert.Partei);
        Assert.Equal("Lena", gespeichert.Name);
    }

    [Fact]
    public void OnPost_gueltig_leitet_zur_Danke_Seite_weiter()
    {
        var modell = Modell(new FakeDienst());
        modell.Eingabe = new Stimme { Partei = "Mondbund" };

        var ergebnis = modell.OnPost();

        var umleitung = Assert.IsType<RedirectToPageResult>(ergebnis);
        Assert.Equal("Danke", umleitung.PageName);
        Assert.Equal("Mondbund", umleitung.RouteValues!["partei"]);
    }

    [Fact]
    public void OnPost_ungueltig_gibt_die_Seite_zurueck_und_speichert_nichts()
    {
        var dienst = new FakeDienst();
        var modell = Modell(dienst);
        modell.ModelState.AddModelError("Eingabe.Partei", "Bitte eine Partei angeben");

        var ergebnis = modell.OnPost();

        Assert.IsType<PageResult>(ergebnis);
        Assert.Empty(dienst.Gespeichert);
    }

    [Fact]
    public void OnPost_ungueltig_fuellt_trotzdem_die_Ergebnisse()
    {
        var modell = Modell(new FakeDienst("Mondbund", "Mondbund"));
        modell.ModelState.AddModelError("Eingabe.Partei", "Bitte eine Partei angeben");

        modell.OnPost();

        Assert.Equal([new ParteiErgebnis("Mondbund", 2)], modell.Ergebnisse);
    }

    [Fact]
    public void Das_Modell_nutzt_den_injizierten_Dienst()
    {
        var dienst = new FakeDienst("Mondbund");
        var modell = Modell(dienst);

        modell.OnGet();

        Assert.Equal(1, dienst.Abrufe);
    }
}
