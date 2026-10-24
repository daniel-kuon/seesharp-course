public class SammlerTests
{
    [Fact]
    public void Wochentage_sind_sieben_in_der_richtigen_Reihenfolge()
    {
        var tage = Sammler.Wochentage();

        Assert.Equal(
            new[] { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" },
            tage);
    }

    [Fact]
    public void Zusammen_haengt_b_hinter_a()
    {
        var z = Sammler.Zusammen(new[] { 1, 2 }, new List<int> { 3, 4, 5 });

        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, z);
    }

    [Fact]
    public void Zusammen_mit_leeren_Folgen_und_Duplikaten()
    {
        Assert.Empty(Sammler.Zusammen(new int[0], new int[0]));
        Assert.Equal(new[] { 7, 7 }, Sammler.Zusammen(new[] { 7 }, new[] { 7 }));
        Assert.Equal(new[] { 1, 2 }, Sammler.Zusammen(new[] { 1, 2 }, Enumerable.Empty<int>()));
    }

    [Fact]
    public void Zusammen_veraendert_die_Eingaben_nicht()
    {
        var a = new List<int> { 1 };
        var b = new List<int> { 2 };

        var z = Sammler.Zusammen(a, b);
        z.Add(99);

        Assert.Equal(new[] { 1 }, a);
        Assert.Equal(new[] { 2 }, b);
    }

    [Fact]
    public void MitRand_setzt_rand_vorn_und_hinten()
    {
        int[] mitte = { 2, 3 };

        var r = Sammler.MitRand(mitte, 0);

        Assert.Equal(new[] { 0, 2, 3, 0 }, r);
        Assert.Equal(new[] { 2, 3 }, mitte);
    }

    [Fact]
    public void MitRand_mit_leerer_Mitte()
    {
        Assert.Equal(new[] { 9, 9 }, Sammler.MitRand(Array.Empty<int>(), 9));
    }

    [Fact]
    public void Leer_liefert_eine_leere_Liste_jeden_Typs()
    {
        IReadOnlyList<string> s = Sammler.Leer<string>();
        IReadOnlyList<double> d = Sammler.Leer<double>();

        Assert.NotNull(s);
        Assert.Empty(s);
        Assert.Empty(d);
    }

    [Fact]
    public void NeuesLager_hat_Name_und_drei_Artikel()
    {
        var lager = Sammler.NeuesLager();

        Assert.Equal("Hauptlager", lager.Name);
        Assert.Equal(new[] { "Schraube", "Mutter", "Dichtung" }, lager.Artikel);
    }

    [Fact]
    public void FuelleAuf_funktioniert_fuer_List()
    {
        var liste = new List<int>();

        Sammler.FuelleAuf(liste, 3, 6);

        Assert.Equal(new[] { 3, 4, 5, 6 }, liste);
    }

    [Fact]
    public void FuelleAuf_funktioniert_fuer_HashSet_und_Duplikate_fallen_weg()
    {
        var menge = new HashSet<int> { 4, 100 };

        Sammler.FuelleAuf(menge, 3, 5);

        Assert.Equal(4, menge.Count);
        Assert.Contains(3, menge);
        Assert.Contains(5, menge);
        Assert.Contains(100, menge);
    }

    [Fact]
    public void FuelleAuf_mit_von_gleich_bis_und_von_groesser_bis()
    {
        var liste = new List<int>();

        Sammler.FuelleAuf(liste, 5, 5);
        Sammler.FuelleAuf(liste, 9, 8);

        Assert.Equal(new[] { 5 }, liste);
    }

    [Fact]
    public void Zaehle_nutzt_ICollection()
    {
        Assert.Equal(3, Sammler.Zaehle(new List<string> { "a", "b", "c" }));
        Assert.Equal(2, Sammler.Zaehle(new HashSet<int> { 1, 2, 2 }));
        Assert.Equal(4, Sammler.Zaehle(new[] { 1, 2, 3, 4 }));
        Assert.Equal(0, Sammler.Zaehle(new List<double>()));
    }

    [Fact]
    public void Gesamt_summiert_jede_Folge_auch_eine_ohne_Count()
    {
        static IEnumerable<int> EinsBis(int n)
        {
            for (int i = 1; i <= n; i++)
                yield return i;
        }

        Assert.Equal(15, Sammler.Gesamt(EinsBis(5)));
        Assert.Equal(6, Sammler.Gesamt(new List<int> { 1, 2, 3 }));
        Assert.Equal(0, Sammler.Gesamt(Array.Empty<int>()));
    }
}
