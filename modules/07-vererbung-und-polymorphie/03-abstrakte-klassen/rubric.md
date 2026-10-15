# Rubrik — Abstrakte Klassen (nur für die Betreuung)

- Kernfrage: Warum abstrakt statt virtueller Leerimplementierung? (Der
  Compiler erzwingt die Vollständigkeit jeder Unterklasse; ein
  vergessenes `Inhalt` fällt beim Bauen auf, nicht beim Kunden.)
- `abstract` Eigenschaften mit nur `get`: Syntax kurz zeigen.
- Liskov (7.14): Darf `Skaliere` in einer Unterklasse plötzlich den
  Mittelpunkt verschieben? Diskussion über Verträge.
- Ausblick: Level 9 vergleicht abstrakte Klassen mit Interfaces.

Modellantwort: `solution/` bzw. `samples/Vererbung und Polymorphie/abstract`.
