public class FigurenTests
{
    [Fact]
    public void Kreis_und_Rechteck_sind_Figuren()
    {
        Assert.True(typeof(Figur).IsAssignableFrom(typeof(Kreis)));
        Assert.True(typeof(Figur).IsAssignableFrom(typeof(Rechteck)));
    }

    [Fact]
    public void Kreis_reicht_die_Position_an_den_Basiskonstruktor_weiter()
    {
        var k = new Kreis(150.0, 200.0, 50.0);

        Assert.Equal((150.0, 200.0), k.Wo);
        Assert.Equal(50.0, k.Radius);
    }

    [Fact]
    public void Ungueltige_Werte_lassen_die_Vorgaben_stehen()
    {
        var k = new Kreis(-1.0, 5.0, -3.0);

        Assert.Equal((100.0, 100.0), k.Wo);
        Assert.Equal(75.0, k.Radius);
        Assert.Equal((100.0, 100.0), new Kreis().Wo);
    }

    [Fact]
    public void UntenRechts_haengt_von_der_Figurart_ab()
    {
        Assert.Equal((250.0, 300.0), new Kreis(150.0, 200.0, 50.0).UntenRechts);
        Assert.Equal((40.0, 50.0), new Rechteck(20.0, 20.0, 20.0, 30.0).UntenRechts);
        Assert.Equal((150.0, 150.0), new Rechteck().UntenRechts);
    }

    [Fact]
    public void Basisklassenreferenz_und_Typtest()
    {
        Figur[] fa = [
            new Figur(10.0, 10.0),
            new Rechteck(20.0, 20.0, 20.0, 20.0),
            new Kreis(30.0, 30.0, 30.0),
            new Kreis(40.0, 40.0, 12.5),
        ];

        Assert.Equal(42.5, Figur.SummeRadien(fa));
        Assert.Equal(0.0, Figur.SummeRadien([new Figur(), new Rechteck()]));
    }
}
