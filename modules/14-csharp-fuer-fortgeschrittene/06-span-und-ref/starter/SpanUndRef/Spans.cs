namespace SpanUndRef;

public static class Spans
{
    // TODO: Summe ohne Kopie. Dank ReadOnlySpan<int> ist die Methode mit einem Array, einem
    //       Ausschnitt (a.AsSpan(2, 3)) und einem stackalloc-Puffer aufrufbar.
    public static int Summe(ReadOnlySpan<int> werte)
    {
        throw new NotImplementedException();
    }

    // TODO: Wörter zählen (durch Leerzeichen getrennt, mehrere Leerzeichen hintereinander
    //       zählen nicht doppelt) mit Slicing: TrimStart, IndexOf, text[ende..].
    //       Es dürfen keine Teilstrings entstehen.
    public static int ZaehleWoerter(ReadOnlySpan<char> text)
    {
        throw new NotImplementedException();
    }

    // TODO: Kehre die Elemente an Ort und Stelle um (Tausch von vorn und hinten). Wird ein
    //       Ausschnitt übergeben (a.AsSpan(1, 3)), ändert sich nur dieser Teil des Arrays.
    public static void SpiegleInPlace(Span<int> werte)
    {
        throw new NotImplementedException();
    }

    // TODO: Verweis auf das größte Element, sodass Hoechster(a) = 0; das Element im Array
    //       auf 0 setzt. Hinweis: ref int m = ref a[0]; ... m = ref a[i]; ... return ref m;
    public static ref int Hoechster(int[] a)
    {
        throw new NotImplementedException();
    }

    // TODO: Verweis auf den Messpunkt mit der größten Helligkeit, ohne die Struktur zu kopieren
    //       (lokale Variable ref readonly Messpunkt m = ref a[0]; ...).
    public static ref readonly Messpunkt Hellster(Messpunkt[] a)
    {
        throw new NotImplementedException();
    }
}
