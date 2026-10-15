public class R2VekTests
{
    const int Genau = 9;

    [Fact]
    public void Laenge_nach_Pythagoras()
    {
        Assert.Equal(5.0, new R2Vek(3, 4).Laenge, Genau);
        Assert.Equal(1.0, new R2Vek().Laenge, Genau);
    }

    [Fact]
    public void Normiere_bringt_den_Vektor_auf_Laenge_1()
    {
        var v = new R2Vek(3, 4);

        Assert.True(v.Normiere());
        Assert.Equal(0.6, v.X, Genau);
        Assert.Equal(0.8, v.Y, Genau);
    }

    [Fact]
    public void Normiere_lehnt_den_Nullvektor_ab()
    {
        var v = new R2Vek(0, 0);

        Assert.False(v.Normiere());
        Assert.Equal(0.0, v.X);
    }

    [Fact]
    public void Addiere_veraendert_den_Vektor()
    {
        var v = new R2Vek(1, 2);

        v.Addiere(new R2Vek(3, 4));

        Assert.Equal((4.0, 6.0), (v.X, v.Y));
    }

    [Fact]
    public void Plus_liefert_einen_neuen_Vektor_und_laesst_die_Operanden_unveraendert()
    {
        var a = new R2Vek(1, 2);
        var b = new R2Vek(3, 4);

        var s = a.Plus(b);

        Assert.NotSame(a, s);
        Assert.Equal((4.0, 6.0), (s.X, s.Y));
        Assert.Equal((1.0, 2.0), (a.X, a.Y));
        Assert.Equal((3.0, 4.0), (b.X, b.Y));
    }

    [Fact]
    public void Skalarprodukt()
    {
        Assert.Equal(11.0, new R2Vek(1, 2).SP(new R2Vek(3, 4)), Genau);
    }

    [Fact]
    public void Winkel_in_Grad()
    {
        Assert.Equal(90.0, new R2Vek(1, 0).Winkel(new R2Vek(0, 1)), 6);
        Assert.Equal(45.0, new R2Vek(1, 0).Winkel(new R2Vek(1, 1)), 6);
        Assert.Equal(0.0, new R2Vek(2, 2).Winkel(new R2Vek(1, 1)), 4);
    }

    [Fact]
    public void Drehe_um_90_Grad_gegen_den_Uhrzeigersinn()
    {
        var v = new R2Vek(1, 0);

        v.Drehe(90);

        Assert.Equal(0.0, v.X, 9);
        Assert.Equal(1.0, v.Y, 9);
    }

    [Fact]
    public void Drehe_um_360_Grad_aendert_nichts()
    {
        var v = new R2Vek(2, 3);

        v.Drehe(360);

        Assert.Equal(2.0, v.X, 9);
        Assert.Equal(3.0, v.Y, 9);
    }
}
