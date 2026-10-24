using System.Text;
using Textdateien;

public class TextdateiTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    static IEnumerable<string> ZeilenDieIrgendwannWerfen()
    {
        yield return "erste";
        throw new InvalidOperationException("Quelle kaputt");
    }

    [Fact]
    public void Schreibe_erzeugt_eine_Zeile_pro_Eintrag()
    {
        var pfad = _ordner.Datei("liste.txt");
        Textdatei.Schreibe(pfad, ["Anna", "Bernd", "Cäcilie"]);
        Assert.Equal(["Anna", "Bernd", "Cäcilie"], File.ReadAllLines(pfad));
    }

    [Fact]
    public void Schreibe_ueberschreibt_eine_vorhandene_Datei()
    {
        var pfad = _ordner.Datei("liste.txt");
        File.WriteAllText(pfad, "alt\nalt\nalt\n");
        Textdatei.Schreibe(pfad, ["neu"]);
        Assert.Equal(["neu"], File.ReadAllLines(pfad));
    }

    [Fact]
    public void Schreibe_gibt_die_Datei_frei()
    {
        var pfad = _ordner.Datei("frei.txt");
        Textdatei.Schreibe(pfad, ["a"]);
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void Schreibe_schliesst_die_Datei_auch_bei_einer_Ausnahme()
    {
        var pfad = _ordner.Datei("kaputt.txt");
        Assert.Throws<InvalidOperationException>(() => Textdatei.Schreibe(pfad, ZeilenDieIrgendwannWerfen()));
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void LiesZeilen_liest_bis_zum_Dateiende()
    {
        var pfad = _ordner.Datei("zeilen.txt");
        File.WriteAllText(pfad, "eins\r\nzwei\n\ndrei\n");
        Assert.Equal(["eins", "zwei", "", "drei"], Textdatei.LiesZeilen(pfad));
    }

    [Fact]
    public void LiesZeilen_einer_leeren_Datei_ist_leer()
    {
        var pfad = _ordner.Datei("leer.txt");
        File.WriteAllText(pfad, "");
        Assert.Empty(Textdatei.LiesZeilen(pfad));
    }

    [Fact]
    public void LiesZeilen_gibt_die_Datei_frei()
    {
        var pfad = _ordner.Datei("frei.txt");
        File.WriteAllText(pfad, "a\nb\n");
        Textdatei.LiesZeilen(pfad);
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void LiesZeilen_einer_fehlenden_Datei_wirft()
    {
        Assert.Throws<FileNotFoundException>(() => Textdatei.LiesZeilen(_ordner.Datei("gibt-es-nicht.txt")));
    }

    [Fact]
    public void LiesOderLeer_faengt_fehlende_Datei_und_fehlenden_Ordner()
    {
        Assert.Empty(Textdatei.LiesOderLeer(_ordner.Datei("gibt-es-nicht.txt")));
        Assert.Empty(Textdatei.LiesOderLeer(Path.Combine(_ordner.Pfad, "kein Ordner", "x.txt")));

        var pfad = _ordner.Datei("da.txt");
        File.WriteAllText(pfad, "ok\n");
        Assert.Equal(["ok"], Textdatei.LiesOderLeer(pfad));
    }

    [Fact]
    public void Anhaengen_haengt_an_und_legt_die_Datei_bei_Bedarf_an()
    {
        var pfad = _ordner.Datei("log.txt");
        Textdatei.Anhaengen(pfad, "erste");
        Textdatei.Anhaengen(pfad, "zweite");
        Assert.Equal(["erste", "zweite"], File.ReadAllLines(pfad));
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void LiesAnsi_liest_Windows_1252()
    {
        var pfad = _ordner.Datei("ansi.txt");
        // "Käse" und "Öl" in Windows-1252: ä = 0xE4, Ö = 0xD6
        File.WriteAllBytes(pfad, [0x4B, 0xE4, 0x73, 0x65, 0x0D, 0x0A, 0xD6, 0x6C]);
        Assert.Equal(["Käse", "Öl"], Textdatei.LiesAnsi(pfad));
    }

    [Fact]
    public void SchreibeAnsi_schreibt_Einzelbytes_fuer_Umlaute()
    {
        var pfad = _ordner.Datei("ansi.txt");
        Textdatei.SchreibeAnsi(pfad, "Käse");
        Assert.Equal(new byte[] { 0x4B, 0xE4, 0x73, 0x65 }, File.ReadAllBytes(pfad));
    }

    [Fact]
    public void SchreibeUtf8_schreibt_ohne_BOM()
    {
        var pfad = _ordner.Datei("utf8.txt");
        Textdatei.SchreibeUtf8(pfad, "Grüße");
        var bytes = File.ReadAllBytes(pfad);
        Assert.Equal(new UTF8Encoding(false).GetBytes("Grüße"), bytes);
        Assert.False(bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF, "Die Datei beginnt mit einem BOM.");
        Assert.Equal("Grüße", File.ReadAllText(pfad, Encoding.UTF8));
    }
}
