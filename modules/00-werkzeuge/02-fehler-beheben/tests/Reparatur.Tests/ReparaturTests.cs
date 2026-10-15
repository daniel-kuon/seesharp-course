public class ReparaturTests
{
    [Fact]
    public void Gruss_liefert_Moin_SeeSharp()
    {
        Assert.Equal("Moin, SeeSharp!", Hallo.Gruss());
    }
}
