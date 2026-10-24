using static TupelListeMaut.Geste;

namespace TupelListeMaut;

public static class SchereSteinPapier
{
    public static Ergebnis Sieger(Geste a, Geste b) => (a, b) switch
    {
        (Schere, Papier) or (Papier, Stein) or (Stein, Schere) => Ergebnis.Erster,
        (var x, var y) when x == y => Ergebnis.Unentschieden,
        _ => Ergebnis.Zweiter
    };
}

public static class Lauf
{
    /// <summary>Bewertet eine 10-km-Zeit; Männer und Frauen haben verschiedene Grenzen.</summary>
    public static string Langstrecke(int minuten, bool maenner) => (minuten, maenner) switch
    {
        (<= 0, _) => throw new ArgumentOutOfRangeException(nameof(minuten)),
        (< 30, true) or (< 35, false) => "Spitze",
        (< 40, true) or (< 45, false) => "Gut",
        (< 55, true) or (< 65, false) => "Durchschnitt",
        _ => "Genießer"
    };
}

public static class Listen
{
    public static string Beschreibe(int[] a) => a switch
    {
        [] => "leer",
        [var x] => $"ein Element: {x}",
        [1, .., 9] => "von 1 bis 9",
        [_, _] => "zwei Elemente",
        [_, _, .. var rest] => $"mehr als zwei, Rest: {rest.Length}"
    };
}
