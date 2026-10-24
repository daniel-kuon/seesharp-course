public class WortanalyseTests
{
    private const string Text =
        "Der Hund und die Katze spielen im Garten.\r\n" +
        "Der Hund bellt, die Katze schläft.\n" +
        "Im Garten wächst der Baum.";

    [Fact]
    public void Woerter_flacht_alle_Zeilen_ab()
    {
        var w = Wortanalyse.Woerter(Text);

        Assert.Equal(19, w.Count);
        Assert.Equal(["der", "hund", "und", "die", "katze"], w.Take(5));
        Assert.Equal("baum", w[^1]);
        Assert.Empty(Wortanalyse.Woerter(""));
    }

    [Fact]
    public void Haeufigste_ordnet_nach_Anzahl_und_Alphabet()
    {
        Assert.Equal(
            [("der", 3), ("die", 2), ("garten", 2), ("hund", 2)],
            Wortanalyse.Haeufigste(Text, 4));
        Assert.Equal(12, Wortanalyse.Haeufigste(Text, 100).Count);
        Assert.Empty(Wortanalyse.Haeufigste("", 3));
    }

    [Fact]
    public void ProAnfangsbuchstabe_gruppiert_verschiedene_Woerter()
    {
        var gruppen = Wortanalyse.ProAnfangsbuchstabe(Text);

        Assert.Equal(9, gruppen.Count);
        Assert.Equal(["der", "die"], gruppen['d']);
        Assert.Equal(["baum", "bellt"], gruppen['b']);
        Assert.Equal(["schläft", "spielen"], gruppen['s']);
        Assert.Equal(["hund"], gruppen['h']);
        Assert.False(gruppen.ContainsKey('x'));
    }

    [Fact]
    public void LaengsteWoerter_liefert_alle_mit_der_groessten_Laenge()
    {
        Assert.Equal(["schläft", "spielen"], Wortanalyse.LaengsteWoerter(Text));
        Assert.Equal(["abc", "xyz"], Wortanalyse.LaengsteWoerter("xyz abc xyz a"));
        Assert.Empty(Wortanalyse.LaengsteWoerter(""));
    }
}
