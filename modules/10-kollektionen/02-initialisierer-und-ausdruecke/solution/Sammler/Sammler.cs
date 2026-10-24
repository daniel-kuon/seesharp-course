public static class Sammler
{
    // Montag bis Sonntag, aufgebaut mit einem Kollektionsinitialisierer.
    public static List<string> Wochentage()
    {
        return new List<string>
        {
            "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag"
        };
    }

    // Erst alle Elemente von a, dann alle von b (Spread-Elemente).
    public static List<int> Zusammen(IEnumerable<int> a, IEnumerable<int> b)
    {
        return [..a, ..b];
    }

    // {rand, mitte..., rand} als Array.
    public static int[] MitRand(int[] mitte, int rand)
    {
        return [rand, ..mitte, rand];
    }

    // Eine leere, schreibgeschützte Liste (Kollektionsausdruck []).
    public static IReadOnlyList<T> Leer<T>()
    {
        return [];
    }

    // Lager "Hauptlager" mit den Artikeln Schraube, Mutter, Dichtung.
    // Objektinitialisierer mit verschachteltem Kollektionsinitialisierer.
    public static Lager NeuesLager()
    {
        return new Lager
        {
            Name = "Hauptlager",
            Artikel = { "Schraube", "Mutter", "Dichtung" }
        };
    }

    // Trägt von..bis (beide eingeschlossen) in ziel ein.
    // Muss für List<int> und HashSet<int> gleichermaßen funktionieren.
    public static void FuelleAuf(ICollection<int> ziel, int von, int bis)
    {
        for (int i = von; i <= bis; i++)
            ziel.Add(i);
    }

    // Anzahl der Elemente über Count (ICollection<T> kennt sie).
    public static int Zaehle<T>(ICollection<T> sammlung)
    {
        return sammlung.Count;
    }

    // Summe einer beliebigen Folge: IEnumerable<T> hat kein Count, man muss aufzählen.
    public static int Gesamt(IEnumerable<int> folge)
    {
        int summe = 0;
        foreach (int x in folge)
            summe += x;
        return summe;
    }
}
