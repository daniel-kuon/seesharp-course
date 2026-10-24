# Rubrik: Zusatz: Bestellungen auswerten (nur für die Betreuung)

- **Kernidee:** Mehrere Tabellen werden über `JOIN ... ON` entlang der Fremdschlüssel
  verknüpft; `GROUP BY` fasst Zeilen zu Gruppen zusammen, auf die Aggregatfunktionen
  (`SUM`) wirken. Ein `LEFT JOIN` behält alle Zeilen der linken Tabelle; wo rechts
  nichts passt, steht `NULL`, und `IS NULL` findet diese Fälle (Anti-Join).
- Typische Fehler:
  - `JOIN` statt `LEFT JOIN` bei den Kunden ohne Bestellung (leeres Ergebnis);
  - `= NULL` statt `IS NULL`;
  - `SUM(Preis)` statt `SUM(Menge * Preis)`;
  - fehlender Gleichstand-Sortierschlüssel bei `Top3Produkte` (Reihenfolge von Hammer
    und Harke zufällig);
  - `GROUP BY` fehlt oder gruppiert nach der falschen Spalte.
- Alternativen sind erlaubt, z. B. `NOT EXISTS` oder `NOT IN` statt `LEFT JOIN ... IS NULL`.
- Modellantwort: `solution/`; keine Vorlage im `samples`-Ordner.
