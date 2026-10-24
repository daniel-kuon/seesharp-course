public class RechnerTests
{
    [Fact]
    public void Anwenden_ruft_statische_Methoden()
    {
        Assert.Equal(5, Rechner.Anwenden(Rechner.Addiere, 2, 3));
        Assert.Equal(-1, Rechner.Anwenden(Rechner.Subtrahiere, 2, 3));
        Assert.Equal(6, Rechner.Anwenden(Rechner.Multipliziere, 2, 3));
        Assert.Equal(2.5, Rechner.Anwenden(Rechner.Dividiere, 5, 2));
    }

    [Fact]
    public void Dividiere_durch_null_liefert_Unendlich()
    {
        Assert.True(double.IsPositiveInfinity(Rechner.Dividiere(1, 0)));
    }

    [Fact]
    public void Reduziere_faltet_von_links()
    {
        Assert.Equal(10, Rechner.Reduziere(Rechner.Addiere, [1, 2, 3, 4]));
        Assert.Equal(24, Rechner.Reduziere(Rechner.Multipliziere, [2, 3, 4]));
        Assert.Equal(-4, Rechner.Reduziere(Rechner.Subtrahiere, [1, 2, 3]));
        Assert.Equal(7, Rechner.Reduziere(Rechner.Addiere, [7]));
    }

    [Fact]
    public void Reduziere_leeres_Array_wirft()
    {
        Assert.Throws<ArgumentException>(() => Rechner.Reduziere(Rechner.Addiere, []));
    }

    [Fact]
    public void Waehle_liefert_den_passenden_Delegaten()
    {
        Assert.Equal(7, Rechner.Waehle('+')!(3, 4));
        Assert.Equal(-1, Rechner.Waehle('-')!(3, 4));
        Assert.Equal(12, Rechner.Waehle('*')!(3, 4));
        Assert.Equal(0.75, Rechner.Waehle('/')!(3, 4));
    }

    [Fact]
    public void Waehle_unbekanntes_Zeichen_liefert_null()
    {
        Assert.Null(Rechner.Waehle('x'));
        Assert.Null(Rechner.Waehle(' '));
    }

    [Fact]
    public void Instanzdelegat_behaelt_sein_Zielobjekt()
    {
        var r = new Rechner { Exponent = 2 };
        Operation op = r.PotenzDelegat();
        Assert.Equal(9, op(1, 2));

        r.Exponent = 3;   // das Delegatenobjekt zeigt auf r, nicht auf eine Kopie
        Assert.Equal(27, op(1, 2));
    }

    [Fact]
    public void Zwei_Rechner_zwei_Ziele()
    {
        var quadrat = new Rechner { Exponent = 2 };
        var kubik = new Rechner { Exponent = 3 };
        Operation a = quadrat.PotenzDelegat();
        Operation b = kubik.PotenzDelegat();

        Assert.Equal(4, Rechner.Anwenden(a, 1, 1));
        Assert.Equal(8, Rechner.Anwenden(b, 1, 1));
    }
}
