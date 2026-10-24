using Microsoft.EntityFrameworkCore;

namespace Beziehungen;

/// <summary>Zugriff auf Blogs, Beiträge und Autoren. Jede Methode benutzt einen frischen Kontext.</summary>
public class BlogDienst
{
    private readonly DbContextOptions<BlogContext> _optionen;

    public BlogDienst(DbContextOptions<BlogContext> optionen)
    {
        _optionen = optionen;
    }

    public int BlogAnlegen(string name)
    {
        using var kontext = new BlogContext(_optionen);
        var blog = new Blog { Name = name };
        kontext.Blogs.Add(blog);
        kontext.SaveChanges();
        return blog.Id;
    }

    public int AutorAnlegen(string name)
    {
        using var kontext = new BlogContext(_optionen);
        var autor = new Autor { Name = name };
        kontext.Autoren.Add(autor);
        kontext.SaveChanges();
        return autor.Id;
    }

    public int BeitragAnlegen(int blogId, string titel, int? autorId = null)
    {
        using var kontext = new BlogContext(_optionen);
        var beitrag = new Beitrag { BlogId = blogId, Titel = titel, AutorId = autorId };
        kontext.Beitraege.Add(beitrag);
        kontext.SaveChanges();
        return beitrag.Id;
    }

    public Blog? BlogMitBeitraegen(int id)
    {
        using var kontext = new BlogContext(_optionen);
        return kontext.Blogs.Include(b => b.Beitraege).FirstOrDefault(b => b.Id == id);
    }

    public void LoescheBlog(int id)
    {
        using var kontext = new BlogContext(_optionen);
        var blog = kontext.Blogs.Find(id);
        if (blog is null) return;
        kontext.Blogs.Remove(blog);
        kontext.SaveChanges();
    }

    public void LoescheAutor(int id)
    {
        using var kontext = new BlogContext(_optionen);
        var autor = kontext.Autoren.Find(id);
        if (autor is null) return;
        kontext.Autoren.Remove(autor);
        kontext.SaveChanges();
    }
}
