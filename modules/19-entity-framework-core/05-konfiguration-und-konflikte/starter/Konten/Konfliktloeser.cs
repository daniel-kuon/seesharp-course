using Microsoft.EntityFrameworkCore;

namespace Konten;

public static class Konfliktloeser
{
    /// <summary>
    /// Wendet aenderung auf das Konto an, zählt die Version hoch und speichert. Hat jemand anderes dieselbe
    /// Zeile inzwischen geändert (DbUpdateConcurrencyException), wird das Konto neu aus der Datenbank geladen
    /// (Reload), die Änderung auf den frischen Stand ERNEUT angewendet und noch EIN Mal gespeichert.
    /// Scheitert auch das, bleibt die Ausnahme beim Aufrufer. Liefert die Zahl der Versuche (1 oder 2).
    /// </summary>
    public static int Speichere(KontoContext kontext, Konto konto, Action<Konto> aenderung)
    {
        // TODO: aenderung(konto); konto.Version++; try { kontext.SaveChanges(); return 1; }
        //       catch (DbUpdateConcurrencyException) { kontext.Entry(konto).Reload(); ... zweiter Versuch ... }
        throw new NotImplementedException();
    }
}
