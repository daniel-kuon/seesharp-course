using Microsoft.EntityFrameworkCore;

namespace Abfragen;

/// <summary>Ein Blogbeitrag (vorgegeben).</summary>
public class Beitrag
{
    public int Id { get; set; }
    public string Titel { get; set; } = "";
    public string Inhalt { get; set; } = "";
    public DateTime Datum { get; set; }
}

/// <summary>Der Kontext (vorgegeben): eine Tabelle Beitraege.</summary>
public class BeitragContext : DbContext
{
    public BeitragContext(DbContextOptions<BeitragContext> options) : base(options)
    {
    }

    public DbSet<Beitrag> Beitraege { get; set; } = null!;
}

/// <summary>Ergebnis einer Statistikabfrage über alle Beiträge.</summary>
public record StatistikErgebnis(int Anzahl, double SchnittLaenge);
