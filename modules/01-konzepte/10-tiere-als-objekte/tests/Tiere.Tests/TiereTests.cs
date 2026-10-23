public class TiereTests
{
    [Fact]
    public void Ein_Hund_heisst_Bello_und_sagt_Wuff()
    {
        var hund = new Hund();
        Assert.Equal("Bello", hund.Name());
        Assert.Equal("Wuff", hund.Laut());
    }

    [Fact]
    public void Ein_Hund_stellt_sich_vor() => Assert.Equal("Bello sagt Wuff", new Hund().StellDichVor());

    [Fact]
    public void Eine_Katze_heisst_Minka_und_sagt_Miau()
    {
        var katze = new Katze();
        Assert.Equal("Minka", katze.Name());
        Assert.Equal("Miau", katze.Laut());
    }

    [Fact]
    public void Eine_Katze_stellt_sich_vor() => Assert.Equal("Minka sagt Miau", new Katze().StellDichVor());

    [Fact]
    public void Im_Konzert_stellen_sich_beide_vor() => Assert.Equal("Bello sagt Wuff, Minka sagt Miau", Zoo.Konzert());
}
