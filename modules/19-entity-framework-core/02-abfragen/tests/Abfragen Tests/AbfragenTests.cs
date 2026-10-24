using Abfragen;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class AbfragenTests : IDisposable
{
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly DbContextOptions<BeitragContext> _optionen;
    private readonly BlogAbfragen _abfragen;

    public AbfragenTests()
    {
        _verbindung.Open();
        _optionen = new DbContextOptionsBuilder<BeitragContext>().UseSqlite(_verbindung).Options;
        using (var kontext = new BeitragContext(_optionen))
        {
            kontext.Database.EnsureCreated();
            // 20 Beiträge: jeder vierte heißt "LINQ Teil n", die übrigen "Erste Schritte n";
            // der Inhalt von Beitrag n hat n Zeichen; das Datum steigt mit der Id.
            for (int i = 1; i <= 20; i++)
            {
                kontext.Beitraege.Add(new Beitrag
                {
                    Titel = i % 4 == 0 ? $"LINQ Teil {i}" : $"Erste Schritte {i}",
                    Inhalt = new string('x', i),
                    Datum = new DateTime(2025, 1, 1).AddDays(i)
                });
            }
            kontext.SaveChanges();
        }
        _abfragen = new BlogAbfragen(_optionen);
    }

    public void Dispose() => _verbindung.Dispose();

    [Fact]
    public void MitTitel_filtert_mit_Where_und_Contains()
    {
        Assert.Equal(new[] { 4, 8, 12, 16, 20 }, _abfragen.MitTitel("LINQ").Select(b => b.Id));
        Assert.Empty(_abfragen.MitTitel("gibt es nicht"));
    }

    [Fact]
    public void Neueste_liefert_die_n_neuesten_Beitraege_absteigend()
    {
        Assert.Equal(new[] { 20, 19, 18 }, _abfragen.Neueste(3).Select(b => b.Id));
        Assert.Equal(20, _abfragen.Neueste(100).Count);
        Assert.Empty(_abfragen.Neueste(0));
    }

    [Fact]
    public void Finde_liefert_den_Beitrag_oder_null()
    {
        Assert.Equal("Erste Schritte 7", _abfragen.Finde(7)!.Titel);
        Assert.Null(_abfragen.Finde(99));
    }

    [Fact]
    public void ErsterMit_liefert_den_ersten_Treffer_oder_null()
    {
        Assert.Equal(4, _abfragen.ErsterMit("LINQ")!.Id);
        Assert.Equal(1, _abfragen.ErsterMit("Erste")!.Id);
        Assert.Null(_abfragen.ErsterMit("Zzz"));
    }

    [Fact]
    public void Titelliste_liefert_alle_Titel_nach_Id()
    {
        var titel = _abfragen.Titelliste();
        Assert.Equal(20, titel.Count);
        Assert.Equal("Erste Schritte 1", titel[0]);
        Assert.Equal("LINQ Teil 20", titel[19]);
    }

    [Fact]
    public void TitellisteAbfrage_waehlt_nur_die_Spalte_Titel_aus()
    {
        using var kontext = new BeitragContext(_optionen);
        string sql = BlogAbfragen.TitellisteAbfrage(kontext).ToQueryString();
        Assert.Contains("Titel", sql);
        Assert.DoesNotContain("Inhalt", sql);
        Assert.DoesNotContain("Datum", sql);
    }

    [Fact]
    public void Statistik_berechnet_Anzahl_und_Durchschnitt()
    {
        var (anzahl, schnitt) = _abfragen.Statistik();
        Assert.Equal(20, anzahl);
        Assert.Equal(10.5, schnitt, 6); // (1 + 2 + ... + 20) / 20
    }

    [Fact]
    public void StatistikAbfrage_rechnet_auf_dem_Server_mit_COUNT_und_AVG()
    {
        using var kontext = new BeitragContext(_optionen);
        string sql = BlogAbfragen.StatistikAbfrage(kontext).ToQueryString();
        Assert.Contains("COUNT", sql);
        Assert.Contains("AVG", sql);
    }

    [Fact]
    public void Statistik_einer_leeren_Tabelle_ist_null_null()
    {
        using (var kontext = new BeitragContext(_optionen))
            kontext.Beitraege.ExecuteDelete();
        Assert.Equal((0, 0.0), _abfragen.Statistik());
        Assert.Equal((0, 0.0), _abfragen.ClientAuswertung());
    }

    [Fact]
    public void ClientAuswertung_liefert_dasselbe_Ergebnis_wie_die_Serverabfrage()
    {
        var (anzahl, schnitt) = _abfragen.ClientAuswertung();
        Assert.Equal(20, anzahl);
        Assert.Equal(10.5, schnitt, 6);
        Assert.Equal(_abfragen.Statistik(), (anzahl, schnitt));
    }
}
