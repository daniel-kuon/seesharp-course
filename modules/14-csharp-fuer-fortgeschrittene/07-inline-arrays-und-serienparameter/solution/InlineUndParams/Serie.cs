namespace InlineUndParams;

public static class Serie
{
    /// <summary>Summe beliebig vieler Zahlen; params ReadOnlySpan kann ohne Heap-Array auskommen.</summary>
    public static int Summe(params ReadOnlySpan<int> werte)
    {
        int summe = 0;
        foreach (var w in werte) summe += w;
        return summe;
    }

    /// <summary>Verbindet die Teile mit "-".</summary>
    public static string Verbinde(params IEnumerable<string> teile) => string.Join("-", teile);

    /// <summary>Anzahl der übergebenen Elemente.</summary>
    public static int Zaehle<T>(params List<T> items) => items.Count;
}
