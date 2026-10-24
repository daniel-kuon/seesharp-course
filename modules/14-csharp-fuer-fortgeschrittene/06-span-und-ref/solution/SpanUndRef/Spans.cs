namespace SpanUndRef;

public static class Spans
{
    /// <summary>Summe über Array, Array-Ausschnitt, String-Zeichen oder stackalloc-Puffer, ohne Kopie.</summary>
    public static int Summe(ReadOnlySpan<int> werte)
    {
        int summe = 0;
        foreach (var w in werte) summe += w;
        return summe;
    }

    /// <summary>Zählt Wörter (durch Leerzeichen getrennt), ohne Teilstrings zu erzeugen.</summary>
    public static int ZaehleWoerter(ReadOnlySpan<char> text)
    {
        int anzahl = 0;
        while (true)
        {
            text = text.TrimStart(' ');
            if (text.IsEmpty) return anzahl;
            anzahl++;
            int ende = text.IndexOf(' ');
            if (ende < 0) return anzahl;
            text = text[ende..];
        }
    }

    /// <summary>Kehrt die Elemente des Ausschnitts um; das zugrunde liegende Array ändert sich.</summary>
    public static void SpiegleInPlace(Span<int> werte)
    {
        for (int i = 0, j = werte.Length - 1; i < j; i++, j--)
            (werte[i], werte[j]) = (werte[j], werte[i]);
    }

    /// <summary>Verweis auf das größte Element: Hoechster(a) = 0 setzt es im Array auf 0.</summary>
    public static ref int Hoechster(int[] a)
    {
        ref int m = ref a[0];
        for (int i = 1; i < a.Length; i++)
            if (a[i] > m) m = ref a[i];
        return ref m;
    }

    /// <summary>Verweis auf den hellsten Messpunkt, nur lesbar und ohne die große Struktur zu kopieren.</summary>
    public static ref readonly Messpunkt Hellster(Messpunkt[] a)
    {
        ref readonly Messpunkt m = ref a[0];
        for (int i = 1; i < a.Length; i++)
            if (a[i].Helligkeit > m.Helligkeit) m = ref a[i];
        return ref m;
    }
}
