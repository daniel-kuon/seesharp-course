public class BedingungenTests
{
    [Theory]
    [InlineData(2024)]
    [InlineData(2000)]
    [InlineData(1996)]
    [InlineData(2400)]
    public void Schaltjahre(int jahr) => Assert.True(Bedingungen.IstSchaltjahr(jahr));

    [Theory]
    [InlineData(2023)]
    [InlineData(1900)]
    [InlineData(2100)]
    [InlineData(2001)]
    public void Keine_Schaltjahre(int jahr) => Assert.False(Bedingungen.IstSchaltjahr(jahr));

    [Fact]
    public void Im_Bereich_einschliesslich_Grenzen()
    {
        Assert.True(Bedingungen.ImBereich(5, 1, 10));
        Assert.True(Bedingungen.ImBereich(1, 1, 10));
        Assert.True(Bedingungen.ImBereich(10, 1, 10));
        Assert.False(Bedingungen.ImBereich(0, 1, 10));
        Assert.False(Bedingungen.ImBereich(11, 1, 10));
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(11)]
    public void Ausserhalb_ist_das_Gegenteil(int x) =>
        Assert.NotEqual(Bedingungen.ImBereich(x, 1, 10), Bedingungen.AusserhalbBereich(x, 1, 10));

    [Fact]
    public void Vorzeichen()
    {
        Assert.Equal(-1, Bedingungen.Vorzeichen(-7));
        Assert.Equal(0, Bedingungen.Vorzeichen(0));
        Assert.Equal(1, Bedingungen.Vorzeichen(42));
    }

    [Fact]
    public void Maximum_egal_an_welcher_Stelle()
    {
        Assert.Equal(9, Bedingungen.Maximum(9, 3, 4));
        Assert.Equal(9, Bedingungen.Maximum(3, 9, 4));
        Assert.Equal(9, Bedingungen.Maximum(3, 4, 9));
        Assert.Equal(5, Bedingungen.Maximum(5, 5, 5));
        Assert.Equal(-1, Bedingungen.Maximum(-3, -1, -2));
    }
}
