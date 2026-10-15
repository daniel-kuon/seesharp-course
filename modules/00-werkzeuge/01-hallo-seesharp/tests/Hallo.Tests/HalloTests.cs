public class HalloTests
{
    [Fact]
    public void Gruss_liefert_die_Begruessung()
    {
        Assert.Equal("Hallo, echt .NET hier!", Hallo.Gruss());
    }

    [Fact]
    public void Gruss_endet_mit_Ausrufezeichen()
    {
        Assert.EndsWith("!", Hallo.Gruss());
    }
}
