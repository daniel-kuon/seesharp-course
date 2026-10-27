public static class Berechnungen
{
    // Summiert das Array mit vier Aufgaben: Das Array wird in vier gleich große Abschnitte geteilt
    // (der letzte darf kürzer sein, bei kurzen Arrays dürfen Abschnitte leer sein), jeder Abschnitt wird
    // in einer eigenen Task.Run-Aufgabe (Task<long>) aufsummiert. Das Ergebnis ist die Summe der
    // vier Teilsummen; man holt sie über die Eigenschaft Result (sie wartet, bis die Aufgabe fertig ist).
    // Hinweis: Die Schleifenvariable vor dem Lambda in eine lokale Variable kopieren (Closure).
    public static long SummeParallel(int[] a)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Eine Aufgabe, die fertig wird, sobald ALLE übergebenen Aufgaben fertig sind, und dann die
    // aufsteigend sortierten Ergebnisse liefert. Die Methode darf NICHT blockieren: Sie wartet nicht
    // selbst, sondern hängt eine Fortsetzung an.
    // Hinweis: Task.WhenAll(aufgaben) liefert eine Task<int[]>; Fortsetzung mit ContinueWith.
    public static Task<int[]> AlleFertig(IEnumerable<Task<int>> aufgaben)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Liefert das Ergebnis der Aufgabe, die als erste fertig wird. Die andere darf unendlich lange laufen.
    // Hinweis: Task.WhenAny(a, b) liefert eine Task, deren Ergebnis die zuerst fertige Aufgabe ist.
    public static string ErsterFertiger(Task<string> a, Task<string> b)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Eine Fortsetzungsaufgabe: Sobald t fertig ist, liefert sie das Doppelte von t.Result.
    // Hinweis: t.ContinueWith(...). Die Methode blockiert nicht.
    public static Task<int> Verdopple(Task<int> t)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Verpackt das nächste Messwert-Ereignis des Sensors in eine Aufgabe.
    // - Die Aufgabe ist bei der Rückgabe noch nicht fertig und wird mit dem ersten Messwert fertig.
    // - Danach meldet sich die Methode vom Ereignis wieder ab (Sensor.Abonnenten ist dann 0), und
    //   weitere Messwerte ändern nichts mehr.
    // Hinweis: TaskCompletionSource<double>; tcs.Task ist die Aufgabe, tcs.SetResult(wert) beendet sie.
    public static Task<double> WartenAufMesswert(Sensor s)
    {
        // TODO
        throw new NotImplementedException();
    }
}
