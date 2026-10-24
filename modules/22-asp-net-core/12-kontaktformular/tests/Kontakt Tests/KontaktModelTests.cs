using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;

public class KontaktModelTests
{
    private static KontaktModel Modell(string name = "Lena", string email = "lena@example.org", string nachricht = "Eine ausreichend lange Nachricht") => new()
    {
        PageContext = new PageContext(new ActionContext(new DefaultHttpContext(), new RouteData(), new PageActionDescriptor())),
        Eingabe = new Anfrage { Name = name, Email = email, Nachricht = nachricht },
    };

    // Ersetzt die Modellbindung: prüft die Eingabe mit denselben Attributen und trägt die Fehler in ModelState ein.
    private static IActionResult Absenden(KontaktModel modell)
    {
        var fehler = new List<ValidationResult>();
        Validator.TryValidateObject(modell.Eingabe, new ValidationContext(modell.Eingabe), fehler, validateAllProperties: true);
        foreach (var f in fehler)
            foreach (var feld in f.MemberNames)
                modell.ModelState.AddModelError("Eingabe." + feld, f.ErrorMessage ?? "");
        return modell.OnPost();
    }

    private static string Meldung(KontaktModel modell, string feld) =>
        Assert.Single(modell.ModelState["Eingabe." + feld]!.Errors).ErrorMessage;

    [Fact]
    public void Eingabe_ist_ein_BindProperty()
    {
        var eigenschaft = typeof(KontaktModel).GetProperty(nameof(KontaktModel.Eingabe))!;

        Assert.NotNull(eigenschaft.GetCustomAttribute<BindPropertyAttribute>());
    }

    [Fact]
    public void Gueltige_Eingabe_leitet_zur_Danke_Seite_weiter()
    {
        var ergebnis = Absenden(Modell());

        var umleitung = Assert.IsType<RedirectToPageResult>(ergebnis);
        Assert.Equal("Danke", umleitung.PageName);
    }

    [Fact]
    public void Fehlender_Name_gibt_die_Seite_mit_Meldung_zurueck()
    {
        var modell = Modell(name: "");

        var ergebnis = Absenden(modell);

        Assert.IsType<PageResult>(ergebnis);
        Assert.Equal("Name fehlt", Meldung(modell, "Name"));
    }

    [Fact]
    public void Fehlende_Email_wird_gemeldet()
    {
        var modell = Modell(email: "");

        var ergebnis = Absenden(modell);

        Assert.IsType<PageResult>(ergebnis);
        Assert.Equal("E-Mail fehlt", Meldung(modell, "Email"));
    }

    [Fact]
    public void Ungueltige_Email_wird_gemeldet()
    {
        var modell = Modell(email: "keine-adresse");

        var ergebnis = Absenden(modell);

        Assert.IsType<PageResult>(ergebnis);
        Assert.Equal("E-Mail-Adresse ungültig", Meldung(modell, "Email"));
    }

    [Theory]
    [InlineData(9, false)]
    [InlineData(10, true)]
    public void Nachricht_braucht_mindestens_10_Zeichen(int laenge, bool gueltig)
    {
        var modell = Modell(nachricht: new string('x', laenge));

        var ergebnis = Absenden(modell);

        if (gueltig)
            Assert.IsType<RedirectToPageResult>(ergebnis);
        else
        {
            Assert.IsType<PageResult>(ergebnis);
            Assert.Equal("Nachricht muss mindestens 10 Zeichen lang sein", Meldung(modell, "Nachricht"));
        }
    }

    [Fact]
    public void Mehrere_Fehler_werden_gemeinsam_gemeldet()
    {
        var modell = Modell(name: "", email: "", nachricht: "");

        Absenden(modell);

        Assert.Equal(3, modell.ModelState.ErrorCount);
    }
}
