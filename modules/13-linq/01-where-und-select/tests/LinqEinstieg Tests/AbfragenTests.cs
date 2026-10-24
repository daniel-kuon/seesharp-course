public class AbfragenTests
{
    private static List<Produkt> Daten() =>
    [
        new("Stift", "Büro", 1.20m, 100),
        new("Heft", "Büro", 2.50m, 0),
        new("Lampe", "Möbel", 12.50m, 5),
        new("Stuhl", "Möbel", 89.90m, 2),
        new("Tisch", "Möbel", 199m, 0),
        new("Kaffee", "Küche", 7.99m, 40),
    ];

    [Fact]
    public void Guenstige_filtert_nach_Preis()
    {
        Assert.Equal(["Stift", "Heft", "Kaffee"], Abfragen.Guenstige(Daten(), 10m).Select(p => p.Name));
        Assert.Equal(["Stift"], Abfragen.Guenstige(Daten(), 1.20m).Select(p => p.Name));   // <= : die Grenze zählt mit
        Assert.Empty(Abfragen.Guenstige(Daten(), 1m));
    }

    [Fact]
    public void Namen_liefert_alle_Namen_in_Reihenfolge()
    {
        Assert.Equal(["Stift", "Heft", "Lampe", "Stuhl", "Tisch", "Kaffee"], Abfragen.Namen(Daten()));
        Assert.Empty(Abfragen.Namen([]));
    }

    [Fact]
    public void Etiketten_formatieren_den_Preis()
    {
        var etiketten = Abfragen.Etiketten(Daten());

        Assert.Equal(6, etiketten.Count);
        Assert.Equal(("Stift", "1,20 EUR"), etiketten[0]);
        Assert.Equal(("Lampe", "12,50 EUR"), etiketten[2]);
        Assert.Equal(("Tisch", "199,00 EUR"), etiketten[4]);
    }

    [Fact]
    public void VorraetigeGuenstige_verkettet_Where_und_Select()
    {
        Assert.Equal(["Stift", "Kaffee"], Abfragen.VorraetigeGuenstige(Daten(), 10m));
        Assert.Equal(["Stift", "Lampe", "Kaffee"], Abfragen.VorraetigeGuenstige(Daten(), 50m));
    }

    [Fact]
    public void Preisliste_ist_ein_Woerterbuch()
    {
        var preise = Abfragen.Preisliste(Daten());

        Assert.Equal(6, preise.Count);
        Assert.Equal(89.90m, preise["Stuhl"]);
        Assert.Equal(7.99m, preise["Kaffee"]);
    }

    [Fact]
    public void Schnappschuss_ist_ein_Array_und_entkoppelt_von_der_Quelle()
    {
        var quelle = Daten();

        Produkt[] kopie = Abfragen.Schnappschuss(quelle);
        quelle.Add(new Produkt("Neu", "Büro", 1m, 1));

        Assert.Equal(6, kopie.Length);
        Assert.Equal(7, quelle.Count);
        Assert.Equal("Stift", kopie[0].Name);
    }

    [Fact]
    public void Die_Quellliste_bleibt_unveraendert()
    {
        var quelle = Daten();

        Abfragen.Guenstige(quelle, 10m).ToList();
        Abfragen.Etiketten(quelle);
        Abfragen.VorraetigeGuenstige(quelle, 10m).ToList();
        Abfragen.Preisliste(quelle);

        Assert.Equal(Daten(), quelle);
    }
}
