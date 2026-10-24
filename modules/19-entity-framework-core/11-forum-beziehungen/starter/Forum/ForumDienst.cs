using Microsoft.EntityFrameworkCore;

namespace Forum;

/// <summary>Das Forum. Jede Methode benutzt einen frischen Kontext.</summary>
public class ForumDienst
{
    private readonly DbContextOptions<ForumContext> _optionen;

    public ForumDienst(DbContextOptions<ForumContext> optionen)
    {
        _optionen = optionen;
    }

    /// <summary>Vorgegeben: legt ein Thema an (und das Schema bei Bedarf) und liefert seine Id.</summary>
    public int ThemaAnlegen(string titel)
    {
        using var kontext = new ForumContext(_optionen);
        kontext.Database.EnsureCreated();
        var thema = new Thema { Titel = titel };
        kontext.Themen.Add(thema);
        kontext.SaveChanges();
        return thema.Id;
    }

    /// <summary>Vorgegeben: hängt eine Antwort an ein Thema.</summary>
    public void Antworten(int themaId, string text)
    {
        using var kontext = new ForumContext(_optionen);
        kontext.Antworten.Add(new Antwort { ThemaId = themaId, Text = text });
        kontext.SaveChanges();
    }

    /// <summary>Das Thema samt Antworten (Include) oder null.</summary>
    public Thema? ThemaMitAntworten(int id)
    {
        // TODO
        throw new NotImplementedException();
    }

    /// <summary>Löscht das Thema; seine Antworten verschwinden mit.</summary>
    public void LoescheThema(int id)
    {
        // TODO
        throw new NotImplementedException();
    }

    /// <summary>Anzahl der Antworten je Themen-Titel, auch 0 für Themen ohne Antworten
    /// (Titel sind in den Tests eindeutig). Die Zählung soll die Datenbank erledigen.</summary>
    public Dictionary<string, int> AntwortenProThema()
    {
        // TODO: Select(t => new { t.Titel, Anzahl = t.Antworten.Count }) und ToDictionary
        throw new NotImplementedException();
    }
}
