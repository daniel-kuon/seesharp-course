# Rubrik — Iteratoren (nur für die Betreuung)

- Vergleich mit 9.4: dieselbe Funktion, ein Bruchteil des Codes. Mit dem
  Decompiler zeigen, dass der Compiler die Enumerator-Klasse erzeugt.
- Faulheit: Die Bereichsprüfung in `RangeIt` läuft erst beim ersten
  `MoveNext`. Nachfragen, ob der Trainee die Folge versteht (Ausnahmen aus
  Iteratoren tauchen beim Durchlaufen auf, nicht beim Aufruf).
- `RangeItUpDown`: zwei Schleifen oder eine mit Schrittweite `±1`; beides
  gut.
- Ausblick: LINQ (Level 13) besteht fast nur aus solchen faulen Iteratoren.

Modellantwort: `solution/` bzw. `samples/Interfaces/Enumeratoren`.
