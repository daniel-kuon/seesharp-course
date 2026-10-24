using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Umsatzstatistik;

public class UmsatzTests : IDisposable
{
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly DbContextOptions<VerkaufContext> _optionen;
    private readonly Umsatz _umsatz;

    public UmsatzTests()
    {
        _verbindung.Open();
        _optionen = new DbContextOptionsBuilder<VerkaufContext>().UseSqlite(_verbindung).Options;
        using (var kontext = new VerkaufContext(_optionen))
        {
            kontext.Database.EnsureCreated();
            var tag = new DateTime(2025, 3, 1);
            kontext.Verkaeufe.AddRange(
                new Verkauf { Produkt = "Hammer", Menge = 2, Preis = 10.0, Datum = tag },
                new Verkauf { Produkt = "Zange", Menge = 1, Preis = 20.0, Datum = tag },
                new Verkauf { Produkt = "Spaten", Menge = 5, Preis = 12.5, Datum = tag },
                new Verkauf { Produkt = "Hammer", Menge = 3, Preis = 10.0, Datum = tag.AddDays(1) },
                new Verkauf { Produkt = "Harke", Menge = 1, Preis = 7.0, Datum = tag.AddDays(2) });
            kontext.SaveChanges();
        }
        _umsatz = new Umsatz(_optionen);
    }

    public void Dispose() => _verbindung.Dispose();

    [Fact]
    public void GesamtUmsatz_summiert_Menge_mal_Preis()
    {
        Assert.Equal(139.5, _umsatz.GesamtUmsatz(), 6); // 20 + 20 + 62.5 + 30 + 7
    }

    [Fact]
    public void GesamtUmsatz_ohne_Verkaeufe_ist_null()
    {
        using (var kontext = new VerkaufContext(_optionen))
            kontext.Verkaeufe.ExecuteDelete();
        Assert.Equal(0.0, _umsatz.GesamtUmsatz());
    }

    [Fact]
    public void ProProdukt_gruppiert_summiert_und_sortiert_absteigend()
    {
        var ergebnis = _umsatz.ProProdukt();
        Assert.Equal(new[] { "Spaten", "Hammer", "Zange", "Harke" }, ergebnis.Select(p => p.Produkt));
        Assert.Equal(new[] { 62.5, 50.0, 20.0, 7.0 }, ergebnis.Select(p => p.Umsatz));
    }

    [Fact]
    public void ProProduktAbfrage_wird_vom_Server_berechnet()
    {
        using var kontext = new VerkaufContext(_optionen);
        string sql = Umsatz.ProProduktAbfrage(kontext).ToQueryString();
        Assert.Contains("SUM", sql);
        Assert.Contains("GROUP BY", sql);
        Assert.Contains("ORDER BY", sql);
    }

    [Fact]
    public void TopProdukte_liefert_die_umsatzstaerksten()
    {
        var top = _umsatz.TopProdukte(2);
        Assert.Equal(new[] { new ProduktUmsatz("Spaten", 62.5), new ProduktUmsatz("Hammer", 50.0) }, top);
        Assert.Empty(_umsatz.TopProdukte(0));
        Assert.Equal(4, _umsatz.TopProdukte(100).Count);
    }
}
