public class BruchTests
{
    [Fact]
    public void Nenner_ignoriert_null()
    {
        var b = new Bruch(3, 0, "x");

        Assert.Equal(1, b.Nenner);
    }

    [Fact]
    public void Etikett_wird_gekuerzt()
    {
        var b = new Bruch(1, 1, new string('a', 50));

        Assert.Equal(40, b.Etikett.Length);
    }

    [Fact]
    public void Anzahl_zaehlt_beide_Konstruktoren()
    {
        var vorher = Bruch.Anzahl;
        _ = new Bruch();
        _ = new Bruch(1, 2, "a");

        Assert.Equal(vorher + 2, Bruch.Anzahl);
    }

    [Fact]
    public void Standardkonstruktor_nutzt_Voreinstellungen_aus_statischem_Konstruktor()
    {
        var b = new Bruch();

        Assert.InRange(b.Zaehler, 1, 6);
        Assert.InRange(b.Nenner, b.Zaehler, 8);
    }

    [Fact]
    public void BenDef_liefert_gekuerzten_Bruch_mit_Etikett()
    {
        Console.SetIn(new StringReader("6\n8\n"));

        var b = Bruch.BenDef("Anteil");

        Assert.NotNull(b);
        Assert.Equal((3, 4, "Anteil"), (b!.Zaehler, b.Nenner, b.Etikett));
    }

    [Fact]
    public void BenDef_liefert_null_bei_ungueltiger_Eingabe()
    {
        Console.SetIn(new StringReader("abc\n"));

        Assert.Null(Bruch.BenDef("x"));
    }
}
