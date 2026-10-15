using System.Numerics;

public static class Rechner {
    // Summe beliebig vieler Werte eines Typs, der den Plusoperator über IAdditionOperators zusichert.
    // Funktioniert für int, double, decimal, ... und für Bruch.
    public static T Summe<T>(T first, params T[] rest) where T : IAdditionOperators<T, T, T> {
        T summe = first;
        foreach (T r in rest)
            summe += r;
        return summe;
    }
}

// Eigenes Interface mit statischem abstraktem Operator (9.1.2.2): Jeder implementierende Typ
// muss operator + bereitstellen.
public interface IKombinierbar<TSelf> where TSelf : IKombinierbar<TSelf> {
    static abstract TSelf operator +(TSelf first, TSelf second);
}

public class Glas(string sticker) : IKombinierbar<Glas> {
    public string Sticker { get; } = sticker;

    public static Glas operator +(Glas first, Glas second) => new(first.Sticker + " " + second.Sticker);
}

public class Gras(int size) : IKombinierbar<Gras> {
    public int Size { get; } = size;

    public static Gras operator +(Gras first, Gras second) => new(first.Size + second.Size);
}

public static class Kombinierer {
    // Kombiniert alle Elemente mit dem Plusoperator des Typs (mindestens ein Element).
    public static T Combine<T>(params T[] elements) where T : IKombinierbar<T> {
        T chain = elements[0];
        for (int i = 1; i < elements.Length; i++)
            chain += elements[i];
        return chain;
    }
}
