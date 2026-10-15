public class BruchTests
{
    [Fact]
    public void Addiere_Bruch_addiert_und_kuerzt()
    {
        var b = new Bruch { Zaehler = 1, Nenner = 2 };
        b.Addiere(new Bruch { Zaehler = 1, Nenner = 4 });

        Assert.Equal((3, 4), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Addiere_Zahlen_mit_autokurz()
    {
        var b = new Bruch { Zaehler = 1, Nenner = 2 };

        Assert.True(b.Addiere(1, 2, autokurz: true));
        Assert.Equal((1, 1), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Addiere_Zahlen_ohne_autokurz_kuerzt_nicht()
    {
        var b = new Bruch { Zaehler = 1, Nenner = 2 };

        Assert.True(b.Addiere(1, 2, autokurz: false));
        Assert.Equal((4, 4), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Addiere_mit_Nenner_null_liefert_false_und_aendert_nichts()
    {
        var b = new Bruch { Zaehler = 1, Nenner = 2 };

        Assert.False(b.Addiere(1, 0, autokurz: true));
        Assert.Equal((1, 2), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Beide_Ueberladungen_sind_aufrufbar()
    {
        var b = new Bruch { Zaehler = 1, Nenner = 3 };
        b.Addiere(new Bruch { Zaehler = 1, Nenner = 3 });
        b.Addiere(1, 3, autokurz: true);

        Assert.Equal((1, 1), (b.Zaehler, b.Nenner));
    }
}
