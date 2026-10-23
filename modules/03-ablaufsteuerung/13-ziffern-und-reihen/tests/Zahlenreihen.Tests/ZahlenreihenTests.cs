public class ZahlenreihenTests
{
    [Fact]
    public void Einmaleins_von_7() => Assert.Equal("7 14 21 28 35 42 49 56 63 70", Zahlenreihen.Einmaleins(7));

    [Fact]
    public void Einmaleins_von_1() => Assert.Equal("1 2 3 4 5 6 7 8 9 10", Zahlenreihen.Einmaleins(1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(7, 7)]
    [InlineData(9045, 18)]
    [InlineData(123456789, 45)]
    [InlineData(9999999999, 90)]
    public void Quersumme_beliebig_langer_Zahlen(long n, int erwartet) => Assert.Equal(erwartet, Zahlenreihen.Quersumme(n));

    [Theory]
    [InlineData(1234, 4321)]
    [InlineData(1230, 321)]
    [InlineData(5, 5)]
    [InlineData(1000000007, 7000000001)]
    public void Umgedreht_beliebig_langer_Zahlen(long n, long erwartet) => Assert.Equal(erwartet, Zahlenreihen.Umgedreht(n));

    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    [InlineData(1221)]
    [InlineData(12321)]
    public void Palindrome(long n) => Assert.True(Zahlenreihen.IstPalindrom(n));

    [Theory]
    [InlineData(12)]
    [InlineData(1230)]
    [InlineData(12341)]
    public void Keine_Palindrome(long n) => Assert.False(Zahlenreihen.IstPalindrom(n));

    [Fact]
    public void Potenzen()
    {
        Assert.Equal(1024, Zahlenreihen.Potenz(2, 10));
        Assert.Equal(1, Zahlenreihen.Potenz(5, 0));
        Assert.Equal(81, Zahlenreihen.Potenz(3, 4));
        Assert.Equal(-8, Zahlenreihen.Potenz(-2, 3));
    }

    [Fact]
    public void Potenz_groesser_als_int() => Assert.Equal(1099511627776L, Zahlenreihen.Potenz(2, 40));
}
