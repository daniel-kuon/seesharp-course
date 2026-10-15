public class ReparaturTests
{
    [Fact]
    public void Abgeleitet_reicht_den_Wert_an_die_Basisklasse_weiter()
    {
        var s = new Abgeleitet(5);

        Assert.Equal(5, s.Ibas);
        Assert.Equal("Hallo-Methode der abgeleiteten Klasse", s.Hallo());
    }

    [Fact]
    public void Basisklasse_hat_weiterhin_nur_den_Konstruktor_mit_Parameter()
    {
        Assert.Null(typeof(Basisklasse).GetConstructor(Type.EmptyTypes));
        Assert.Equal(3, new Basisklasse(3).Ibas);
    }

    [Fact]
    public void Kreis_uebernimmt_eine_gueltige_Position()
    {
        var k = new Kreis(10.0, 10.0, 5.0);

        Assert.Equal((10.0, 10.0), k.Wo);
        Assert.Equal(5.0, k.Radius);
    }

    [Fact]
    public void Kreis_behaelt_bei_ungueltiger_Position_die_Vorgabe()
    {
        var k = new Kreis(-1.0, 10.0, 5.0);

        Assert.Equal((100.0, 100.0), k.Wo);
        Assert.Equal((100.0, 100.0), new Kreis().Wo);
    }
}
