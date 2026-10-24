using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Produkte;

public class VerwaltungTests : IDisposable
{
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly DbContextOptions<ProduktContext> _optionen;
    private readonly Verwaltung _verwaltung;

    public VerwaltungTests()
    {
        _verbindung.Open();
        _optionen = new DbContextOptionsBuilder<ProduktContext>().UseSqlite(_verbindung).Options;
        using (var kontext = new ProduktContext(_optionen))
        {
            kontext.Database.EnsureCreated();
            kontext.Produkte.AddRange(
                new Produkt { Name = "Hammer", Preis = 10m, Angelegt = new DateTime(2024, 1, 1) },
                new Produkt { Name = "Zange", Preis = 20m, Angelegt = new DateTime(2024, 6, 1) },
                new Produkt { Name = "Spaten", Preis = 30m, Angelegt = new DateTime(2025, 6, 1) });
            kontext.SaveChanges();
        }
        _verwaltung = new Verwaltung(_optionen);
    }

    public void Dispose() => _verbindung.Dispose();

    private List<Produkt> Alle()
    {
        using var kontext = new ProduktContext(_optionen);
        return kontext.Produkte.AsNoTracking().OrderBy(p => p.Id).ToList();
    }

    [Fact]
    public void Umbenennen_aendert_die_verfolgte_Entitaet_und_speichert_eine_Zeile()
    {
        Assert.Equal(1, _verwaltung.Umbenennen(2, "Kneifzange"));
        Assert.Equal(new[] { "Hammer", "Kneifzange", "Spaten" }, Alle().Select(p => p.Name));
    }

    [Fact]
    public void Umbenennen_eines_unbekannten_Produkts_schreibt_nichts()
    {
        Assert.Equal(0, _verwaltung.Umbenennen(99, "x"));
        Assert.Equal(new[] { "Hammer", "Zange", "Spaten" }, Alle().Select(p => p.Name));
    }

    [Fact]
    public void Entfernen_loescht_das_Produkt_und_meldet_ob_es_eines_gab()
    {
        Assert.True(_verwaltung.Entfernen(1));
        Assert.False(_verwaltung.Entfernen(1));
        Assert.Equal(new[] { "Zange", "Spaten" }, Alle().Select(p => p.Name));
    }

    [Theory]
    [InlineData(Aktion.Hinzufuegen, EntityState.Added)]
    [InlineData(Aktion.Anhaengen, EntityState.Unchanged)]
    [InlineData(Aktion.Aendern, EntityState.Modified)]
    [InlineData(Aktion.Entfernen, EntityState.Deleted)]
    [InlineData(Aktion.OhneNachverfolgung, EntityState.Detached)]
    public void ZustandNach_meldet_den_EntityState(Aktion aktion, EntityState erwartet)
    {
        Assert.Equal(erwartet, _verwaltung.ZustandNach(aktion, 1));
    }

    [Fact]
    public void ZustandNach_speichert_nichts()
    {
        _verwaltung.ZustandNach(Aktion.Hinzufuegen, 1);
        _verwaltung.ZustandNach(Aktion.Entfernen, 1);
        _verwaltung.ZustandNach(Aktion.Aendern, 1);
        Assert.Equal(new[] { "Hammer", "Zange", "Spaten" }, Alle().Select(p => p.Name));
    }

    [Fact]
    public void Ohne_Nachverfolgung_speichert_SaveChanges_nichts()
    {
        Assert.Equal(0, _verwaltung.UmbenennenOhneNachverfolgung(1, "Fäustel"));
        Assert.Equal("Hammer", Alle()[0].Name);
    }

    [Fact]
    public void ErhoehePreise_aendert_alle_Zeilen_ohne_Entitaeten_zu_laden()
    {
        using var kontext = new ProduktContext(_optionen);
        Assert.Equal(3, Verwaltung.ErhoehePreise(kontext, 1.5m));
        Assert.Empty(kontext.ChangeTracker.Entries()); // nichts wurde geladen oder verfolgt
        Assert.Equal(new[] { 15m, 30m, 45m }, Alle().Select(p => p.Preis));
    }

    [Fact]
    public void LoescheAlte_loescht_per_ExecuteDelete_ohne_zu_laden()
    {
        using var kontext = new ProduktContext(_optionen);
        Assert.Equal(2, Verwaltung.LoescheAlte(kontext, new DateTime(2025, 1, 1)));
        Assert.Empty(kontext.ChangeTracker.Entries());
        Assert.Equal(new[] { "Spaten" }, Alle().Select(p => p.Name));
        Assert.Equal(0, Verwaltung.LoescheAlte(kontext, new DateTime(2025, 1, 1)));
    }
}
