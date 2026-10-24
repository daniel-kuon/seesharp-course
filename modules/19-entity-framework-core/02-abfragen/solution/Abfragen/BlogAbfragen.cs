using Microsoft.EntityFrameworkCore;

namespace Abfragen;

/// <summary>Abfragen mit LINQ-to-Entities: EF Core übersetzt die Ausdrücke in SQL.</summary>
public class BlogAbfragen
{
    private readonly DbContextOptions<BeitragContext> _optionen;

    public BlogAbfragen(DbContextOptions<BeitragContext> optionen)
    {
        _optionen = optionen;
    }

    public List<Beitrag> MitTitel(string teil)
    {
        using var kontext = new BeitragContext(_optionen);
        return kontext.Beitraege.Where(b => b.Titel.Contains(teil)).OrderBy(b => b.Id).ToList();
    }

    public List<Beitrag> Neueste(int n)
    {
        using var kontext = new BeitragContext(_optionen);
        return kontext.Beitraege.OrderByDescending(b => b.Datum).Take(n).ToList();
    }

    public Beitrag? Finde(int id)
    {
        using var kontext = new BeitragContext(_optionen);
        return kontext.Beitraege.Find(id);
    }

    public Beitrag? ErsterMit(string teil)
    {
        using var kontext = new BeitragContext(_optionen);
        return kontext.Beitraege.Where(b => b.Titel.Contains(teil)).OrderBy(b => b.Id).FirstOrDefault();
    }

    public static IQueryable<string> TitellisteAbfrage(BeitragContext kontext) =>
        kontext.Beitraege.OrderBy(b => b.Id).Select(b => b.Titel);

    public List<string> Titelliste()
    {
        using var kontext = new BeitragContext(_optionen);
        return TitellisteAbfrage(kontext).ToList();
    }

    public static IQueryable<StatistikErgebnis> StatistikAbfrage(BeitragContext kontext) =>
        kontext.Beitraege
            .GroupBy(b => 1)
            .Select(g => new StatistikErgebnis(g.Count(), g.Average(b => b.Inhalt.Length)));

    public (int anzahl, double schnittLaenge) Statistik()
    {
        using var kontext = new BeitragContext(_optionen);
        var ergebnis = StatistikAbfrage(kontext).FirstOrDefault();
        return ergebnis is null ? (0, 0) : (ergebnis.Anzahl, ergebnis.SchnittLaenge);
    }

    public (int anzahl, double schnittLaenge) ClientAuswertung()
    {
        using var kontext = new BeitragContext(_optionen);
        var alle = kontext.Beitraege.AsEnumerable().ToList(); // alles wird geladen, danach rechnet C#
        return alle.Count == 0 ? (0, 0) : (alle.Count(), alle.Average(b => b.Inhalt.Length));
    }
}
