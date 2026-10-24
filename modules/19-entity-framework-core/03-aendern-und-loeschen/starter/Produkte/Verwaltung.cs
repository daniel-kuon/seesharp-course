using Microsoft.EntityFrameworkCore;

namespace Produkte;

/// <summary>
/// Ändern und Löschen mit EF Core. Der Kontext verfolgt geladene Entitäten nach (Change Tracking):
/// Ändert man eine Eigenschaft, merkt er sich das, und SaveChanges schreibt genau die Änderungen.
/// Jede Instanzmethode benutzt einen frischen Kontext.
/// </summary>
public class Verwaltung
{
    private readonly DbContextOptions<ProduktContext> _optionen;

    public Verwaltung(DbContextOptions<ProduktContext> optionen)
    {
        _optionen = optionen;
    }

    /// <summary>Lädt das Produkt (nachverfolgt), ändert den Namen und speichert.
    /// Liefert die Zahl der geschriebenen Zeilen von SaveChanges (1, oder 0 wenn es das Produkt nicht gibt).</summary>
    public int Umbenennen(int id, string neu)
    {
        // TODO: using var kontext; var produkt = kontext.Produkte.Find(id); null -> 0;
        //       produkt.Name = neu; return kontext.SaveChanges();   (kein Update-Aufruf nötig!)
        throw new NotImplementedException();
    }

    /// <summary>Löscht das Produkt. true, wenn es eines gab.</summary>
    public bool Entfernen(int id)
    {
        // TODO: Find, Remove, SaveChanges
        throw new NotImplementedException();
    }

    /// <summary>Führt die Aktion aus (siehe Aktion) und liefert den EntityState des betroffenen Produkts,
    /// den kontext.Entry(produkt).State meldet. Erwartet: Added, Unchanged, Modified, Deleted, Detached.
    /// Für alle Aktionen außer Hinzufuegen ist id die Id eines vorhandenen Produkts. Es wird nichts gespeichert.</summary>
    public EntityState ZustandNach(Aktion aktion, int id)
    {
        // TODO: pro Aktion ein Zweig (switch). Der Zustand kommt aus kontext.Entry(produkt).State.
        throw new NotImplementedException();
    }

    /// <summary>Lädt das Produkt mit AsNoTracking, ändert den Namen und ruft SaveChanges auf. Weil der Kontext die
    /// Entität nicht verfolgt, wird nichts gespeichert: Die Methode liefert die Zahl der geschriebenen Zeilen (0).</summary>
    public int UmbenennenOhneNachverfolgung(int id, string neu)
    {
        // TODO: kontext.Produkte.AsNoTracking().First(p => p.Id == id), Name ändern, SaveChanges zurückgeben.
        throw new NotImplementedException();
    }

    /// <summary>Multipliziert alle Preise mit faktor, ohne ein Produkt zu laden (ExecuteUpdate + SetProperty).
    /// Liefert die Zahl der geänderten Zeilen. Der Kontext kommt von außen, damit der Test prüfen kann,
    /// dass er nichts nachverfolgt.</summary>
    public static int ErhoehePreise(ProduktContext kontext, decimal faktor)
    {
        // TODO: kontext.Produkte.ExecuteUpdate(s => s.SetProperty(p => p.Preis, p => p.Preis * faktor))
        throw new NotImplementedException();
    }

    /// <summary>Löscht alle Produkte, die vor der Grenze angelegt wurden, ohne sie zu laden (ExecuteDelete).
    /// Liefert die Zahl der gelöschten Zeilen.</summary>
    public static int LoescheAlte(ProduktContext kontext, DateTime grenze)
    {
        // TODO: kontext.Produkte.Where(...).ExecuteDelete()
        throw new NotImplementedException();
    }
}
