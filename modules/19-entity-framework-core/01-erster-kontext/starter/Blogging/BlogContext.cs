using Microsoft.EntityFrameworkCore;

namespace Blogging;

/// <summary>
/// Der Datenbankkontext: die Brücke zwischen den Entitätsklassen und der Datenbank. Eine Instanz ist
/// leichtgewichtig und kurzlebig (Arbeitseinheit). Die Verbindung kommt von außen über DbContextOptions
/// (die Tests übergeben eine SQLite-Datenbank im Speicher), nicht per OnConfiguring.
/// </summary>
public class BlogContext : DbContext
{
    // TODO: Die Optionen müssen an die Basisklasse weitergereicht werden: ": base(options)".
    // Ohne sie weiß der Kontext nichts von SQLite und wirft beim ersten Zugriff eine Ausnahme.
    public BlogContext(DbContextOptions<BlogContext> options) : base()
    {
    }

    // TODO: Die Tabelle Blogs als DbSet<Blog>: eine Eigenschaft mit get und set, z. B. "{ get; set; } = null!;".
    public DbSet<Blog> Blogs => throw new NotImplementedException();
}
