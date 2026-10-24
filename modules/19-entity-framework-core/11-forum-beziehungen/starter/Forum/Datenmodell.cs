using Microsoft.EntityFrameworkCore;

namespace Forum;

/// <summary>Ein Thema mit seinen Antworten (1:n).</summary>
public class Thema
{
    public int Id { get; set; }
    public string Titel { get; set; } = "";
    public List<Antwort> Antworten { get; set; } = new();
}

public class Antwort
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public int ThemaId { get; set; }
    public Thema Thema { get; set; } = null!;
}

public class ForumContext : DbContext
{
    public ForumContext(DbContextOptions<ForumContext> options) : base(options)
    {
    }

    public DbSet<Thema> Themen { get; set; } = null!;
    public DbSet<Antwort> Antworten { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO (Fluent API): Ein Thema hat viele Antworten, jede Antwort gehört zu einem Thema (Fremdschlüssel ThemaId).
        // Wird ein Thema gelöscht, werden seine Antworten mitgelöscht: OnDelete(DeleteBehavior.Cascade).
    }
}
