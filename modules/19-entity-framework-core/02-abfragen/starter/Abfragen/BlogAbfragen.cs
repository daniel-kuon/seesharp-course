using Microsoft.EntityFrameworkCore;

namespace Abfragen;

/// <summary>
/// Abfragen mit LINQ-to-Entities. EF Core übersetzt die LINQ-Ausdrücke in SQL, das die Datenbank
/// ausführt; erst ToList(), Count(), FirstOrDefault() usw. führen die Abfrage aus.
/// Die Instanzmethoden öffnen je Aufruf einen frischen Kontext. Die statischen ...Abfrage-Methoden
/// bekommen einen Kontext von außen und liefern eine noch nicht ausgeführte IQueryable, damit
/// die Tests das erzeugte SQL mit ToQueryString() ansehen können.
/// </summary>
public class BlogAbfragen
{
    private readonly DbContextOptions<BeitragContext> _optionen;

    public BlogAbfragen(DbContextOptions<BeitragContext> optionen)
    {
        _optionen = optionen;
    }

    /// <summary>Beiträge, deren Titel den Text teil enthält, nach Id sortiert (Where + Contains).</summary>
    public List<Beitrag> MitTitel(string teil)
    {
        // TODO: using var k = new BeitragContext(_optionen); k.Beitraege.Where(...).OrderBy(...).ToList()
        throw new NotImplementedException();
    }

    /// <summary>Die n neuesten Beiträge, neuester zuerst (OrderByDescending nach Datum + Take).</summary>
    public List<Beitrag> Neueste(int n)
    {
        // TODO
        throw new NotImplementedException();
    }

    /// <summary>Der Beitrag mit dieser Id oder null (Find).</summary>
    public Beitrag? Finde(int id)
    {
        // TODO: k.Beitraege.Find(id)
        throw new NotImplementedException();
    }

    /// <summary>Der erste Beitrag (kleinste Id), dessen Titel teil enthält, oder null (FirstOrDefault).</summary>
    public Beitrag? ErsterMit(string teil)
    {
        // TODO: Where + OrderBy(Id) + FirstOrDefault
        throw new NotImplementedException();
    }

    /// <summary>Nur die Spalte Titel, nach Id sortiert: Select projiziert, die Datenbank liefert keinen Inhalt mit.</summary>
    public static IQueryable<string> TitellisteAbfrage(BeitragContext kontext)
    {
        // TODO: kontext.Beitraege.OrderBy(b => b.Id).Select(b => b.Titel)  (ohne ToList)
        throw new NotImplementedException();
    }

    public List<string> Titelliste()
    {
        using var kontext = new BeitragContext(_optionen);
        return TitellisteAbfrage(kontext).ToList();
    }

    /// <summary>Anzahl und durchschnittliche Inhaltslänge in EINER serverseitigen Abfrage:
    /// GroupBy mit einer Konstanten, dann Select mit Count() und Average().</summary>
    public static IQueryable<StatistikErgebnis> StatistikAbfrage(BeitragContext kontext)
    {
        // TODO: kontext.Beitraege.GroupBy(b => 1)
        //           .Select(g => new StatistikErgebnis(g.Count(), g.Average(b => b.Inhalt.Length)))
        throw new NotImplementedException();
    }

    /// <summary>Ergebnis der Statistikabfrage; bei einer leeren Tabelle (0, 0).</summary>
    public (int anzahl, double schnittLaenge) Statistik()
    {
        // TODO: frischer Kontext, StatistikAbfrage(kontext).FirstOrDefault(); null bedeutet: keine Beiträge.
        throw new NotImplementedException();
    }

    /// <summary>Dasselbe Ergebnis, aber CLIENTSEITIG: AsEnumerable() holt erst ALLE Beiträge in den Speicher
    /// (mit dem Inhalt!), Count und Average laufen dann in C#. Der Gegensatz zu Statistik() (20.9.6).</summary>
    public (int anzahl, double schnittLaenge) ClientAuswertung()
    {
        // TODO: k.Beitraege.AsEnumerable() und dann Count() / Average(b => b.Inhalt.Length) in C#.
        // Achtung: Average einer leeren Folge wirft eine Ausnahme: den Fall behandeln.
        throw new NotImplementedException();
    }
}
