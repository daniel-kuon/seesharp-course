using Microsoft.EntityFrameworkCore;

namespace Umsatzstatistik;

/// <summary>
/// Auswertungen über die Verkäufe. Summen, Gruppen, Sortierung und Begrenzung soll die DATENBANK erledigen.
/// Die statische Methode ProProduktAbfrage bekommt den Kontext von außen und liefert eine noch nicht ausgeführte
/// IQueryable, damit die Tests das erzeugte SQL mit ToQueryString() prüfen können.
/// </summary>
public class Umsatz
{
    private readonly DbContextOptions<VerkaufContext> _optionen;

    public Umsatz(DbContextOptions<VerkaufContext> optionen)
    {
        _optionen = optionen;
    }

    /// <summary>Summe aus Menge * Preis über alle Verkäufe (0, wenn es keine gibt).</summary>
    public double GesamtUmsatz()
    {
        // TODO: using var kontext...; kontext.Verkaeufe.Sum(v => v.Menge * v.Preis)
        throw new NotImplementedException();
    }

    /// <summary>Umsatz je Produkt, höchster Umsatz zuerst: GroupBy, OrderByDescending nach der Summe, dann Select auf das Record.</summary>
    public static IQueryable<ProduktUmsatz> ProProduktAbfrage(VerkaufContext kontext)
    {
        // TODO: kontext.Verkaeufe.GroupBy(v => v.Produkt)
        //           .OrderByDescending(g => g.Sum(v => v.Menge * v.Preis))   // erst sortieren (EF Core kann nicht nach dem Record sortieren)
        //           .Select(g => new ProduktUmsatz(g.Key, g.Sum(v => v.Menge * v.Preis)))
        throw new NotImplementedException();
    }

    public List<ProduktUmsatz> ProProdukt()
    {
        using var kontext = new VerkaufContext(_optionen);
        return ProProduktAbfrage(kontext).ToList();
    }

    /// <summary>Die n umsatzstärksten Produkte (Take auf die sortierte Abfrage: LIMIT im SQL).</summary>
    public List<ProduktUmsatz> TopProdukte(int n)
    {
        // TODO
        throw new NotImplementedException();
    }
}
