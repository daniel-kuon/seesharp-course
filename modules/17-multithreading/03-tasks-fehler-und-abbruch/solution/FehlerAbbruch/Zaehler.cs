public static class Zaehler
{
    public static void ZaehleHoch(CancellationToken token, ManualResetEventSlim erreicht)
    {
        for (long stand = 1; ; stand++)
        {
            token.ThrowIfCancellationRequested();   // kooperatives Abbrechen: bei jedem Durchlauf fragen

            if (stand == 1000)
                erreicht.Set();
        }
    }
}
