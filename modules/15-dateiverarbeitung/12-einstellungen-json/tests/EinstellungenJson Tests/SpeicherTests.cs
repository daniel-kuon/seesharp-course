using EinstellungenJson;

public class SpeicherTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    [Fact]
    public void Lade_ohne_Datei_liefert_die_Standardwerte()
    {
        Assert.Equal(Speicher.Standard, Speicher.Lade(_ordner.Datei("gibt-es-nicht.json")));
        Assert.Equal(new Einstellungen("de", 12, false), Speicher.Standard);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("{ kaputt")]
    [InlineData("[1, 2, 3]")]
    [InlineData("null")]
    public void Lade_mit_unbrauchbarem_Inhalt_liefert_die_Standardwerte(string inhalt)
    {
        var pfad = _ordner.Datei("kaputt.json");
        File.WriteAllText(pfad, inhalt);
        Assert.Equal(Speicher.Standard, Speicher.Lade(pfad));
    }

    [Fact]
    public void Lade_liest_gueltiges_camelCase_JSON()
    {
        var pfad = _ordner.Datei("einstellungen.json");
        File.WriteAllText(pfad, """{ "sprache": "en", "schriftgroesse": 16, "dunkel": true }""");
        Assert.Equal(new Einstellungen("en", 16, true), Speicher.Lade(pfad));
    }

    [Fact]
    public void Speichere_schreibt_eingerueckt_und_in_camelCase()
    {
        var pfad = _ordner.Datei("einstellungen.json");
        Speicher.Speichere(pfad, new Einstellungen("fr", 14, true));

        var text = File.ReadAllText(pfad);
        Assert.Contains("\n", text);
        Assert.Contains("\"sprache\": \"fr\"", text);
        Assert.Contains("\"schriftgroesse\": 14", text);
        Assert.Contains("\"dunkel\": true", text);
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void Speichern_und_Laden_ergeben_dasselbe()
    {
        var pfad = _ordner.Datei("einstellungen.json");
        var original = new Einstellungen("it", 20, true);
        Speicher.Speichere(pfad, original);
        Assert.Equal(original, Speicher.Lade(pfad));
    }

    [Fact]
    public void Speichere_ueberschreibt_eine_vorhandene_Datei()
    {
        var pfad = _ordner.Datei("einstellungen.json");
        Speicher.Speichere(pfad, new Einstellungen("de", 30, true));
        Speicher.Speichere(pfad, new Einstellungen("de", 8, false));
        Assert.Equal(new Einstellungen("de", 8, false), Speicher.Lade(pfad));
    }
}
