using Beziehungen;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class BeziehungenTests : IDisposable
{
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly DbContextOptions<BlogContext> _optionen;
    private readonly BlogDienst _dienst;

    public BeziehungenTests()
    {
        _verbindung.Open();
        Sql("PRAGMA foreign_keys = ON");
        _optionen = new DbContextOptionsBuilder<BlogContext>().UseSqlite(_verbindung).Options;
        using (var kontext = new BlogContext(_optionen))
            kontext.Database.EnsureCreated();
        _dienst = new BlogDienst(_optionen);
    }

    public void Dispose() => _verbindung.Dispose();

    private long Sql(string sql)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = sql;
        return Convert.ToInt64(befehl.ExecuteScalar() ?? 0L);
    }

    [Fact]
    public void BlogMitBeitraegen_laedt_die_Beitraege_mit_Include()
    {
        int blog = _dienst.BlogAnlegen("Technik");
        _dienst.BeitragAnlegen(blog, "Eins");
        _dienst.BeitragAnlegen(blog, "Zwei");
        _dienst.BeitragAnlegen(blog, "Drei");

        Blog? geladen = _dienst.BlogMitBeitraegen(blog); // der Kontext ist schon freigegeben
        Assert.NotNull(geladen);
        Assert.Equal("Technik", geladen.Name);
        Assert.Equal(3, geladen.Beitraege.Count);
        Assert.Equal(new[] { "Drei", "Eins", "Zwei" }, geladen.Beitraege.Select(b => b.Titel).Order());
        Assert.All(geladen.Beitraege, b => Assert.Equal(blog, b.BlogId));
    }

    [Fact]
    public void BlogMitBeitraegen_liefert_null_fuer_unbekannte_Id_und_leere_Liste_ohne_Beitraege()
    {
        Assert.Null(_dienst.BlogMitBeitraegen(99));
        int leer = _dienst.BlogAnlegen("Leer");
        Assert.Empty(_dienst.BlogMitBeitraegen(leer)!.Beitraege);
    }

    [Fact]
    public void LoescheBlog_loescht_auch_die_Beitraege_aber_nur_seine_eigenen()
    {
        int a = _dienst.BlogAnlegen("A");
        int b = _dienst.BlogAnlegen("B");
        _dienst.BeitragAnlegen(a, "A1");
        _dienst.BeitragAnlegen(a, "A2");
        _dienst.BeitragAnlegen(b, "B1");

        _dienst.LoescheBlog(a);

        Assert.Equal(0, Sql($"SELECT COUNT(*) FROM Beitraege WHERE BlogId = {a}"));
        Assert.Equal(1, Sql("SELECT COUNT(*) FROM Beitraege"));
        Assert.Equal(1, Sql("SELECT COUNT(*) FROM Blogs"));
    }

    [Fact]
    public void LoescheAutor_laesst_die_Beitraege_mit_AutorId_null_zurueck()
    {
        int blog = _dienst.BlogAnlegen("Technik");
        int anna = _dienst.AutorAnlegen("Anna");
        int bert = _dienst.AutorAnlegen("Bert");
        int b1 = _dienst.BeitragAnlegen(blog, "Von Anna", anna);
        int b2 = _dienst.BeitragAnlegen(blog, "Von Bert", bert);

        _dienst.LoescheAutor(anna);

        using var kontext = new BlogContext(_optionen);
        Assert.Null(kontext.Beitraege.Single(b => b.Id == b1).AutorId);
        Assert.Equal(bert, kontext.Beitraege.Single(b => b.Id == b2).AutorId);
        Assert.Equal(2, kontext.Beitraege.Count());
        Assert.Equal(1, kontext.Autoren.Count());
    }

    [Fact]
    public void Doppelte_Blognamen_loesen_DbUpdateException_aus()
    {
        _dienst.BlogAnlegen("Technik");
        Assert.Throws<DbUpdateException>(() => _dienst.BlogAnlegen("Technik"));
        _dienst.BlogAnlegen("Reisen"); // andere Namen gehen weiterhin
    }

    [Fact]
    public void Das_Modell_enthaelt_die_konfigurierten_Regeln()
    {
        using var kontext = new BlogContext(_optionen);
        var beitrag = kontext.Model.FindEntityType(typeof(Beitrag))!;

        var zuBlog = beitrag.GetForeignKeys().Single(f => f.PrincipalEntityType.ClrType == typeof(Blog));
        Assert.Equal(DeleteBehavior.Cascade, zuBlog.DeleteBehavior);
        Assert.Equal(nameof(Beitrag.BlogId), zuBlog.Properties.Single().Name);

        var zuAutor = beitrag.GetForeignKeys().Single(f => f.PrincipalEntityType.ClrType == typeof(Autor));
        Assert.Equal(DeleteBehavior.SetNull, zuAutor.DeleteBehavior);

        var blog = kontext.Model.FindEntityType(typeof(Blog))!;
        Assert.Contains(blog.GetIndexes(), i => i.IsUnique && i.Properties.Single().Name == nameof(Blog.Name));
    }
}
