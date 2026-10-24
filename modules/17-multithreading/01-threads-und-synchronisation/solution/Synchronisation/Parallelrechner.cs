public static class Parallelrechner
{
    public static int[] Quadrate(int[] eingabe, int threads) => Berechne(eingabe, threads, x => x * x);

    public static int[] Berechne(int[] eingabe, int threads, Func<int, int> f)
    {
        if (threads < 1)
            throw new ArgumentOutOfRangeException(nameof(threads));

        int n = eingabe.Length;
        int[] ergebnis = new int[n];
        if (n == 0)
            return ergebnis;

        int blockgroesse = (n + threads - 1) / threads;   // aufgerundet: höchstens 'threads' Blöcke
        var arbeiter = new List<Thread>();

        for (int start = 0; start < n; start += blockgroesse)
        {
            int von = start;                                // Kopie für die Closure
            int bis = Math.Min(n, start + blockgroesse);

            var thread = new Thread(() =>
            {
                for (int i = von; i < bis; i++)
                    ergebnis[i] = f(eingabe[i]);
            });
            arbeiter.Add(thread);
            thread.Start();
        }

        foreach (Thread thread in arbeiter)
            thread.Join();

        return ergebnis;
    }
}
