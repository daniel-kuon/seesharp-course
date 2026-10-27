# Rubrik — Threads, lock und Interlocked (nur für die Betreuung)

- Kern: Ein Thread ist billig zu starten und teuer zu verstehen. Drei
  Dinge müssen sitzen: `Start()` und `Join()` (ohne `Join` ist das
  Ergebnisarray noch nicht fertig), gemeinsamer Zustand ist gefährlich, und
  zwei Werkzeuge schützen ihn (`lock` für Bereiche, `Interlocked` für einzelne
  Operationen).
- Abweichung vom Plan: Die Arbeit steckt in `Berechne(eingabe, threads,
  f)`; `Quadrate` ruft es mit `x => x * x` auf. Nur so lässt sich testen, dass
  die Blöcke WIRKLICH gleichzeitig laufen (Barrier mit drei Teilnehmern):
  Wer die Threads nacheinander startet und sofort `Join()` aufruft, scheitert
  an der Zeitüberschreitung, statt unbemerkt sequenziell zu rechnen.
- Typische Fehler: Die Schleifenvariable `start` direkt im Lambda benutzen
  (Threads sehen einen späteren Wert, oft den Endwert: die Closure-Falle); `Join()` direkt nach
  `Start()` im selben Schleifendurchlauf; die Blockgröße abrunden und dadurch
  Elemente am Ende vergessen (7 Elemente auf 3 Threads).
- `SichererZaehler`: Wer nur das Erhöhen sperrt und das Lesen nicht, besteht
  den Test, hat aber das Sichtbarkeitsproblem nicht verstanden: Nachfragen.
  Ein `lock (this)` oder auf ein öffentliches Objekt ist ein Stilmangel
  (jeder kann dasselbe Objekt sperren): privates `readonly object` verlangen
  (ab .NET 9 ist auch `private readonly Lock _gate = new();` richtig).
- `AtomarerZaehler`: `Interlocked.Increment(ref _wert)` ist ein einzelner
  atomarer CPU-Befehl, deutlich billiger als `lock` bei so kurzer Arbeit.
  Gesprächsanlass: Warum hilft `Interlocked` nicht, sobald zwei Felder
  zusammen konsistent bleiben müssen? (Dann braucht es `lock`.)
- Das Quiz: Der exakte Mindestwert 2 ist ein bekanntes Rätsel; wichtiger ist
  die Einsicht, dass der Wert unvorhersagbar ist und deshalb nicht in einem
  Test stehen darf. Darum prüft die Aufgabe nur die korrekten Varianten.

Modellantwort: `solution/`.
