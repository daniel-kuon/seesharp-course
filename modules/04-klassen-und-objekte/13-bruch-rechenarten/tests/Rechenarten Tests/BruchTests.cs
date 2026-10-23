public class BruchTests
{
    static (int, int) Werte(Bruch? b)
    {
        Assert.NotNull(b);
        return (b.Zaehler, b.Nenner);
    }

    [Fact]
    public void Vorzeichenwechsel_liefert_neuen_Bruch()
    {
        var a = new Bruch(3, 4);

        var m = -a;

        Assert.Equal((-3, 4), Werte(m));
        Assert.Equal((3, 4), Werte(a));
        Assert.NotSame(a, m);
    }

    [Fact]
    public void Subtraktion_kuerzt_und_laesst_Operanden_unveraendert()
    {
        var a = new Bruch(3, 4);
        var b = new Bruch(1, 4);

        Assert.Equal((1, 2), Werte(a - b));
        Assert.Equal((-1, 2), Werte(b - a));
        Assert.Equal((3, 4), Werte(a));
        Assert.Equal((1, 4), Werte(b));
    }

    [Fact]
    public void Multiplikation_kuerzt()
    {
        Assert.Equal((1, 8), Werte(new Bruch(3, 4) * new Bruch(1, 6)));
        Assert.Equal((-1, 2), Werte(new Bruch(-2, 3) * new Bruch(3, 4)));
    }

    [Fact]
    public void Kehrwert_vertauscht_und_behaelt_das_Vorzeichen_im_Zaehler()
    {
        Assert.Equal((4, 3), Werte(new Bruch(3, 4).Kehrwert()));
        Assert.Equal((-5, 2), Werte(new Bruch(-2, 5).Kehrwert()));
    }

    [Fact]
    public void Kehrwert_von_null_ist_null()
    {
        Assert.Null(new Bruch(0, 7).Kehrwert());
    }

    [Fact]
    public void Division_multipliziert_mit_dem_Kehrwert()
    {
        Assert.Equal((9, 2), Werte(new Bruch(3, 4) / new Bruch(1, 6)));
        Assert.Equal((-1, 1), Werte(new Bruch(1, 2) / new Bruch(-1, 2)));
    }

    [Fact]
    public void Division_durch_null_liefert_null()
    {
        Assert.Null(new Bruch(3, 4) / new Bruch(0, 1));
    }

    [Fact]
    public void Vergleiche_liefert_minus_eins_null_oder_eins()
    {
        Assert.Equal(-1, new Bruch(1, 3).Vergleiche(new Bruch(1, 2)));
        Assert.Equal(1, new Bruch(2, 3).Vergleiche(new Bruch(3, 5)));
        Assert.Equal(0, new Bruch(2, 4).Vergleiche(new Bruch(1, 2)));
        Assert.Equal(-1, new Bruch(-1, 2).Vergleiche(new Bruch(1, 3)));
    }
}
