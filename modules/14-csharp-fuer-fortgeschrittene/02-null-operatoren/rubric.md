# Rubrik — Null-Operatoren (nur für die Betreuung)

- Kern: `?.` bricht die ganze restliche Kette ab (Kurzschluss), `??` liefert
  den Ersatzwert, `??=` weist nur zu, wenn die linke Seite null ist. Die
  Zeile `k?.Alter = berechne()` wertet die rechte Seite nur aus, wenn `k` nicht
  null ist; der Test `SetzeAlterBerechnet_…` prüft das mit einem Zähler.
- Die null-bedingte Zuweisung ist neu in C# 14; ein Lösungsweg mit
  `if (k is not null) k.Alter = alter;` ist fachlich richtig, verfehlt aber das
  Lernziel. Nachfragen, was die Zeile vor C# 14 bedeutet hätte
  (Übersetzungsfehler: ältere Compiler meldeten CS0131, der aktuelle mit
  `LangVersion` 13 meldet CS9260).
- `Erstes` bei einer leeren Liste wirft `ArgumentOutOfRangeException`: `?[ ]`
  prüft nur auf null, nicht auf Länge. Gesprächsanlass: `FirstOrDefault()` (Level 13).
- `Nachschlagen`: Warum ist `wert` nach `== true` sicher zugewiesen? (Der
  Compiler weiß: Ergebnis `true` heißt, `?.` hat den Aufruf ausgeführt.)

Modellantwort: `solution/` bzw. `samples/C# für Fortgeschrittene/Nullable-Kontext für Referenztypen/null-bedingte Zuweisung`.
