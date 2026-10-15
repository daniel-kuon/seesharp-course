public class RecordFigurenTests
{
    [Fact]
    public void Kreis_reicht_die_Position_an_den_Figur_Record_weiter()
    {
        var k = new Kreis(50.0, 50.0, 30.0);

        var (dx, dy, dr) = k;

        Assert.Equal((50.0, 50.0, 30.0), (dx, dy, dr));
        Assert.Equal((50.0, 50.0), (k.X, k.Y));
    }

    [Fact]
    public void Records_mit_gleichen_Werten_sind_gleich()
    {
        Assert.Equal(new Kreis(50.0, 50.0, 30.0), new Kreis(50.0, 50.0, 30.0));
        Assert.NotEqual(new Kreis(50.0, 50.0, 30.0), new Kreis(51.0, 50.0, 30.0));
    }

    [Fact]
    public void Validierung_der_Basis_greift_auch_fuer_Kreis()
    {
        Assert.Throws<ArgumentException>(() => new Kreis(-1.0, 0.0, 1.0));
        Assert.Throws<ArgumentException>(() => new Kreis(0.0, 0.0, -1.0));
        Assert.Throws<ArgumentException>(() => new Figur(0.0, -1.0));
    }

    [Fact]
    public void Kreis_ist_eine_Figur_aber_nicht_gleich_einer_Figur_mit_gleicher_Position()
    {
        Figur f = new Kreis(1.0, 2.0, 3.0);

        Assert.IsType<Kreis>(f);
        Assert.Equal((1.0, 2.0), (f.X, f.Y));
        Assert.NotEqual(new Figur(1.0, 2.0), f);
    }

    [Fact]
    public void Parameterloser_Kreis_liegt_im_Ursprung()
    {
        Assert.Equal(new Kreis(0.0, 0.0, 0.0), new Kreis());
    }
}
