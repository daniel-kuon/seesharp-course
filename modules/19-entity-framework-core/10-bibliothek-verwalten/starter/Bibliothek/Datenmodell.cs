using Microsoft.EntityFrameworkCore;

namespace Bibliothek;

/// <summary>Ein Buch (vorgegeben). Ausgeliehen ist true, solange es verliehen ist.</summary>
public class Buch
{
    public int Id { get; set; }
    public string Titel { get; set; } = "";
    public string Autor { get; set; } = "";
    public int Jahr { get; set; }
    public bool Ausgeliehen { get; set; }
}

/// <summary>Der Kontext (vorgegeben): eine Tabelle Buecher.</summary>
public class BuchContext : DbContext
{
    public BuchContext(DbContextOptions<BuchContext> options) : base(options)
    {
    }

    public DbSet<Buch> Buecher { get; set; } = null!;
}
