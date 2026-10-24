public class LottoTests
{
    static SortedSet<int> S(params int[] zahlen) => new(zahlen);

    [Fact]
    public void Ziehe_mit_festem_Startwert_liefert_das_Ergebnis_der_Musterloesung()
    {
        var z = Lotto.Ziehe(new Random(42));

        Assert.Equal(new[] { 7, 9, 13, 26, 33, 36 }, z);
    }

    [Fact]
    public void Ziehe_mit_anderem_Startwert()
    {
        var z = Lotto.Ziehe(new Random(7));

        Assert.Equal(new[] { 3, 18, 19, 33, 34, 43 }, z);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(100)]
    public void Ziehe_liefert_sechs_verschiedene_Zahlen_von_1_bis_49_aufsteigend(int startwert)
    {
        var z = Lotto.Ziehe(new Random(startwert));

        Assert.Equal(6, z.Count);
        Assert.All(z, n => Assert.InRange(n, 1, 49));
        Assert.Equal(z.OrderBy(n => n).ToList(), z.ToList());
    }

    [Fact]
    public void Doppelte_Zahl_aendert_die_Menge_nicht()
    {
        var z = Lotto.Ziehe(new Random(42));

        Assert.False(z.Add(z.Min));
        Assert.Equal(6, z.Count);
    }

    [Fact]
    public void Treffer_zaehlt_gemeinsame_Zahlen()
    {
        Assert.Equal(3, Lotto.Treffer(S(1, 2, 3, 4, 5, 6), S(4, 5, 6, 7, 8, 9)));
        Assert.Equal(0, Lotto.Treffer(S(1, 2, 3), S(4, 5, 6)));
        Assert.Equal(6, Lotto.Treffer(S(1, 2, 3, 4, 5, 6), S(6, 5, 4, 3, 2, 1)));
        Assert.Equal(0, Lotto.Treffer(S(), S(1, 2)));
    }

    [Fact]
    public void Treffer_veraendert_keine_der_Mengen()
    {
        var tipp = S(1, 2, 3, 4, 5, 6);
        var ziehung = S(4, 5, 6, 7, 8, 9);

        Lotto.Treffer(tipp, ziehung);

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, tipp);
        Assert.Equal(new[] { 4, 5, 6, 7, 8, 9 }, ziehung);
    }

    [Theory]
    [InlineData(0, 3)]
    [InlineData(3, 7)]
    [InlineData(4, 7)]
    [InlineData(7, 20)]
    [InlineData(19, 20)]
    [InlineData(20, -1)]
    [InlineData(100, -1)]
    [InlineData(int.MaxValue, -1)]
    [InlineData(int.MinValue, 3)]
    public void NaechsteZahl_liefert_die_kleinste_groessere_Zahl(int x, int erwartet)
    {
        var s = S(3, 7, 20);

        Assert.Equal(erwartet, Lotto.NaechsteZahl(s, x));
    }

    [Fact]
    public void NaechsteZahl_bei_leerer_Menge()
    {
        Assert.Equal(-1, Lotto.NaechsteZahl(S(), 5));
    }

    [Fact]
    public void Spanne_ist_Maximum_minus_Minimum()
    {
        Assert.Equal(40, Lotto.Spanne(S(3, 17, 43, 10)));
        Assert.Equal(0, Lotto.Spanne(S(8)));
        Assert.Equal(0, Lotto.Spanne(S()));
    }
}
