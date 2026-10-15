public class EuklidTests
{
    [Fact]
    public void Ggt_von_12_und_18_ist_6() => Assert.Equal(6, Euklid.GgtModulo(12, 18));

    [Fact]
    public void Ggt_von_1071_und_462_ist_21() => Assert.Equal(21, Euklid.GgtModulo(1071, 462));

    [Fact]
    public void Ggt_von_teilerfremden_Zahlen_ist_1() => Assert.Equal(1, Euklid.GgtModulo(17, 5));

    [Fact]
    public void Ggt_wenn_b_Teiler_von_a_ist() => Assert.Equal(5, Euklid.GgtModulo(20, 5));

    [Fact]
    public void Kgv_von_4_und_6_ist_12() => Assert.Equal(12, Euklid.Kgv(4, 6));
}
