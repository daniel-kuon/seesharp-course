namespace EigeneRessource;

/// <summary>
/// Ein Logbuch, das eine Datei offen hält und deshalb freigegeben werden muss.
/// </summary>
// TODO: Mach die Klasse zu einer sauberen IDisposable-Klasse (Buch 16.2.1 und 5.4.5):
//       - Dispose() schließt den StreamWriter.
//       - Dispose() ist idempotent: Ein zweiter Aufruf tut nichts (insbesondere zählt
//         Offene nur einmal herunter).
//       - Nach Dispose() wirft Eintrag(...) eine ObjectDisposedException
//         (ObjectDisposedException.ThrowIf(bedingung, this)).
//       - Offene wird im Konstruktor hochgezählt, aber erst NACH dem erfolgreichen Öffnen
//         der Datei, und in Dispose() genau einmal heruntergezählt.
//       Einen Finalizer (~Logbuch) brauchst du nicht: Die Klasse hält nur ein verwaltetes Objekt,
//       keine rohe Ressource.
public sealed class Logbuch : IDisposable
{
    readonly StreamWriter _schreiber;

    /// <summary>Anzahl der Logbücher, die erzeugt und noch nicht freigegeben wurden.</summary>
    public static int Offene { get; private set; }

    public string Pfad { get; }

    public Logbuch(string pfad)
    {
        _schreiber = new StreamWriter(pfad);
        Pfad = pfad;
        Offene++;
    }

    public void Eintrag(string text)
    {
        _schreiber.WriteLine(text);
    }

    public void Dispose()
    {
        // TODO
    }
}
