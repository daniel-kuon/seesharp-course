# Rubrik — Enums und Tupel (nur für die Betreuung)

- Enum-Validierung: `Enum.IsDefined(value)` (generische Fassung) oder
  `Enum.IsDefined(typeof(Temperament), value)`; beides gut. Nachfragen,
  warum ein Cast auf 13 nicht knallt.
- `TryParse("7")` liefert `true` und den Wert 7 — die Falle steht in der
  Anleitung; prüfen, ob der Trainee sie verstanden oder nur umschifft hat.
- Benannte Tupel-Elemente: `an.First` statt `an.Item1`; Discards (`_`) beim
  Dekonstruieren zeigen.
- `Deconstruct` mit `out`-Parametern: Im Buch stehen sie in 5.3.1.3.2.2
  (Seite 317), geübt werden sie hier zum ersten Mal; kurz erklären, warum
  kein Rückgabewert nötig ist.

Modellantwort: `solution/` bzw. `samples/Weitere .NETte Typen/Enumerationen`
und `Struktur-Tupel/*`.
