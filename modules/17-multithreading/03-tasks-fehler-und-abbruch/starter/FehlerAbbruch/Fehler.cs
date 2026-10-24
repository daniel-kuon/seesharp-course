public static class Fehler
{
    // Führt jede Funktion in einer eigenen Task.Run-Aufgabe aus und wartet auf alle (Task.WaitAll).
    // Wirft mindestens eine Aufgabe eine Ausnahme, löst WaitAll eine AggregateException aus. Sie wird
    // gefangen; Sammle liefert die Meldungen (Message) aller enthaltenen Ausnahmen aufsteigend sortiert
    // (StringComparer.Ordinal). Funktionen, die mit einem Ergebnis enden, tragen nichts bei.
    // Die AggregateException kann selbst wieder AggregateExceptions enthalten: Flatten() löst das auf.
    // Ohne Fehler (oder ohne Funktionen) ist das Ergebnis eine leere Liste.
    public static List<string> Sammle(params Func<int>[] aufgaben)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die Meldung der ersten Ausnahme, mit der t fehlgeschlagen ist (t.Exception.InnerExceptions).
    // Ist t nicht fehlgeschlagen (fertig, abgebrochen oder noch nicht fertig), ist das Ergebnis null.
    public static string? ErsteMeldung(Task t)
    {
        // TODO
        throw new NotImplementedException();
    }
}
