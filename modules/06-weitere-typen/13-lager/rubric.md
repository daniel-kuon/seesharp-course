# Rubrik — Zusatzaufgabe Lager (nur für die Betreuung)

- `with` erzeugt eine flache Kopie mit geänderten Eigenschaften; das
  Original bleibt. Nachfragen: Warum kann `Nachbestellen` die Artikel nicht
  einfach im übergebenen Array ändern? (Positionale Records haben nur
  `init`-Eigenschaften; außerdem soll der Aufrufer sein Array behalten.)
- `Einlagern` mit ungültiger Menge liefert `a` selbst (Test mit
  `Assert.Same`): Bei unveränderlichen Objekten ist das gefahrlos. Gute
  Gelegenheit, Referenz- und Wertgleichheit gegenüberzustellen
  (`Assert.Same` vs. `Assert.Equal`).
- Bonus (Deep Dive): Rundung: `MidpointRounding.AwayFromZero` ist die kaufmännische Rundung;
  der Standard von `Math.Round` ist "Banker's Rounding" (0,275 → 0,28, aber
  0,265 → 0,26). Kurz zeigen lassen.
- `Preisstatistik`: Min/Max mit dem ersten Element initialisieren, nicht mit
  0 (sonst wäre das Minimum bei lauter positiven Preisen 0).
- Ausblick: Mit LINQ (Level 13) schrumpfen `Gesamtwert` und
  `Preisstatistik` auf je eine Zeile.

Modellantwort: `solution/Lager/Lager.cs`.
