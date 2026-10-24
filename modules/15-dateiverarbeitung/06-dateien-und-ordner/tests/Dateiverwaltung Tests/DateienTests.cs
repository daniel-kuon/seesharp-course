using Dateiverwaltung;

public class DateienTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    static readonly char T = Path.DirectorySeparatorChar;

    [Fact]
    public void Sichere_legt_den_Zielordner_an_und_kopiert_mit_neuem_Namen()
    {
        var datei = _ordner.Datei("Jahresbericht.final.txt");
        File.WriteAllText(datei, "Inhalt");
        var ziel = Path.Combine(_ordner.Pfad, "Sicherung", "Büro 2025");

        var ergebnis = Dateien.Sichere(datei, ziel);

        Assert.Equal(Path.Combine(ziel, "Jahresbericht.final_backup.txt"), ergebnis);
        Assert.Equal("Inhalt", File.ReadAllText(ergebnis));
        Assert.True(File.Exists(datei), "Das Original muss bleiben.");
    }

    [Fact]
    public void Sichere_funktioniert_auch_ohne_Endung_und_ueberschreibt_ein_altes_Backup()
    {
        var datei = _ordner.Datei("README");
        File.WriteAllText(datei, "neu");
        var ziel = Path.Combine(_ordner.Pfad, "b");
        Directory.CreateDirectory(ziel);
        File.WriteAllText(Path.Combine(ziel, "README_backup"), "alt");

        var ergebnis = Dateien.Sichere(datei, ziel);

        Assert.Equal(Path.Combine(ziel, "README_backup"), ergebnis);
        Assert.Equal("neu", File.ReadAllText(ergebnis));
    }

    [Fact]
    public void ListeRekursiv_liefert_relative_sortierte_Pfade_zum_Muster()
    {
        var wurzel = _ordner.Pfad;
        Directory.CreateDirectory(Path.Combine(wurzel, "sub", "tief"));
        File.WriteAllText(Path.Combine(wurzel, "z.txt"), "");
        File.WriteAllText(Path.Combine(wurzel, "a.txt"), "");
        File.WriteAllText(Path.Combine(wurzel, "a.csv"), "");
        File.WriteAllText(Path.Combine(wurzel, "sub", "b.txt"), "");
        File.WriteAllText(Path.Combine(wurzel, "sub", "tief", "c.txt"), "");
        File.WriteAllText(Path.Combine(wurzel, "sub", "tief", "c.log"), "");

        Assert.Equal(
            ["a.txt", $"sub{T}b.txt", $"sub{T}tief{T}c.txt", "z.txt"],
            Dateien.ListeRekursiv(wurzel, "*.txt"));
        Assert.Equal(["a.csv"], Dateien.ListeRekursiv(wurzel, "*.csv"));
        Assert.Empty(Dateien.ListeRekursiv(wurzel, "*.xyz"));
    }

    [Fact]
    public void Verschiebe_verschiebt_und_legt_den_Zielordner_an()
    {
        var von = _ordner.Datei("alt.txt");
        File.WriteAllText(von, "x");
        var nach = Path.Combine(_ordner.Pfad, "neu", "unter", "alt.txt");

        Assert.True(Dateien.Verschiebe(von, nach));

        Assert.False(File.Exists(von));
        Assert.Equal("x", File.ReadAllText(nach));
    }

    [Fact]
    public void Verschiebe_liefert_false_wenn_die_Quelle_fehlt_und_ueberschreibt_das_Ziel()
    {
        Assert.False(Dateien.Verschiebe(_ordner.Datei("gibt-es-nicht.txt"), _ordner.Datei("ziel.txt")));
        Assert.False(File.Exists(_ordner.Datei("ziel.txt")));

        var von = _ordner.Datei("a.txt");
        var nach = _ordner.Datei("b.txt");
        File.WriteAllText(von, "neu");
        File.WriteAllText(nach, "alt");
        Assert.True(Dateien.Verschiebe(von, nach));
        Assert.Equal("neu", File.ReadAllText(nach));
    }

    [Fact]
    public void LoescheLeereOrdner_loescht_von_unten_nach_oben()
    {
        var w = Path.Combine(_ordner.Pfad, "wurzel");
        Directory.CreateDirectory(Path.Combine(w, "leer1"));
        Directory.CreateDirectory(Path.Combine(w, "a", "leer2", "leer3"));
        Directory.CreateDirectory(Path.Combine(w, "voll", "leer4"));
        File.WriteAllText(Path.Combine(w, "voll", "datei.txt"), "x");

        int geloescht = Dateien.LoescheLeereOrdner(w);

        // leer1, leer3, leer2, a (wird erst durch das Löschen von leer2 leer) und leer4
        Assert.Equal(5, geloescht);
        Assert.True(Directory.Exists(w), "Die Wurzel bleibt.");
        Assert.True(Directory.Exists(Path.Combine(w, "voll")));
        Assert.False(Directory.Exists(Path.Combine(w, "leer1")));
        Assert.False(Directory.Exists(Path.Combine(w, "a")));
        Assert.False(Directory.Exists(Path.Combine(w, "voll", "leer4")));
    }

    [Fact]
    public void LoescheLeereOrdner_ohne_leere_Ordner_loescht_nichts()
    {
        var w = Path.Combine(_ordner.Pfad, "w");
        Directory.CreateDirectory(Path.Combine(w, "x"));
        File.WriteAllText(Path.Combine(w, "x", "f.txt"), "");
        Assert.Equal(0, Dateien.LoescheLeereOrdner(w));
        Assert.True(File.Exists(Path.Combine(w, "x", "f.txt")));
    }

    [Theory]
    [InlineData("daten.txt", "csv", "daten.csv")]
    [InlineData("archiv.tar.gz", "zip", "archiv.tar.zip")]
    [InlineData("ohne", "txt", "ohne.txt")]
    public void ErsetzeEndung_tauscht_nur_die_letzte_Endung(string pfad, string neu, string erwartet)
    {
        Assert.Equal(erwartet, Dateien.ErsetzeEndung(pfad, neu));
    }

    [Fact]
    public void ErsetzeEndung_laesst_Ordner_mit_Punkt_und_Umlaut_in_Ruhe()
    {
        var pfad = Path.Combine("C:", "Büro, v1.2", "bericht.txt");
        Assert.Equal(Path.Combine("C:", "Büro, v1.2", "bericht.md"), Dateien.ErsetzeEndung(pfad, "md"));
    }

    [Fact]
    public void NeuerArbeitsordner_liegt_im_Temp_Ordner_und_ist_eindeutig()
    {
        var a = Dateien.NeuerArbeitsordner();
        var b = Dateien.NeuerArbeitsordner();
        try
        {
            Assert.NotEqual(a, b);
            Assert.True(Directory.Exists(a));
            Assert.True(Directory.Exists(b));
            var temp = Path.GetFullPath(Path.GetTempPath()).TrimEnd(T);
            Assert.Equal(temp, Path.GetDirectoryName(Path.GetFullPath(a))!.TrimEnd(T));
        }
        finally
        {
            if (Directory.Exists(a)) Directory.Delete(a, true);
            if (Directory.Exists(b)) Directory.Delete(b, true);
        }
    }

    [Fact]
    public void AppOrdner_liegt_im_lokalen_Anwendungsdatenordner()
    {
        var erwartet = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mein Prüfprogramm");
        Assert.Equal(erwartet, Dateien.AppOrdner("Mein Prüfprogramm"));
        Assert.False(Directory.Exists(Dateien.AppOrdner("Mein Prüfprogramm " + Guid.NewGuid())), "AppOrdner darf nichts anlegen.");
    }
}
