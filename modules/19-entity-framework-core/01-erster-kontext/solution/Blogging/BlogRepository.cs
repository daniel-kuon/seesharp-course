using Microsoft.EntityFrameworkCore;

namespace Blogging;

/// <summary>Speichert und liest Blogs. Jede Methode verwendet einen eigenen, frischen Kontext.</summary>
public class BlogRepository
{
    private readonly DbContextOptions<BlogContext> _optionen;

    public BlogRepository(DbContextOptions<BlogContext> optionen)
    {
        _optionen = optionen;
    }

    public int Anlegen(string name)
    {
        using var kontext = new BlogContext(_optionen);
        kontext.Database.EnsureCreated();
        var blog = new Blog { Name = name };
        kontext.Blogs.Add(blog);
        kontext.SaveChanges();
        return blog.Id;
    }

    public List<Blog> Alle()
    {
        using var kontext = new BlogContext(_optionen);
        return kontext.Blogs.OrderBy(b => b.Id).ToList();
    }
}
