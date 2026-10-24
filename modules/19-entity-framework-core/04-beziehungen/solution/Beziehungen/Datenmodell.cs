using Microsoft.EntityFrameworkCore;

namespace Beziehungen;

/// <summary>Ein Blog hat viele Beiträge (1:n). Beitraege ist die Navigationseigenschaft auf der "1"-Seite.</summary>
public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public List<Beitrag> Beitraege { get; set; } = new();
}

/// <summary>Ein Autor; Beiträge dürfen ohne Autor sein (optionale Beziehung).</summary>
public class Autor
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

/// <summary>Ein Beitrag gehört zu genau einem Blog (BlogId ist der Fremdschlüssel) und optional zu einem Autor.</summary>
public class Beitrag
{
    public int Id { get; set; }
    public string Titel { get; set; } = "";

    public int BlogId { get; set; }
    public Blog Blog { get; set; } = null!;

    public int? AutorId { get; set; }
    public Autor? Autor { get; set; }
}

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Beitrag> Beitraege { get; set; } = null!;
    public DbSet<Autor> Autoren { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.Beitraege)
            .WithOne(x => x.Blog)
            .HasForeignKey(x => x.BlogId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Blog>()
            .HasIndex(b => b.Name)
            .IsUnique();

        modelBuilder.Entity<Beitrag>()
            .HasOne(b => b.Autor)
            .WithMany()
            .HasForeignKey(b => b.AutorId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
