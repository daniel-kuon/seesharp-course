public static class Asynchron
{
    // Wartet auf alle Aufgaben und liefert die Summe ihrer Ergebnisse.
    // async/await: Die Methode kehrt SOFORT zurück, auch wenn die Aufgaben noch laufen; sie blockiert den
    // Thread nicht (kein .Result, kein .Wait(), kein WaitAll). Scheitert eine Aufgabe, kommt beim await
    // die ursprüngliche Ausnahme an.
    // Hinweis: await Task.WhenAll(aufgaben) liefert ein int[].
    public static Task<int> SummeAsync(IEnumerable<Task<int>> aufgaben)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Ruft aktion auf und wartet auf das Ergebnis. Scheitert der Versuch mit einer Ausnahme, wird erneut
    // aufgerufen, insgesamt höchstens 'versuche' Mal. Scheitert auch der letzte Versuch, wird DESSEN
    // Ausnahme weitergegeben. versuche < 1 ist ein ArgumentOutOfRangeException.
    // Hinweis: await in try/catch; der Ausnahmefilter "catch (Exception) when (nr < versuche)" lässt die
    // Ausnahme des letzten Versuchs ungefangen.
    public static Task<int> MitWiederholung(Func<Task<int>> aktion, int versuche)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Verarbeitet die Daten nacheinander und liefert ihre Summe. Vor jedem Element wird mit
    // token.ThrowIfCancellationRequested() geprüft, ob abgebrochen wurde, danach gibt "await Task.Yield()"
    // dem Thread die Gelegenheit, andere Arbeit zu erledigen. Bei Abbruch endet die Aufgabe als
    // "abgebrochen" (OperationCanceledException).
    public static Task<int> VerarbeiteAsync(IEnumerable<int> daten, CancellationToken token)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Vorgegeben: eine async-Methode, die mit einer Ausnahme endet.
    public static async Task FehlerAsync()
    {
        await Task.CompletedTask;
        throw new InvalidOperationException("Kaputt");
    }

    // Ruft FehlerAsync mit await auf und fängt die InvalidOperationException. Liefert deren Meldung.
    // Fehlt der Fehler, liefert die Methode "kein Fehler".
    public static Task<string> MeldungMitAwait()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Ruft FehlerAsync mit .Wait() auf, also BLOCKIEREND (nur zum Vergleich; im echten Code vermeiden,
    // siehe 17.6.12.2). Hier kommt keine InvalidOperationException an, sondern eine AggregateException:
    // Fang sie und liefere die Meldung ihrer InnerException. Fehlt der Fehler: "kein Fehler".
    public static string MeldungMitWait()
    {
        // TODO
        throw new NotImplementedException();
    }
}
