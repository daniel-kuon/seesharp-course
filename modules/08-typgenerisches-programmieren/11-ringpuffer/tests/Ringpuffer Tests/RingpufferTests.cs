public class RingpufferTests
{
    [Fact]
    public void Neuer_Puffer_ist_leer()
    {
        var p = new Ringpuffer<int>(3);

        Assert.Equal(3, p.Kapazitaet);
        Assert.Equal(0, p.Count);
        Assert.False(p.IstVoll);
        Assert.Empty(p.AlsArray());
    }

    [Fact]
    public void Ungueltige_Kapazitaet_wirft()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Ringpuffer<int>(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Ringpuffer<string>(-1));
    }

    [Fact]
    public void Entnehmen_liefert_das_aelteste_zuerst()
    {
        var p = new Ringpuffer<string>(3);
        p.Hinzufuegen("a");
        p.Hinzufuegen("b");

        Assert.Equal("a", p.Entnehmen());
        Assert.Equal("b", p.Entnehmen());
        Assert.Equal(0, p.Count);
    }

    [Fact]
    public void Voller_Puffer_ueberschreibt_das_aelteste()
    {
        var p = new Ringpuffer<int>(3);
        for (int i = 1; i <= 5; i++)
            p.Hinzufuegen(i);

        Assert.True(p.IstVoll);
        Assert.Equal(3, p.Count);
        Assert.Equal([3, 4, 5], p.AlsArray());
        Assert.Equal(3, p.Entnehmen());
        Assert.False(p.IstVoll);
    }

    [Fact]
    public void Indexer_zaehlt_ab_dem_aeltesten()
    {
        var p = new Ringpuffer<char>(3);
        foreach (char c in "abcde")
            p.Hinzufuegen(c);

        Assert.Equal('c', p[0]);
        Assert.Equal('e', p[2]);
        Assert.Throws<ArgumentOutOfRangeException>(() => p[3]);
        Assert.Throws<ArgumentOutOfRangeException>(() => p[-1]);
    }

    [Fact]
    public void Leerer_Puffer_wirft_oder_liefert_default()
    {
        var zahlen = new Ringpuffer<int>(2);
        var texte = new Ringpuffer<string>(2);

        Assert.Throws<InvalidOperationException>(() => zahlen.Entnehmen());
        Assert.Equal(0, zahlen.EntnehmenOderDefault());
        Assert.Null(texte.EntnehmenOderDefault());

        texte.Hinzufuegen("x");
        Assert.Equal("x", texte.EntnehmenOderDefault());
        Assert.Equal(0, texte.Count);
    }

    [Fact]
    public void Viele_Runden_ueber_das_Arrayende()
    {
        var p = new Ringpuffer<int>(3);
        p.Hinzufuegen(-1);
        for (int i = 0; i < 20; i++) {
            p.Hinzufuegen(i);
            Assert.Equal(i - 1, p.Entnehmen());
        }

        Assert.Equal(1, p.Count);
        Assert.Equal([19], p.AlsArray());
    }
}
