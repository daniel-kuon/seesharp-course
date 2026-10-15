public class PrimzahlenTests
{
    [Fact]
    public void Primzahlen_bis_18()
    {
        Assert.Equal([2, 3, 5, 7, 11, 13, 17], Primzahlen.BisZu(18));
    }

    [Fact]
    public void Grenze_selbst_ist_enthalten_wenn_prim()
    {
        Assert.Equal([2, 3, 5, 7, 11, 13], Primzahlen.BisZu(13));
        Assert.Equal([2], Primzahlen.BisZu(2));
    }

    [Fact]
    public void Kleine_Grenzen_liefern_ein_leeres_Array()
    {
        Assert.Empty(Primzahlen.BisZu(1));
        Assert.Empty(Primzahlen.BisZu(0));
    }

    [Fact]
    public void Es_gibt_168_Primzahlen_unter_1000()
    {
        Assert.Equal(168, Primzahlen.Anzahl(1000));
        Assert.Equal(78498, Primzahlen.Anzahl(1_000_000));
    }

    [Fact]
    public void Quadrate_und_Produkte_fehlen()
    {
        var p = Primzahlen.BisZu(100);

        Assert.DoesNotContain(49, p);
        Assert.DoesNotContain(91, p);
        Assert.Contains(97, p);
    }
}
