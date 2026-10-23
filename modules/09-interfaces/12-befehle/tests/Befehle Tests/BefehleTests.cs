public class BefehleTests
{
    [Fact]
    public void Alle_Befehle_sind_IBefehle()
    {
        IBefehl[] alle = [new Addiere(5), new Multipliziere(3), new Negiere(), new Makro(new Addiere(2), new Negiere())];

        Assert.Equal("Addiere 5", alle[0].Name);
        Assert.Equal("Multipliziere 3", alle[1].Name);
        Assert.Equal("Negiere", alle[2].Name);
        Assert.Equal("Makro(Addiere 2, Negiere)", alle[3].Name);
        Assert.Equal("Makro()", new Makro().Name);
    }

    [Fact]
    public void Ausfuehren_und_Rueckgaengig_heben_sich_auf()
    {
        Assert.Equal(12, new Addiere(5).Ausfuehren(7));
        Assert.Equal(21, new Multipliziere(3).Ausfuehren(7));
        Assert.Equal(-7, new Negiere().Ausfuehren(7));

        IBefehl[] alle = [new Multipliziere(-4), new Negiere(), new Makro(new Negiere(), new Multipliziere(2))];
        foreach (IBefehl b in alle)
            Assert.Equal(7, b.Rueckgaengig(b.Ausfuehren(7)));
    }

    [Fact]
    public void Multipliziere_mit_0_wirft()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Multipliziere(0));
    }

    [Fact]
    public void Makro_fuehrt_der_Reihe_nach_aus_und_rueckwaerts_zurueck()
    {
        var m = new Makro(new Addiere(2), new Multipliziere(3));   // (x + 2) * 3

        Assert.Equal(9, m.Ausfuehren(1));
        Assert.Equal(1, m.Rueckgaengig(9));                        // erst / 3, dann - 2

        var verschachtelt = new Makro(m, new Negiere());
        Assert.Equal(-9, verschachtelt.Ausfuehren(1));
        Assert.Equal(1, verschachtelt.Rueckgaengig(-9));
        Assert.Equal("Makro(Makro(Addiere 2, Multipliziere 3), Negiere)", verschachtelt.Name);
    }

    [Fact]
    public void Rechner_fuehrt_aus_und_protokolliert()
    {
        var r = new Rechner();

        Assert.Equal(0, r.Wert);
        Assert.Equal("", r.Protokoll());

        r.Ausfuehren(new Addiere(5));
        r.Ausfuehren(new Multipliziere(3));

        Assert.Equal(15, r.Wert);
        Assert.Equal("Addiere 5, Multipliziere 3", r.Protokoll());
    }

    [Fact]
    public void Rueckgaengig_nimmt_den_letzten_Befehl_zurueck()
    {
        var r = new Rechner();
        Assert.False(r.Rueckgaengig());

        r.Ausfuehren(new Addiere(5));
        r.Ausfuehren(new Multipliziere(3));
        r.Ausfuehren(new Negiere());

        Assert.True(r.Rueckgaengig());
        Assert.Equal(15, r.Wert);
        Assert.True(r.Rueckgaengig());
        Assert.Equal(5, r.Wert);
        Assert.Equal("Addiere 5", r.Protokoll());
        Assert.True(r.Rueckgaengig());
        Assert.False(r.Rueckgaengig());
        Assert.Equal(0, r.Wert);
    }

    [Fact]
    public void Wiederholen_nach_Rueckgaengig()
    {
        var r = new Rechner();
        Assert.False(r.Wiederholen());

        r.Ausfuehren(new Addiere(5));
        r.Ausfuehren(new Multipliziere(3));
        r.Rueckgaengig();
        r.Rueckgaengig();

        Assert.True(r.Wiederholen());
        Assert.Equal(5, r.Wert);
        Assert.True(r.Wiederholen());
        Assert.Equal(15, r.Wert);
        Assert.False(r.Wiederholen());

        r.Rueckgaengig();
        r.Ausfuehren(new Negiere());               // ein neuer Befehl verwirft das Zurückgenommene
        Assert.False(r.Wiederholen());
        Assert.Equal(-5, r.Wert);
        Assert.Equal("Addiere 5, Negiere", r.Protokoll());
    }
}
