public record Mitarbeiter(string Name, decimal Gehalt);

public static class Auswertung
{
    // vorgegeben
    private static readonly char[] Trenner = [' ', ',', '.', '!', '?', ';', ':'];

    public static List<string> Woerter(IEnumerable<string> saetze) =>
        saetze
            .SelectMany(s => s.Split(Trenner, StringSplitOptions.RemoveEmptyEntries))
            .Select(w => w.ToLowerInvariant())
            .Distinct()
            .ToList();

    public static List<string> Kombinationen(IEnumerable<int> a, IEnumerable<char> b) =>
        (from x in a
         from y in b
         select $"{x}{y}").ToList();

    public static List<Mitarbeiter> UeberDemSchnitt(IEnumerable<Mitarbeiter> mitarbeiter)
    {
        var liste = mitarbeiter.ToList();        // die Quelle genau einmal aufzählen
        if (liste.Count == 0) return [];
        decimal schnitt = liste.Average(m => m.Gehalt);   // einmal berechnen, nicht je Element
        return liste.Where(m => m.Gehalt > schnitt).ToList();
    }

    public static List<string> Spitzenverdiener(IEnumerable<Mitarbeiter> mitarbeiter)
    {
        var liste = mitarbeiter.ToList();
        return (from m in liste
                where m.Gehalt == (from x in liste select x.Gehalt).Max()
                select m.Name).ToList();
    }

    public static List<string> NurTexte(object[] objekte) => objekte.OfType<string>().ToList();

    public static List<int> NurGanzzahlen(object[] objekte) => objekte.OfType<int>().ToList();
}

public static class MeineOperatoren
{
    public static IEnumerable<T> TakeEvery<T>(this IEnumerable<T> quelle, int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(n);
        int position = 0;
        foreach (T element in quelle)
        {
            if (position % n == 0)
                yield return element;
            position++;
        }
    }

    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> quelle, Func<T, bool> bedingung)
    {
        foreach (T element in quelle)
            if (!bedingung(element))
                yield return element;
    }

    public static IEnumerable<(T, T)> Paarweise<T>(this IEnumerable<T> quelle)
    {
        bool hatVorgaenger = false;
        T vorgaenger = default!;
        foreach (T element in quelle)
        {
            if (hatVorgaenger)
                yield return (vorgaenger, element);
            vorgaenger = element;
            hatVorgaenger = true;
        }
    }
}
