public class PrimzahlenTests
{
    [Fact]
    public void Anzahl_bis_10_ist_4() => Assert.Equal(4, Primzahlen.AnzahlBis(10));

    [Fact]
    public void Anzahl_bis_100_ist_25() => Assert.Equal(25, Primzahlen.AnzahlBis(100));

    [Fact]
    public void Anzahl_unter_2_ist_0()
    {
        Assert.Equal(0, Primzahlen.AnzahlBis(1));
        Assert.Equal(1, Primzahlen.AnzahlBis(2));
    }

    [Theory]
    [InlineData(0, 2)]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(13, 17)]
    [InlineData(89, 97)]
    public void Naechste_Primzahl(int n, int erwartet) => Assert.Equal(erwartet, Primzahlen.NaechsteNach(n));

    [Theory]
    [InlineData(3)]
    [InlineData(11)]
    [InlineData(41)]
    public void Primzahlzwillinge(int n) => Assert.True(Primzahlen.SindZwillinge(n));

    [Theory]
    [InlineData(7)]
    [InlineData(9)]
    [InlineData(23)]
    public void Keine_Zwillinge(int n) => Assert.False(Primzahlen.SindZwillinge(n));

    [Theory]
    [InlineData(12, "2 * 2 * 3")]
    [InlineData(360, "2 * 2 * 2 * 3 * 3 * 5")]
    [InlineData(91, "7 * 13")]
    [InlineData(1024, "2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2")]
    public void Primfaktoren_zusammengesetzter_Zahlen(int n, string erwartet) => Assert.Equal(erwartet, Primzahlen.Primfaktoren(n));

    [Theory]
    [InlineData(2, "2")]
    [InlineData(13, "13")]
    [InlineData(7919, "7919")]
    public void Primfaktoren_einer_Primzahl(int n, string erwartet) => Assert.Equal(erwartet, Primzahlen.Primfaktoren(n));
}
