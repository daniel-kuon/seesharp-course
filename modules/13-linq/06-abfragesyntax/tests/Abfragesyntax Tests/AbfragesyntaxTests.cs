public class AbfragesyntaxTests
{
    private static List<Produkt> Produkte() =>
    [
        new("Stift", "Büro", 1.20m, 100),
        new("Heft", "Büro", 2.50m, 0),
        new("Lampe", "Möbel", 12.50m, 5),
        new("Stuhl", "Möbel", 89.90m, 2),
        new("Tisch", "Möbel", 199m, 0),
        new("Kaffee", "Küche", 7.99m, 40),
        new("Tee", "Küche", 5.49m, 12),
        new("Uhr", "Büro", 19.99m, 3),
        new("Rechen", "Garten", 15m, 4),
    ];

    private static List<Kunde> Kunden() => [new(1, "Anna"), new(2, "Bert"), new(3, "Clara")];

    private static List<Bestellung> Bestellungen() =>
    [
        new(10, 1, 50m), new(11, 3, 100m), new(12, 1, 25.5m), new(13, 99, 5m),
    ];

    // ---- Methodensyntax (vorgegeben, bestehende Tests) ----

    [Fact]
    public void Methodensyntax_Teuer()
    {
        Assert.Equal(["Lampe", "Rechen", "Stuhl", "Tisch", "Uhr"], Methodensyntax.Teuer(Produkte(), 10m));
    }

    [Fact]
    public void Methodensyntax_MitMehrwertsteuer()
    {
        Assert.Equal(
            [("Stuhl", 106.981m), ("Tisch", 236.81m), ("Uhr", 23.7881m)],
            Methodensyntax.MitMehrwertsteuer(Produkte()));
    }

    [Fact]
    public void Methodensyntax_GroessteKategorien()
    {
        Assert.Equal(
            [("Büro", 3), ("Möbel", 3), ("Küche", 2)],
            Methodensyntax.GroessteKategorien(Produkte()));
    }

    [Fact]
    public void Methodensyntax_Kunden()
    {
        Assert.Equal([("Anna", 50m), ("Anna", 25.5m), ("Clara", 100m)],
            Methodensyntax.KundenMitBestellung(Kunden(), Bestellungen()));
        Assert.Equal([("Anna", 75.5m), ("Bert", 0m), ("Clara", 100m)],
            Methodensyntax.KundenSummen(Kunden(), Bestellungen()));
    }

    // ---- Abfragesyntax (deine Aufgabe) ----

    [Fact]
    public void TeuerQ_wie_Methodensyntax()
    {
        Assert.Equal(Methodensyntax.Teuer(Produkte(), 10m), Abfragesyntax.TeuerQ(Produkte(), 10m));
        Assert.Equal(["Lampe", "Rechen", "Stuhl", "Tisch", "Uhr"], Abfragesyntax.TeuerQ(Produkte(), 10m));
        Assert.Empty(Abfragesyntax.TeuerQ(Produkte(), 1000m));
    }

    [Fact]
    public void MitMehrwertsteuerQ_wie_Methodensyntax()
    {
        Assert.Equal(Methodensyntax.MitMehrwertsteuer(Produkte()), Abfragesyntax.MitMehrwertsteuerQ(Produkte()));
        Assert.Equal(3, Abfragesyntax.MitMehrwertsteuerQ(Produkte()).Count);
    }

    [Fact]
    public void GroessteKategorienQ_wie_Methodensyntax()
    {
        Assert.Equal(Methodensyntax.GroessteKategorien(Produkte()), Abfragesyntax.GroessteKategorienQ(Produkte()));
        Assert.Equal(("Küche", 2), Abfragesyntax.GroessteKategorienQ(Produkte())[2]);
        Assert.DoesNotContain(Abfragesyntax.GroessteKategorienQ(Produkte()), k => k.Kategorie == "Garten");
    }

    [Fact]
    public void KundenMitBestellungQ_wie_Methodensyntax()
    {
        Assert.Equal(
            Methodensyntax.KundenMitBestellung(Kunden(), Bestellungen()),
            Abfragesyntax.KundenMitBestellungQ(Kunden(), Bestellungen()));
    }

    [Fact]
    public void KundenSummenQ_enthaelt_auch_Kunden_ohne_Bestellung()
    {
        var q = Abfragesyntax.KundenSummenQ(Kunden(), Bestellungen());

        Assert.Equal(Methodensyntax.KundenSummen(Kunden(), Bestellungen()), q);
        Assert.Equal(("Bert", 0m), q[1]);
    }
}
