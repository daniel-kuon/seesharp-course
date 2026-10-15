public class PersListTests
{
    static PersList Drei()
    {
        var pl = new PersList();
        pl.Add(new Person("Otto", "Kolbe"));
        pl.Add(new Person("Kurt", "Saar"));
        pl.Add(new Person("Theo", "Müller"));
        return pl;
    }

    [Fact]
    public void Add_erhoeht_Count()
    {
        var pl = new PersList();
        Assert.Equal(0, pl.Count);

        pl.Add(new Person("Otto", "Kolbe"));
        pl.Add(new Person("Kurt", "Saar"));

        Assert.Equal(2, pl.Count);
    }

    [Fact]
    public void Indexer_liefert_die_Person_an_der_Position()
    {
        var pl = Drei();

        Assert.Equal("Otto", pl[0].Vorname);
        Assert.Equal("Kurt", pl[1].Vorname);
        Assert.Equal("Müller", pl[2].Name);
    }

    [Fact]
    public void Indexer_setzt_eine_Person_um()
    {
        var pl = Drei();

        pl[1] = new Person("Ilse", "Golter");

        Assert.Equal("Ilse", pl[1].Vorname);
        Assert.Equal(3, pl.Count);
    }

    [Fact]
    public void Ungueltiger_Index_wirft_ArgumentOutOfRangeException()
    {
        var pl = Drei();

        Assert.Throws<ArgumentOutOfRangeException>(() => pl[3]);
        Assert.Throws<ArgumentOutOfRangeException>(() => pl[-1]);
    }

    [Fact]
    public void Ungueltiger_Index_beim_Setzen_aendert_nichts()
    {
        var pl = Drei();

        pl[7] = new Person("Nie", "Mand");

        Assert.Equal(3, pl.Count);
    }

    [Fact]
    public void String_Indexer_findet_die_erste_Person_mit_dem_Vornamen()
    {
        var pl = Drei();
        pl.Add(new Person("Kurt", "Zweiter"));

        Assert.Equal("Saar", pl["Kurt"].Name);
        Assert.Throws<ArgumentException>(() => pl["Ilse"]);
    }
}
