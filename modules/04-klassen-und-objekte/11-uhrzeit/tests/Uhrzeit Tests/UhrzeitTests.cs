public class UhrzeitTests
{
    [Fact]
    public void Konstruktor_mit_gueltigen_Werten()
    {
        var u = new Uhrzeit(7, 5);

        Assert.Equal((7, 5), (u.Stunde, u.Minute));
    }

    [Fact]
    public void Konstruktor_normiert_Ueberlauf()
    {
        var u = new Uhrzeit(25, 70);

        Assert.Equal((2, 10), (u.Stunde, u.Minute));
    }

    [Fact]
    public void Konstruktor_normiert_negative_Werte()
    {
        Assert.Equal((23, 0), (new Uhrzeit(-1, 0).Stunde, new Uhrzeit(-1, 0).Minute));
        Assert.Equal((23, 59), (new Uhrzeit(0, -1).Stunde, new Uhrzeit(0, -1).Minute));
        Assert.Equal((0, 0), (new Uhrzeit(-48, 0).Stunde, new Uhrzeit(-48, 0).Minute));
    }

    [Fact]
    public void Konstruktor_aus_Minuten_seit_Mitternacht()
    {
        var u = new Uhrzeit(1500);

        Assert.Equal((1, 0), (u.Stunde, u.Minute));
    }

    [Fact]
    public void Text_mit_fuehrenden_Nullen()
    {
        Assert.Equal("07:05", new Uhrzeit(7, 5).Text());
        Assert.Equal("23:59", new Uhrzeit(23, 59).Text());
        Assert.Equal("00:00", new Uhrzeit(24, 0).Text());
    }

    [Fact]
    public void Addiere_Minuten_ueber_Mitternacht()
    {
        var u = new Uhrzeit(23, 30);

        u.Addiere(45);

        Assert.Equal("00:15", u.Text());
    }

    [Fact]
    public void Addiere_negative_Minuten()
    {
        var u = new Uhrzeit(0, 10);

        u.Addiere(-20);

        Assert.Equal("23:50", u.Text());
    }

    [Fact]
    public void Addiere_Stunden_und_Minuten()
    {
        var u = new Uhrzeit(10, 0);

        u.Addiere(-2, 30);

        Assert.Equal("08:30", u.Text());
    }

    [Fact]
    public void Plus_liefert_neues_Objekt_und_laesst_das_Original_in_Ruhe()
    {
        var abfahrt = new Uhrzeit(22, 45);

        var ankunft = abfahrt + 150;

        Assert.Equal("01:15", ankunft.Text());
        Assert.Equal("22:45", abfahrt.Text());
        Assert.NotSame(abfahrt, ankunft);
    }

    [Fact]
    public void Minus_liefert_Minuten_vorwaerts_auch_ueber_Mitternacht()
    {
        Assert.Equal(150, new Uhrzeit(1, 15) - new Uhrzeit(22, 45));
        Assert.Equal(90, new Uhrzeit(10, 30) - new Uhrzeit(9, 0));
        Assert.Equal(0, new Uhrzeit(12, 0) - new Uhrzeit(12, 0));
    }
}
