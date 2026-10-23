public class PaareTests
{
    [Fact]
    public void Paar_haelt_zwei_Werte_verschiedener_Typen()
    {
        var p = new Paar<int, string>(1, "eins");

        Assert.Equal(1, p.Erstes);
        Assert.Equal("eins", p.Zweites);
        Assert.Equal(2, typeof(Paar<,>).GetGenericArguments().Length);
    }

    [Fact]
    public void ToString_zeigt_beide_Werte()
    {
        Assert.Equal("(1, eins)", new Paar<int, string>(1, "eins").ToString());
        Assert.Equal("(True, x)", new Paar<bool, char>(true, 'x').ToString());
    }

    [Fact]
    public void Getauscht_tauscht_Werte_und_Typen()
    {
        var p = new Paar<int, string>(1, "eins");

        Paar<string, int> g = p.Getauscht();

        Assert.Equal("eins", g.Erstes);
        Assert.Equal(1, g.Zweites);
        Assert.Equal(1, p.Erstes); // das Original bleibt
    }

    [Fact]
    public void MitErstem_kann_den_Typ_wechseln()
    {
        var p = new Paar<int, string>(1, "eins");

        Paar<double, string> q = p.MitErstem(2.5);
        Paar<int, string> r = p.MitErstem(7);

        Assert.Equal(2.5, q.Erstes);
        Assert.Equal("eins", q.Zweites);
        Assert.Equal(7, r.Erstes);
        Assert.Equal(1, p.Erstes);
    }

    [Fact]
    public void Von_leitet_die_Typargumente_ab()
    {
        var p = Paar.Von(1, "eins");
        var q = Paar.Von("x", 2.0);

        Assert.IsType<Paar<int, string>>(p);
        Assert.IsType<Paar<string, double>>(q);
        Assert.Equal("(1, eins)", p.ToString());
    }

    [Fact]
    public void Geordnet_legt_den_kleineren_Wert_nach_vorn()
    {
        var zahlen = Paar.Geordnet(5, 2);
        var namen = Paar.Geordnet("Anna", "Zoe");

        Assert.Equal(2, zahlen.Erstes);
        Assert.Equal(5, zahlen.Zweites);
        Assert.Equal("Anna", namen.Erstes);
        Assert.Equal("Zoe", namen.Zweites);
        Assert.Equal(3, Paar.Geordnet(3, 3).Erstes);
    }
}
