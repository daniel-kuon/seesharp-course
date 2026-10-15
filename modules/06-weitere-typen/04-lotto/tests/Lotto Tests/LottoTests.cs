public class LottoTests
{
    [Fact]
    public void SortiereAuswahl_sortiert_aufsteigend()
    {
        int[] a = [31, 7, 49, 1, 7, 12];

        Lotto.SortiereAuswahl(a);

        Assert.Equal([1, 7, 7, 12, 31, 49], a);
    }

    [Fact]
    public void Mische_veraendert_das_Array_selbst_und_behaelt_alle_Elemente()
    {
        int[] v = Enumerable.Range(1, 49).ToArray();

        Lotto.Mische(v, new Random(1));

        Assert.NotEqual(Enumerable.Range(1, 49), v);
        Assert.Equal(Enumerable.Range(1, 49), v.OrderBy(x => x));
    }

    [Fact]
    public void Mische_mit_gleichem_Seed_liefert_dieselbe_Reihenfolge()
    {
        int[] a = Enumerable.Range(1, 20).ToArray();
        int[] b = Enumerable.Range(1, 20).ToArray();

        Lotto.Mische(a, new Random(42));
        Lotto.Mische(b, new Random(42));

        Assert.Equal(a, b);
    }

    [Fact]
    public void Mische_folgt_genau_dem_Fisher_Yates_Verfahren()
    {
        int[] v = [1, 2, 3, 4, 5];

        Lotto.Mische(v, new Random(7));

        Assert.Equal([3, 1, 5, 4, 2], v);
    }

    [Fact]
    public void Ziehe_liefert_6_verschiedene_sortierte_Zahlen_aus_1_bis_49()
    {
        var z = Lotto.Ziehe(123);

        Assert.Equal(6, z.Length);
        Assert.Equal(6, z.Distinct().Count());
        Assert.All(z, n => Assert.InRange(n, 1, 49));
        Assert.Equal(z.OrderBy(n => n), z);
    }

    [Fact]
    public void Ziehe_ist_bei_gleichem_Seed_reproduzierbar()
    {
        Assert.Equal(Lotto.Ziehe(2024), Lotto.Ziehe(2024));
        Assert.NotEqual(Lotto.Ziehe(2024), Lotto.Ziehe(2025));
    }
}
