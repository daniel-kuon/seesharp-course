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
        modelBuilder.Entity<Thema>()
            .HasMany(t => t.Antworten)
            .WithOne(a => a.Thema)
            .HasForeignKey(a => a.ThemaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
