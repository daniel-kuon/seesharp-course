using Microsoft.EntityFrameworkCore;

namespace Blogging;

/// <summary>Der Datenbankkontext für Blogs; die Verbindung kommt über DbContextOptions von außen.</summary>
public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; } = null!;
}
