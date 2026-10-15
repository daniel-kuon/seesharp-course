public class IteratorenTests
{
    static SimpleSortedList<int> Liste() => new(5) { 11, 2, 1, 4, 7 };

    [Fact]
    public void Standard_Enumeration_ist_aufsteigend()
    {
        Assert.Equal([1, 2, 4, 7, 11], Liste());
    }

    [Fact]
    public void RangeIt_liefert_den_Bereich_einschliesslich()
    {
        Assert.Equal([2, 4, 7], Liste().RangeIt(1, 3));
        Assert.Equal([1], Liste().RangeIt(0, 0));
    }

    [Fact]
    public void RangeIt_liefert_bei_ungueltigem_Bereich_nichts()
    {
        Assert.Empty(Liste().RangeIt(1, 14));
        Assert.Empty(Liste().RangeIt(-1, 2));
    }

    [Fact]
    public void Iteratoren_sind_faul()
    {
        var liste = Liste();

        var bereich = liste.RangeIt(1, 99); // noch keine Prüfung, kein Durchlauf

        Assert.Empty(bereich);              // erst jetzt läuft der Iterator
    }

    [Fact]
    public void DownIt_ist_absteigend()
    {
        Assert.Equal([11, 7, 4, 2, 1], Liste().DownIt);
    }

    [Fact]
    public void RangeItUpDown_waehlt_die_Richtung()
    {
        Assert.Equal([7, 4, 2], Liste().RangeItUpDown(3, 1));
        Assert.Equal([2, 4, 7], Liste().RangeItUpDown(1, 3));
        Assert.Equal([4], Liste().RangeItUpDown(2, 2));
        Assert.Empty(Liste().RangeItUpDown(4, 7));
        Assert.Empty(Liste().RangeItUpDown(7, 4));
    }

    [Fact]
    public void Funktioniert_mit_Strings()
    {
        var s = new SimpleSortedList<string> { "one", "two", "three" };

        Assert.Equal(["two", "three", "one"], s.DownIt);
    }
}
