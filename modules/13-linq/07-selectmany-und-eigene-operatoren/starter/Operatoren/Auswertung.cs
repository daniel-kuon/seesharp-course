public record Mitarbeiter(string Name, decimal Gehalt);

public static class Auswertung
{
    // vorgegeben
    private static readonly char[] Trenner = [' ', ',', '.', '!', '?', ';', ':'];

    // TODO: SelectMany über die Sätze (s.Split(Trenner, StringSplitOptions.RemoveEmptyEntries)),
    // ToLowerInvariant, Distinct
    public static List<string> Woerter(IEnumerable<string> saetze) => throw new NotImplementedException();

    // TODO: Abfragesyntax mit zwei from-Klauseln: from x in a from y in b select ...
    public static List<string> Kombinationen(IEnumerable<int> a, IEnumerable<char> b) => throw new NotImplementedException();

    // TODO: Quelle einmal in eine Liste kopieren, Durchschnitt EINMAL berechnen, dann filtern
    public static List<Mitarbeiter> UeberDemSchnitt(IEnumerable<Mitarbeiter> mitarbeiter) => throw new NotImplementedException();

    // TODO: Abfragesyntax mit Unterabfrage: where m.Gehalt == (from x in liste select x.Gehalt).Max()
    public static List<string> Spitzenverdiener(IEnumerable<Mitarbeiter> mitarbeiter) => throw new NotImplementedException();

    // TODO: OfType<string>()
    public static List<string> NurTexte(object[] objekte) => throw new NotImplementedException();

    // TODO: OfType<int>()
    public static List<int> NurGanzzahlen(object[] objekte) => throw new NotImplementedException();
}

public static class MeineOperatoren
{
    // TODO: Iterator mit yield return: das erste und dann jedes n-te Element; n <= 0: ArgumentOutOfRangeException
    public static IEnumerable<T> TakeEvery<T>(this IEnumerable<T> quelle, int n) => throw new NotImplementedException();

    // TODO: Iterator: nur Elemente, für die die Bedingung false ergibt
    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> quelle, Func<T, bool> bedingung) => throw new NotImplementedException();

    // TODO: Iterator: aufeinanderfolgende Paare (vorgaenger, element)
    public static IEnumerable<(T, T)> Paarweise<T>(this IEnumerable<T> quelle) => throw new NotImplementedException();
}
