namespace Zeichenstatistik;

public static class Statistik
{
    /// <summary>Zählt Vokale (a, e, i, o, u und Umlaute, groß wie klein).</summary>
    public static int ZaehleVokale(ReadOnlySpan<char> text)
    {
        int anzahl = 0;
        foreach (char c in text)
            if ("aeiouäöüAEIOUÄÖÜ".Contains(c)) anzahl++;
        return anzahl;
    }

    /// <summary>Erstes Wort als Ausschnitt des Eingabetexts, ohne Kopie.</summary>
    public static ReadOnlySpan<char> ErstesWort(ReadOnlySpan<char> text)
    {
        text = text.TrimStart(' ');
        int ende = text.IndexOf(' ');
        return ende < 0 ? text : text[..ende];
    }

    /// <summary>Summe der Werte von Index von (einschließlich) bis bis (ausschließlich).</summary>
    public static int Teilsumme(ReadOnlySpan<int> werte, int von, int bis)
    {
        if (von < 0 || bis > werte.Length || von > bis)
            throw new ArgumentOutOfRangeException(nameof(von));
        int summe = 0;
        foreach (int w in werte[von..bis]) summe += w;
        return summe;
    }
}
