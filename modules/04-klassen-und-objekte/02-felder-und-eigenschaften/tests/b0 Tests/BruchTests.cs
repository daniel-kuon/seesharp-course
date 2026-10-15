public class BruchTests
{
    [Fact]
    public void Zaehler_liest_und_schreibt_das_Feld()
    {
        var b = new Bruch();
        b.Zaehler = 5;

        Assert.Equal(5, b.Zaehler);
    }

    [Fact]
    public void Nenner_ignoriert_null()
    {
        var b = new Bruch();
        b.Nenner = 4;
        b.Nenner = 0;

        Assert.Equal(4, b.Nenner);
    }

    [Fact]
    public void Nenner_uebernimmt_gueltige_Werte()
    {
        var b = new Bruch();
        b.Nenner = -3;

        Assert.Equal(-3, b.Nenner);
    }

    [Fact]
    public void Etikett_wird_auf_40_Zeichen_gekuerzt()
    {
        var b = new Bruch();
        b.Etikett = new string('a', 50);

        Assert.Equal(40, b.Etikett.Length);
        b.Etikett = "kurz";
        Assert.Equal("kurz", b.Etikett);
    }

    [Fact]
    public void Kuerze_teilt_durch_den_ggT()
    {
        var b = new Bruch { Zaehler = 6, Nenner = 8 };
        b.Kuerze();

        Assert.Equal((3, 4), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Kuerze_macht_aus_null_Zaehler_null_durch_eins()
    {
        var b = new Bruch { Zaehler = 0, Nenner = 8 };
        b.Kuerze();

        Assert.Equal((0, 1), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Kuerze_mit_negativem_Zaehler()
    {
        var b = new Bruch { Zaehler = -6, Nenner = 8 };
        b.Kuerze();

        Assert.Equal((-3, 4), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Addiere_addiert_und_kuerzt()
    {
        var b = new Bruch { Zaehler = 1, Nenner = 2 };
        b.Addiere(new Bruch { Zaehler = 1, Nenner = 4 });

        Assert.Equal((3, 4), (b.Zaehler, b.Nenner));
    }
}
