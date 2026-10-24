using Microsoft.EntityFrameworkCore;

namespace Bibliothek;

/// <summary>Verwaltet Bücher. Jeder Aufruf benutzt einen frischen Kontext (using).</summary>
public class Buecherei
{
    private readonly DbContextOptions<BuchContext> _optionen;

    public Buecherei(DbContextOptions<BuchContext> optionen)
    {
        _optionen = optionen;
    }

    public int Aufnehmen(string titel, string autor, int jahr)
    {
        using var kontext = new BuchContext(_optionen);
        kontext.Database.EnsureCreated();
        var buch = new Buch { Titel = titel, Autor = autor, Jahr = jahr };
        kontext.Buecher.Add(buch);
        kontext.SaveChanges();
        return buch.Id;
    }

    public bool Ausleihen(int id)
    {
        using var kontext = new BuchContext(_optionen);
        var buch = kontext.Buecher.Find(id);
        if (buch is null || buch.Ausgeliehen) return false;
        buch.Ausgeliehen = true;
        kontext.SaveChanges();
        return true;
    }

    public bool Entfernen(int id)
    {
        using var kontext = new BuchContext(_optionen);
        var buch = kontext.Buecher.Find(id);
        if (buch is null) return false;
        kontext.Buecher.Remove(buch);
        kontext.SaveChanges();
        return true;
    }

    public List<Buch> Suche(string teil)
    {
        using var kontext = new BuchContext(_optionen);
        return kontext.Buecher.Where(b => b.Titel.Contains(teil)).OrderBy(b => b.Titel).ToList();
    }
}
