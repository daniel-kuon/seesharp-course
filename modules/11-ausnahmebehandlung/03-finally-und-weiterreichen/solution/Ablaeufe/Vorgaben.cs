// Vorgegeben, nicht ändern.

// Ein Arbeitsschritt, der gelingen oder mit einer Ausnahme scheitern kann.
public interface IArbeitsschritt
{
    void Ausfuehren();
}

// Ein einfaches Protokoll: Jede Zeile ist ein Text.
public class Protokoll
{
    public List<string> Zeilen { get; } = new();

    public void Schreibe(string zeile)
    {
        Zeilen.Add(zeile);
    }
}
