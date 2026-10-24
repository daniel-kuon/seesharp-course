using System.Runtime.CompilerServices;

namespace InlineUndParams;

/// <summary>Ein Inline-Array: acht int-Werte direkt in der Struktur, ohne eigenes Array-Objekt.</summary>
[InlineArray(8)]
public struct Puffer8
{
    private int _element0;
}

public static class Puffer8Werkzeuge
{
    /// <summary>Schreibt start, start + 1, ... in die acht Plätze.</summary>
    public static void Fuelle(ref Puffer8 p, int start)
    {
        for (int i = 0; i < 8; i++)
            p[i] = start + i;
    }

    /// <summary>Summe aller acht Elemente über einen Span.</summary>
    public static int Summe(in Puffer8 p)
    {
        ReadOnlySpan<int> s = p;
        int summe = 0;
        foreach (var w in s) summe += w;
        return summe;
    }

    /// <summary>Liest ein Element über den Indexer des Inline-Arrays.</summary>
    public static int Lies(in Puffer8 p, int index) => p[index];
}
