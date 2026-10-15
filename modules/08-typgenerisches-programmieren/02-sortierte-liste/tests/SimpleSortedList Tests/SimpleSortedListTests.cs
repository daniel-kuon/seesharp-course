public class SimpleSortedListTests
{
    [Fact]
    public void Elemente_werden_sortiert_eingefuegt()
    {
        var si = new SimpleSortedList<int>(5);
        si.Add(11);
        si.Add(2);
        si.Add(1);
        si.Add(4);

        Assert.Equal(4, si.Count);
        Assert.Equal([1, 2, 4, 11], Enumerable.Range(0, si.Count).Select(i => si[i]));
    }

    [Fact]
    public void Funktioniert_mit_Strings()
    {
        var ss = new SimpleSortedList<string>();
        ss.Add("Otto");
        ss.Add("Anna");
        ss.Add("Kurt");

        Assert.Equal("Anna", ss[0]);
        Assert.Equal("Otto", ss[2]);
    }

    [Fact]
    public void Gleiche_Werte_bleiben_erhalten()
    {
        var si = new SimpleSortedList<int>();
        si.Add(3);
        si.Add(3);
        si.Add(1);

        Assert.Equal([1, 3, 3], Enumerable.Range(0, si.Count).Select(i => si[i]));
    }

    [Fact]
    public void Volle_Liste_und_ungueltiger_Index_werfen()
    {
        var si = new SimpleSortedList<int>(1);
        si.Add(1);

        Assert.Throws<InvalidOperationException>(() => si.Add(2));
        Assert.Throws<ArgumentOutOfRangeException>(() => si[1]);
        Assert.Throws<ArgumentOutOfRangeException>(() => si[-1]);
    }

    [Fact]
    public void T_ist_auf_IComparable_eingeschraenkt()
    {
        var t = typeof(SimpleSortedList<>).GetGenericArguments()[0];

        Assert.Contains(t.GetGenericParameterConstraints(),
            c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IComparable<>));
    }
}
