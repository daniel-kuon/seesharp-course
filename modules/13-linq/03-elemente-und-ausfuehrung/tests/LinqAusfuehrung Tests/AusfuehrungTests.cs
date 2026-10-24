public class AusfuehrungTests
{
    [Fact]
    public void Abfrage_laeuft_erst_bei_der_Aufzaehlung()
    {
        var log = new List<string>();

        IEnumerable<int> abfrage = Ausfuehrung.GeradeZahlen(log);
        Assert.Empty(log);   // gebaut, aber nicht ausgeführt

        var ergebnis = abfrage.ToList();

        Assert.Equal([2, 4], ergebnis);
        Assert.Equal(["liefere 1", "liefere 2", "liefere 3", "liefere 4"], log);
    }

    [Fact]
    public void Jede_Aufzaehlung_fuehrt_die_Abfrage_neu_aus()
    {
        var log = new List<string>();
        var abfrage = Ausfuehrung.GeradeZahlen(log);

        abfrage.ToList();
        abfrage.ToList();

        Assert.Equal(8, log.Count);
    }

    [Fact]
    public void ZweimalNutzen_zaehlt_die_Quelle_nur_einmal()
    {
        var log = new List<string>();

        var (summe, anzahl) = Ausfuehrung.ZweimalNutzen(log);

        Assert.Equal(9, summe);    // 2 + 3 + 4
        Assert.Equal(3, anzahl);
        Assert.Equal(["liefere 1", "liefere 2", "liefere 3", "liefere 4"], log);
    }

    [Fact]
    public void Abfrage_sieht_spaetere_Aenderungen_der_Quelle()
    {
        var quelle = new List<int> { 5, 20 };
        var abfrage = Ausfuehrung.GrosseWerte(quelle);

        quelle.Add(50);   // nach dem Bauen der Abfrage, vor der Aufzählung

        Assert.Equal([20, 50], abfrage);
    }

    [Fact]
    public void Schnappschuss_sieht_spaetere_Aenderungen_nicht()
    {
        var quelle = new List<int> { 5, 20 };
        var schnappschuss = Ausfuehrung.GrosseWerteJetzt(quelle);

        quelle.Add(50);

        Assert.Equal([20], schnappschuss);
    }
}
