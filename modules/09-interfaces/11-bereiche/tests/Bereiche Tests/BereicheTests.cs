public class BereicheTests
{
    [Fact]
    public void Bereich_ist_mit_foreach_durchlaufbar()
    {
        Assert.True(typeof(IEnumerable<int>).IsAssignableFrom(typeof(Bereich)));

        var werte = new List<int>();
        foreach (int x in new Bereich(1, 3))
            werte.Add(x);

        Assert.Equal([1, 2, 3], werte);
    }

    [Fact]
    public void Schrittweite_auf_und_ab()
    {
        Assert.Equal([1, 4, 7, 10], new Bereich(1, 10, 3));
        Assert.Equal([1, 5, 9], new Bereich(1, 10, 4));
        Assert.Equal([5, 3, 1], new Bereich(5, 1, -2));
        Assert.Equal([-2, -1, 0], new Bereich(-2, 0));
        Assert.Equal([3], new Bereich(3, 3));
        Assert.Empty(new Bereich(1, 5, -1));
        Assert.Empty(new Bereich(5, 1));
    }

    [Fact]
    public void Schrittweite_0_wirft()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Bereich(1, 5, 0));
    }

    [Fact]
    public void Count_und_Enthaelt_rechnen()
    {
        var b = new Bereich(1, 10, 3);
        var ab = new Bereich(5, 1, -2);

        Assert.Equal(4, b.Count);
        Assert.Equal(3, new Bereich(1, 10, 4).Count);
        Assert.Equal(3, ab.Count);
        Assert.Equal(0, new Bereich(1, 5, -1).Count);
        Assert.Equal(1_000_000_001, new Bereich(0, 1_000_000_000).Count);

        Assert.True(b.Enthaelt(7));
        Assert.False(b.Enthaelt(8));
        Assert.False(b.Enthaelt(13));
        Assert.False(b.Enthaelt(-2));
        Assert.True(ab.Enthaelt(3));
        Assert.False(ab.Enthaelt(4));
        Assert.False(ab.Enthaelt(7));
        Assert.True(new Bereich(0, 1_000_000_000).Enthaelt(999_999_999));
    }

    [Fact]
    public void Rueckwaerts_ist_ein_Iterator_als_Eigenschaft()
    {
        Assert.Equal([9, 5, 1], new Bereich(1, 10, 4).Rueckwaerts);
        Assert.Equal([1, 3, 5], new Bereich(5, 1, -2).Rueckwaerts);
        Assert.Empty(new Bereich(5, 1).Rueckwaerts);
        Assert.NotNull(typeof(Bereich).GetProperty("Rueckwaerts"));
    }

    [Fact]
    public void Vielfache_filtert_und_bricht_bei_0_ab()
    {
        Assert.Equal([3, 6, 9], new Bereich(1, 10).Vielfache(3));
        Assert.Equal([10, 5, 0], new Bereich(10, 0, -1).Vielfache(5));
        Assert.Empty(new Bereich(1, 10).Vielfache(0));
    }

    [Fact]
    public void Erste_holt_aus_einer_unendlichen_Folge()
    {
        Assert.Equal([1L, 4L, 9L, 16L, 25L], Folgen.Erste(Folgen.Quadratzahlen(), 5));
        Assert.Equal([1, 2, 3], Folgen.Erste(new Bereich(1, 3), 10));
        Assert.Empty(Folgen.Erste(Folgen.Quadratzahlen(), 0));
        Assert.Equal(1_000_000L * 1_000_000L, Folgen.Erste(Folgen.Quadratzahlen(), 1_000_000).Last());
    }

    [Fact]
    public void Zwei_Durchlaeufe_sind_unabhaengig()
    {
        var b = new Bereich(1, 3);
        int paare = 0;

        foreach (int x in b)
            foreach (int y in b)
                paare++;

        Assert.Equal(9, paare);
    }
}
