public class BruchTests
{
    [Fact]
    public void ToString_liefert_Zaehler_Schraegstrich_Nenner()
    {
        Assert.Equal("7/8", new Bruch(7, 8, "").ToString());
    }

    [Fact]
    public void ToString_ignoriert_das_Etikett_und_kuerzt_nicht()
    {
        Assert.Equal("2/4", new Bruch(2, 4, "mit Etikett").ToString());
    }

    [Fact]
    public void Interpolation_und_Verkettung_rufen_ToString_implizit_auf()
    {
        var b = new Bruch(1, 3, "");

        Assert.Equal("Bruch: 1/3", $"Bruch: {b}");
        Assert.Equal("1/3!", b + "!");
    }

    [Fact]
    public void Summe_laesst_sich_direkt_ausgeben()
    {
        var summe = new Bruch(1, 2, "a") + new Bruch(1, 4, "b");

        Assert.Equal("3/4", summe.ToString());
    }
}
