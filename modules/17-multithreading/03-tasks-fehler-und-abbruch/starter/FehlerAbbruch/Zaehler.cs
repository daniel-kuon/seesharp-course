public static class Zaehler
{
    // Zählt in einer Schleife ohne Ende aufwärts, bis der Abbruch angefordert wird.
    // - Sobald der Zählerstand 1000 erreicht, wird 'erreicht' gesetzt (erreicht.Set()).
    // - In JEDEM Schleifendurchlauf wird token.ThrowIfCancellationRequested() aufgerufen: Das ist
    //   das kooperative Abbrechen. Die OperationCanceledException beendet die Methode, und eine mit
    //   demselben Token gestartete Task endet dadurch im Zustand "abgebrochen" (nicht "fehlgeschlagen").
    // - Ein schon vor dem Aufruf abgebrochenes Token beendet die Methode, bevor etwas gezählt wird.
    public static void ZaehleHoch(CancellationToken token, ManualResetEventSlim erreicht)
    {
        // TODO
        throw new NotImplementedException();
    }
}
