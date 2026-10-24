// Vier kleine Klassen auf Basis von Queue<T>, Stack<T> und LinkedList<T>.

// Aufträge werden in der Reihenfolge bearbeitet, in der sie eintreffen (FIFO).
public class Druckerwarteschlange
{
    readonly Queue<string> auftraege = new();

    public int Anzahl => auftraege.Count;

    public void Einreihen(string auftrag)
    {
        auftraege.Enqueue(auftrag);
    }

    // Entnimmt den ältesten Auftrag; null, wenn nichts wartet.
    public string? Naechster()
    {
        return auftraege.Count > 0 ? auftraege.Dequeue() : null;
    }

    // Zeigt den ältesten Auftrag, ohne ihn zu entnehmen; null, wenn nichts wartet.
    public string? Peek()
    {
        return auftraege.Count > 0 ? auftraege.Peek() : null;
    }
}

public static class KlammernPruefer
{
    // true, wenn jede öffnende Klammer ()[]{} richtig geschlossen wird.
    // Andere Zeichen werden ignoriert.
    public static bool IstAusgeglichen(string text)
    {
        var offen = new Stack<char>();
        foreach (char c in text)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    offen.Push(c);
                    break;
                case ')':
                    if (offen.Count == 0 || offen.Pop() != '(') return false;
                    break;
                case ']':
                    if (offen.Count == 0 || offen.Pop() != '[') return false;
                    break;
                case '}':
                    if (offen.Count == 0 || offen.Pop() != '{') return false;
                    break;
            }
        }
        return offen.Count == 0;
    }
}

// Browserverlauf mit zwei Stapeln.
public class Verlauf
{
    readonly Stack<string> rueckwaerts = new();
    readonly Stack<string> vorwaerts = new();

    // Die Seite, die gerade angezeigt wird; null vor dem ersten Besuch.
    public string? Aktuell { get; private set; }

    public void Besuche(string seite)
    {
        if (Aktuell != null)
            rueckwaerts.Push(Aktuell);
        Aktuell = seite;
        vorwaerts.Clear();
    }

    // Geht eine Seite zurück und liefert sie. Gibt es keine frühere Seite: null, Aktuell bleibt.
    public string? Zurueck()
    {
        if (rueckwaerts.Count == 0)
            return null;
        vorwaerts.Push(Aktuell!);
        Aktuell = rueckwaerts.Pop();
        return Aktuell;
    }

    // Geht eine Seite vor und liefert sie. Gibt es keine: null, Aktuell bleibt.
    public string? Vor()
    {
        if (vorwaerts.Count == 0)
            return null;
        rueckwaerts.Push(Aktuell!);
        Aktuell = vorwaerts.Pop();
        return Aktuell;
    }
}

// "Zuletzt geöffnet": der neueste Name steht vorn, höchstens kapazitaet Namen.
public class ZuletztGeoeffnet(int kapazitaet)
{
    readonly LinkedList<string> namen = new();

    public void Oeffne(string name)
    {
        namen.Remove(name);
        namen.AddFirst(name);
        if (namen.Count > kapazitaet)
            namen.RemoveLast();
    }

    // Vom neuesten zum ältesten Namen.
    public List<string> Liste()
    {
        var ergebnis = new List<string>();
        for (var knoten = namen.First; knoten != null; knoten = knoten.Next)
            ergebnis.Add(knoten.Value);
        return ergebnis;
    }

    // Vom ältesten zum neuesten Namen, über Last und Previous.
    public List<string> ListeRueckwaerts()
    {
        var ergebnis = new List<string>();
        for (var knoten = namen.Last; knoten != null; knoten = knoten.Previous)
            ergebnis.Add(knoten.Value);
        return ergebnis;
    }
}
