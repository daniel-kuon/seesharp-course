public class VerknuepfungenTests
{
    private static List<Kunde> Kunden() => [new(1, "Anna"), new(2, "Bert"), new(3, "Clara")];

    private static List<Bestellung> Bestellungen() =>
    [
        new(10, 1, 50m),
        new(11, 3, 100m),
        new(12, 1, 25.5m),
        new(13, 99, 5m),   // Kunde 99 gibt es nicht
    ];

    [Fact]
    public void KundenMitBestellung_ist_ein_innerer_Join()
    {
        var ergebnis = Verknuepfungen.KundenMitBestellung(Kunden(), Bestellungen());

        // Reihenfolge der Kunden; Bert (ohne Bestellung) und Bestellung 13 (ohne Kunde) fehlen
        Assert.Equal([("Anna", 50m), ("Anna", 25.5m), ("Clara", 100m)], ergebnis);
    }

    [Fact]
    public void BestellungenProKunde_enthaelt_auch_Kunden_ohne_Bestellung()
    {
        var ergebnis = Verknuepfungen.BestellungenProKunde(Kunden(), Bestellungen());

        Assert.Equal([("Anna", 2, 75.5m), ("Bert", 0, 0m), ("Clara", 1, 100m)], ergebnis);
    }

    [Fact]
    public void BestellungenProKunde_ohne_Bestellungen()
    {
        var ergebnis = Verknuepfungen.BestellungenProKunde(Kunden(), []);

        Assert.Equal([("Anna", 0, 0m), ("Bert", 0, 0m), ("Clara", 0, 0m)], ergebnis);
    }

    [Fact]
    public void TopKunde_hat_die_groesste_Summe()
    {
        Assert.Equal(new Kunde(3, "Clara"), Verknuepfungen.TopKunde(Kunden(), Bestellungen()));
    }

    [Fact]
    public void TopKunde_bei_Gleichstand_der_erste_Kunde()
    {
        Bestellung[] gleich = [new(1, 2, 10m), new(2, 1, 10m)];

        Assert.Equal(new Kunde(1, "Anna"), Verknuepfungen.TopKunde(Kunden(), gleich));
    }

    [Fact]
    public void TopKunde_ohne_Kunden_ist_null()
    {
        Assert.Null(Verknuepfungen.TopKunde([], Bestellungen()));
    }

    [Fact]
    public void Paare_endet_mit_der_kuerzeren_Folge()
    {
        Assert.Equal(["a:1", "b:2"], Verknuepfungen.Paare(["a", "b", "c"], [1, 2]));
        Assert.Equal(["a:1", "b:2"], Verknuepfungen.Paare(["a", "b"], [1, 2, 3, 4]));
        Assert.Empty(Verknuepfungen.Paare([], [1, 2]));
    }
}
