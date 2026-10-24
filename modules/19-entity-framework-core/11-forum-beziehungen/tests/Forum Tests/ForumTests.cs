using Forum;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class ForumTests : IDisposable
{
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly DbContextOptions<ForumContext> _optionen;
    private readonly ForumDienst _forum;
    private readonly int _csharp, _datenbank, _leer;

    public ForumTests()
    {
        _verbindung.Open();
        Roh("PRAGMA foreign_keys = ON");
        _optionen = new DbContextOptionsBuilder<ForumContext>().UseSqlite(_verbindung).Options;
        _forum = new ForumDienst(_optionen);
        _csharp = _forum.ThemaAnlegen("C#");
        _datenbank = _forum.ThemaAnlegen("Datenbanken");
        _leer = _forum.ThemaAnlegen("Leer");
        _forum.Antworten(_csharp, "Klasse");
        _forum.Antworten(_csharp, "Struktur");
        _forum.Antworten(_csharp, "Schnittstelle");
        _forum.Antworten(_datenbank, "SQLite");
    }

    public void Dispose() => _verbindung.Dispose();

    private long Roh(string sql)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = sql;
        return Convert.ToInt64(befehl.ExecuteScalar() ?? 0L);
    }

    [Fact]
    public void ThemaMitAntworten_laedt_die_Antworten_mit_Include()
    {
        Thema? thema = _forum.ThemaMitAntworten(_csharp); // Kontext ist schon freigegeben
        Assert.NotNull(thema);
        Assert.Equal("C#", thema.Titel);
        Assert.Equal(new[] { "Klasse", "Schnittstelle", "Struktur" }, thema.Antworten.Select(a => a.Text).Order());
    }

    [Fact]
    public void ThemaMitAntworten_liefert_null_oder_leere_Liste()
    {
        Assert.Null(_forum.ThemaMitAntworten(999));
        Assert.Empty(_forum.ThemaMitAntworten(_leer)!.Antworten);
    }

    [Fact]
    public void LoescheThema_entfernt_auch_die_Antworten()
    {
        _forum.LoescheThema(_csharp);
        Assert.Equal(0, Roh($"SELECT COUNT(*) FROM Antworten WHERE ThemaId = {_csharp}"));
        Assert.Equal(1, Roh("SELECT COUNT(*) FROM Antworten")); // die Antwort des anderen Themas bleibt
        Assert.Equal(2, Roh("SELECT COUNT(*) FROM Themen"));
    }

    [Fact]
    public void LoescheThema_ohne_Antworten_und_unbekanntes_Thema()
    {
        _forum.LoescheThema(_leer);
        _forum.LoescheThema(999);
        Assert.Equal(2, Roh("SELECT COUNT(*) FROM Themen"));
        Assert.Equal(4, Roh("SELECT COUNT(*) FROM Antworten"));
    }

    [Fact]
    public void AntwortenProThema_zaehlt_je_Titel_auch_Nullen()
    {
        var zaehlung = _forum.AntwortenProThema();
        Assert.Equal(3, zaehlung["C#"]);
        Assert.Equal(1, zaehlung["Datenbanken"]);
        Assert.Equal(0, zaehlung["Leer"]);
        Assert.Equal(3, zaehlung.Count);
    }

    [Fact]
    public void Das_Modell_loescht_Antworten_per_Kaskade()
    {
        using var kontext = new ForumContext(_optionen);
        var fk = kontext.Model.FindEntityType(typeof(Antwort))!.GetForeignKeys().Single();
        Assert.Equal(DeleteBehavior.Cascade, fk.DeleteBehavior);
        Assert.Equal(nameof(Antwort.ThemaId), fk.Properties.Single().Name);
    }
}
