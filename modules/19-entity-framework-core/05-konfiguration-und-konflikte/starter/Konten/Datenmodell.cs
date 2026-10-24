using Microsoft.EntityFrameworkCore;

namespace Konten;

public enum Status { Neu, Aktiv, Gesperrt }

public class Konto
{
    public int Id { get; set; }
    public string Inhaber { get; set; } = "";
    public decimal Saldo { get; set; }
    public Status Status { get; set; }

    // TODO: Concurrency Token. SQLite hat keinen rowversion-Typ, deshalb zählt der Code die Version selbst hoch.
    // Mit der Annotation [ConcurrencyCheck] (System.ComponentModel.DataAnnotations) prüft EF Core bei jedem UPDATE,
    // ob sich die Version in der Datenbank seit dem Laden geändert hat.
    public int Version { get; set; }
}

public class KontoContext : DbContext
{
    public KontoContext(DbContextOptions<KontoContext> options) : base(options)
    {
    }

    public DbSet<Konto> Konten { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: Den Aufzählungstyp Status als Text speichern ("Neu", "Aktiv", "Gesperrt") statt als Zahl:
        // modelBuilder.Entity<Konto>().Property(k => k.Status).HasConversion<string>();
    }
}
