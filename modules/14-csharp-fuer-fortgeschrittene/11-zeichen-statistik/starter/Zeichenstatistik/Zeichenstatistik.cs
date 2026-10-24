namespace Zeichenstatistik;

public static class Statistik
{
    // TODO: Zähle die Vokale a, e, i, o, u sowie ä, ö, ü, groß oder klein.
    //       Der Text kommt als Span an; es sollen keine Strings entstehen.
    public static int ZaehleVokale(ReadOnlySpan<char> text)
    {
        throw new NotImplementedException();
    }

    // TODO: Liefere das erste Wort als Ausschnitt des Eingabetexts (kein Substring):
    //       führende Leerzeichen überspringen (TrimStart), dann bis zum nächsten Leerzeichen.
    //       Für leeren Text oder nur Leerzeichen kommt ein leerer Ausschnitt heraus.
    public static ReadOnlySpan<char> ErstesWort(ReadOnlySpan<char> text)
    {
        throw new NotImplementedException();
    }

    // TODO: Summe der Werte von Index von (einschließlich) bis bis (ausschließlich),
    //       gebildet über einen Ausschnitt werte[von..bis]. Bei ungültigen Grenzen
    //       (von < 0, bis > Länge, von > bis) ArgumentOutOfRangeException werfen.
    public static int Teilsumme(ReadOnlySpan<int> werte, int von, int bis)
    {
        throw new NotImplementedException();
    }
}
