using System.Runtime.CompilerServices;

namespace InlineUndParams;

// TODO: Mache aus dieser Struktur ein Inline-Array für acht int-Werte: das Attribut
//       [InlineArray(8)] auf der Struktur, die Struktur selbst enthält genau ein Feld.
//       Danach ist sie 32 Byte groß und lässt sich wie ein Array mit p[i] ansprechen.
public struct Puffer8
{
    private int _element0;
}

public static class Puffer8Werkzeuge
{
    // TODO: Schreibt start, start + 1, ... in die acht Plätze (Indexer p[i]).
    public static void Fuelle(ref Puffer8 p, int start)
    {
        throw new NotImplementedException();
    }

    // TODO: Summe aller acht Elemente. Ein Inline-Array lässt sich einem Span zuweisen:
    //       ReadOnlySpan<int> s = p;
    public static int Summe(in Puffer8 p)
    {
        throw new NotImplementedException();
    }

    // TODO: Liest ein Element über den Indexer.
    public static int Lies(in Puffer8 p, int index)
    {
        throw new NotImplementedException();
    }
}
