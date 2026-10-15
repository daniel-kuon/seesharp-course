public class AbstraktTests
{
    [Fact]
    public void Figur_ist_abstrakt_mit_abstrakten_Mitgliedern()
    {
        Assert.True(typeof(Figur).IsAbstract);
        Assert.True(typeof(Figur).GetMethod("Skaliere")!.IsAbstract);
        Assert.True(typeof(Figur).GetProperty("Inhalt")!.GetMethod!.IsAbstract);
        Assert.True(typeof(Figur).GetProperty("Breite")!.GetMethod!.IsAbstract);
    }

    [Fact]
    public void Kreis_berechnet_Inhalt_und_Breite()
    {
        var k = new Kreis(0.0, 0.0, 5.0);

        Assert.Equal(Math.PI * 25.0, k.Inhalt, 9);
        Assert.Equal(10.0, k.Breite);
    }

    [Fact]
    public void Rechteck_berechnet_Inhalt_und_Breite()
    {
        var r = new Rechteck(0.0, 0.0, 4.0, 6.0);

        Assert.Equal(24.0, r.Inhalt);
        Assert.Equal(4.0, r.Breite);
    }

    [Fact]
    public void Skaliere_wirkt_polymorph()
    {
        Figur[] fa = [new Kreis(50.0, 50.0, 5.0), new Rechteck(10.0, 10.0, 5.0, 5.0)];

        foreach (var f in fa)
            f.Skaliere(2.0);

        Assert.Equal(20.0, fa[0].Breite);
        Assert.Equal(100.0, fa[1].Inhalt);
        Assert.Equal(Math.PI * 100.0 + 100.0, Figur.Gesamtflaeche(fa), 9);
    }

    [Fact]
    public void Negativer_Faktor_wird_ignoriert()
    {
        var r = new Rechteck(0.0, 0.0, 2.0, 3.0);

        r.Skaliere(-1.0);

        Assert.Equal(6.0, r.Inhalt);
    }
}
