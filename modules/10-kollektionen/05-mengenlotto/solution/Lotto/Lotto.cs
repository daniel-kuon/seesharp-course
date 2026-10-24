public static class Lotto
{
    // Sechs verschiedene Zahlen von 1 bis 49. Es wird so lange gezogen (rnd.Next(1, 50)),
    // bis die Menge sechs Elemente hat; doppelte Zahlen ignoriert die Menge von selbst.
    public static SortedSet<int> Ziehe(Random rnd)
    {
        var ziehung = new SortedSet<int>();
        while (ziehung.Count < 6)
            ziehung.Add(rnd.Next(1, 50));
        return ziehung;
    }

    // Anzahl der Zahlen, die in beiden Mengen vorkommen. Die Argumente bleiben unverändert.
    public static int Treffer(SortedSet<int> tipp, SortedSet<int> ziehung)
    {
        var gemeinsam = new SortedSet<int>(tipp);
        gemeinsam.IntersectWith(ziehung);
        return gemeinsam.Count;
    }

    // Die kleinste Zahl in s, die größer als x ist, oder -1, wenn es keine gibt.
    public static int NaechsteZahl(SortedSet<int> s, int x)
    {
        if (x == int.MaxValue)
            return -1;
        var groesser = s.GetViewBetween(x + 1, int.MaxValue);
        return groesser.Count > 0 ? groesser.Min : -1;
    }

    // Größte minus kleinste Zahl; 0 bei einer leeren Menge.
    public static int Spanne(SortedSet<int> s)
    {
        return s.Count == 0 ? 0 : s.Max - s.Min;
    }
}
