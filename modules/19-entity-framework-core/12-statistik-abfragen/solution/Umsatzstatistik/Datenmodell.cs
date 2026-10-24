using Microsoft.EntityFrameworkCore;

namespace Umsatzstatistik;

/// <summary>Ein Verkauf (vorgegeben).</summary>
public class Verkauf
{
    public int Id { get; set; }
    public string Produkt { get; set; } = "";
    public int Menge { get; set; }
    public double Preis { get; set; }
    public DateTime Datum { get; set; }
}

public class VerkaufContext : DbContext
{
    public VerkaufContext(DbContextOptions<VerkaufContext> options) : base(options)
    {
    }

    public DbSet<Verkauf> Verkaeufe { get; set; } = null!;
}

/// <summary>Umsatz eines Produkts: Summe aus Menge * Preis.</summary>
public record ProduktUmsatz(string Produkt, double Umsatz);
