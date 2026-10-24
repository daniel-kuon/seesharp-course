public static class ParallelRechner
{
    public static long SummeQuadrate(int[] a)
    {
        long summe = 0;
        Parallel.For(0, a.Length, i => Interlocked.Add(ref summe, (long)a[i] * a[i]));
        return summe;
    }

    public static List<int> SammleGerade(int[] a)
    {
        var ergebnis = new List<int>();
        var sperre = new object();

        Parallel.ForEach(a, x =>
        {
            if (x % 2 == 0)
            {
                lock (sperre)
                {
                    ergebnis.Add(x);
                }
            }
        });
        return ergebnis;
    }

    // Vorgegeben und absichtlich FALSCH (die Tests rufen sie nicht auf): Mehrere Threads fügen gleichzeitig in
    // eine List<int> ein. List<T> ist dafür nicht gebaut: Es gehen Elemente verloren, es können doppelte
    // Einträge oder sogar Ausnahmen entstehen, und das Ergebnis ändert sich von Lauf zu Lauf.
    // So sieht der Fehler aus, den SammleGerade mit dem lock vermeiden soll.
    public static List<int> SammleGeradeUnsicher(int[] a)
    {
        var ergebnis = new List<int>();
        Parallel.ForEach(a, x =>
        {
            if (x % 2 == 0)
                ergebnis.Add(x);   // RACE CONDITION
        });
        return ergebnis;
    }

    public static void Gleichzeitig(Action a, Action b, Action c) => Parallel.Invoke(a, b, c);

    public static void WiederholeParallel(int anzahl, int maxGrad, Action koerper)
    {
        var optionen = new ParallelOptions { MaxDegreeOfParallelism = maxGrad };
        Parallel.For(0, anzahl, optionen, _ => koerper());
    }

    public static bool IstPrim(int n)
    {
        if (n < 2) return false;
        if (n % 2 == 0) return n == 2;
        for (int teiler = 3; (long)teiler * teiler <= n; teiler += 2)
            if (n % teiler == 0)
                return false;
        return true;
    }

    public static List<int> Primzahlen(int bis)
    {
        if (bis < 2)
            return [];

        return Enumerable.Range(2, bis - 1)
            .AsParallel()
            .AsOrdered()
            .Where(IstPrim)
            .ToList();
    }
}
