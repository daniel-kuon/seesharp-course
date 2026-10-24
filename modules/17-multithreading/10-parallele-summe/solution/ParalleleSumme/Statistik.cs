public static class Statistik
{
    public static long Summe(int[] daten)
    {
        long summe = 0;
        Parallel.For(0, daten.Length, i => Interlocked.Add(ref summe, daten[i]));
        return summe;
    }

    public static int Maximum(int[] daten)
    {
        if (daten.Length == 0)
            throw new InvalidOperationException("Das Array ist leer.");

        int abschnitt = (daten.Length + 3) / 4;
        var teilergebnisse = new List<Task<int>>();

        for (int i = 0; i < 4; i++)
        {
            int von = i * abschnitt;                       // Kopien für die Closure
            int bis = Math.Min(daten.Length, von + abschnitt);
            if (von >= bis)
                continue;                                  // leerer Abschnitt bei kurzen Arrays

            teilergebnisse.Add(Task.Run(() =>
            {
                int maximum = daten[von];
                for (int k = von + 1; k < bis; k++)
                    if (daten[k] > maximum)
                        maximum = daten[k];
                return maximum;
            }));
        }

        return teilergebnisse.Max(t => t.Result);
    }

    public static int[] Histogramm(int[] daten, int klassen)
    {
        if (klassen < 1)
            throw new ArgumentOutOfRangeException(nameof(klassen));

        int[] ergebnis = new int[klassen];
        Parallel.For(0, daten.Length, i =>
        {
            int klasse = daten[i] * klassen / 100;
            Interlocked.Increment(ref ergebnis[klasse]);
        });
        return ergebnis;
    }
}
