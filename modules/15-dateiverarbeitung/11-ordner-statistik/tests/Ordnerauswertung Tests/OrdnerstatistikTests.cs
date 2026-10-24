using Ordnerauswertung;

public class OrdnerstatistikTests : IDisposable
{
    readonly TestOrdner _ordner = new();
    readonly string _baum;

    static readonly char T = Path.DirectorySeparatorChar;

    public OrdnerstatistikTests()
    {
        // Baum mit Leerzeichen und Umlauten:
        //   wurzel/Notizen.txt               (5 Bytes)
        //   wurzel/Übersicht.TXT             (3 Bytes)
        //   wurzel/Büro Ordner/plan.txt      (20 Bytes)
        //   wurzel/Büro Ordner/bild.png      (50 Bytes)
        //   wurzel/Büro Ordner/tief/info.txt (7 Bytes)
        //   wurzel/Büro Ordner/tief/LIESMICH (1 Byte)
        _baum = Path.Combine(_ordner.Pfad, "wurzel");
        Schreibe("Notizen.txt", 5);
        Schreibe("Übersicht.TXT", 3);
        Schreibe(Path.Combine("Büro Ordner", "plan.txt"), 20);
        Schreibe(Path.Combine("Büro Ordner", "bild.png"), 50);
        Schreibe(Path.Combine("Büro Ordner", "tief", "info.txt"), 7);
        Schreibe(Path.Combine("Büro Ordner", "tief", "LIESMICH"), 1);
        Directory.CreateDirectory(Path.Combine(_baum, "leerer Ordner"));
    }

    void Schreibe(string relativ, int bytes)
    {
        var pfad = Path.Combine(_baum, relativ);
        Directory.CreateDirectory(Path.GetDirectoryName(pfad)!);
        File.WriteAllBytes(pfad, new byte[bytes]);
    }

    public void Dispose() => _ordner.Dispose();

    [Fact]
    public void AnzahlDateien_zaehlt_rekursiv()
    {
        Assert.Equal(6, Ordnerstatistik.AnzahlDateien(_baum));
        Assert.Equal(2, Ordnerstatistik.AnzahlDateien(Path.Combine(_baum, "Büro Ordner", "tief")));
        Assert.Equal(0, Ordnerstatistik.AnzahlDateien(Path.Combine(_baum, "leerer Ordner")));
    }

    [Fact]
    public void GroessteDatei_liefert_den_relativen_Pfad()
    {
        Assert.Equal(Path.Combine("Büro Ordner", "bild.png"), Ordnerstatistik.GroessteDatei(_baum));
    }

    [Fact]
    public void GroessteDatei_ohne_Dateien_ist_null()
    {
        Assert.Null(Ordnerstatistik.GroessteDatei(Path.Combine(_baum, "leerer Ordner")));
    }

    [Fact]
    public void GroessteDatei_bei_Gleichstand_gewinnt_der_ordinal_kleinere_Pfad()
    {
        var ordner = Path.Combine(_ordner.Pfad, "gleich");
        Directory.CreateDirectory(ordner);
        File.WriteAllBytes(Path.Combine(ordner, "b.bin"), new byte[10]);
        File.WriteAllBytes(Path.Combine(ordner, "a.bin"), new byte[10]);
        File.WriteAllBytes(Path.Combine(ordner, "c.bin"), new byte[9]);
        Assert.Equal("a.bin", Ordnerstatistik.GroessteDatei(ordner));
    }

    [Fact]
    public void ProEndung_zaehlt_klein_geschrieben_und_mit_Punkt()
    {
        var ergebnis = Ordnerstatistik.ProEndung(_baum);

        Assert.Equal(3, ergebnis.Count);
        Assert.Equal(4, ergebnis[".txt"]);
        Assert.Equal(1, ergebnis[".png"]);
        Assert.Equal(1, ergebnis["(keine)"]);
    }

    [Fact]
    public void KopiereAlleTxt_behaelt_die_Ordnerstruktur()
    {
        var ziel = Path.Combine(_ordner.Pfad, "kopie", "Ziel Ordner");

        int anzahl = Ordnerstatistik.KopiereAlleTxt(_baum, ziel);

        Assert.Equal(4, anzahl); // Notizen.txt, Übersicht.TXT, plan.txt, info.txt
        Assert.True(File.Exists(Path.Combine(ziel, "Notizen.txt")));
        Assert.True(File.Exists(Path.Combine(ziel, "Übersicht.TXT")));
        Assert.True(File.Exists(Path.Combine(ziel, "Büro Ordner", "plan.txt")));
        Assert.True(File.Exists(Path.Combine(ziel, "Büro Ordner", "tief", "info.txt")));
        Assert.False(File.Exists(Path.Combine(ziel, "Büro Ordner", "bild.png")));
        Assert.Equal(20, new FileInfo(Path.Combine(ziel, "Büro Ordner", "plan.txt")).Length);
    }
}
