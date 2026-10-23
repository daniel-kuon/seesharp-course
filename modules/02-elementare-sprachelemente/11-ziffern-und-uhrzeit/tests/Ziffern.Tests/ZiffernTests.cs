public class ZiffernTests
{
    [Fact]
    public void Quersumme_dreistellig()
    {
        Assert.Equal(13, Ziffern.Quersumme(472));
        Assert.Equal(27, Ziffern.Quersumme(999));
        Assert.Equal(1, Ziffern.Quersumme(100));
    }

    [Fact]
    public void Quersumme_kleiner_Zahlen()
    {
        Assert.Equal(0, Ziffern.Quersumme(0));
        Assert.Equal(7, Ziffern.Quersumme(7));
        Assert.Equal(9, Ziffern.Quersumme(45));
    }

    [Fact]
    public void Umgedreht_dreistellig()
    {
        Assert.Equal(274, Ziffern.Umgedreht(472));
        Assert.Equal(321, Ziffern.Umgedreht(123));
    }

    [Fact]
    public void Umgedreht_mit_Null_am_Ende() => Assert.Equal(21, Ziffern.Umgedreht(120));

    [Fact]
    public void Gerade_und_ungerade()
    {
        Assert.True(Ziffern.IstGerade(0));
        Assert.True(Ziffern.IstGerade(8));
        Assert.True(Ziffern.IstGerade(-4));
        Assert.False(Ziffern.IstGerade(7));
        Assert.False(Ziffern.IstGerade(-3));
    }

    [Fact]
    public void Uhrzeit_mit_fuehrenden_Nullen() => Assert.Equal("01:02:05", Ziffern.Uhrzeit(3725));

    [Fact]
    public void Uhrzeit_Grenzen()
    {
        Assert.Equal("00:00:00", Ziffern.Uhrzeit(0));
        Assert.Equal("23:59:59", Ziffern.Uhrzeit(86399));
        Assert.Equal("12:00:00", Ziffern.Uhrzeit(43200));
    }
}
