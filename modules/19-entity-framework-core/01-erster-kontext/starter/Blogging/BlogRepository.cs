using Microsoft.EntityFrameworkCore;

namespace Blogging;

/// <summary>
/// Speichert und liest Blogs. Jede Methode verwendet einen EIGENEN, frischen Kontext in einer
/// using-Anweisung: Der Kontext ist eine kurze Arbeitseinheit und wird nicht als Feld aufbewahrt.
/// </summary>
public class BlogRepository
{
    private readonly DbContextOptions<BlogContext> _optionen;

    public BlogRepository(DbContextOptions<BlogContext> optionen)
    {
        _optionen = optionen;
    }

    /// <summary>Legt einen Blog mit diesem Namen an und liefert seine neue Id (größer als 0).
    /// Das Schema wird bei Bedarf angelegt. Ein Name null verletzt die NOT-NULL-Spalte: Dann wirft
    /// SaveChanges eine DbUpdateException (nicht abfangen).</summary>
    public int Anlegen(string name)
    {
        // TODO: using var kontext = new BlogContext(_optionen);
        //       kontext.Database.EnsureCreated();  (legt Tabellen an, falls es sie noch nicht gibt)
        //       Blog erzeugen, kontext.Blogs.Add(blog), kontext.SaveChanges();  danach ist blog.Id gesetzt.
        throw new NotImplementedException();
    }

    /// <summary>Alle Blogs, sortiert nach Id, gelesen mit einem frischen Kontext.</summary>
    public List<Blog> Alle()
    {
        // TODO: frischer Kontext (using), kontext.Blogs.OrderBy(b => b.Id).ToList()
        throw new NotImplementedException();
    }
}
