public static class Berechnungen
{
    public static long SummeParallel(int[] a)
    {
        int abschnitt = (a.Length + 3) / 4;
        var teilsummen = new List<Task<long>>();

        for (int i = 0; i < 4; i++)
        {
            int von = Math.Min(a.Length, i * abschnitt);   // Kopien für die Closure
            int bis = Math.Min(a.Length, von + abschnitt);

            teilsummen.Add(Task.Run(() =>
            {
                long summe = 0;
                for (int k = von; k < bis; k++)
                    summe += a[k];
                return summe;
            }));
        }

        long gesamt = 0;
        foreach (Task<long> t in teilsummen)
            gesamt += t.Result;
        return gesamt;
    }

    public static Task<int[]> AlleFertig(IEnumerable<Task<int>> aufgaben)
    {
        return Task.WhenAll(aufgaben).ContinueWith(alle =>
        {
            int[] ergebnisse = alle.Result;
            Array.Sort(ergebnisse);
            return ergebnisse;
        });
    }

    public static string ErsterFertiger(Task<string> a, Task<string> b)
    {
        Task<string> erste = Task.WhenAny(a, b).Result;
        return erste.Result;
    }

    public static Task<int> Verdopple(Task<int> t)
    {
        return t.ContinueWith(vorgaenger => vorgaenger.Result * 2);
    }

    public static Task<double> WartenAufMesswert(Sensor s)
    {
        var tcs = new TaskCompletionSource<double>(TaskCreationOptions.RunContinuationsAsynchronously);

        Action<double>? handler = null;
        handler = wert =>
        {
            s.Messwert -= handler;      // nur einmal zuhören
            tcs.TrySetResult(wert);
        };
        s.Messwert += handler;

        return tcs.Task;
    }
}
