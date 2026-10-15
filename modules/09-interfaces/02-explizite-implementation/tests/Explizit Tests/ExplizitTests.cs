using System.Reflection;

public class ExplizitTests
{
    [Fact]
    public void Sensor_liefert_je_nach_Interface_verschiedene_Werte()
    {
        var s = new Sensor();

        Assert.Equal(1, ((IZaehler)s).Wert());
        Assert.Equal(2, ((IMesser)s).Wert());
    }

    [Fact]
    public void Sensor_hat_kein_oeffentliches_Wert()
    {
        Assert.Null(typeof(Sensor).GetMethod("Wert", BindingFlags.Public | BindingFlags.Instance));
    }

    [Fact]
    public void Geraet_mischt_implizite_und_explizite_Implementation()
    {
        var g = new Geraet();

        Assert.Equal(1, g.Wert());
        Assert.Equal(1, ((IZaehler)g).Wert());
        Assert.Equal(2, ((IMesser)g).Wert());
    }

    [Fact]
    public void Interface_Referenzen_ueber_as()
    {
        object o = new Sensor();

        Assert.Equal(1, (o as IZaehler)!.Wert());
        Assert.Equal(2, (o as IMesser)!.Wert());
    }
}
