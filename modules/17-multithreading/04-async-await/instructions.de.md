# async und await

Lies im Buch **17.6 C#-Sprachunterstützung für asynchrone Operationen**
(Seite 1161), **17.6.4 Definition von async-Methoden** (Seite 1169),
**17.6.5 await-Ausdruck** (Seite 1173), **17.6.7 Ausnahmebehandlung**
(Seite 1178), **17.6.8 Kooperatives Abbrechen** (Seite 1181) und **17.6.12
Tipps zur Vermeidung von Ärger** (Seite 1197 bis 1200). Das Buch arbeitet
mit WPF-Beispielen; diese Aufgabe kommt ohne Oberfläche aus, nur die Ideen
sind dieselben.

`async` und `await` schreiben asynchronen Code wie sequenziellen: Bei
`await` gibt die Methode den Thread frei, bis die erwartete Aufgabe
fertig ist, und läuft dann dort weiter. Ausnahmen kommen beim `await`
ganz normal an, und die Methode liefert eine `Task` bzw. `Task<T>`.

**Die Tests sind deterministisch** (`async Task`-Tests, keine Zeitmessung,
kein `Thread.Sleep`). Sie warten nie blockierend auf deine Methoden; die
Zeitgrenzen sind nur Hängerschutz. Eine Methode, die intern blockiert,
fällt dadurch durch.

1. `Dateien.LiesLaengeAsync(pfad)`: Mach daraus eine `async`-Methode, die
   mit `await File.ReadAllTextAsync` liest und die Zeichenzahl liefert.
2. `Dateien.SpeichereAsync(pfad, text)`: Diese Methode ist `async void`: ein
   klassischer Fehler. Der Aufrufer kann nicht warten, und eine Ausnahme
   findet keinen Empfänger. Ändere den Rückgabetyp in `Task`.
3. `Asynchron.SummeAsync(aufgaben)`: `await Task.WhenAll`, dann summieren,
   ohne zu blockieren.
4. `Asynchron.MitWiederholung(aktion, versuche)`: höchstens `versuche`
   Aufrufe, `await` in `try/catch`. Scheitert der letzte, wird dessen
   Ausnahme weitergegeben. `versuche < 1` ist eine
   `ArgumentOutOfRangeException`.
5. `Asynchron.VerarbeiteAsync(daten, token)`: prüft vor jedem Element
   `ThrowIfCancellationRequested`, gibt dann mit `await Task.Yield()`
   den Thread frei und summiert die Elemente. Bei Abbruch endet die
   Aufgabe als abgebrochen.
6. `MeldungMitAwait` und `MeldungMitWait`: Beide fangen den Fehler aus der
   vorgegebenen Methode `FehlerAsync` und liefern seine Meldung. Bei `await` kommt die
   `InvalidOperationException` selbst an, bei `.Wait()` verpackt in eine
   `AggregateException`. Die Wait-Variante dient nur dem Vergleich.
7. Beantworte die Quizfrage zum Deadlock durch blockierendes Warten.

Diese Tests müssen bestehen:

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
