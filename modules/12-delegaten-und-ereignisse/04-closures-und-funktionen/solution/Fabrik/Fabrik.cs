using System.Text;

public static class Fabrik
{
    public static Predicate<int> KleinerGleich(int k) => x => x <= k;

    public static Func<int> Zaehler()
    {
        int n = 0;
        return () => ++n;
    }

    public static Func<int, int> Addierer(int n) => x => x + n;

    public static Func<int, int> Komponiere(Func<int, int> f, Func<int, int> g) => x => g(f(x));

    public static void FuehreAus(IEnumerable<Action> aktionen)
    {
        foreach (Action a in aktionen)
            a();
    }

    public static List<Action> ErzeugeAktionen(StringBuilder sb, int n)
    {
        var aktionen = new List<Action>();
        for (int i = 0; i < n; i++)
        {
            int index = i;   // eigene Variable je Durchlauf, sonst teilen sich alle Lambdas dieselbe Schleifenvariable
            aktionen.Add(() => sb.Append(index));
        }
        return aktionen;
    }

    public static Func<int, int> Merke(Func<int, int> f)
    {
        var gemerkt = new Dictionary<int, int>();
        return x =>
        {
            if (!gemerkt.TryGetValue(x, out int ergebnis))
            {
                ergebnis = f(x);
                gemerkt[x] = ergebnis;
            }
            return ergebnis;
        };
    }
}
