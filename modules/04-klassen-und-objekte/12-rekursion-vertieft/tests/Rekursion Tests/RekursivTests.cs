public class RekursivTests
{
    [Fact]
    public void Quersumme_einstellig_und_mehrstellig()
    {
        Assert.Equal(0, Rekursiv.Quersumme(0));
        Assert.Equal(7, Rekursiv.Quersumme(7));
        Assert.Equal(10, Rekursiv.Quersumme(1234));
        Assert.Equal(1, Rekursiv.Quersumme(1000000));
    }

    [Fact]
    public void Potenz_Sonderfaelle()
    {
        Assert.Equal(1, Rekursiv.Potenz(5, 0));
        Assert.Equal(5, Rekursiv.Potenz(5, 1));
        Assert.Equal(0, Rekursiv.Potenz(0, 3));
    }

    [Fact]
    public void Potenz_gerade_und_ungerade_Exponenten()
    {
        Assert.Equal(1024, Rekursiv.Potenz(2, 10));
        Assert.Equal(2187, Rekursiv.Potenz(3, 7));
        Assert.Equal(-8, Rekursiv.Potenz(-2, 3));
        Assert.Equal(4611686018427387904L, Rekursiv.Potenz(2, 62));
    }

    [Fact]
    public void Binomial_Rand_des_Dreiecks_ist_1()
    {
        Assert.Equal(1, Rekursiv.Binomial(0, 0));
        Assert.Equal(1, Rekursiv.Binomial(7, 0));
        Assert.Equal(1, Rekursiv.Binomial(7, 7));
    }

    [Fact]
    public void Binomial_im_Inneren()
    {
        Assert.Equal(10, Rekursiv.Binomial(5, 2));
        Assert.Equal(252, Rekursiv.Binomial(10, 5));
        Assert.Equal(184756, Rekursiv.Binomial(20, 10));
    }

    [Fact]
    public void HanoiZuege_verdoppeln_sich_plus_eins()
    {
        Assert.Equal(0, Rekursiv.HanoiZuege(0));
        Assert.Equal(1, Rekursiv.HanoiZuege(1));
        Assert.Equal(7, Rekursiv.HanoiZuege(3));
        Assert.Equal(1023, Rekursiv.HanoiZuege(10));
    }

    [Fact]
    public void Fibonacci_Anfangswerte()
    {
        Assert.Equal(0, Rekursiv.Fibonacci(0, 0, 1));
        Assert.Equal(1, Rekursiv.Fibonacci(1, 0, 1));
        Assert.Equal(1, Rekursiv.Fibonacci(2, 0, 1));
        Assert.Equal(55, Rekursiv.Fibonacci(10, 0, 1));
    }

    [Fact]
    public void Fibonacci_von_90_ist_schnell()
    {
        Assert.Equal(2880067194370816120L, Rekursiv.Fibonacci(90, 0, 1));
    }
}
