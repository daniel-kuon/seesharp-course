namespace InlineUndParams;

// C# 13 erlaubt Serienparameter mit Kollektionstyp (Buch 15.6). Bisher brauchte man für jeden Fall
// eine eigene Überladung (15.6.2): ein params-Array für die Einzelwerte und eine Überladung für
// vorhandene Kollektionen. Die Methoden hier sind noch so gebaut.
//
// TODO: Fasse jede Gruppe zu EINER Methode zusammen und lösche die überzähligen Überladungen:
//       Summe:    params ReadOnlySpan<int> werte       (kann ohne Heap-Array auskommen)
//       Verbinde: params IEnumerable<string> teile
//       Zaehle:   params List<T> items
public static class Serie
{
    // Summe beliebig vieler Zahlen.
    public static int Summe(params int[] werte)
    {
        throw new NotImplementedException();
    }

    // Verbindet die Teile mit "-" (string.Join).
    public static string Verbinde(params string[] teile)
    {
        throw new NotImplementedException();
    }

    public static string Verbinde(IEnumerable<string> teile)
    {
        throw new NotImplementedException();
    }

    // Anzahl der übergebenen Elemente.
    public static int Zaehle<T>(params T[] items)
    {
        throw new NotImplementedException();
    }

    public static int Zaehle<T>(List<T> items)
    {
        throw new NotImplementedException();
    }
}
