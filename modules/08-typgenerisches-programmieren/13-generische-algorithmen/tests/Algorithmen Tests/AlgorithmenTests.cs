public class AlgorithmenTests
{
    // Zählt jeden Vergleich mit, um lineare Suche von binärer zu unterscheiden.
    class Zaehler(int wert) : IComparable<Zaehler>
    {
        public static int Vergleiche;
        public int Wert { get; } = wert;

        public int CompareTo(Zaehler? other)
        {
            Vergleiche++;
            return Wert.CompareTo(other!.Wert);
        }
    }

    [Fact]
    public void Alle_Methoden_sind_auf_IComparable_eingeschraenkt()
    {
        foreach (var name in new[] { "IstSortiert", "BinaereSuche", "Zusammenfuehren", "MinMax" })
        {
            var t = typeof(Algorithmen).GetMethod(name)!.GetGenericArguments()[0];
            Assert.True(t.GetGenericParameterConstraints().Any(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IComparable<>)),
                $"{name} braucht where T : IComparable<T>");
        }
    }

    [Fact]
    public void IstSortiert_prueft_die_Reihenfolge()
    {
        Assert.True(Algorithmen.IstSortiert(new[] { 1, 2, 2, 5 }));
        Assert.False(Algorithmen.IstSortiert(new[] { 1, 3, 2 }));
        Assert.True(Algorithmen.IstSortiert(new[] { "Anna", "Otto", "Zoe" }));
        Assert.True(Algorithmen.IstSortiert(new int[0]));
        Assert.True(Algorithmen.IstSortiert(new[] { 7 }));
    }

    [Fact]
    public void BinaereSuche_findet_den_Index()
    {
        int[] z = [2, 3, 5, 7, 11, 13];

        Assert.Equal(0, Algorithmen.BinaereSuche(z, 2));
        Assert.Equal(3, Algorithmen.BinaereSuche(z, 7));
        Assert.Equal(5, Algorithmen.BinaereSuche(z, 13));
        Assert.Equal(-1, Algorithmen.BinaereSuche(z, 4));
        Assert.Equal(-1, Algorithmen.BinaereSuche(z, 99));
        Assert.Equal(-1, Algorithmen.BinaereSuche(new int[0], 1));
        Assert.Equal(1, Algorithmen.BinaereSuche(new[] { "a", "m", "z" }, "m"));
    }

    [Fact]
    public void BinaereSuche_halbiert_den_Bereich()
    {
        var werte = new Zaehler[1000];
        for (int i = 0; i < werte.Length; i++)
            werte[i] = new Zaehler(2 * i);

        Zaehler.Vergleiche = 0;
        int index = Algorithmen.BinaereSuche(werte, new Zaehler(1996));
        int vergleiche = Zaehler.Vergleiche;

        Assert.Equal(998, index);
        Assert.True(vergleiche <= 20, $"{vergleiche} Vergleiche: das ist keine binäre Suche");
    }

    [Fact]
    public void Zusammenfuehren_verschmilzt_zwei_sortierte_Arrays()
    {
        Assert.Equal([1, 2, 3, 4, 9, 10], Algorithmen.Zusammenfuehren(new[] { 1, 4, 9 }, new[] { 2, 3, 10 }));
        Assert.Equal([1, 1, 2], Algorithmen.Zusammenfuehren(new[] { 1, 2 }, new[] { 1 }));
        Assert.Equal([5, 6], Algorithmen.Zusammenfuehren(new int[0], new[] { 5, 6 }));
        Assert.Equal(["a", "b", "c"], Algorithmen.Zusammenfuehren(new[] { "b" }, new[] { "a", "c" }));
    }

    [Fact]
    public void MinMax_liefert_ein_Tupel()
    {
        var (min, max) = Algorithmen.MinMax(3, 9, -4, 7);

        Assert.Equal(-4, min);
        Assert.Equal(9, max);
        Assert.Equal(("Anna", "Zoe"), Algorithmen.MinMax("Otto", "Anna", "Zoe"));
        Assert.Equal((2.5, 2.5), Algorithmen.MinMax(2.5));
        Assert.Throws<ArgumentException>(() => Algorithmen.MinMax<int>());
    }
}
