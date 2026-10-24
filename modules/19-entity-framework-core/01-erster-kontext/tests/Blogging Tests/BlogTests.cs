using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Blogging;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class BlogTests : IDisposable
{
    // Eine offene SQLite-Verbindung im Speicher hält die Datenbank am Leben; jeder Test hat seine eigene.
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly DbContextOptions<BlogContext> _optionen;

    public BlogTests()
    {
        _verbindung.Open();
        _optionen = new DbContextOptionsBuilder<BlogContext>().UseSqlite(_verbindung).Options;
    }

    public void Dispose() => _verbindung.Dispose();

    [Fact]
    public void Blog_hat_die_Annotationen_Required_und_MaxLength()
    {
        PropertyInfo name = typeof(Blog).GetProperty(nameof(Blog.Name))!;
        Assert.NotNull(name.GetCustomAttribute<RequiredAttribute>());
        Assert.Equal(100, name.GetCustomAttribute<MaxLengthAttribute>()?.Length);
    }

    [Fact]
    public void Kontext_kennt_die_Annotationen_im_Modell()
    {
        using var kontext = new BlogContext(_optionen);
        var eigenschaft = kontext.Model.FindEntityType(typeof(Blog))!.FindProperty(nameof(Blog.Name))!;
        Assert.Equal(100, eigenschaft.GetMaxLength());
        Assert.False(eigenschaft.IsNullable);
    }

    [Fact]
    public void Kontext_hat_ein_DbSet_fuer_Blogs()
    {
        using var kontext = new BlogContext(_optionen);
        kontext.Database.EnsureCreated();
        Assert.Equal(0, kontext.Blogs.Count());
    }

    [Fact]
    public void Anlegen_liefert_nach_SaveChanges_eine_Id_groesser_0()
    {
        var repo = new BlogRepository(_optionen);
        int erste = repo.Anlegen("Technik");
        int zweite = repo.Anlegen("Reisen");
        Assert.True(erste > 0);
        Assert.True(zweite > erste);
    }

    [Fact]
    public void Alle_liefert_die_gespeicherten_Blogs()
    {
        var repo = new BlogRepository(_optionen);
        int id = repo.Anlegen("Technik");
        repo.Anlegen("Reisen");
        var alle = repo.Alle();
        Assert.Equal(new[] { "Technik", "Reisen" }, alle.Select(b => b.Name));
        Assert.Equal(id, alle[0].Id);
        Assert.Null(alle[0].Beschreibung);
    }

    [Fact]
    public void Alle_auf_leerer_Datenbank_liefert_leere_Liste()
    {
        var repo = new BlogRepository(_optionen);
        repo.Anlegen("x");
        using (var kontext = new BlogContext(_optionen))
        {
            kontext.Blogs.ExecuteDelete();
        }
        Assert.Empty(repo.Alle());
    }

    [Fact]
    public void Anlegen_ohne_Namen_loest_DbUpdateException_aus()
    {
        var repo = new BlogRepository(_optionen);
        Assert.Throws<DbUpdateException>(() => repo.Anlegen(null!));
    }

    [Fact]
    public void Daten_sind_fuer_einen_anderen_Kontext_erst_nach_SaveChanges_sichtbar()
    {
        using var kontext1 = new BlogContext(_optionen);
        kontext1.Database.EnsureCreated();
        kontext1.Blogs.Add(new Blog { Name = "Neu" });

        using var kontext2 = new BlogContext(_optionen);
        Assert.Equal(0, kontext2.Blogs.Count()); // noch nicht gespeichert

        kontext1.SaveChanges();
        Assert.Equal(1, kontext2.Blogs.Count());
    }

    [Fact]
    public void Alle_verwendet_bei_jedem_Aufruf_einen_frischen_Kontext()
    {
        var repo = new BlogRepository(_optionen);
        repo.Anlegen("Technik");

        // Ein dauerhaft geteilter Kontext würde dieselbe nachverfolgte Instanz liefern.
        Assert.NotSame(repo.Alle()[0], repo.Alle()[0]);

        // Und er würde Änderungen von außen nicht sehen.
        using (var befehl = _verbindung.CreateCommand())
        {
            befehl.CommandText = "UPDATE Blogs SET Name = 'Geändert'";
            befehl.ExecuteNonQuery();
        }
        Assert.Equal("Geändert", repo.Alle()[0].Name);
    }

    [Fact]
    public void Bei_Anlegen_wird_das_Schema_bei_Bedarf_erzeugt_und_mehrfach_verwendet()
    {
        var repo = new BlogRepository(_optionen); // Datenbank ist noch leer, kein EnsureCreated im Test
        repo.Anlegen("A");
        repo.Anlegen("B");
        Assert.Equal(2, repo.Alle().Count);
    }
}
