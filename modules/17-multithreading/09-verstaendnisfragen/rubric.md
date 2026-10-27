# Rubrik — Verständnisfragen Level 17 (nur für die Betreuung und den KI-Tutor)

Die Code-Ausgaben wurden in einem Konsolenprojekt (net10.0) geprüft. Eine
Antwort besteht, wenn die genannten Kernpunkte sinngemäß vorkommen; Wortlaut
und Fachbegriffe müssen nicht exakt stimmen.

## race-condition

Kernpunkte:
- `zaehler++` ist **keine unteilbare Operation**, sondern Lesen, Addieren, Schreiben. Zwei Threads können denselben alten Wert lesen und beide dasselbe Ergebnis zurückschreiben: **ein Update geht verloren**. Wie oft das passiert, entscheidet der Zufall der Thread-Umschaltung (Race Condition).
- Lösung 1: `lock` auf ein privates Objekt um den Zugriff (allgemein, auch für mehrere zusammengehörige Anweisungen und Sammlungen).
- Lösung 2: `Interlocked.Increment(ref zaehler)` bzw. `Interlocked.Add` (genügt für einzelne Operationen auf Zahlen; schneller, kein Blockieren).

Typische Irrtümer: `++` sei eine einzelne Anweisung und daher sicher; der Verlust sei vorhersagbar (z. B. immer mindestens 1.000.000); `volatile` reiche (es sorgt nur dafür, dass alle Threads den aktuellen Wert sehen, macht `++` aber nicht unteilbar; 17.2.4.2.4, Seite 1085).

## lock-regeln

Kernpunkte:
- `lock (objekt)` lässt **nur einen Thread zugleich** in den geschützten Block; alle Threads müssen dasselbe Sperrobjekt benutzen (ein Referenztyp, kein `int`, und nicht für jeden Aufruf ein neues Objekt).
- Das Sperrobjekt ist **privat** (z. B. `private readonly object _gate = new();`), damit fremder Code nicht auf dasselbe Objekt sperren und so Blockaden auslösen kann.
- Eine `List<T>` verträgt gleichzeitigen Zugriff nicht: **jeder** Zugriff (schreibend und lesend) gehört unter dieselbe Sperre, sonst kann ein Lesen mitten in eine Änderung fallen und inkonsistente Werte oder Ausnahmen liefern.

Typische Irrtümer: Lesen brauche keine Sperre; man könne auf die Liste selbst oder auf ein Zahlenfeld sperren; jeder Thread dürfe sein eigenes Sperrobjekt anlegen.

## task-ausnahmen

Kernpunkte:
- Eine Ausnahme in einer Aufgabe wird **nicht sofort** am Aufrufer sichtbar, sondern erst **beim Warten** (`Wait`, `WaitAll`, `Result`) bzw. beim `await`.
- Beim Warten kommt sie als **`AggregateException`** an: Sie sammelt **alle** Fehler (mehrere Aufgaben können unabhängig scheitern) in `InnerExceptions`; `Flatten()` löst verschachtelte Gruppen auf.
- Bei `await` wird die **erste Ausnahme im Originaltyp** weitergegeben (nicht als `AggregateException`), sodass man normal mit `catch (SpezifischeAusnahme)` arbeiten kann.

Typische Irrtümer: Die Ausnahme beende das Programm sofort an der Stelle von `Task.Run`; `AggregateException` enthalte nur den ersten Fehler; `await` liefere ebenfalls eine `AggregateException`.

## abbruch

Kernpunkte:
- Der **Aufrufer** besitzt die `CancellationTokenSource` und ruft `Cancel()` auf; die **Aufgabe** bekommt das `CancellationToken` (`cts.Token`) und prüft es regelmäßig, am einfachsten mit `ThrowIfCancellationRequested()`.
- **Kooperativ** heißt: Es wird kein Thread von außen abgeschossen; die Aufgabe muss selbst auf den Abbruchwunsch reagieren (sonst läuft sie weiter).
- Die Aufgabe endet im Zustand **„abgebrochen“** (Canceled, `IsCanceled`); beim Warten kommt eine `OperationCanceledException` (bzw. `TaskCanceledException`, bei `Wait` verpackt in einer `AggregateException`).

Typische Irrtümer: `Cancel()` beende den Thread sofort; die Aufgabe sei danach „fehlgeschlagen“ (Faulted); `Thread.Abort` sei der Weg.

## async-fallen

Kernpunkte:
- Bei `await` **gibt die Methode den Thread frei** und läuft, wenn die erwartete Aufgabe fertig ist, weiter (Fortsetzung); der Thread kann solange anderes tun, deshalb blockiert nichts.
- `async void`: Der Aufrufer kann nicht warten und ihre Ausnahmen nicht abfangen; sie werden im Synchronisierungskontext geworfen und beenden z. B. eine Konsolenanwendung (17.6.12.1, Seite 1197); nur für Ereignishandler, sonst `async Task`.
- `.Result`/`.Wait()` in einer UI-Anwendung: Der UI-Thread blockiert und wartet auf die Aufgabe; deren Fortsetzung nach dem `await` will aber im UI-Thread weiterlaufen (Synchronisierungskontext) und kann das nicht, solange er blockiert ist: **Deadlock**. Lösung: durchgehend `await` verwenden.

Typische Irrtümer: `await` starte einen neuen Thread oder blockiere den aktuellen; `async void` sei eine Kurzform für `async Task`; das Deadlock-Problem trete in Konsolenanwendungen genauso auf.

## code-lock-zaehler

Ausgabe: `4000`.
Kernpunkte:
- Vier Threads zählen je 1000-mal; `lock (gate)` sorgt dafür, dass immer nur einer `zaehler++` ausführt, kein Update geht verloren; `Join()` wartet auf alle, erst dann wird ausgegeben. Das Ergebnis ist **bei jedem Lauf** 4000.
- Ohne `lock` wäre das Ergebnis unsicher: oft weniger als 4000 und bei jedem Lauf anders (Race Condition); mit zu wenig Last fällt es manchmal nicht auf.

Typische Irrtümer: Ohne `Join` stimme die Ausgabe trotzdem; das Ergebnis sei 1000 (nur ein Thread zähle); ohne `lock` sei es immer 4000.

## code-thread-kopie

Ausgabe: `0,10,20`.
Kernpunkte:
- Jeder Thread schreibt an seinen eigenen Index `kopie` des Arrays; `Join()` wartet auf alle, danach steht das Ergebnis fest.
- `int kopie = i;` ist eine **neue Variable je Schleifendurchlauf**. Würde das Lambda `i` direkt benutzen, fingen alle Threads **dieselbe** Schleifenvariable ein; die Threads lesen sie erst, wenn sie laufen, und bis dahin kann die Schleife weitergezählt haben (am Ende auf 3): Sie würden einen falschen, zufälligen Index sehen (bei Index 3 sogar eine `IndexOutOfRangeException`).

Typische Irrtümer: `0,1,2` (Wert vergessen zu multiplizieren); die Kopie sei überflüssig, weil `i` ein Wert sei.

## code-waitall

Ausgabe, zwei Zeilen: `2` und `A,B`.
Kernpunkte:
- Beide Aufgaben scheitern unabhängig; `Task.WaitAll` wartet auf beide und wirft **eine** `AggregateException`, die **beide** Fehler in `InnerExceptions` enthält (Anzahl 2).
- `WaitAll` sammelt die Fehler in der Reihenfolge der übergebenen Aufgaben (in .NET 10 geprüft), das ist aber nicht dokumentiert zugesichert; deshalb ist nach der Nachricht sortiert (A, B).

Typische Irrtümer: Es werde nur die erste Ausnahme gemeldet (Anzahl 1); der `catch` nehme `InvalidOperationException` direkt entgegen; die Ausnahme erscheine schon bei `Task.Run`.

## code-async-reihenfolge

Ausgabe, vier Zeilen: `start 1`, `dazwischen`, `ende 1`, `2`.
Kernpunkte:
- `HoleAsync(1)` läuft **synchron bis zum ersten `await`**: Darum erscheint „start 1“ zuerst.
- Das `await Task.Delay(50)` gibt den Aufrufer frei: `HoleAsync` liefert eine noch nicht beendete `Task<int>` zurück, und „dazwischen“ wird ausgegeben, bevor die Methode fertig ist.
- Mit `await t` wartet der Aufrufer (ohne Thread zu blockieren) auf das Ende: erst „ende 1“, dann die Rückgabe 2.

Typische Irrtümer: `start 1`, `ende 1`, `dazwischen`, `2` (sequenzielles Verhalten, als wäre `await` ein blockierendes Warten schon beim Aufruf); „dazwischen“ erscheine zuerst.
