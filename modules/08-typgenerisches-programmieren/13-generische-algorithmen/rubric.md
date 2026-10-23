# Rubrik — Zusatz generische Algorithmen (nur für die Betreuung)

- `BinaereSuche`: Der Test benutzt einen eigenen Typ `Zaehler`, der jeden
  `CompareTo`-Aufruf mitzählt, und verlangt höchstens 20 Vergleiche bei
  1000 Elementen (zwei Vergleiche pro Schritt sind erlaubt). Lineare Suche
  fällt durch. Typische Fehler: `mitte = (links + rechts) / 2` ist hier
  unkritisch, bei sehr großen Arrays aber ein Überlauf
  (`links + (rechts - links) / 2`); Endlosschleife durch `links = mitte`
  statt `mitte + 1`.
- `Zusammenfuehren` mit `Array.Sort` statt Merge-Schritt besteht die Tests;
  dann nach der Laufzeit fragen (O(n log n) statt O(n)) und den
  Merge-Schritt nachholen lassen.
- `MinMax` gibt ein benanntes Tupel zurück (Level 6); Aufrufer können
  dekonstruieren: `var (min, max) = Algorithmen.MinMax(...)`.
- Gleiche Elemente in `Zusammenfuehren`: `<= 0` übernimmt zuerst aus `a`
  (stabil). Gute Frage zum Nachdenken, nicht getestet.

Modellantwort: `solution/`.
