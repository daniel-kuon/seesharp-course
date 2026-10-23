using System.Collections;

// Ganzzahlbereich von Start bis höchstens Ende (einschließlich) mit Schrittweite:
// new Bereich(1, 10, 3) liefert 1, 4, 7, 10; new Bereich(5, 1, -2) liefert 5, 3, 1.
public class Bereich : IEnumerable<int> {
    public int Start { get; }
    public int Ende { get; }
    public int Schritt { get; }

    public Bereich(int start, int ende, int schritt = 1) {
        if (schritt == 0)
            throw new ArgumentOutOfRangeException(nameof(schritt));
        Start = start;
        Ende = ende;
        Schritt = schritt;
    }

    // Anzahl der Werte, ohne sie zu durchlaufen.
    public int Count {
        get {
            if (Schritt > 0 ? Ende < Start : Ende > Start)
                return 0;
            return (Ende - Start) / Schritt + 1;
        }
    }

    // Liegt zahl auf einem der Schritte? Ohne Durchlauf.
    public bool Enthaelt(int zahl) {
        int abstand = zahl - Start;
        if (abstand % Schritt != 0)
            return false;
        int index = abstand / Schritt;
        return index >= 0 && index < Count;
    }

    public IEnumerator<int> GetEnumerator() {
        for (int i = 0; i < Count; i++)
            yield return Start + i * Schritt;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Benannter Iterator als Eigenschaft: dieselben Werte rückwärts.
    public IEnumerable<int> Rueckwaerts {
        get {
            for (int i = Count - 1; i >= 0; i--)
                yield return Start + i * Schritt;
        }
    }

    // Benannter Iterator als Methode: nur Werte, die durch teiler teilbar sind.
    public IEnumerable<int> Vielfache(int teiler) {
        if (teiler == 0)
            yield break;
        foreach (int x in this)
            if (x % teiler == 0)
                yield return x;
    }
}

public static class Folgen {
    // Unendliche Folge 1, 4, 9, 16, ...
    public static IEnumerable<long> Quadratzahlen() {
        for (long n = 1; ; n++)
            yield return n * n;
    }

    // Höchstens die ersten anzahl Werte von quelle.
    public static IEnumerable<T> Erste<T>(IEnumerable<T> quelle, int anzahl) {
        if (anzahl <= 0)
            yield break;
        int geliefert = 0;
        foreach (T wert in quelle) {
            yield return wert;
            if (++geliefert == anzahl)
                yield break;
        }
    }
}
