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

    // --- vorgegeben ---

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

    // --- deine Aufgaben ---

    /// <summary>Der Blog samt seiner Beiträge (Eager Loading mit Include) oder null. Lazy Loading ist nicht
    /// eingerichtet: Ohne Include wäre Beitraege nach dem Freigeben des Kontexts leer.</summary>
    public Blog? BlogMitBeitraegen(int id)
    {
        // TODO: using var kontext; kontext.Blogs.Include(b => b.Beitraege).FirstOrDefault(b => b.Id == id)
        throw new NotImplementedException();
    }

    /// <summary>Löscht den Blog. Seine Beiträge verschwinden mit (Cascade), ohne dass du sie laden musst.</summary>
    public void LoescheBlog(int id)
    {
        // TODO: Find, Remove, SaveChanges
        throw new NotImplementedException();
    }

    /// <summary>Löscht den Autor. Seine Beiträge bleiben erhalten und haben danach AutorId == null (SetNull).</summary>
    public void LoescheAutor(int id)
    {
        // TODO: Find, Remove, SaveChanges (das Verhalten kommt aus der Konfiguration in OnModelCreating)
        throw new NotImplementedException();
    }
}
