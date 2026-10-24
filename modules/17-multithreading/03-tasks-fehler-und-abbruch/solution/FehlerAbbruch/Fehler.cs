public static class Fehler
{
    public static List<string> Sammle(params Func<int>[] aufgaben)
    {
        Task[] tasks = aufgaben.Select(f => (Task)Task.Run(f)).ToArray();
        var meldungen = new List<string>();

        try
        {
            Task.WaitAll(tasks);
        }
        catch (AggregateException ex)
        {
            foreach (Exception inner in ex.Flatten().InnerExceptions)
                meldungen.Add(inner.Message);
        }

        meldungen.Sort(StringComparer.Ordinal);
        return meldungen;
    }

    public static string? ErsteMeldung(Task t)
    {
        return t.IsFaulted ? t.Exception!.InnerExceptions[0].Message : null;
    }
}
