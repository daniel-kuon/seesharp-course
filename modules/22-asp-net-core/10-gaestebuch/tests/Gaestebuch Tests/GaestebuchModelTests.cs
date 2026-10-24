using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;

public class GaestebuchModelTests
{
    private sealed class FakeGaestebuch(params Eintrag[] vorhanden) : IGaestebuch
    {
        public List<Eintrag> Gespeichert { get; } = [.. vorhanden];
        public void Hinzufuegen(Eintrag eintrag) => Gespeichert.Add(eintrag);
        public IReadOnlyList<Eintrag> Alle() => Gespeichert.ToList();
    }

    private static Eintrag E(string name, string text = "Hallo") => new() { Name = name, Text = text };

    private static GaestebuchModel Modell(IGaestebuch gaestebuch) => new(gaestebuch)
    {
        PageContext = new PageContext(new ActionContext(new DefaultHttpContext(), new RouteData(), new PageActionDescriptor())),
    };

    [Fact]
    public void Neu_ist_ein_BindProperty()
    {
        var eigenschaft = typeof(GaestebuchModel).GetProperty(nameof(GaestebuchModel.Neu))!;

        Assert.NotNull(eigenschaft.GetCustomAttribute<BindPropertyAttribute>());
    }

    [Fact]
    public void OnGet_zeigt_die_neuesten_Eintraege_zuerst()
    {
        var modell = Modell(new FakeGaestebuch(E("Alt"), E("Mitte"), E("Neu")));

        modell.OnGet();

        Assert.Equal(["Neu", "Mitte", "Alt"], modell.Eintraege.Select(e => e.Name));
    }

    [Fact]
    public void OnPost_gueltig_speichert_den_gebundenen_Eintrag()
    {
        var gaestebuch = new FakeGaestebuch();
        var modell = Modell(gaestebuch);
        modell.Neu = E("Lena", "Schöne Seite");

        modell.OnPost();

        var gespeichert = Assert.Single(gaestebuch.Gespeichert);
        Assert.Same(modell.Neu, gespeichert);
    }

    [Fact]
    public void OnPost_gueltig_leitet_auf_dieselbe_Seite_um()
    {
        var modell = Modell(new FakeGaestebuch());
        modell.Neu = E("Lena");

        var ergebnis = modell.OnPost();

        var umleitung = Assert.IsType<RedirectToPageResult>(ergebnis);
        Assert.Null(umleitung.PageName);
    }

    [Fact]
    public void OnPost_ungueltig_gibt_die_Seite_zurueck_und_speichert_nichts()
    {
        var gaestebuch = new FakeGaestebuch(E("Alt"));
        var modell = Modell(gaestebuch);
        modell.ModelState.AddModelError("Neu.Name", "Name fehlt");

        var ergebnis = modell.OnPost();

        Assert.IsType<PageResult>(ergebnis);
        Assert.Single(gaestebuch.Gespeichert);
    }

    [Fact]
    public void OnPost_ungueltig_zeigt_trotzdem_die_Eintraege()
    {
        var modell = Modell(new FakeGaestebuch(E("Alt"), E("Neu")));
        modell.ModelState.AddModelError("Neu.Text", "Text fehlt");

        modell.OnPost();

        Assert.Equal(["Neu", "Alt"], modell.Eintraege.Select(e => e.Name));
    }
}
