public class SortiererTests
{
    private static List<Person> Beispiel() =>
    [
        new("Carla", 30),
        new("Anna", 17),
        new("Bert", 45),
        new("Anna", 12),
        new("Dora", 30),
        new("Emil", 18),
    ];

    [Fact]
    public void NachAlter_sortiert_aufsteigend()
    {
        var liste = Beispiel();

        Sortierer.NachAlter(liste);

        // gleich alte Personen (Carla und Dora, 30) stehen in unbestimmter Reihenfolge: nur die Altersfolge ist festgelegt
        Assert.Equal([12, 17, 18, 30, 30, 45], liste.Select(p => p.Alter));
        Assert.Equal(6, liste.Count);
    }

    [Fact]
    public void NachNameDannAlter_bricht_Gleichstand_nach_Alter()
    {
        var liste = Beispiel();

        Sortierer.NachNameDannAlter(liste);

        Assert.Equal(
            [new Person("Anna", 12), new Person("Anna", 17), new Person("Bert", 45),
             new Person("Carla", 30), new Person("Dora", 30), new Person("Emil", 18)],
            liste);
    }

    [Fact]
    public void AelterAls_ist_strikt_groesser()
    {
        var liste = Beispiel();

        var aelter = Sortierer.AelterAls(liste, 30);

        Assert.Equal([new Person("Bert", 45)], aelter);
        Assert.Equal(6, liste.Count);   // Quelle unverändert
        Assert.Equal(5, Sortierer.AelterAls(liste, 12).Count);
    }

    [Fact]
    public void EntferneMinderjaehrige_veraendert_die_Liste()
    {
        var liste = Beispiel();

        int entfernt = Sortierer.EntferneMinderjaehrige(liste);

        Assert.Equal(2, entfernt);   // 17 und 12; 18 ist volljährig
        Assert.Equal(4, liste.Count);
        Assert.DoesNotContain(liste, p => p.Alter < 18);
    }

    [Fact]
    public void Juengste_nimmt_bei_Gleichstand_die_erste()
    {
        var liste = new List<Person> { new("A", 20), new("B", 15), new("C", 15), new("D", 40) };

        Assert.Equal(new Person("B", 15), Sortierer.Juengste(liste));
        Assert.Equal(4, liste.Count);
    }

    [Fact]
    public void Juengste_einer_leeren_Liste_ist_null()
    {
        Assert.Null(Sortierer.Juengste([]));
    }

    [Fact]
    public void Juengste_bei_einer_Person()
    {
        Assert.Equal(new Person("Solo", 99), Sortierer.Juengste([new("Solo", 99)]));
    }
}
