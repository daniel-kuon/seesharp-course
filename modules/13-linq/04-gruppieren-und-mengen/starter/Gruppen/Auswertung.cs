public record Dateieintrag(string Pfad, long Groesse, string Hash);

public static class Auswertung
{
    // TODO: GroupBy nach (Groesse, Hash); Gruppen mit mehr als einem Eintrag behalten;
    // je Gruppe die Pfade sortieren (Order(StringComparer.Ordinal)); Gruppen nach erstem Pfad ordnen
    public static List<List<string>> Duplikate(IEnumerable<Dateieintrag> eintraege) => throw new NotImplementedException();

    // TODO: GroupBy nach Endung (Path.GetExtension, ToLowerInvariant), Summe der Größen,
    // OrderByDescending(Summe), ThenBy(Endung, StringComparer.Ordinal)
    public static List<(string Endung, long Summe)> SpeicherProEndung(IEnumerable<Dateieintrag> eintraege) => throw new NotImplementedException();

    // TODO: CountBy(w => w) und in ein Dictionary umwandeln
    public static Dictionary<string, int> Haeufigkeiten(IEnumerable<string> werte) => throw new NotImplementedException();

    // TODO: AggregateBy(Endung, 0L, (summe, e) => summe + e.Groesse) und in ein Dictionary umwandeln
    public static Dictionary<string, long> GroesseProEndung(IEnumerable<Dateieintrag> eintraege) => throw new NotImplementedException();

    // TODO: Except, sortiert (Order(StringComparer.Ordinal)), ToList
    public static List<string> NeueTags(IEnumerable<string> alt, IEnumerable<string> neu) => throw new NotImplementedException();

    // TODO: Union, sortiert
    public static List<string> AlleTags(IEnumerable<string> a, IEnumerable<string> b) => throw new NotImplementedException();

    // TODO: Intersect, sortiert
    public static List<string> GemeinsameTags(IEnumerable<string> a, IEnumerable<string> b) => throw new NotImplementedException();
}
