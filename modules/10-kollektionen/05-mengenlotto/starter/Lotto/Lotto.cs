public static class Lotto
{
    // Sechs verschiedene Zahlen von 1 bis 49. Ziehe so lange mit rnd.Next(1, 50) und
    // füge die Zahl der Menge hinzu, bis sie sechs Elemente hat. Doppelte Zahlen
    // ignoriert die Menge von selbst. (Die Reihenfolge der Aufrufe von rnd.Next
    // ist festgelegt, damit ein Test mit new Random(42) das genaue Ergebnis kennt.)
    public static SortedSet<int> Ziehe(Random rnd)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Anzahl der Zahlen, die in beiden Mengen vorkommen. Die Argumente bleiben
    // unverändert: IntersectWith nur auf einer Kopie.
    public static int Treffer(SortedSet<int> tipp, SortedSet<int> ziehung)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die kleinste Zahl in s, die größer als x ist, oder -1, wenn es keine gibt.
    // Tipp: GetViewBetween(x + 1, int.MaxValue) liefert eine Sicht auf die Zahlen
    // ab x + 1; Achtung bei x == int.MaxValue.
    public static int NaechsteZahl(SortedSet<int> s, int x)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Größte minus kleinste Zahl (Max und Min); 0 bei einer leeren Menge.
    public static int Spanne(SortedSet<int> s)
    {
        // TODO
        throw new NotImplementedException();
    }
}
