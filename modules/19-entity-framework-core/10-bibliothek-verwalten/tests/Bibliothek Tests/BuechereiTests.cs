using Bibliothek;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class BuechereiTests : IDisposable
{
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly DbContextOptions<BuchContext> _optionen;
    private readonly Buecherei _buecherei;

    public BuechereiTests()
    {
        _verbindung.Open();
        _optionen = new DbContextOptionsBuilder<BuchContext>().UseSqlite(_verbindung).Options;
        using (var kontext = new BuchContext(_optionen))
        {
            kontext.Database.EnsureCreated();
            kontext.Buecher.AddRange(
                new Buch { Titel = "Programmieren mit C#", Autor = "Baltes-Götz", Jahr = 2024 },
                new Buch { Titel = "Datenbanken für Einsteiger", Autor = "Meier", Jahr = 2019 },
                new Buch { Titel = "C# Rezepte", Autor = "Schulz", Jahr = 2022, Ausgeliehen = true });
            kontext.SaveChanges();
        }
        _buecherei = new Buecherei(_optionen);
    }

    public void Dispose() => _verbindung.Dispose();

    private List<Buch> Alle()
    {
        using var kontext = new BuchContext(_optionen);
        return kontext.Buecher.AsNoTracking().OrderBy(b => b.Id).ToList();
    }

    [Fact]
    public void Aufnehmen_speichert_das_Buch_und_liefert_die_Id()
    {
        int id = _buecherei.Aufnehmen("Neues Buch", "Autorin", 2025);
        Assert.True(id > 3);
        var buch = Alle().Single(b => b.Id == id);
        Assert.Equal(("Neues Buch", "Autorin", 2025, false), (buch.Titel, buch.Autor, buch.Jahr, buch.Ausgeliehen));
    }

    [Fact]
    public void Aufnehmen_legt_das_Schema_bei_Bedarf_an()
    {
        using var leer = new SqliteConnection("Data Source=:memory:");
        leer.Open();
        var optionen = new DbContextOptionsBuilder<BuchContext>().UseSqlite(leer).Options;
        Assert.Equal(1, new Buecherei(optionen).Aufnehmen("Erstes", "A", 2000));
    }

    [Fact]
    public void Ausleihen_markiert_das_Buch_als_ausgeliehen()
    {
        Assert.True(_buecherei.Ausleihen(1));
        Assert.True(Alle().Single(b => b.Id == 1).Ausgeliehen);
        Assert.False(Alle().Single(b => b.Id == 2).Ausgeliehen);
    }

    [Fact]
    public void Ausleihen_scheitert_bei_schon_ausgeliehenem_oder_unbekanntem_Buch()
    {
        Assert.False(_buecherei.Ausleihen(3));
        Assert.False(_buecherei.Ausleihen(99));
        Assert.True(Alle().Single(b => b.Id == 3).Ausgeliehen);
    }

    [Fact]
    public void Entfernen_loescht_genau_das_Buch()
    {
        Assert.True(_buecherei.Entfernen(2));
        Assert.False(_buecherei.Entfernen(2));
        Assert.Equal(new[] { 1, 3 }, Alle().Select(b => b.Id));
    }

    [Fact]
    public void Suche_findet_Teiltext_und_sortiert_nach_Titel()
    {
        Assert.Equal(new[] { "C# Rezepte", "Programmieren mit C#" }, _buecherei.Suche("C#").Select(b => b.Titel));
        Assert.Empty(_buecherei.Suche("Python"));
    }

    [Fact]
    public void Suche_mit_leerem_Text_liefert_alle_sortiert()
    {
        Assert.Equal(new[] { "C# Rezepte", "Datenbanken für Einsteiger", "Programmieren mit C#" },
            _buecherei.Suche("").Select(b => b.Titel));
    }
}
