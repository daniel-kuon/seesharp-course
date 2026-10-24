# Rubrik — Ausnahmen und Abbruch bei Aufgaben (nur für die Betreuung)

- Kern: Fehler und Abbruch haben bei Aufgaben je einen eigenen Weg.
  Fehler sind `AggregateException` (immer ein Bündel, auch bei einer
  Aufgabe), Abbruch ist kooperativ und endet im Zustand "abgebrochen".
  Wer das Muster versteht, kann auch erklären, warum
  `catch (InvalidOperationException)` um ein `Task.Wait()` nie trifft.
- `Sammle`: Der Test mit der verschachtelten `AggregateException` zeigt
  `Flatten()`; ohne den Aufruf käme eine einzige Meldung ("One or more errors
  occurred..."). `WaitAll` wartet auf ALLE Aufgaben, auch wenn eine
  früh scheitert: Der Test mit dem Zähler prüft es. Wer stattdessen jede Task
  einzeln mit `Wait()` abfragt und beim ersten Fehler abbricht, besteht
  nicht.
- `ZaehleHoch`: Wer in der Schleife `if (token.IsCancellationRequested) return;`
  schreibt, beendet die Methode, aber die Aufgabe endet "erfolgreich", nicht
  "abgebrochen": Der Test `IsCanceled` deckt das auf. Das ist die
  wichtigste Einsicht dieser Aufgabe. Gesprächsanlass: Warum ist
  "abgebrochen" nicht dasselbe wie "fehlgeschlagen"? (Der Aufrufer wollte es
  so; es ist kein Fehler, der protokolliert werden müsste.)
- Abbruch ist kooperativ: Eine Schleife ohne Abfrage ließe sich nie
  beenden. `Thread.Abort` gibt es in .NET nicht mehr; Abschnitt 17.2.5
  (Seite 1091) behandelt die kooperative Terminierung von Threads.
- `ErstenTreffer`: Die Prüfung gehört VOR den Aufruf des Prädikats. Der
  Test mit dem Abbruch beim dritten Element zeigt, dass der Abbruch
  mitten in der Arbeit bemerkt wird; die Tests brauchen dafür keinen zweiten
  Thread und sind deshalb stabil.
- Die Aufgabe verlangt kein `await`; der Abschnitt zu async kommt in der
  nächsten Aufgabe.

Modellantwort: `solution/`.
