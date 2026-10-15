using System.Numerics;

public static class Rechner {
    // Summe beliebig vieler Werte eines Typs, der den Plusoperator über IAdditionOperators zusichert.
    // Funktioniert für int, double, decimal, ... und für Bruch.
    public static T Summe<T>(T first, params T[] rest) where T : IAdditionOperators<T, T, T> {
        // TODO
        throw new NotImplementedException();
    }
}

// Eigenes Interface mit statischem abstraktem Operator (9.1.2.2): Jeder implementierende Typ
// muss operator + bereitstellen.
public interface IKombinierbar<TSelf> where TSelf : IKombinierbar<TSelf> {
    static abstract TSelf operator +(TSelf first, TSelf second);
}

public class Glas(string sticker) : IKombinierbar<Glas> {
    public string Sticker { get; } = sticker;

    // TODO: operator + verbindet beide Sticker mit einem Leerzeichen zu einem neuen Glas
    public static Glas operator +(Glas first, Glas second) {
        throw new NotImplementedException();
    }
}

public class Gras(int size) : IKombinierbar<Gras> {
    public int Size { get; } = size;

    // TODO: operator + addiert die Größen zu einem neuen Gras
    public static Gras operator +(Gras first, Gras second) {
        throw new NotImplementedException();
    }
}

public static class Kombinierer {
    // Kombiniert alle Elemente mit dem Plusoperator des Typs (mindestens ein Element).
    public static T Combine<T>(params T[] elements) where T : IKombinierbar<T> {
        // TODO
        throw new NotImplementedException();
    }
}
