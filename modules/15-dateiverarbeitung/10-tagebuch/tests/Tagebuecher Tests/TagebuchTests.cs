using Tagebuecher;

public class TagebuchTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    [Fact]
    public void Schreibe_haengt_Zeilen_im_vereinbarten_Format_an()
    {
        var pfad = _ordner.Datei("tagebuch.txt");
        var buch = new Tagebuch(pfad);
        buch.Schreibe(new DateOnly(2025, 6, 4), "Sonne");
        buch.Schreibe(new DateOnly(2025, 6, 5), "Regen; aber warm");

        Assert.Equal(["2025-06-04;Sonne", "2025-06-05;Regen; aber warm"], File.ReadAllLines(pfad));
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void Schreibe_ueberschreibt_nichts()
    {
        var pfad = _ordner.Datei("tagebuch.txt");
        File.WriteAllText(pfad, "2025-01-01;alt\n");
        new Tagebuch(pfad).Schreibe(new DateOnly(2025, 1, 2), "neu");
        Assert.Equal(["2025-01-01;alt", "2025-01-02;neu"], File.ReadAllLines(pfad));
    }

    [Fact]
    public void Schreibe_lehnt_Zeilenumbrueche_ab_ohne_zu_schreiben()
    {
        var pfad = _ordner.Datei("tagebuch.txt");
        var buch = new Tagebuch(pfad);
        Assert.Throws<ArgumentException>(() => buch.Schreibe(new DateOnly(2025, 6, 4), "zwei\nZeilen"));
        Assert.Throws<ArgumentException>(() => buch.Schreibe(new DateOnly(2025, 6, 4), "zwei\rZeilen"));
        Assert.False(File.Exists(pfad));
    }

    [Fact]
    public void Eintraege_liefert_alle_Texte_des_Tages_in_Schreibreihenfolge()
    {
        var buch = new Tagebuch(_ordner.Datei("tagebuch.txt"));
        var montag = new DateOnly(2025, 6, 2);
        var dienstag = new DateOnly(2025, 6, 3);
        buch.Schreibe(montag, "morgens");
        buch.Schreibe(dienstag, "anderer Tag");
        buch.Schreibe(montag, "abends; mit Semikolon");

        Assert.Equal(["morgens", "abends; mit Semikolon"], buch.Eintraege(montag));
        Assert.Equal(["anderer Tag"], buch.Eintraege(dienstag));
        Assert.Empty(buch.Eintraege(new DateOnly(2025, 6, 4)));
    }

    [Fact]
    public void Datum_ist_unabhaengig_von_der_Spracheinstellung()
    {
        var pfad = _ordner.Datei("tagebuch.txt");
        var alt = System.Globalization.CultureInfo.CurrentCulture;
        try
        {
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
            new Tagebuch(pfad).Schreibe(new DateOnly(2025, 6, 4), "x");
        }
        finally
        {
            System.Globalization.CultureInfo.CurrentCulture = alt;
        }
        Assert.Equal(["2025-06-04;x"], File.ReadAllLines(pfad));
    }

    [Fact]
    public void Ohne_Datei_ist_alles_leer()
    {
        var buch = new Tagebuch(_ordner.Datei("gibt-es-nicht.txt"));
        Assert.Equal(0, buch.AnzahlEintraege());
        Assert.Empty(buch.Eintraege(new DateOnly(2025, 6, 4)));
    }

    [Fact]
    public void AnzahlEintraege_zaehlt_alle_Zeilen()
    {
        var buch = new Tagebuch(_ordner.Datei("tagebuch.txt"));
        Assert.Equal(0, buch.AnzahlEintraege());
        buch.Schreibe(new DateOnly(2025, 6, 4), "a");
        buch.Schreibe(new DateOnly(2025, 6, 4), "b");
        buch.Schreibe(new DateOnly(2025, 6, 5), "c");
        Assert.Equal(3, buch.AnzahlEintraege());
    }
}
