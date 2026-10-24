using Microsoft.EntityFrameworkCore;

namespace Produkte;

/// <summary>Ändern und Löschen mit EF Core; jede Instanzmethode benutzt einen frischen Kontext.</summary>
public class Verwaltung
{
    private readonly DbContextOptions<ProduktContext> _optionen;

    public Verwaltung(DbContextOptions<ProduktContext> optionen)
    {
        _optionen = optionen;
    }

    public int Umbenennen(int id, string neu)
    {
        using var kontext = new ProduktContext(_optionen);
        var produkt = kontext.Produkte.Find(id);
        if (produkt is null) return 0;
        produkt.Name = neu;
        return kontext.SaveChanges();
    }

    public bool Entfernen(int id)
    {
        using var kontext = new ProduktContext(_optionen);
        var produkt = kontext.Produkte.Find(id);
        if (produkt is null) return false;
        kontext.Produkte.Remove(produkt);
        kontext.SaveChanges();
        return true;
    }

    public EntityState ZustandNach(Aktion aktion, int id)
    {
        using var kontext = new ProduktContext(_optionen);
        Produkt produkt;
        switch (aktion)
        {
            case Aktion.Hinzufuegen:
                produkt = new Produkt { Name = "Neu", Preis = 1m, Angelegt = DateTime.UtcNow };
                kontext.Produkte.Add(produkt);
                break;
            case Aktion.Anhaengen:
                produkt = new Produkt { Id = id, Name = "Unbekannt" };
                kontext.Produkte.Attach(produkt);
                break;
            case Aktion.Aendern:
                produkt = kontext.Produkte.Find(id)!;
                produkt.Name += "!";
                break;
            case Aktion.Entfernen:
                produkt = kontext.Produkte.Find(id)!;
                kontext.Produkte.Remove(produkt);
                break;
            case Aktion.OhneNachverfolgung:
                produkt = kontext.Produkte.AsNoTracking().First(p => p.Id == id);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(aktion));
        }
        return kontext.Entry(produkt).State;
    }

    public int UmbenennenOhneNachverfolgung(int id, string neu)
    {
        using var kontext = new ProduktContext(_optionen);
        var produkt = kontext.Produkte.AsNoTracking().First(p => p.Id == id);
        produkt.Name = neu;
        return kontext.SaveChanges();
    }

    public static int ErhoehePreise(ProduktContext kontext, decimal faktor) =>
        kontext.Produkte.ExecuteUpdate(s => s.SetProperty(p => p.Preis, p => p.Preis * faktor));

    public static int LoescheAlte(ProduktContext kontext, DateTime grenze) =>
        kontext.Produkte.Where(p => p.Angelegt < grenze).ExecuteDelete();
}
