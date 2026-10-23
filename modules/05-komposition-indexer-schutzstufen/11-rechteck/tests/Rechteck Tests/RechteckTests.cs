public class RechteckTests
{
    const double Tol = 1e-9;

    [Fact]
    public void Konstruktor_ordnet_die_Ecken()
    {
        var r = new Rechteck(new Punkt(4, 2), new Punkt(1, 6));

        Assert.Equal(1, r.LinksUnten.X, Tol);
        Assert.Equal(2, r.LinksUnten.Y, Tol);
        Assert.Equal(4, r.RechtsOben.X, Tol);
        Assert.Equal(6, r.RechtsOben.Y, Tol);
    }

    [Fact]
    public void Rechteck_haengt_nicht_an_den_uebergebenen_Punkten()
    {
        var a = new Punkt(0, 0);
        var b = new Punkt(2, 3);
        var r = new Rechteck(a, b);

        a.Verschiebe(100, 100);
        b.X = -50;

        Assert.Equal("[(0; 0), (2; 3)]", r.ToString());
    }

    [Fact]
    public void Eckpunkte_werden_als_Kopie_geliefert()
    {
        var r = new Rechteck(new Punkt(0, 0), new Punkt(2, 3));

        r.LinksUnten.Verschiebe(5, 5);
        r.RechtsOben.X = 99;

        Assert.Equal("[(0; 0), (2; 3)]", r.ToString());
    }

    [Fact]
    public void Breite_Hoehe_Flaeche_Umfang()
    {
        var r = new Rechteck(new Punkt(1, 2), new Punkt(4, 6));

        Assert.Equal(3, r.Breite, Tol);
        Assert.Equal(4, r.Hoehe, Tol);
        Assert.Equal(12, r.Flaeche, Tol);
        Assert.Equal(14, r.Umfang, Tol);
    }

    [Fact]
    public void Enthaelt_innen_auf_dem_Rand_und_aussen()
    {
        var r = new Rechteck(new Punkt(1, 2), new Punkt(4, 6));

        Assert.True(r.Enthaelt(new Punkt(2, 3)));
        Assert.True(r.Enthaelt(new Punkt(1, 6)));
        Assert.True(r.Enthaelt(new Punkt(4, 4)));
        Assert.False(r.Enthaelt(new Punkt(0.5, 3)));
        Assert.False(r.Enthaelt(new Punkt(2, 6.1)));
    }

    [Fact]
    public void Verschiebe_bewegt_beide_Ecken()
    {
        var r = new Rechteck(new Punkt(1, 2), new Punkt(4, 6));

        r.Verschiebe(10, -2);

        Assert.Equal("[(11; 0), (14; 4)]", r.ToString());
        Assert.Equal(12, r.Flaeche, Tol);
    }

    [Fact]
    public void Schnitt_liefert_die_Ueberlappung()
    {
        var r = new Rechteck(new Punkt(1, 2), new Punkt(4, 6));
        var s = new Rechteck(new Punkt(3, 0), new Punkt(8, 4));

        var x = r.Schnitt(s);

        Assert.NotNull(x);
        Assert.Equal("[(3; 2), (4; 4)]", x.ToString());
        Assert.Equal("[(1; 2), (4; 6)]", r.ToString());
    }

    [Fact]
    public void Schnitt_ohne_Ueberlappung_oder_bei_Beruehrung_ist_null()
    {
        var r = new Rechteck(new Punkt(0, 0), new Punkt(2, 2));

        Assert.Null(r.Schnitt(new Rechteck(new Punkt(5, 5), new Punkt(6, 6))));
        Assert.Null(r.Schnitt(new Rechteck(new Punkt(2, 0), new Punkt(3, 2))));
    }

    [Fact]
    public void Schnitt_mit_enthaltenem_Rechteck_ist_das_innere()
    {
        var gross = new Rechteck(new Punkt(0, 0), new Punkt(10, 10));
        var klein = new Rechteck(new Punkt(2, 3), new Punkt(4, 5));

        Assert.Equal("[(2; 3), (4; 5)]", gross.Schnitt(klein)?.ToString());
        Assert.NotSame(klein, gross.Schnitt(klein));
    }
}
