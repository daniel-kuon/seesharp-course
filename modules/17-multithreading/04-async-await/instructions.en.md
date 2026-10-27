# async and await

See the book, **17.6 C# Language Support for Asynchronous Operations** (page 1161), **17.6.4 Defining async Methods** (page 1169), **17.6.5 The `await` Expression** (page 1173), **17.6.7 Exception Handling** (page 1178), **17.6.8 Cooperative Cancellation** (page 1181), and **17.6.12 Tips for Avoiding Trouble** (pages 1197–1200). The book uses WPF examples; this exercise does not require a user interface—only the concepts are the same.

`async` and `await` allow you to write asynchronous code as if it were sequential: At an `await`, the method releases the thread until the awaited task is complete, and then continues from there. Exceptions arrive at the `await` as usual, and the method returns a `Task` or `Task<T>`.

**The tests are deterministic** (`async Task` tests, no timing, no `Thread.Sleep`). They never wait for your methods in a blocking manner; the time limits are only there to prevent hangs. A method that blocks internally will therefore fail.

1. `Dateien.LiesLaengeAsync(pfad)`: Turn this into an `async` method that reads the file using `await File.ReadAllTextAsync` and returns the number of characters.
2. `Dateien.SpeichereAsync(pfad, text)`: This method is `async void`—a classic mistake. The caller cannot wait, and an exception will have no receiver. Change the return type to `Task`.
3. `Asynchron.SummeAsync(aufgaben)`: `await Task.WhenAll`, then sum, without blocking.
4. `Asynchron.MitWiederholung(aktion, versuche)`: at most `versuche` calls; `await` in `try/catch`. If the last one fails, its exception is propagated. `versuche < 1` is an `ArgumentOutOfRangeException`.
5. `Asynchron.VerarbeiteAsync(daten, token)`: calls `ThrowIfCancellationRequested` before each element, then releases the thread using `await Task.Yield()`, and sums the elements. If canceled, the task ends as canceled.
6. `MeldungMitAwait` and `MeldungMitWait`: Both catch the exception from the given method `FehlerAsync` and return its message. With `await`, the `InvalidOperationException` is thrown directly; with `.Wait()`, it is wrapped in an `AggregateException`. The Wait variant is provided for comparison purposes only.
7. Answer the quiz question about deadlock caused by blocking waits.

The following tests must be passed:

- `AsyncAwaitTests.LiesLaengeAsync_liefert_die_Anzahl_der_Zeichen`
- `AsyncAwaitTests.LiesLaengeAsync_gibt_beim_await_die_urspruengliche_Ausnahme_weiter`
- `AsyncAwaitTests.SpeichereAsync_liefert_eine_Task_auf_die_man_warten_kann`
- `AsyncAwaitTests.SpeichereAsync_meldet_Fehler_ueber_die_Task`
- `AsyncAwaitTests.SummeAsync_wartet_auf_alle_und_summiert`
- `AsyncAwaitTests.SummeAsync_blockiert_den_Aufrufer_nicht`
- `AsyncAwaitTests.SummeAsync_gibt_die_urspruengliche_Ausnahme_weiter`
- `AsyncAwaitTests.MitWiederholung_versucht_es_erneut_bis_es_klappt`
- `AsyncAwaitTests.MitWiederholung_gibt_nach_dem_letzten_Versuch_dessen_Ausnahme_weiter`
- `AsyncAwaitTests.MitWiederholung_ruft_bei_Erfolg_nur_einmal_auf`
- `AsyncAwaitTests.MitWiederholung_verlangt_mindestens_einen_Versuch`
- `AsyncAwaitTests.VerarbeiteAsync_liefert_die_Summe_der_Daten`
- `AsyncAwaitTests.VerarbeiteAsync_endet_bei_vorab_abgebrochenem_Token_als_abgebrochen`
- `AsyncAwaitTests.VerarbeiteAsync_bemerkt_einen_Abbruch_mitten_in_der_Verarbeitung`
- `AsyncAwaitTests.Await_wirft_den_Originaltyp_Wait_wirft_eine_AggregateException`
- `AsyncAwaitTests.MeldungMitAwait_faengt_die_Originalausnahme`
- `AsyncAwaitTests.MeldungMitWait_faengt_die_AggregateException_und_liefert_die_innere_Meldung`
