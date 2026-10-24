// Eine Warteschlange (FIFO), die von mehreren Threads gleichzeitig benutzt werden darf.
// Intern steckt eine gewöhnliche Queue<T>, die das nicht verträgt: Jeder Zugriff gehört unter dasselbe lock.
public class SichereWarteschlange<T>
{
    // TODO: Eine Queue<T> und ein privates Sperrobjekt (readonly object) als Felder anlegen.

    // Hängt element hinten an.
    public void Einreihen(T element)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Entnimmt das vorderste Element. Ist die Warteschlange leer, liefert die Methode false (element = default).
    // Prüfen (Count > 0) und Entnehmen (Dequeue) müssen unter EINEM lock zusammen stehen: Sonst kann ein
    // anderer Thread dazwischen das letzte Element wegnehmen.
    public bool TryNaechster(out T? element)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die Anzahl der wartenden Elemente.
    public int Anzahl
    {
        get
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
