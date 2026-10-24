using Microsoft.EntityFrameworkCore;

namespace Produkte;

/// <summary>Ein Produkt (vorgegeben).</summary>
public class Produkt
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Preis { get; set; }
    public DateTime Angelegt { get; set; }
}

/// <summary>Der Kontext (vorgegeben): eine Tabelle Produkte.</summary>
public class ProduktContext : DbContext
{
    public ProduktContext(DbContextOptions<ProduktContext> options) : base(options)
    {
    }

    public DbSet<Produkt> Produkte { get; set; } = null!;
}

/// <summary>Was ZustandNach mit dem Produkt tut, bevor es den EntityState meldet.</summary>
public enum Aktion
{
    /// <summary>Ein neues Produkt mit Add vormerken.</summary>
    Hinzufuegen,
    /// <summary>Ein Produkt mit der gegebenen Id (ohne es zu laden) mit Attach anhängen.</summary>
    Anhaengen,
    /// <summary>Ein Produkt laden und seinen Namen ändern.</summary>
    Aendern,
    /// <summary>Ein Produkt laden und mit Remove zum Löschen vormerken.</summary>
    Entfernen,
    /// <summary>Ein Produkt mit AsNoTracking laden.</summary>
    OhneNachverfolgung
}
