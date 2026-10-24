public class PruefungenTests
{
    [Fact]
    public void All_Any_Contains()
    {
        Assert.True(Pruefungen.AlleVolljaehrig([18, 30, 65]));
        Assert.False(Pruefungen.AlleVolljaehrig([18, 17, 65]));
        Assert.True(Pruefungen.AlleVolljaehrig([]));   // leere Folge: kein Gegenbeispiel

        Assert.True(Pruefungen.HatNegativenWert([3, -1, 5]));
        Assert.False(Pruefungen.HatNegativenWert([3, 0, 5]));
        Assert.False(Pruefungen.HatNegativenWert([]));

        Assert.True(Pruefungen.Enthaelt(["Apfel", "Birne"], "BIRNE"));
        Assert.False(Pruefungen.Enthaelt(["Apfel", "Birne"], "Kirsche"));
    }

    [Fact]
    public void ErstesOderStandard_liefert_Erstes_oder_Standard()
    {
        Assert.Equal(7, Zugriff.ErstesOderStandard([7, 8, 9], -1));
        Assert.Equal(-1, Zugriff.ErstesOderStandard([], -1));
    }

    [Fact]
    public void EindeutigerTreffer_wirft_bei_keinem_und_bei_mehreren()
    {
        Assert.Equal(8, Zugriff.EindeutigerTreffer([1, 8, 3], w => w > 5));

        Assert.Throws<InvalidOperationException>(() => Zugriff.EindeutigerTreffer([1, 2, 3], w => w > 5));
        Assert.Throws<InvalidOperationException>(() => Zugriff.EindeutigerTreffer([6, 7, 3], w => w > 5));
    }

    [Fact]
    public void EindeutigerTrefferText_faengt_die_Ausnahme()
    {
        Assert.Equal("Treffer: 8", Zugriff.EindeutigerTrefferText([1, 8, 3], w => w > 5));
        Assert.Equal("kein eindeutiger Treffer", Zugriff.EindeutigerTrefferText([1, 2, 3], w => w > 5));
        Assert.Equal("kein eindeutiger Treffer", Zugriff.EindeutigerTrefferText([6, 7, 3], w => w > 5));
    }

    [Fact]
    public void Dritte_und_Letzte()
    {
        Assert.Equal("c", Zugriff.Dritte(["a", "b", "c", "d"]));
        Assert.Equal("d", Zugriff.Letzte(["a", "b", "c", "d"]));

        // eine Abfrage als Quelle (kein Array oder Liste): ElementAt wirft dann ArgumentOutOfRangeException
        Assert.Throws<ArgumentOutOfRangeException>(() => Zugriff.Dritte(Enumerable.Range(1, 2).Select(i => "x" + i)));
        Assert.Throws<InvalidOperationException>(() => Zugriff.Letzte([]));
    }
}
