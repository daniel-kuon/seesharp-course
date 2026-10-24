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

    /// <summary>Nimmt ein Buch auf (zunächst nicht ausgeliehen) und liefert seine Id.
    /// Legt das Schema bei Bedarf mit EnsureCreated an.</summary>
    public int Aufnehmen(string titel, string autor, int jahr)
    {
        // TODO
        throw new NotImplementedException();
    }

    /// <summary>Verleiht das Buch (Ausgeliehen = true). false, wenn es das Buch nicht gibt oder es schon
    /// ausgeliehen ist.</summary>
    public bool Ausleihen(int id)
    {
        // TODO: Find, prüfen, Eigenschaft ändern, SaveChanges
        throw new NotImplementedException();
    }

    /// <summary>Entfernt das Buch. true, wenn es eines gab.</summary>
    public bool Entfernen(int id)
    {
        // TODO
        throw new NotImplementedException();
    }

    /// <summary>Bücher, deren Titel den Text teil enthält, nach Titel sortiert.</summary>
    public List<Buch> Suche(string teil)
    {
        // TODO
        throw new NotImplementedException();
    }
}
