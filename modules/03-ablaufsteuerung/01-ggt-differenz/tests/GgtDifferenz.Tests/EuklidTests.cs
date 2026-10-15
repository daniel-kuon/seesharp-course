public class EuklidTests
{
    [Fact]
    public void Ggt_von_12_und_18_ist_6() => Assert.Equal(6, Euklid.GgtDifferenz(12, 18));

    [Fact]
    public void Ggt_von_teilerfremden_Zahlen_ist_1() => Assert.Equal(1, Euklid.GgtDifferenz(17, 5));

    [Fact]
    public void Ggt_gleicher_Zahlen_ist_die_Zahl() => Assert.Equal(7, Euklid.GgtDifferenz(7, 7));

    [Fact]
    public void Ggt_von_100_und_75_ist_25() => Assert.Equal(25, Euklid.GgtDifferenz(100, 75));

    [Fact]
    public void Groesster_Exponent_ist_52() => Assert.Equal(52, Euklid.GroessterExponent());
}
