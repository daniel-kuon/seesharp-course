public record Dateieintrag(string Pfad, long Groesse, string Hash);

public static class Auswertung
{
    public static List<List<string>> Duplikate(IEnumerable<Dateieintrag> eintraege) =>
        eintraege
            .GroupBy(e => (e.Groesse, e.Hash))
            .Where(g => g.Count() > 1)
            .Select(g => g.Select(e => e.Pfad).Order(StringComparer.Ordinal).ToList())
            .OrderBy(pfade => pfade[0], StringComparer.Ordinal)
            .ToList();

    private static string Endung(Dateieintrag e) => Path.GetExtension(e.Pfad).ToLowerInvariant();

    public static List<(string Endung, long Summe)> SpeicherProEndung(IEnumerable<Dateieintrag> eintraege) =>
        eintraege
            .GroupBy(Endung)
            .Select(g => (Endung: g.Key, Summe: g.Sum(e => e.Groesse)))
            .OrderByDescending(x => x.Summe)
            .ThenBy(x => x.Endung, StringComparer.Ordinal)
            .ToList();

    public static Dictionary<string, int> Haeufigkeiten(IEnumerable<string> werte) =>
        werte.CountBy(w => w).ToDictionary(paar => paar.Key, paar => paar.Value);

    public static Dictionary<string, long> GroesseProEndung(IEnumerable<Dateieintrag> eintraege) =>
        eintraege
            .AggregateBy(Endung, 0L, (summe, e) => summe + e.Groesse)
            .ToDictionary(paar => paar.Key, paar => paar.Value);

    public static List<string> NeueTags(IEnumerable<string> alt, IEnumerable<string> neu) =>
        neu.Except(alt).Order(StringComparer.Ordinal).ToList();

    public static List<string> AlleTags(IEnumerable<string> a, IEnumerable<string> b) =>
        a.Union(b).Order(StringComparer.Ordinal).ToList();

    public static List<string> GemeinsameTags(IEnumerable<string> a, IEnumerable<string> b) =>
        a.Intersect(b).Order(StringComparer.Ordinal).ToList();
}
