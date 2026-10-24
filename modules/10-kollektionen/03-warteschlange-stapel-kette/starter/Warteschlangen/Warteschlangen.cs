// Vier kleine Klassen auf Basis von Queue<T>, Stack<T> und LinkedList<T>.

// Aufträge werden in der Reihenfolge bearbeitet, in der sie eintreffen (FIFO).
public class Druckerwarteschlange
{
    readonly Queue<string> auftraege = new();

    // Anzahl der wartenden Aufträge.
    public int Anzahl
    {
        get
        {
            // TODO
            throw new NotImplementedException();
        }
    }

    public void Einreihen(string auftrag)
    {
        // TODO: Enqueue
        throw new NotImplementedException();
    }

    // Entnimmt den ältesten Auftrag; null, wenn nichts wartet.
    // Dequeue() auf einer leeren Queue wirft eine Ausnahme: erst Count prüfen.
    public string? Naechster()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Zeigt den ältesten Auftrag, ohne ihn zu entnehmen; null, wenn nichts wartet.
    public string? Peek()
    {
        // TODO
        throw new NotImplementedException();
    }
}

public static class KlammernPruefer
{
    // true, wenn jede öffnende Klammer ()[]{} richtig geschlossen wird.
    // Andere Zeichen werden ignoriert. Idee: Öffnende Klammern auf einen
    // Stack<char> legen; eine schließende Klammer muss zur obersten passen.
    // Vorsicht: Eine schließende Klammer bei leerem Stapel ist ein Fehler.
    public static bool IstAusgeglichen(string text)
    {
        // TODO
        throw new NotImplementedException();
    }
}

// Browserverlauf mit zwei Stapeln (zurück und vor).
public class Verlauf
{
    readonly Stack<string> rueckwaerts = new();
    readonly Stack<string> vorwaerts = new();

    // Die Seite, die gerade angezeigt wird; null vor dem ersten Besuch.
    public string? Aktuell { get; private set; }

    // Zeigt eine neue Seite an. Die bisherige Seite wandert auf den Zurück-Stapel,
    // der Vor-Stapel wird geleert.
    public void Besuche(string seite)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Geht eine Seite zurück und liefert sie. Gibt es keine frühere Seite: null, Aktuell bleibt.
    public string? Zurueck()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Geht eine Seite vor und liefert sie. Gibt es keine: null, Aktuell bleibt.
    public string? Vor()
    {
        // TODO
        throw new NotImplementedException();
    }
}

// "Zuletzt geöffnet": der neueste Name steht vorn, höchstens kapazitaet Namen.
public class ZuletztGeoeffnet(int kapazitaet)
{
    readonly LinkedList<string> namen = new();

    // Stellt name an den Anfang. Ist er schon vorhanden, wird er verschoben (kein Duplikat).
    // Sind danach mehr als kapazitaet Namen da, fällt der letzte weg.
    public void Oeffne(string name)
    {
        // TODO: Remove, AddFirst, RemoveLast
        throw new NotImplementedException();
    }

    // Vom neuesten zum ältesten Namen (First und Next).
    public List<string> Liste()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Vom ältesten zum neuesten Namen (Last und Previous).
    public List<string> ListeRueckwaerts()
    {
        // TODO
        throw new NotImplementedException();
    }
}
