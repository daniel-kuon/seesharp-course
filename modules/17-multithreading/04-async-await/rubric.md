# Rubrik — async und await (nur für die Betreuung)

- Kern: `async`/`await` ist kein neuer Thread, sondern ein Compiler-Trick,
  der die Methode an jedem `await` in eine Zustandsmaschine zerlegt: Die
  Methode gibt den Thread frei und läuft später weiter. Wer das erklären
  kann ("Wo läuft der Code nach dem await?"), hat die Aufgabe verstanden;
  17.6.9 (Seite 1182) zeigt die Zustandsmaschine.
- `async void`: Der Test ruft `SpeichereAsync` per Reflexion auf und prüft
  zuerst den Rückgabetyp. Hintergrund: `async void` ist nur für
  Ereignishandler gedacht; Ausnahmen darin landen im Synchronisierungskontext
  oder beenden das Programm (17.6.12.1, Seite 1197). Frage: Was würde im
  Test schiefgehen, wenn die Methode `void` bliebe und man darauf warten
  wollte? (Es gibt nichts zu warten.)
- `SummeAsync`: Der Test `blockiert_den_Aufrufer_nicht` fängt `.Result`,
  `.Wait()` und `WaitAll` ab, indem er die Methode auf einem Threadpool-Thread
  aufruft und mit einer Zeitgrenze auf die Rückkehr wartet. In dieser
  Testumgebung deadlockt `.Result` nicht von selbst (es gibt keinen
  Synchronisierungskontext wie in WPF); gerade deshalb prüft der Test das
  Blockieren und die Quizfrage klärt den Deadlock. Wer hier `Task.WhenAll(...).Result`
  schreibt, hat nicht begriffen, worum es geht.
- `MitWiederholung`: Der Ausnahmefilter `when (nr < versuche)` ist die
  kürzeste Lösung. Gleichwertig: Variable `Exception? letzte` speichern und am
  Ende `throw`. Warnen vor `throw ex;` (zerstört den Stapel) gegenüber
  `throw;`. Ein weiterer Gesprächsanlass: Würde man einen
  `OperationCanceledException` auch wiederholen? (Nein.)
- `VerarbeiteAsync`: Die Datenquelle im Test löst den Abbruch selbst aus,
  deshalb ist der Ablauf deterministisch. Wer `token.IsCancellationRequested`
  prüft und mit `return` aussteigt, liefert eine erfolgreiche Aufgabe: Der
  Test auf `IsCanceled` fängt das ab.
- `FehlerAsync` beginnt absichtlich mit `await Task.CompletedTask` (läuft
  synchron weiter); so entsteht in keiner Testumgebung ein Deadlock durch
  `Wait()`, und `MeldungMitWait` ist stabil. In echtem UI-Code wäre
  genau dieser Aufruf riskant: Die Aufgabe zeigt den Unterschied der
  Ausnahmetypen, nicht ein empfohlenes Muster.
- Abweichung vom Plan: Das Buch behandelt den Deadlock am WPF-Beispiel
  `AsyncWaitDeadlock`; hier nur als Quizfrage, weil er ohne
  Synchronisierungskontext nicht reproduzierbar ist.

Modellantwort: `solution/`.
