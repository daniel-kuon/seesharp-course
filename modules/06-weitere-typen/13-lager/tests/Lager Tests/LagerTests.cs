public class LagerTests
{
    static Artikel[] Bestand() => [
        new("Apfel", 0.40m, 120),
        new("Birne", 0.55m, 3),
        new("Kiwi", 0.35m, 0),
    ];

    [Fact]
    public void Einlagern_liefert_Kopie_mit_hoeherem_Bestand()
    {
        var a = new Artikel("Apfel", 0.40m, 10);

        var b = Lager.Einlagern(a, 5);

        Assert.Equal(new Artikel("Apfel", 0.40m, 15), b);
        Assert.Equal(10, a.Bestand);
        Assert.NotSame(a, b);
    }

    [Fact]
    public void Einlagern_mit_ungueltiger_Menge_aendert_nichts()
    {
        var a = new Artikel("Apfel", 0.40m, 10);

        Assert.Same(a, Lager.Einlagern(a, 0));
        Assert.Same(a, Lager.Einlagern(a, -3));
    }

    [Fact]
    public void Reduziere_rundet_auf_Cent()
    {
        var a = new Artikel("Birne", 0.55m, 3);

        Assert.Equal(new Artikel("Birne", 0.41m, 3), Lager.Reduziere(a, 25));
        Assert.Equal(new Artikel("Birne", 0.28m, 3), Lager.Reduziere(a, 50));
        Assert.Equal(0.55m, a.Preis);
    }

    [Fact]
    public void Gesamtwert_summiert_Preis_mal_Bestand()
    {
        Assert.Equal(49.65m, Lager.Gesamtwert(Bestand()));
        Assert.Equal(0m, Lager.Gesamtwert([]));
    }

    [Fact]
    public void Preisstatistik_liefert_benanntes_Tupel()
    {
        var stat = Lager.Preisstatistik(Bestand());

        Assert.Equal(0.35m, stat.Min);
        Assert.Equal(0.55m, stat.Max);
        Assert.Equal(0.43m, stat.Schnitt);
    }

    [Fact]
    public void Preisstatistik_laesst_sich_dekonstruieren()
    {
        var (min, max, schnitt) = Lager.Preisstatistik([new("Brot", 2.50m, 1)]);

        Assert.Equal((2.50m, 2.50m, 2.50m), (min, max, schnitt));
        Assert.Equal((0m, 0m, 0m), Lager.Preisstatistik([]));
    }

    [Fact]
    public void Nachbestellen_fuellt_auf_und_liefert_neues_Array()
    {
        Artikel[] alt = Bestand();

        Artikel[] neu = Lager.Nachbestellen(alt, 10);

        Artikel[] erwartet = [new("Apfel", 0.40m, 120), new("Birne", 0.55m, 10), new("Kiwi", 0.35m, 10)];
        Assert.NotSame(alt, neu);
        Assert.Equal(erwartet, neu);
        Assert.Equal(Bestand(), alt);
    }

    [Fact]
    public void Nachbestellen_uebernimmt_ausreichende_Artikel_unveraendert()
    {
        Artikel[] alt = Bestand();

        Artikel[] neu = Lager.Nachbestellen(alt, 10);

        Assert.Same(alt[0], neu[0]);
    }
}
