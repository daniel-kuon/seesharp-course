using static TupelListeMaut.Geste;

namespace TupelListeMaut;

public static class SchereSteinPapier
{
    // TODO: EIN switch-Ausdruck über das Tupel (a, b):
    //       (Schere, Papier), (Papier, Stein) und (Stein, Schere) gewinnt der Erste;
    //       sind beide Gesten gleich (var x, var y) when x == y, ist es unentschieden;
    //       sonst gewinnt der Zweite.
    public static Ergebnis Sieger(Geste a, Geste b)
    {
        throw new NotImplementedException();
    }
}

public static class Lauf
{
    // TODO: Tupelmuster über (minuten, maenner), Relationsmuster in den Positionen:
    //       Männer: unter 30 "Spitze", unter 40 "Gut", unter 55 "Durchschnitt", sonst "Genießer".
    //       Frauen: dieselben Stufen bei 35, 45 und 65 Minuten.
    //       minuten <= 0 wirft ArgumentOutOfRangeException (als Arm mit throw-Ausdruck).
    public static string Langstrecke(int minuten, bool maenner)
    {
        throw new NotImplementedException();
    }
}

public static class Listen
{
    // TODO: Listenmuster, in dieser Reihenfolge:
    //       []                  -> "leer"
    //       [var x]             -> "ein Element: 7"
    //       [1, .., 9]          -> "von 1 bis 9"
    //       [_, _]              -> "zwei Elemente"
    //       [_, _, .. var rest] -> "mehr als zwei, Rest: 2" (Länge von rest)
    public static string Beschreibe(int[] a)
    {
        throw new NotImplementedException();
    }
}
