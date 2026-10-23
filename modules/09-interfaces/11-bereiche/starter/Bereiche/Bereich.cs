using System.Collections;

// Ganzzahlbereich von Start bis höchstens Ende (einschließlich) mit Schrittweite:
// new Bereich(1, 10, 3) liefert 1, 4, 7, 10; new Bereich(5, 1, -2) liefert 5, 3, 1.
public class Bereich : IEnumerable<int> {
    public int Start { get; }
    public int Ende { get; }
    public int Schritt { get; }

    public Bereich(int start, int ende, int schritt = 1) {
        // TODO: schritt == 0 -> ArgumentOutOfRangeException
        throw new NotImplementedException();
    }

    // Anzahl der Werte, ohne sie zu durchlaufen (falsche Richtung: 0).
    public int Count => throw new NotImplementedException();

    // Liegt zahl auf einem der Schritte? Ohne Durchlauf.
    public bool Enthaelt(int zahl) {
        // TODO
        throw new NotImplementedException();
    }

    public IEnumerator<int> GetEnumerator() {
        // TODO: yield return
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Benannter Iterator als Eigenschaft: dieselben Werte rückwärts.
    public IEnumerable<int> Rueckwaerts => throw new NotImplementedException();

    // Benannter Iterator als Methode: nur Werte, die durch teiler teilbar sind; teiler 0 -> yield break.
    public IEnumerable<int> Vielfache(int teiler) {
        // TODO
        throw new NotImplementedException();
    }
}

public static class Folgen {
    // Unendliche Folge 1, 4, 9, 16, ... (nicht in einem Array sammeln!)
    public static IEnumerable<long> Quadratzahlen() {
        // TODO
        throw new NotImplementedException();
    }

    // Höchstens die ersten anzahl Werte von quelle; danach yield break.
    public static IEnumerable<T> Erste<T>(IEnumerable<T> quelle, int anzahl) {
        // TODO
        throw new NotImplementedException();
    }
}
