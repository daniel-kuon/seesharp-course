namespace EigeneRessource;

/// <summary>
/// Ein Logbuch, das eine Datei offen hält und deshalb freigegeben werden muss.
/// Die Klasse hält nur ein verwaltetes Objekt (den StreamWriter), keine rohe Ressource;
/// deshalb braucht sie keinen Finalizer (Buch 16.2.2).
/// </summary>
public sealed class Logbuch : IDisposable
{
    readonly StreamWriter _schreiber;
    bool _freigegeben;

    /// <summary>Anzahl der Logbücher, die erzeugt und noch nicht freigegeben wurden.</summary>
    public static int Offene { get; private set; }

    public string Pfad { get; }

    public Logbuch(string pfad)
    {
        _schreiber = new StreamWriter(pfad);
        Pfad = pfad;
        Offene++; // erst nach dem erfolgreichen Öffnen: Scheitert der Konstruktor, gibt es nichts freizugeben
    }

    public void Eintrag(string text)
    {
        ObjectDisposedException.ThrowIf(_freigegeben, this);
        _schreiber.WriteLine(text);
    }

    public void Dispose()
    {
        if (_freigegeben)
            return;
        _freigegeben = true;
        Offene--;
        _schreiber.Dispose();
    }
}
