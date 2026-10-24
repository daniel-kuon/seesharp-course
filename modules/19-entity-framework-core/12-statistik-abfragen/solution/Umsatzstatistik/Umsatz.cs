using Microsoft.EntityFrameworkCore;

namespace Umsatzstatistik;

/// <summary>Auswertungen über die Verkäufe; die Datenbank erledigt Summen, Gruppen, Sortierung und Begrenzung.</summary>
public class Umsatz
{
    private readonly DbContextOptions<VerkaufContext> _optionen;

    public Umsatz(DbContextOptions<VerkaufContext> optionen)
    {
        _optionen = optionen;
    }

    public double GesamtUmsatz()
    {
        using var kontext = new VerkaufContext(_optionen);
        return kontext.Verkaeufe.Sum(v => v.Menge * v.Preis);
    }

    public static IQueryable<ProduktUmsatz> ProProduktAbfrage(VerkaufContext kontext) =>
        kontext.Verkaeufe
            .GroupBy(v => v.Produkt)
            .OrderByDescending(g => g.Sum(v => v.Menge * v.Preis))
            .Select(g => new ProduktUmsatz(g.Key, g.Sum(v => v.Menge * v.Preis)));

    public List<ProduktUmsatz> ProProdukt()
    {
        using var kontext = new VerkaufContext(_optionen);
        return ProProduktAbfrage(kontext).ToList();
    }

    public List<ProduktUmsatz> TopProdukte(int n)
    {
        using var kontext = new VerkaufContext(_optionen);
        return ProProduktAbfrage(kontext).Take(n).ToList();
    }
}
