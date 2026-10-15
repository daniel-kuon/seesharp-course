using System.Collections;

public class EnumeratorenTests
{
    static SimpleSortedList<int> Liste() => new(5) { 11, 2, 1, 4, 7 };

    [Fact]
    public void Foreach_liefert_die_Elemente_sortiert()
    {
        var gesehen = new List<int>();

        foreach (int i in Liste())
            gesehen.Add(i);

        Assert.Equal([1, 2, 4, 7, 11], gesehen);
    }

    [Fact]
    public void Enumerator_von_Hand_bedienen()
    {
        using var e = Liste().GetEnumerator();

        Assert.True(e.MoveNext());
        Assert.Equal(1, e.Current);
        Assert.True(e.MoveNext());
        Assert.Equal(2, e.Current);
        Assert.True(e.MoveNext());
        Assert.True(e.MoveNext());
        Assert.True(e.MoveNext());
        Assert.Equal(11, e.Current);
        Assert.False(e.MoveNext());
        Assert.False(e.MoveNext());
    }

    [Fact]
    public void Current_vor_MoveNext_und_nach_dem_Ende_wirft()
    {
        var e = new SimpleSortedList<int> { 1 }.GetEnumerator();

        Assert.Throws<InvalidOperationException>(() => e.Current);
        e.MoveNext();
        e.MoveNext();
        Assert.Throws<InvalidOperationException>(() => e.Current);
    }

    [Fact]
    public void Reset_setzt_vor_das_erste_Element()
    {
        var e = Liste().GetEnumerator();
        e.MoveNext();
        e.MoveNext();

        e.Reset();

        Assert.True(e.MoveNext());
        Assert.Equal(1, e.Current);
    }

    [Fact]
    public void Jeder_GetEnumerator_Aufruf_ist_unabhaengig()
    {
        var liste = new SimpleSortedList<int> { 1, 2 };
        var paare = new List<(int, int)>();

        foreach (int a in liste)
            foreach (int b in liste)
                paare.Add((a, b));

        Assert.Equal([(1, 1), (1, 2), (2, 1), (2, 2)], paare);
    }

    [Fact]
    public void Nicht_generische_Schnittstelle_funktioniert_und_ist_explizit()
    {
        IEnumerable nichtGenerisch = Liste();
        var gesehen = new List<object?>();

        foreach (var x in nichtGenerisch)
            gesehen.Add(x);

        Assert.Equal([1, 2, 4, 7, 11], gesehen.Cast<int>());
        Assert.Single(typeof(SimpleSortedList<int>).GetMethods().Where(m => m.Name == "GetEnumerator"));
    }

    [Fact]
    public void Leere_Liste_hat_keine_Elemente()
    {
        var e = new SimpleSortedList<string>().GetEnumerator();

        Assert.False(e.MoveNext());
    }
}
