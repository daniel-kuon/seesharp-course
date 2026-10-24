using System.Collections;

public class AuswertungTests
{
    private sealed class ZaehlendeQuelle<T>(IEnumerable<T> inner) : IEnumerable<T>
    {
        public int Aufzaehlungen { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            Aufzaehlungen++;
            return inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private static IEnumerable<int> Zahlen()
    {
        int i = 0;
        while (true) yield return i++;   // unendlich
    }

    private static List<Mitarbeiter> Team() =>
    [
        new("Anna", 3000m), new("Bert", 4000m), new("Clara", 5000m), new("Dora", 4000m), new("Emil", 6000m),
    ];

    [Fact]
    public void Woerter_flacht_Saetze_ab_und_entfernt_Wiederholungen()
    {
        var woerter = Auswertung.Woerter(["Der Hund bellt, der Hund schläft.", "Die Katze schläft!"]);

        Assert.Equal(["der", "hund", "bellt", "schläft", "die", "katze"], woerter);
        Assert.Empty(Auswertung.Woerter([]));
        Assert.Empty(Auswertung.Woerter(["", " . "]));
    }

    [Fact]
    public void Kombinationen_ist_das_kartesische_Produkt()
    {
        Assert.Equal(["1x", "1y", "2x", "2y", "3x", "3y"], Auswertung.Kombinationen([1, 2, 3], ['x', 'y']));
        Assert.Empty(Auswertung.Kombinationen([1, 2], []));
    }

    [Fact]
    public void UeberDemSchnitt_liefert_die_Besserverdiener()
    {
        // Durchschnitt 4400
        Assert.Equal(["Clara", "Emil"], Auswertung.UeberDemSchnitt(Team()).Select(m => m.Name));
        Assert.Empty(Auswertung.UeberDemSchnitt([]));
        Assert.Empty(Auswertung.UeberDemSchnitt([new("Solo", 1m)]));
    }

    [Fact]
    public void UeberDemSchnitt_zaehlt_die_Quelle_hoechstens_zweimal()
    {
        var quelle = new ZaehlendeQuelle<Mitarbeiter>(Team());

        Auswertung.UeberDemSchnitt(quelle);

        Assert.InRange(quelle.Aufzaehlungen, 1, 2);
    }

    [Fact]
    public void Spitzenverdiener_nutzt_eine_Unterabfrage()
    {
        Assert.Equal(["Emil"], Auswertung.Spitzenverdiener(Team()));

        var gleich = new List<Mitarbeiter> { new("A", 10m), new("B", 20m), new("C", 20m) };
        Assert.Equal(["B", "C"], Auswertung.Spitzenverdiener(gleich));
        Assert.Empty(Auswertung.Spitzenverdiener([]));
    }

    [Fact]
    public void OfType_filtert_nach_Laufzeittyp()
    {
        object[] gemischt = ["a", 1, 2.5, "b", 3L, null!, 4, 'c'];

        Assert.Equal(["a", "b"], Auswertung.NurTexte(gemischt));
        Assert.Equal([1, 4], Auswertung.NurGanzzahlen(gemischt));   // 3L ist ein long, kein int
    }

    [Fact]
    public void TakeEvery_nimmt_das_erste_und_jedes_nte_Element()
    {
        Assert.Equal([1, 3, 5], new[] { 1, 2, 3, 4, 5, 6 }.TakeEvery(2));
        Assert.Equal([1, 4], new[] { 1, 2, 3, 4, 5, 6 }.TakeEvery(3));
        Assert.Equal([1, 2, 3], new[] { 1, 2, 3 }.TakeEvery(1));
        Assert.Empty(Array.Empty<int>().TakeEvery(2));
    }

    [Fact]
    public void TakeEvery_funktioniert_auf_unendlichen_Quellen()
    {
        Assert.Equal([0, 3, 6, 9, 12], Zahlen().TakeEvery(3).Take(5));
    }

    [Fact]
    public void TakeEvery_ist_zurueckgestellt()
    {
        var quelle = new ZaehlendeQuelle<int>([1, 2, 3, 4]);

        var abfrage = quelle.TakeEvery(2);
        Assert.Equal(0, quelle.Aufzaehlungen);

        Assert.Equal([1, 3], abfrage.ToList());
        Assert.Equal(1, quelle.Aufzaehlungen);
    }

    [Fact]
    public void TakeEvery_mit_ungueltigem_n_wirft()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new[] { 1, 2 }.TakeEvery(0).ToList());
        Assert.Throws<ArgumentOutOfRangeException>(() => new[] { 1, 2 }.TakeEvery(-1).ToList());
    }

    [Fact]
    public void WhereNot_dreht_die_Bedingung_um()
    {
        Assert.Equal([1, 3, 5], new[] { 1, 2, 3, 4, 5 }.WhereNot(x => x % 2 == 0));
        Assert.Equal(["a", "b"], new[] { "a", "", "b" }.WhereNot(string.IsNullOrEmpty));
        Assert.Equal([5, 6], Zahlen().Skip(5).WhereNot(x => x > 6).Take(2));
    }

    [Fact]
    public void Paarweise_liefert_aufeinanderfolgende_Paare()
    {
        Assert.Equal([(1, 2), (2, 3), (3, 4)], new[] { 1, 2, 3, 4 }.Paarweise());
        Assert.Equal([("a", "b")], new[] { "a", "b" }.Paarweise());
        Assert.Empty(new[] { 1 }.Paarweise());
        Assert.Empty(Array.Empty<int>().Paarweise());
        Assert.Equal([(0, 1), (1, 2)], Zahlen().Paarweise().Take(2));
    }
}
