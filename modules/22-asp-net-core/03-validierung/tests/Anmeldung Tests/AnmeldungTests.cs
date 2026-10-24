using System.ComponentModel.DataAnnotations;

public class AnmeldungTests
{
    private static Anmeldung Gueltig() => new()
    {
        Name = "Anna",
        Alter = 30,
        Email = null,
        Beginn = new DateOnly(2026, 1, 10),
        Ende = new DateOnly(2026, 1, 20),
    };

    // Dieselbe Prüfung, die ASP.NET Core bei der Modellbindung ausführt.
    private static List<ValidationResult> Pruefe(Anmeldung a)
    {
        var fehler = new List<ValidationResult>();
        Validator.TryValidateObject(a, new ValidationContext(a), fehler, validateAllProperties: true);
        return fehler;
    }

    private static void ErwarteGenau(List<ValidationResult> fehler, string meldung, string eigenschaft)
    {
        var f = Assert.Single(fehler);
        Assert.Equal(meldung, f.ErrorMessage);
        Assert.Equal([eigenschaft], f.MemberNames);
    }

    [Fact]
    public void Gueltige_Anmeldung_hat_keine_Fehler()
    {
        Assert.Empty(Pruefe(Gueltig()));
    }

    [Fact]
    public void Anmeldung_implementiert_IValidatableObject()
    {
        Assert.IsAssignableFrom<IValidatableObject>(Gueltig());
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Name_fehlt(string? name)
    {
        var a = Gueltig();
        a.Name = name!;

        ErwarteGenau(Pruefe(a), "Name fehlt", "Name");
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(50, true)]
    [InlineData(51, false)]
    public void Name_Laenge_hat_die_Grenzen_2_und_50(int laenge, bool gueltig)
    {
        var a = Gueltig();
        a.Name = new string('x', laenge);

        var fehler = Pruefe(a);

        if (gueltig)
            Assert.Empty(fehler);
        else
            ErwarteGenau(fehler, "Name muss 2 bis 50 Zeichen lang sein", "Name");
    }

    [Theory]
    [InlineData(17, false)]
    [InlineData(18, true)]
    [InlineData(120, true)]
    [InlineData(121, false)]
    public void Alter_hat_die_Grenzen_18_und_120(int alter, bool gueltig)
    {
        var a = Gueltig();
        a.Alter = alter;

        var fehler = Pruefe(a);

        if (gueltig)
            Assert.Empty(fehler);
        else
            ErwarteGenau(fehler, "Alter muss zwischen 18 und 120 liegen", "Alter");
    }

    [Fact]
    public void Email_darf_fehlen()
    {
        var a = Gueltig();
        a.Email = null;

        Assert.Empty(Pruefe(a));
    }

    [Fact]
    public void Email_gueltig_wird_akzeptiert()
    {
        var a = Gueltig();
        a.Email = "anna@example.org";

        Assert.Empty(Pruefe(a));
    }

    [Fact]
    public void Email_ungueltig_wird_gemeldet()
    {
        var a = Gueltig();
        a.Email = "keine-adresse";

        ErwarteGenau(Pruefe(a), "E-Mail-Adresse ungültig", "Email");
    }

    [Fact]
    public void Ende_vor_Beginn_wird_fuer_Ende_gemeldet()
    {
        var a = Gueltig();
        a.Ende = a.Beginn.AddDays(-1);

        ErwarteGenau(Pruefe(a), "Ende liegt vor dem Beginn", "Ende");
    }

    [Fact]
    public void Ende_gleich_Beginn_ist_erlaubt()
    {
        var a = Gueltig();
        a.Ende = a.Beginn;

        Assert.Empty(Pruefe(a));
    }

    [Fact]
    public void Mehrere_Eigenschaftsfehler_werden_alle_gemeldet()
    {
        var a = Gueltig();
        a.Name = "";
        a.Alter = 5;

        var fehler = Pruefe(a);

        Assert.Equal(2, fehler.Count);
        Assert.Contains(fehler, f => f.MemberNames.Contains("Name"));
        Assert.Contains(fehler, f => f.MemberNames.Contains("Alter"));
    }

    [Fact]
    public void Validate_laeuft_erst_wenn_alle_Eigenschaftsregeln_erfuellt_sind()
    {
        var a = Gueltig();
        a.Name = "";
        a.Ende = a.Beginn.AddDays(-1);

        // Nur der Eigenschaftsfehler erscheint; die Regel aus Validate wird übersprungen.
        ErwarteGenau(Pruefe(a), "Name fehlt", "Name");
    }
}
