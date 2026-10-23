# Rubrik — Zusatz Ringpuffer (nur für die Betreuung)

- Kern ist die Modulo-Arithmetik: Position des neuesten Elements
  `(anfang + anzahl) % data.Length`, Indexer `data[(anfang + index) %
  data.Length]`. Wer stattdessen Elemente verschiebt, besteht die Tests
  auch; Aufwand O(n) pro Entnahme ansprechen.
- `data[anfang] = default!;` beim Entnehmen: nicht testbar, aber wichtig
  für den Garbage Collector (Level 1). Nachfragen, warum es für `int` egal
  wäre und für große Objekte nicht.
- `EntnehmenOderDefault()` gibt `T?` zurück: Für unbeschränktes `T` ist
  das bei Werttypen **kein** `Nullable<T>`; `Ringpuffer<int>` liefert 0,
  nicht `null`. Gute Brücke zur `where T : struct`-Frage aus Übung 5.
- Ausblick: `Queue<T>` (Level 10) wächst dynamisch statt zu überschreiben.

Modellantwort: `solution/`.
