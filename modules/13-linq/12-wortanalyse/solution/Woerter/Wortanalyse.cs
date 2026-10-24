public static class Wortanalyse
{
    // vorgegeben
    private static readonly char[] Trenner = [' ', ',', '.', '!', '?', ';', ':', '\r', '\t', '-', '(', ')', '"'];

    public static List<string> Woerter(string text) =>
        text.Split('\n')
            .SelectMany(zeile => zeile.Split(Trenner, StringSplitOptions.RemoveEmptyEntries))
            .Select(w => w.ToLowerInvariant())
            .ToList();

    public static List<(string Wort, int Anzahl)> Haeufigste(string text, int n) =>
        Woerter(text)
            .CountBy(w => w)
            .OrderByDescending(paar => paar.Value)
            .ThenBy(paar => paar.Key, StringComparer.Ordinal)
            .Take(n)
            .Select(paar => (paar.Key, paar.Value))
            .ToList();

    public static Dictionary<char, List<string>> ProAnfangsbuchstabe(string text) =>
        Woerter(text)
            .Distinct()
            .GroupBy(w => w[0])
            .ToDictionary(g => g.Key, g => g.Order(StringComparer.Ordinal).ToList());

    public static List<string> LaengsteWoerter(string text)
    {
        var verschiedene = Woerter(text).Distinct().ToList();
        if (verschiedene.Count == 0) return [];
        int laenge = verschiedene.Max(w => w.Length);
        return verschiedene.Where(w => w.Length == laenge).Order(StringComparer.Ordinal).ToList();
    }
}
