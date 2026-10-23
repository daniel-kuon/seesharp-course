# Rubrik — Zusatz Bereiche (nur für die Betreuung)

- `Count`: `(Ende - Start) / Schritt + 1`, wenn die Richtung stimmt, sonst
  0. Die Ganzzahldivision schneidet den Rest ab (1 bis 10 in Viererschritten:
  9 / 4 + 1 = 3). `Enthaelt` analog: `(zahl - Start) % Schritt == 0` und
  Schrittindex `0 .. Count - 1`. Wer stattdessen iteriert, besteht auch;
  nach der Laufzeit für `new Bereich(0, 1_000_000_000)` fragen.
- `GetEnumerator` über den Schrittindex (`Start + i * Schritt` für
  `i < Count`) statt `for (int x = Start; x <= Ende; x += Schritt)`:
  Letzteres braucht zwei Fassungen für auf/ab und läuft bei `Ende` nahe
  `int.MaxValue` über (Endlosschleife). Nicht getestet, aber eine gute
  Frage.
- Unendliche Folge: Wer `Quadratzahlen` in ein Array sammelt, hängt den
  Test auf (der Grader bricht nach einer Zeitgrenze ab). Faulheit ist hier
  keine Optimierung, sondern Voraussetzung.
- `Erste<T>` ist generisch und funktioniert deshalb mit `Bereich`
  (`IEnumerable<int>`) und `Quadratzahlen` (`IEnumerable<long>`).
  Ausblick: LINQ (Level 13) hat genau das als `Take`.

Modellantwort: `solution/`.
