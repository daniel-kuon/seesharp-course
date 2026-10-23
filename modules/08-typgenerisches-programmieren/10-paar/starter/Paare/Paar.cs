// Ein Paar aus zwei Werten beliebiger, auch verschiedener Typen.
public class Paar<T1, T2> {
    public T1 Erstes { get; }
    public T2 Zweites { get; }

    public Paar(T1 erstes, T2 zweites) {
        // TODO
        throw new NotImplementedException();
    }

    // Neues Paar mit vertauschten Werten (und Typen).
    public Paar<T2, T1> Getauscht() {
        // TODO
        throw new NotImplementedException();
    }

    // Neues Paar, dessen erster Wert ersetzt ist; der neue Wert darf einen anderen Typ haben.
    public Paar<TNeu, T2> MitErstem<TNeu>(TNeu neu) {
        // TODO
        throw new NotImplementedException();
    }

    // TODO: ToString() überschreiben: "(erstes, zweites)"
}

// Nicht generische Hilfsklasse mit Fabrikmethoden.
public static class Paar {
    // Paar.Von(1, "eins") -> Paar<int, string>, Typargumente per Inferenz.
    public static Paar<T1, T2> Von<T1, T2>(T1 erstes, T2 zweites) {
        // TODO
        throw new NotImplementedException();
    }

    // Paar zweier gleichartiger Werte, das kleinere zuerst.
    public static Paar<T, T> Geordnet<T>(T a, T b) where T : IComparable<T> {
        // TODO: CompareTo
        throw new NotImplementedException();
    }
}
