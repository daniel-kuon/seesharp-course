namespace Messreihen;

public static class Messreihe
{
    // TODO: switch-Ausdruck mit Listenmustern, in dieser Reihenfolge:
    //       []                                  -> "leer"
    //       genau ein Element                   -> "einzeln"
    //       drei Elemente, streng aufsteigend   -> "steigend"
    //                                              ([var a, var b, var c] when a < b && b < c)
    //       beliebig viele Elemente, das letzte über 100 ([.., > 100]) -> "Ausreißer am Ende"
    //       alles andere                        -> "sonstige"
    public static string Trend(int[] werte)
    {
        throw new NotImplementedException();
    }

    // TODO: Erstes Element und Anzahl der restlichen Elemente, mit dem Listenmuster [var kopf, .. var rest].
    //       Für eine leere Liste (null, 0).
    public static (string? Kopf, int Uebrige) Kopf(List<string> liste)
    {
        throw new NotImplementedException();
    }
}
