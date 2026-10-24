public static class Pruefungen
{
    public static bool AlleVolljaehrig(IEnumerable<int> alter) => alter.All(a => a >= 18);

    public static bool HatNegativenWert(IEnumerable<int> werte) => werte.Any(w => w < 0);

    public static bool Enthaelt(IEnumerable<string> texte, string text) =>
        texte.Contains(text, StringComparer.OrdinalIgnoreCase);
}

public static class Zugriff
{
    public static int ErstesOderStandard(IEnumerable<int> werte, int standard) =>
        werte.FirstOrDefault(standard);

    public static int EindeutigerTreffer(IEnumerable<int> werte, Predicate<int> bedingung) =>
        werte.Single(w => bedingung(w));

    public static string EindeutigerTrefferText(IEnumerable<int> werte, Predicate<int> bedingung)
    {
        try
        {
            return "Treffer: " + werte.Single(w => bedingung(w));
        }
        catch (InvalidOperationException)
        {
            return "kein eindeutiger Treffer";
        }
    }

    public static string Dritte(IEnumerable<string> texte) => texte.ElementAt(2);

    public static string Letzte(IEnumerable<string> texte) => texte.Last();
}

public static class Ausfuehrung
{
    // vorgegeben: ein Iterator, der jede Lieferung protokolliert
    public static IEnumerable<int> Quelle(List<string> log)
    {
        for (int i = 1; i <= 4; i++)
        {
            log.Add($"liefere {i}");
            yield return i;
        }
    }

    public static IEnumerable<int> GeradeZahlen(List<string> log) =>
        Quelle(log).Where(z => z % 2 == 0);

    public static (int summe, int anzahl) ZweimalNutzen(List<string> log)
    {
        var abfrage = Quelle(log).Where(z => z > 1).ToList();   // einmal aufzählen, dann wiederverwenden
        int summe = abfrage.Sum();
        int anzahl = abfrage.Count();
        return (summe, anzahl);
    }

    public static IEnumerable<int> GrosseWerte(List<int> liste) =>
        liste.Where(w => w > 10);

    public static List<int> GrosseWerteJetzt(List<int> liste) =>
        liste.Where(w => w > 10).ToList();
}
