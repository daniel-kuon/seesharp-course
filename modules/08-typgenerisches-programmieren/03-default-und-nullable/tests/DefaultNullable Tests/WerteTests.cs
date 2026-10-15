public class WerteTests
{
    [Fact]
    public void Default_von_Werttypen_ist_der_Nullwert()
    {
        Assert.Equal("0", Werte.BeschreibeDefault<int>());
        Assert.Equal("False", Werte.BeschreibeDefault<bool>());
        Assert.Equal("(0, 0)", Werte.BeschreibeDefault<(int, int)>());
    }

    [Fact]
    public void Default_von_Referenztypen_und_Nullable_ist_null()
    {
        Assert.Equal("null", Werte.BeschreibeDefault<string>());
        Assert.Equal("null", Werte.BeschreibeDefault<int?>());
        Assert.Equal("null", Werte.BeschreibeDefault<int[]>());
    }

    [Fact]
    public void ErstesOderDefault()
    {
        Assert.Equal(5, Werte.ErstesOderDefault([5, 6]));
        Assert.Equal(0, Werte.ErstesOderDefault<int>([]));
        Assert.Null(Werte.ErstesOderDefault<string>([]));
        Assert.Equal("a", Werte.ErstesOderDefault(["a"]));
    }

    [Fact]
    public void Summe_ueberspringt_null()
    {
        Assert.Equal(12, Werte.Summe([3, null, 4, null, 5]));
        Assert.Equal(0, Werte.Summe([null, null]));
        Assert.Equal(0, Werte.Summe([]));
    }

    [Fact]
    public void OderErsatz_nutzt_den_Ersatz_nur_bei_null()
    {
        Assert.Equal(7, Werte.OderErsatz(7, -1));
        Assert.Equal(-1, Werte.OderErsatz(null, -1));
        Assert.Equal(0, Werte.OderErsatz(0, -1));
    }
}
