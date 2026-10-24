public class DualogTests
{
    // Die Standardmeldung der Ausnahme, in der aktuellen Kultur. Eine eigene Meldung muss anders lauten.
    static void PruefeEigeneMeldung(ArgumentOutOfRangeException ex)
    {
        Assert.False(string.IsNullOrWhiteSpace(ex.Message));
        Assert.NotEqual(new ArgumentOutOfRangeException(ex.ParamName).Message, ex.Message);
    }

    [Theory]
    [InlineData(1.0, 0.0)]
    [InlineData(8.0, 3.0)]
    [InlineData(0.5, -1.0)]
    [InlineData(1024.0, 10.0)]
    public void Log2_liefert_den_Logarithmus_gueltiger_Argumente(double x, double erwartet)
    {
        Assert.Equal(erwartet, Dualog.Log2(x), 10);
    }

    [Theory]
    [InlineData(0.0)]
    [InlineData(-1.0)]
    [InlineData(-0.001)]
    [InlineData(double.NegativeInfinity)]
    public void Log2_wirft_fuer_Argumente_kleiner_gleich_null(double x)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Dualog.Log2(x));

        Assert.Equal("x", ex.ParamName);
    }

    [Fact]
    public void Log2_hat_eine_eigene_Meldung()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Dualog.Log2(-1));

        PruefeEigeneMeldung(ex);
    }

    [Theory]
    [InlineData(16.0, 4.0)]
    [InlineData(0.0, 0.0)]
    [InlineData(2.25, 1.5)]
    public void Wurzel_liefert_die_Quadratwurzel(double x, double erwartet)
    {
        Assert.Equal(erwartet, Dualog.Wurzel(x), 10);
    }

    [Theory]
    [InlineData(-1.0)]
    [InlineData(-0.5)]
    public void Wurzel_wirft_fuer_negative_Zahlen(double x)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Dualog.Wurzel(x));

        Assert.Equal("x", ex.ParamName);
        PruefeEigeneMeldung(ex);
    }

    [Theory]
    [InlineData(0, 1L)]
    [InlineData(1, 1L)]
    [InlineData(5, 120L)]
    [InlineData(10, 3628800L)]
    [InlineData(20, 2432902008176640000L)]
    public void Fakultaet_liefert_n_Fakultaet(int n, long erwartet)
    {
        Assert.Equal(erwartet, Dualog.Fakultaet(n));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Fakultaet_wirft_fuer_negative_n(int n)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Dualog.Fakultaet(n));

        Assert.Equal("n", ex.ParamName);
        PruefeEigeneMeldung(ex);
    }

    [Fact]
    public void Eine_Vorabpruefung_vermeidet_die_Ausnahme()
    {
        double x = -4;

        double ergebnis = x > 0 ? Dualog.Log2(x) : double.NaN;

        Assert.True(double.IsNaN(ergebnis));
    }
}
