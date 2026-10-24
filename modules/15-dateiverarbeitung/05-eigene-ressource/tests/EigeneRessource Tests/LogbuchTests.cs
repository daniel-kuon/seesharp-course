using EigeneRessource;

public class LogbuchTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    [Fact]
    public void Logbuch_implementiert_IDisposable()
    {
        Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Logbuch)));
    }

    [Fact]
    public void Eintraege_stehen_nach_dem_Dispose_in_der_Datei()
    {
        var pfad = _ordner.Datei("log.txt");
        using (var buch = new Logbuch(pfad))
        {
            buch.Eintrag("erster");
            buch.Eintrag("zweiter");
        }
        Assert.Equal(["erster", "zweiter"], File.ReadAllLines(pfad));
    }

    [Fact]
    public void Dispose_gibt_die_Datei_frei()
    {
        var pfad = _ordner.Datei("log.txt");
        var buch = new Logbuch(pfad);
        buch.Eintrag("x");
        buch.Dispose();
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void Offene_zaehlt_erzeugte_und_noch_nicht_freigegebene_Logbuecher()
    {
        int vorher = Logbuch.Offene;
        var a = new Logbuch(_ordner.Datei("a.txt"));
        var b = new Logbuch(_ordner.Datei("b.txt"));
        Assert.Equal(vorher + 2, Logbuch.Offene);
        a.Dispose();
        Assert.Equal(vorher + 1, Logbuch.Offene);
        b.Dispose();
        Assert.Equal(vorher, Logbuch.Offene);
    }

    [Fact]
    public void Zweites_Dispose_tut_nichts()
    {
        int vorher = Logbuch.Offene;
        var buch = new Logbuch(_ordner.Datei("log.txt"));
        buch.Dispose();
        buch.Dispose();
        buch.Dispose();
        Assert.Equal(vorher, Logbuch.Offene);
    }

    [Fact]
    public void Eintrag_nach_Dispose_wirft_ObjectDisposedException()
    {
        var buch = new Logbuch(_ordner.Datei("log.txt"));
        buch.Dispose();
        var fehler = Assert.Throws<ObjectDisposedException>(() => buch.Eintrag("zu spaet"));
        Assert.IsAssignableFrom<InvalidOperationException>(fehler);
    }

    [Fact]
    public void Using_gibt_auch_frei_wenn_eine_Ausnahme_durchlaeuft()
    {
        int vorher = Logbuch.Offene;
        var pfad = _ordner.Datei("log.txt");

        Action aktion = () =>
        {
            using var buch = new Logbuch(pfad);
            buch.Eintrag("vor dem Fehler");
            throw new InvalidOperationException("mitten im Eintragen");
        };
        Assert.Throws<InvalidOperationException>(aktion);

        Assert.Equal(vorher, Logbuch.Offene);
        TestOrdner.PruefeDateiFrei(pfad);
        Assert.Equal(["vor dem Fehler"], File.ReadAllLines(pfad));
    }

    [Fact]
    public void Scheitert_der_Konstruktor_wird_nichts_gezaehlt()
    {
        int vorher = Logbuch.Offene;
        var pfad = Path.Combine(_ordner.Pfad, "gibt es nicht", "log.txt");
        Assert.Throws<DirectoryNotFoundException>(() => new Logbuch(pfad));
        Assert.Equal(vorher, Logbuch.Offene);
    }

    [Fact]
    public void Ohne_Dispose_bleibt_die_Datei_gesperrt()
    {
        var pfad = _ordner.Datei("gesperrt.txt");
        var buch = new Logbuch(pfad);
        try
        {
            buch.Eintrag("x");
            Assert.Throws<IOException>(() => TestOrdner.PruefeDateiFrei(pfad));
        }
        finally
        {
            buch.Dispose();
        }
        TestOrdner.PruefeDateiFrei(pfad);
    }
}
