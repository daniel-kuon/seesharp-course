public class FilterTests
{
    [Fact]
    public void LangeWoerter_filtert_nach_Laenge()
    {
        var woerter = new List<string> { "Haus", "Fenster", "Tür", "Schlüssel", "Dach", "Garten" };

        Assert.Equal(["Fenster", "Schlüssel", "Garten"], Filter.LangeWoerter(woerter));
        Assert.Empty(Filter.LangeWoerter(["Hund", "Katze"]));   // genau 5 Zeichen zählt nicht
    }

    [Fact]
    public void LangeWoerter_aendert_die_Quelle_nicht()
    {
        var woerter = new List<string> { "kurz", "ziemlich lang" };

        var ergebnis = Filter.LangeWoerter(woerter);

        Assert.Equal(2, woerter.Count);
        Assert.NotSame(woerter, ergebnis);
    }

    [Fact]
    public void OhneLeere_entfernt_in_der_Liste_selbst()
    {
        var woerter = new List<string?> { "a", null, "", "b", "   ", "\t", "c" };

        int entfernt = Filter.OhneLeere(woerter);

        Assert.Equal(4, entfernt);
        Assert.Equal(["a", "b", "c"], woerter);
    }

    [Fact]
    public void OhneLeere_ohne_Treffer()
    {
        var woerter = new List<string?> { "x", "y" };

        Assert.Equal(0, Filter.OhneLeere(woerter));
        Assert.Equal(2, woerter.Count);
    }

    [Fact]
    public void Existiert_findet_Werte()
    {
        var werte = new List<int> { 3, 8, 15 };

        Assert.True(Filter.Existiert(werte, 8));
        Assert.False(Filter.Existiert(werte, 9));
        Assert.False(Filter.Existiert([], 1));
    }

    [Fact]
    public void ErstesMit_findet_das_erste_Wort()
    {
        var woerter = new List<string> { "", "Birne", "Apfel", "Aprikose" };

        Assert.Equal("Apfel", Filter.ErstesMit(woerter, 'A'));
        Assert.Equal("Birne", Filter.ErstesMit(woerter, 'B'));
    }

    [Fact]
    public void ErstesMit_ohne_Treffer_ist_null()
    {
        Assert.Null(Filter.ErstesMit(["Birne", ""], 'Z'));
        Assert.Null(Filter.ErstesMit([], 'A'));
    }

    [Fact]
    public void Sortiere_nach_Laenge_dann_alphabetisch()
    {
        var woerter = new List<string> { "Birne", "Apfel", "Kiwi", "Ananas", "Fig", "apfel", "Zeit" };

        Filter.SortiereNachLaenge(woerter);

        // CompareOrdinal: Großbuchstaben vor Kleinbuchstaben
        Assert.Equal(["Fig", "Kiwi", "Zeit", "Apfel", "Birne", "apfel", "Ananas"], woerter);
    }

    [Fact]
    public void Summe_addiert_alle_Werte()
    {
        Assert.Equal(15, Filter.Summe([1, 2, 3, 4, 5]));
        Assert.Equal(0, Filter.Summe([]));
        Assert.Equal(-1, Filter.Summe([4, -5]));
    }
}
