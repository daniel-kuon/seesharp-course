namespace SpanUndRef;

public static class SpanErweiterungen
{
    // C# 14: Ein extension-Block macht IstPalindrom zu einem Mitglied von ReadOnlySpan<char>.
    // Dank der impliziten Span-Konvertierungen ist sie auch auf string und char[] aufrufbar.
    extension(ReadOnlySpan<char> s)
    {
        // TODO: Der Text liest sich vorwärts wie rückwärts (Groß-/Kleinschreibung zählt; der
        //       leere Text ist ein Palindrom). Vergleiche von vorn und hinten, ohne Kopie.
        public bool IstPalindrom()
        {
            throw new NotImplementedException();
        }
    }
}
