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

    public int ThemaAnlegen(string titel)
    {
        using var kontext = new ForumContext(_optionen);
        kontext.Database.EnsureCreated();
        var thema = new Thema { Titel = titel };
        kontext.Themen.Add(thema);
        kontext.SaveChanges();
        return thema.Id;
    }

    public void Antworten(int themaId, string text)
    {
        using var kontext = new ForumContext(_optionen);
        kontext.Antworten.Add(new Antwort { ThemaId = themaId, Text = text });
        kontext.SaveChanges();
    }

    public Thema? ThemaMitAntworten(int id)
    {
        using var kontext = new ForumContext(_optionen);
        return kontext.Themen.Include(t => t.Antworten).FirstOrDefault(t => t.Id == id);
    }

    public void LoescheThema(int id)
    {
        using var kontext = new ForumContext(_optionen);
        var thema = kontext.Themen.Find(id);
        if (thema is null) return;
        kontext.Themen.Remove(thema);
        kontext.SaveChanges();
    }

    public Dictionary<string, int> AntwortenProThema()
    {
        using var kontext = new ForumContext(_optionen);
        return kontext.Themen
            .Select(t => new { t.Titel, Anzahl = t.Antworten.Count })
            .ToDictionary(x => x.Titel, x => x.Anzahl);
    }
}
