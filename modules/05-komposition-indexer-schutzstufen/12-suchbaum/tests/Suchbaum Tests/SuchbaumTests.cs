public class SuchbaumTests
{
    static Suchbaum Beispiel()
    {
        var b = new Suchbaum();
        foreach (int z in new[] { 8, 3, 10, 1, 6, 14, 4, 7, 13 })
            b.Einfuegen(z);
        return b;
    }

    [Fact]
    public void Leerer_Baum()
    {
        var b = new Suchbaum();

        Assert.Equal(0, b.Anzahl);
        Assert.Equal(0, b.Hoehe);
        Assert.Equal("", b.ToString());
        Assert.False(b.Enthaelt(1));
    }

    [Fact]
    public void Einfuegen_lehnt_Duplikate_ab()
    {
        var b = new Suchbaum();

        Assert.True(b.Einfuegen(5));
        Assert.True(b.Einfuegen(2));
        Assert.False(b.Einfuegen(5));
        Assert.Equal(2, b.Anzahl);
    }

    [Fact]
    public void Enthaelt_findet_eingefuegte_Werte()
    {
        var b = Beispiel();

        Assert.True(b.Enthaelt(8));
        Assert.True(b.Enthaelt(7));
        Assert.True(b.Enthaelt(13));
        Assert.False(b.Enthaelt(5));
        Assert.False(b.Enthaelt(15));
    }

    [Fact]
    public void Anzahl_zaehlt_alle_Knoten()
    {
        Assert.Equal(9, Beispiel().Anzahl);
    }

    [Fact]
    public void Hoehe_des_Beispielbaums()
    {
        // 8 -> 3 -> 6 -> 4 bzw. 8 -> 10 -> 14 -> 13: vier Ebenen
        Assert.Equal(4, Beispiel().Hoehe);
    }

    [Fact]
    public void Sortiert_eingefuegt_entsteht_eine_Kette()
    {
        var b = new Suchbaum();
        for (int i = 1; i <= 6; i++)
            b.Einfuegen(i);

        Assert.Equal(6, b.Hoehe);
    }

    [Fact]
    public void ToString_liefert_die_Werte_aufsteigend()
    {
        Assert.Equal("1 3 4 6 7 8 10 13 14", Beispiel().ToString());
    }

    [Fact]
    public void Negative_Werte_funktionieren()
    {
        var b = new Suchbaum();
        b.Einfuegen(0);
        b.Einfuegen(-5);
        b.Einfuegen(5);
        b.Einfuegen(-7);

        Assert.Equal("-7 -5 0 5", b.ToString());
        Assert.Equal(3, b.Hoehe);
    }
}
