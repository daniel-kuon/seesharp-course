public static class Asynchron
{
    public static async Task<int> SummeAsync(IEnumerable<Task<int>> aufgaben)
    {
        int[] ergebnisse = await Task.WhenAll(aufgaben);
        return ergebnisse.Sum();
    }

    public static async Task<int> MitWiederholung(Func<Task<int>> aktion, int versuche)
    {
        if (versuche < 1)
            throw new ArgumentOutOfRangeException(nameof(versuche));

        for (int nr = 1; ; nr++)
        {
            try
            {
                return await aktion();
            }
            catch (Exception) when (nr < versuche)
            {
                // Es gibt noch einen weiteren Versuch. Die Ausnahme des letzten Versuchs wird nicht gefangen.
            }
        }
    }

    public static async Task<int> VerarbeiteAsync(IEnumerable<int> daten, CancellationToken token)
    {
        int summe = 0;
        foreach (int element in daten)
        {
            token.ThrowIfCancellationRequested();
            await Task.Yield();
            summe += element;
        }
        return summe;
    }

    public static async Task FehlerAsync()
    {
        await Task.CompletedTask;
        throw new InvalidOperationException("Kaputt");
    }

    public static async Task<string> MeldungMitAwait()
    {
        try
        {
            await FehlerAsync();
            return "kein Fehler";
        }
        catch (InvalidOperationException ex)
        {
            return ex.Message;
        }
    }

    public static string MeldungMitWait()
    {
        try
        {
            FehlerAsync().Wait();
            return "kein Fehler";
        }
        catch (AggregateException ex)
        {
            return ex.InnerException!.Message;
        }
    }
}
