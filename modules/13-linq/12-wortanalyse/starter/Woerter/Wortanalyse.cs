public static class Wortanalyse
{
    // vorgegeben
    private static readonly char[] Trenner = [' ', ',', '.', '!', '?', ';', ':', '\r', '\t', '-', '(', ')', '"'];

    // TODO: text.Split('\n'), SelectMany über zeile.Split(Trenner, StringSplitOptions.RemoveEmptyEntries),
    // ToLowerInvariant, ToList
    public static List<string> Woerter(string text) => throw new NotImplementedException();

    // TODO: Woerter(text).CountBy(...), absteigend nach Anzahl, dann nach Wort (Ordinal), Take(n)
    public static List<(string Wort, int Anzahl)> Haeufigste(string text, int n) => throw new NotImplementedException();

    // TODO: verschiedene Wörter, GroupBy(erster Buchstabe), ToDictionary mit sortierter Liste je Gruppe
    public static Dictionary<char, List<string>> ProAnfangsbuchstabe(string text) => throw new NotImplementedException();

    // TODO: größte Länge bestimmen (Max), alle verschiedenen Wörter dieser Länge sortiert; leerer Text: leere Liste
    public static List<string> LaengsteWoerter(string text) => throw new NotImplementedException();
}
