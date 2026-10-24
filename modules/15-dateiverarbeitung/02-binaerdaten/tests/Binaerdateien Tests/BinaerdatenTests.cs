using Binaerdateien;

public class BinaerdatenTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    static byte[] ZufallsBytes(int anzahl)
    {
        var bytes = new byte[anzahl];
        new Random(42).NextBytes(bytes);
        return bytes;
    }

    [Fact]
    public void Kopiere_kopiert_100000_Bytes_unveraendert()
    {
        var quelle = _ordner.Datei("quelle.bin");
        var ziel = _ordner.Datei("ziel.bin");
        var inhalt = ZufallsBytes(100_000);
        File.WriteAllBytes(quelle, inhalt);

        long kopiert = Binaerdaten.Kopiere(quelle, ziel);

        Assert.Equal(100_000, kopiert);
        Assert.Equal(inhalt, File.ReadAllBytes(ziel));
        TestOrdner.PruefeDateiFrei(quelle);
        TestOrdner.PruefeDateiFrei(ziel);
    }

    [Fact]
    public void Kopiere_ueberschreibt_ein_laengeres_Ziel_vollstaendig()
    {
        var quelle = _ordner.Datei("quelle.bin");
        var ziel = _ordner.Datei("ziel.bin");
        File.WriteAllBytes(quelle, [1, 2, 3]);
        File.WriteAllBytes(ziel, ZufallsBytes(500));

        Binaerdaten.Kopiere(quelle, ziel);

        Assert.Equal(new byte[] { 1, 2, 3 }, File.ReadAllBytes(ziel));
    }

    [Fact]
    public void Kopiere_kopiert_eine_leere_Datei()
    {
        var quelle = _ordner.Datei("leer.bin");
        var ziel = _ordner.Datei("ziel.bin");
        File.WriteAllBytes(quelle, []);
        Assert.Equal(0, Binaerdaten.Kopiere(quelle, ziel));
        Assert.Empty(File.ReadAllBytes(ziel));
    }

    [Fact]
    public void Kopiere_oeffnet_die_Quelle_nur_lesend()
    {
        // Ein anderer Leser hält die Quelle offen und erlaubt anderen nur Lesen.
        // Wer die Quelle mit Schreibzugriff öffnet, scheitert daran.
        var quelle = _ordner.Datei("gesperrt.bin");
        File.WriteAllBytes(quelle, ZufallsBytes(1000));
        using var anderer = new FileStream(quelle, FileMode.Open, FileAccess.Read, FileShare.Read);

        var ziel = _ordner.Datei("ziel.bin");
        Assert.Equal(1000, Binaerdaten.Kopiere(quelle, ziel));
    }

    [Fact]
    public void Kopiere_fehlende_Quelle_wirft()
    {
        Assert.Throws<FileNotFoundException>(() => Binaerdaten.Kopiere(_ordner.Datei("fehlt.bin"), _ordner.Datei("z.bin")));
    }

    [Fact]
    public void Messwerte_haben_die_Dateigroesse_4_plus_8_mal_n()
    {
        var pfad = _ordner.Datei("werte.bin");
        double[] werte = [1.5, -2.25, 1e10];
        Binaerdaten.SchreibeMesswerte(pfad, werte);
        Assert.Equal(4 + 8 * 3, new FileInfo(pfad).Length);
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void Messwerte_Rundreise()
    {
        var pfad = _ordner.Datei("werte.bin");
        double[] werte = [1.5, -2.25, 1e10, double.Epsilon, 0];
        Binaerdaten.SchreibeMesswerte(pfad, werte);
        Assert.Equal(werte, Binaerdaten.LiesMesswerte(pfad));
    }

    [Fact]
    public void Messwerte_Rundreise_ohne_Werte()
    {
        var pfad = _ordner.Datei("leer.bin");
        Binaerdaten.SchreibeMesswerte(pfad, []);
        Assert.Equal(4, new FileInfo(pfad).Length);
        Assert.Empty(Binaerdaten.LiesMesswerte(pfad));
    }

    [Fact]
    public void Messwerte_speichern_die_Anzahl_zuerst_als_int()
    {
        var pfad = _ordner.Datei("werte.bin");
        Binaerdaten.SchreibeMesswerte(pfad, [7.0, 8.0]);
        var bytes = File.ReadAllBytes(pfad);
        Assert.Equal(2, BitConverter.ToInt32(bytes, 0));
        Assert.Equal(7.0, BitConverter.ToDouble(bytes, 4));
        Assert.Equal(8.0, BitConverter.ToDouble(bytes, 12));
    }

    [Fact]
    public void HaengeAn_haengt_hinten_an_und_legt_bei_Bedarf_an()
    {
        var pfad = _ordner.Datei("log.bin");
        Binaerdaten.HaengeAn(pfad, [1, 2]);
        Binaerdaten.HaengeAn(pfad, [3]);
        Assert.Equal(new byte[] { 1, 2, 3 }, File.ReadAllBytes(pfad));
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void LiesAb_springt_an_die_Position()
    {
        var pfad = _ordner.Datei("zahlen.bin");
        File.WriteAllBytes(pfad, Enumerable.Range(0, 256).Select(i => (byte)i).ToArray());

        Assert.Equal(new byte[] { 10, 11, 12, 13, 14 }, Binaerdaten.LiesAb(pfad, 10, 5));
        Assert.Equal(new byte[] { 0 }, Binaerdaten.LiesAb(pfad, 0, 1));
    }

    [Fact]
    public void LiesAb_am_Dateiende_liefert_weniger()
    {
        var pfad = _ordner.Datei("zahlen.bin");
        File.WriteAllBytes(pfad, Enumerable.Range(0, 256).Select(i => (byte)i).ToArray());

        Assert.Equal(new byte[] { 253, 254, 255 }, Binaerdaten.LiesAb(pfad, 253, 10));
        Assert.Empty(Binaerdaten.LiesAb(pfad, 256, 10));
        Assert.Empty(Binaerdaten.LiesAb(pfad, 1000, 10));
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void Erzeuge_legt_neu_an_und_verweigert_Vorhandenes_ohne_Ausnahme()
    {
        var pfad = _ordner.Datei("neu.bin");
        Assert.True(Binaerdaten.Erzeuge(pfad));
        Assert.True(File.Exists(pfad));
        Assert.Equal(0, new FileInfo(pfad).Length);

        File.WriteAllBytes(pfad, [9, 9, 9]);
        Assert.False(Binaerdaten.Erzeuge(pfad));
        Assert.Equal(new byte[] { 9, 9, 9 }, File.ReadAllBytes(pfad));
        TestOrdner.PruefeDateiFrei(pfad);
    }
}
