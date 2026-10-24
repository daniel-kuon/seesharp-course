public class ListenwerkzeugeTests
{
    [Fact]
    public void RemoveEvens_entfernt_auch_aufeinanderfolgende_gerade_Zahlen()
    {
        var zahlen = new List<int> { 1, 2, 4, 6, 7, 8, 10, 12, 3 };

        Listenwerkzeuge.RemoveEvens(zahlen);

        Assert.Equal(new[] { 1, 7, 3 }, zahlen);
    }

    [Fact]
    public void RemoveEvens_leere_und_rein_ungerade_Liste()
    {
        var leer = new List<int>();
        var ungerade = new List<int> { 1, 3, 5 };

        Listenwerkzeuge.RemoveEvens(leer);
        Listenwerkzeuge.RemoveEvens(ungerade);

        Assert.Empty(leer);
        Assert.Equal(new[] { 1, 3, 5 }, ungerade);
    }

    [Fact]
    public void RemoveEvens_nur_gerade_Zahlen_leert_die_Liste()
    {
        var zahlen = new List<int> { 2, 4, 6, 8 };

        Listenwerkzeuge.RemoveEvens(zahlen);

        Assert.Empty(zahlen);
    }

    [Theory]
    [InlineData(5, new[] { 1, 3, 5, 5, 8 })]
    [InlineData(0, new[] { 0, 1, 3, 5, 8 })]
    [InlineData(10, new[] { 1, 3, 5, 8, 10 })]
    [InlineData(4, new[] { 1, 3, 4, 5, 8 })]
    public void InsertSorted_haelt_die_Liste_aufsteigend(int wert, int[] erwartet)
    {
        var liste = new List<int> { 1, 3, 5, 8 };

        Listenwerkzeuge.InsertSorted(liste, wert);

        Assert.Equal(erwartet, liste);
    }

    [Fact]
    public void InsertSorted_in_leere_Liste()
    {
        var liste = new List<int>();

        Listenwerkzeuge.InsertSorted(liste, 7);

        Assert.Equal(new[] { 7 }, liste);
    }

    [Fact]
    public void MoveToFront_verschiebt_vorhandenen_Eintrag_ohne_Duplikat()
    {
        var liste = new List<string> { "a.txt", "b.txt", "c.txt" };

        Listenwerkzeuge.MoveToFront(liste, "c.txt");

        Assert.Equal(new[] { "c.txt", "a.txt", "b.txt" }, liste);
    }

    [Fact]
    public void MoveToFront_fuegt_fehlenden_Eintrag_vorn_ein()
    {
        var liste = new List<string> { "a.txt", "b.txt" };

        Listenwerkzeuge.MoveToFront(liste, "z.txt");

        Assert.Equal(new[] { "z.txt", "a.txt", "b.txt" }, liste);
    }

    [Fact]
    public void MoveToFront_Eintrag_steht_schon_vorn()
    {
        var liste = new List<string> { "a.txt", "b.txt" };

        Listenwerkzeuge.MoveToFront(liste, "a.txt");

        Assert.Equal(new[] { "a.txt", "b.txt" }, liste);
    }

    [Fact]
    public void Top3_liefert_die_drei_groessten_absteigend()
    {
        var zahlen = new List<int> { 4, 9, 1, 7, 3, 9, 2 };

        var top = Listenwerkzeuge.Top3(zahlen);

        Assert.Equal(new[] { 9, 9, 7 }, top);
    }

    [Fact]
    public void Top3_veraendert_das_Argument_nicht()
    {
        var zahlen = new List<int> { 4, 9, 1, 7 };

        var top = Listenwerkzeuge.Top3(zahlen);

        Assert.Equal(new[] { 4, 9, 1, 7 }, zahlen);
        Assert.NotSame(zahlen, top);
    }

    [Fact]
    public void Top3_mit_weniger_als_drei_Werten()
    {
        Assert.Equal(new[] { 5, 2 }, Listenwerkzeuge.Top3(new List<int> { 2, 5 }));
        Assert.Empty(Listenwerkzeuge.Top3(new List<int>()));
    }

    [Fact]
    public void Rotate_dreht_nach_links_und_laesst_das_Original_unveraendert()
    {
        int[] a = { 1, 2, 3, 4, 5 };

        var r = Listenwerkzeuge.Rotate(a, 2);

        Assert.Equal(new[] { 3, 4, 5, 1, 2 }, r);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, a);
        Assert.NotSame(a, r);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(10)]
    public void Rotate_um_Vielfache_der_Laenge_aendert_nichts(int k)
    {
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, Listenwerkzeuge.Rotate(new[] { 1, 2, 3, 4, 5 }, k));
    }

    [Fact]
    public void Rotate_mit_k_groesser_als_Laenge_und_leeres_Array()
    {
        Assert.Equal(new[] { 2, 3, 1 }, Listenwerkzeuge.Rotate(new[] { 1, 2, 3 }, 4));
        Assert.Empty(Listenwerkzeuge.Rotate(Array.Empty<int>(), 3));
    }
}
