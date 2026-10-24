namespace Messreihen;

public static class Messreihe
{
    public static string Trend(int[] werte) => werte switch
    {
        [] => "leer",
        [_] => "einzeln",
        [var a, var b, var c] when a < b && b < c => "steigend",
        [.., > 100] => "Ausreißer am Ende",
        _ => "sonstige"
    };

    /// <summary>Erstes Element und Anzahl der restlichen; (null, 0) für eine leere Liste.</summary>
    public static (string? Kopf, int Uebrige) Kopf(List<string> liste) => liste switch
    {
        [var kopf, .. var rest] => (kopf, rest.Count),
        _ => (null, 0)
    };
}
