using Messreihen;

public class MessreiheTests
{
    [Fact]
    public void Trend_leer_und_einzeln()
    {
        Assert.Equal("leer", Messreihe.Trend([]));
        Assert.Equal("einzeln", Messreihe.Trend([5]));
        Assert.Equal("einzeln", Messreihe.Trend([500]));
    }

    [Fact]
    public void Trend_steigend_bei_drei_streng_aufsteigenden_Werten()
    {
        Assert.Equal("steigend", Messreihe.Trend([1, 2, 3]));
        Assert.Equal("steigend", Messreihe.Trend([-5, 0, 7]));
        Assert.Equal("sonstige", Messreihe.Trend([1, 1, 3]));
        Assert.Equal("sonstige", Messreihe.Trend([3, 2, 1]));
    }

    [Fact]
    public void Trend_steigend_hat_Vorrang_vor_dem_Ausreisser()
    {
        Assert.Equal("steigend", Messreihe.Trend([1, 50, 101]));
    }

    [Fact]
    public void Trend_Ausreisser_am_Ende()
    {
        Assert.Equal("Ausreißer am Ende", Messreihe.Trend([3, 2, 101]));
        Assert.Equal("Ausreißer am Ende", Messreihe.Trend([1, 2, 3, 4, 200]));
        Assert.Equal("Ausreißer am Ende", Messreihe.Trend([9, 101]));
        Assert.Equal("sonstige", Messreihe.Trend([3, 2, 100]));
        Assert.Equal("sonstige", Messreihe.Trend([200, 1, 2, 3]));
    }

    [Fact]
    public void Kopf_zerlegt_die_Liste()
    {
        Assert.Equal(("a", 2), Messreihe.Kopf(["a", "b", "c"]));
        Assert.Equal(("a", 0), Messreihe.Kopf(["a"]));
        Assert.Equal((null, 0), Messreihe.Kopf([]));
    }
}
