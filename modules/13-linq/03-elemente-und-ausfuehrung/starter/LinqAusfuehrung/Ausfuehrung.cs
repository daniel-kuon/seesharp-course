public static class Pruefungen
{
    // TODO: All (Alter >= 18); beachte: auf einer leeren Folge ergibt All true
    public static bool AlleVolljaehrig(IEnumerable<int> alter) => throw new NotImplementedException();

    // TODO: Any mit Bedingung (w < 0)
    public static bool HatNegativenWert(IEnumerable<int> werte) => throw new NotImplementedException();

    // TODO: Contains mit StringComparer.OrdinalIgnoreCase
    public static bool Enthaelt(IEnumerable<string> texte, string text) => throw new NotImplementedException();
}

public static class Zugriff
{
    // TODO: FirstOrDefault mit Standardwert
    public static int ErstesOderStandard(IEnumerable<int> werte, int standard) => throw new NotImplementedException();

    // TODO: Single mit Bedingung (wirft bei 0 und bei mehreren Treffern)
    public static int EindeutigerTreffer(IEnumerable<int> werte, Predicate<int> bedingung) => throw new NotImplementedException();

    // TODO: Single in try/catch (InvalidOperationException); "Treffer: N" oder "kein eindeutiger Treffer"
    public static string EindeutigerTrefferText(IEnumerable<int> werte, Predicate<int> bedingung) => throw new NotImplementedException();

    // TODO: ElementAt(2)
    public static string Dritte(IEnumerable<string> texte) => throw new NotImplementedException();

    // TODO: Last
    public static string Letzte(IEnumerable<string> texte) => throw new NotImplementedException();
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

    // TODO: Quelle(log).Where(gerade); die Abfrage zurückgeben, nicht ausführen (kein ToList!)
    public static IEnumerable<int> GeradeZahlen(List<string> log) => throw new NotImplementedException();

    // FEHLER: Die Abfrage wird zweimal aufgezählt (Sum und Count), jedes Element erscheint doppelt im Protokoll.
    // TODO: Mit ToList() einmal materialisieren.
    public static (int summe, int anzahl) ZweimalNutzen(List<string> log)
    {
        var abfrage = Quelle(log).Where(z => z > 1);
        int summe = abfrage.Sum();
        int anzahl = abfrage.Count();
        return (summe, anzahl);
    }

    // TODO: Where (> 10) als Abfrage zurückgeben; spätere Änderungen der Liste sind bei der Aufzählung sichtbar
    public static IEnumerable<int> GrosseWerte(List<int> liste) => throw new NotImplementedException();

    // TODO: Where (> 10) und sofort materialisieren (ToList)
    public static List<int> GrosseWerteJetzt(List<int> liste) => throw new NotImplementedException();
}
