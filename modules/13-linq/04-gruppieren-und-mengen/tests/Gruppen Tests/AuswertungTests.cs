public class AuswertungTests
{
    private static List<Dateieintrag> Daten() =>
    [
        new("f/notiz3.txt", 20, "h3"),
        new("a/foto1.png", 100, "h1"),
        new("d/notiz.txt", 20, "h3"),
        new("c/andere.png", 100, "h2"),
        new("b/foto1_kopie.png", 100, "h1"),
        new("h/x.bin", 55, "h1"),            // gleicher Hash, andere Größe: keine Dublette
        new("e/notiz2.txt", 20, "h3"),
        new("g/gleichgross.txt", 20, "h9"),
        new("i/BILD.PNG", 10, "h4"),
    ];

    [Fact]
    public void Duplikate_findet_gleiche_Groesse_und_Hash()
    {
        var duplikate = Auswertung.Duplikate(Daten());

        Assert.Equal(2, duplikate.Count);
        Assert.Equal(["a/foto1.png", "b/foto1_kopie.png"], duplikate[0]);
        Assert.Equal(["d/notiz.txt", "e/notiz2.txt", "f/notiz3.txt"], duplikate[1]);
    }

    [Fact]
    public void Duplikate_ohne_Treffer_ist_leer()
    {
        Assert.Empty(Auswertung.Duplikate([new("a", 1, "x"), new("b", 2, "x"), new("c", 1, "y")]));
        Assert.Empty(Auswertung.Duplikate([]));
    }

    [Fact]
    public void SpeicherProEndung_summiert_und_sortiert()
    {
        var speicher = Auswertung.SpeicherProEndung(Daten());

        Assert.Equal([(".png", 310L), (".txt", 80L), (".bin", 55L)], speicher);
    }

    [Fact]
    public void SpeicherProEndung_bricht_Gleichstand_nach_Endung()
    {
        var speicher = Auswertung.SpeicherProEndung([new("a.zip", 5, "1"), new("b.cs", 5, "2")]);

        Assert.Equal([(".cs", 5L), (".zip", 5L)], speicher);
    }

    [Fact]
    public void Haeufigkeiten_zaehlen_je_Wert()
    {
        var h = Auswertung.Haeufigkeiten(["a", "b", "a", "c", "a", "b"]);

        Assert.Equal(3, h.Count);
        Assert.Equal(3, h["a"]);
        Assert.Equal(2, h["b"]);
        Assert.Equal(1, h["c"]);
        Assert.Empty(Auswertung.Haeufigkeiten([]));
    }

    [Fact]
    public void GroesseProEndung_verdichtet_je_Schluessel()
    {
        var g = Auswertung.GroesseProEndung(Daten());

        Assert.Equal(3, g.Count);
        Assert.Equal(310L, g[".png"]);
        Assert.Equal(80L, g[".txt"]);
        Assert.Equal(55L, g[".bin"]);
    }

    [Fact]
    public void Mengenoperatoren_auf_Tags()
    {
        string[] alt = ["C#", "LINQ", "XML"];
        string[] neu = ["LINQ", "JSON", "C#", "JSON"];

        Assert.Equal(["JSON"], Auswertung.NeueTags(alt, neu));
        Assert.Equal(["XML"], Auswertung.NeueTags(neu, alt));
        Assert.Equal(["C#", "JSON", "LINQ", "XML"], Auswertung.AlleTags(alt, neu));
        Assert.Equal(["C#", "LINQ"], Auswertung.GemeinsameTags(alt, neu));
        Assert.Empty(Auswertung.GemeinsameTags(alt, ["Z"]));
    }
}
