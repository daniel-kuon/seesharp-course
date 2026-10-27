# Rubrik — Sortieren und Aggregate (nur für die Betreuung)

- Kernidee: `OrderBy` sortiert nach genau einem Schlüssel; weitere Schlüssel
  nur über `ThenBy`. Bonus (Deep Dive): `OrderBy` sortiert **stabil** (nicht im Buch). Ein zweites `OrderBy` würde die erste
  Sortierung überschreiben (typischer Fehler: `OrderBy(...).OrderByDescending(...)`).
- Der Test mit gleichen Preisen (Lampe/Leuchte) fängt Lösungen, die
  `List.Sort` verwenden, nicht — aber `OrderBy` ist hier ohnehin das Mittel.
- `Skip`/`Take` vertragen Überschreitungen (leere Seite statt Ausnahme); das
  ist ein Unterschied zu `ElementAt`.
- `Preisspanne` auf leerer Quelle: `Min`/`Max`/`Average` werfen; die Lösung
  prüft mit `Any()` zuerst (Bonus (Deep Dive): `DefaultIfEmpty()`). Nachfrage: Warum
  zählt `Sum` auf leerer Quelle 0, `Average` aber nicht?
- Mehrfaches Aufzählen: `produkte` wird in `Preisspanne` mehrfach durchlaufen
  (`Min`, `Max`, `Average`); für List unbedenklich, für teure Quellen ein
  Fall für `ToList()` (Verweis auf 13/03).

Modellantwort: `solution/` bzw. `samples/LINQ-to-Objects/Sortieren`.
