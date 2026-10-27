# Rubrik: Zusatz: Bestellungen auswerten (nur für die Betreuung)

- **Kernidee:** Mehrere Tabellen werden über `JOIN ... ON` entlang der Fremdschlüssel
  verknüpft; `GROUP BY` fasst Zeilen zu Gruppen zusammen, auf die Aggregatfunktionen
  (`SUM`) wirken.
- Typische Fehler:
  - `SUM(Preis)` statt `SUM(Menge * Preis)`;
  - fehlender Gleichstand-Sortierschlüssel bei `Top3Produkte` (Reihenfolge von Hammer
    und Harke zufällig);
  - `GROUP BY` fehlt oder gruppiert nach der falschen Spalte.
- `LIMIT 3` ist in der Aufgabe vorgegeben (das Buch kennt weder `LIMIT` noch `TOP`).
- **Bonus (Deep Dive)**, nicht im Buch, nicht verlangt: `KundenOhneBestellung` mit
  `LEFT JOIN ... IS NULL` (Anti-Join; ein `LEFT JOIN` behält alle Zeilen der linken
  Tabelle, wo rechts nichts passt, steht `NULL`). Typische Fehler: `JOIN` statt
  `LEFT JOIN` (leeres Ergebnis), `= NULL` statt `IS NULL`. Alternativen sind erlaubt,
  z. B. `NOT EXISTS` oder `NOT IN`.
- Modellantwort: `solution/`; keine Vorlage im `samples`-Ordner.
