using System.Globalization;
using Mittelwertrechnung;

public class MittelwerteTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    string Schreibe(string name, string inhalt)
    {
        var pfad = _ordner.Datei(name);
        File.WriteAllText(pfad, inhalt);
        return pfad;
    }

    const string BuchBeispiel = "12;3;345\n7;5;298\n9;4;411\n10;2;326\n5;6;195\n4;sieben;120\n";

    [Fact]
    public void Berechne_das_Beispiel_aus_dem_Buch()
    {
        var (mittel, warnungen) = Mittelwerte.Berechne(Schreibe("daten.txt", BuchBeispiel));

        Assert.Equal(3, mittel.Length);
        Assert.Equal(47.0 / 6, mittel[0], 9);
        Assert.Equal(4.0, mittel[1], 9);
        Assert.Equal(282.5, mittel[2], 9);
        Assert.Equal(["Zeile 6, Spalte 2: 'sieben' ist keine Zahl"], warnungen);
    }

    [Fact]
    public void Berechne_ohne_Fehler_hat_keine_Warnungen()
    {
        var (mittel, warnungen) = Mittelwerte.Berechne(Schreibe("ok.txt", "1;2\r\n3;4\r\n"));
        Assert.Equal([2.0, 3.0], mittel);
        Assert.Empty(warnungen);
    }

    [Fact]
    public void Berechne_verwendet_Punkt_als_Dezimaltrennzeichen()
    {
        var (mittel, warnungen) = Mittelwerte.Berechne(Schreibe("punkt.txt", "1.5;2\n2.5;4\n"));
        Assert.Equal([2.0, 3.0], mittel);
        Assert.Empty(warnungen);
    }

    [Fact]
    public void Berechne_ist_unabhaengig_von_der_Spracheinstellung()
    {
        var pfad = Schreibe("kultur.txt", "1.5;2\n2.5;4\n");
        var alt = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");
            var (mittel, warnungen) = Mittelwerte.Berechne(pfad);
            Assert.Equal([2.0, 3.0], mittel);
            Assert.Empty(warnungen);
        }
        finally
        {
            CultureInfo.CurrentCulture = alt;
        }
    }

    [Fact]
    public void Berechne_meldet_ein_Komma_als_Warnung()
    {
        var (mittel, warnungen) = Mittelwerte.Berechne(Schreibe("komma.txt", "4,5;1\n3;2\n"));
        Assert.Equal(3.0, mittel[0]);
        Assert.Equal(1.5, mittel[1]);
        Assert.Equal(["Zeile 1, Spalte 1: '4,5' ist keine Zahl"], warnungen);
    }

    [Fact]
    public void Berechne_ignoriert_Leerraum_um_die_Felder_und_leere_Zeilen()
    {
        var (mittel, warnungen) = Mittelwerte.Berechne(Schreibe("leer.txt", " 1 ; 2 \n\n3;4\n"));
        Assert.Equal([2.0, 3.0], mittel);
        Assert.Empty(warnungen);
    }

    [Fact]
    public void Berechne_meldet_mehrere_Warnungen_mit_Zeile_und_Spalte()
    {
        var (mittel, warnungen) = Mittelwerte.Berechne(Schreibe("viele.txt", "1;x;3\na;2;3\n1;2;\n"));
        Assert.Equal(
            [
                "Zeile 1, Spalte 2: 'x' ist keine Zahl",
                "Zeile 2, Spalte 1: 'a' ist keine Zahl",
                "Zeile 3, Spalte 3: '' ist keine Zahl",
            ],
            warnungen);
        Assert.Equal([1.0, 2.0, 3.0], mittel);
    }

    [Fact]
    public void Berechne_mit_ungleich_langen_Zeilen_und_Spalte_ohne_Werte()
    {
        var (mittel, warnungen) = Mittelwerte.Berechne(Schreibe("kurz.txt", "1;2;x\n3\n"));
        Assert.Equal(3, mittel.Length);
        Assert.Equal(2.0, mittel[0]);
        Assert.Equal(2.0, mittel[1]);
        Assert.True(double.IsNaN(mittel[2]));
        Assert.Single(warnungen);
    }

    [Fact]
    public void Kopiere_schreibt_Grossbuchstaben()
    {
        var quelle = Schreibe("quelle.txt", "hallo\nwelt\n");
        var ziel = _ordner.Datei("ziel.txt");
        Mittelwerte.Kopiere(quelle, ziel);
        Assert.Equal(["HALLO", "WELT"], File.ReadAllLines(ziel));
    }

    [Fact]
    public void Bytes_liefert_die_Dateigroesse()
    {
        var pfad = _ordner.Datei("roh.bin");
        File.WriteAllBytes(pfad, new byte[1234]);
        Assert.Equal(1234, Mittelwerte.Bytes(pfad));
    }

    [Fact]
    public void Anhaengen_haengt_Text_an()
    {
        var pfad = Schreibe("anhang.txt", "eins");
        Mittelwerte.Anhaengen(pfad, "zwei");
        Mittelwerte.Anhaengen(pfad, "drei");
        Assert.Equal("einszweidrei", File.ReadAllText(pfad));
    }
}
