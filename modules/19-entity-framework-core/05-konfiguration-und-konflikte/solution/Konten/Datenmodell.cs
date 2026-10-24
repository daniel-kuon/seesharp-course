using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Konten;

public enum Status { Neu, Aktiv, Gesperrt }

public class Konto
{
    public int Id { get; set; }
    public string Inhaber { get; set; } = "";
    public decimal Saldo { get; set; }
    public Status Status { get; set; }

    /// <summary>Concurrency Token: wird bei jeder Änderung von Hand hochgezählt.</summary>
    [ConcurrencyCheck]
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
        modelBuilder.Entity<Konto>().Property(k => k.Status).HasConversion<string>();
    }
}
