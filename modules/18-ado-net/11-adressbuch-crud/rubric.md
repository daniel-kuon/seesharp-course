# Rubrik: Zusatz: Adressbuch mit Suche (nur für die Betreuung)

- **Kernidee:** Die vier Grundoperationen (Anlegen, Ändern, Löschen, Suchen) bestehen
  aus je einem parametrisierten Befehl. Schreibende Befehle liefern die Zahl der
  betroffenen Zeilen (daraus wird „gab es den Kontakt?“), lesende werden Zeile für
  Zeile in Objekte abgebildet, wobei NULL zu `null` wird.
- Typische Fehler:
  - SQL per Textverkettung (Test mit `O'Brien'); DROP TABLE ...` schlägt fehl);
  - `GetString` für ein NULL-Telefon ohne `IsDBNull` (Ausnahme bei Anna);
  - `Aendern` liefert immer `true` (die Zahl der Zeilen wird nicht ausgewertet);
  - neue Id über `SELECT MAX(Id)`: wettlaufanfällig und bei leerer Tabelle `DBNull`;
    `last_insert_rowid()` bzw. `RETURNING` ist richtig;
  - `Suche` sortiert nicht (die Reihenfolge der Datenbank ist ohne `ORDER BY` nicht
    zugesichert);
  - Verbindung selbst geschlossen oder in `using` gesetzt.
- Modellantwort: `solution/`; keine Vorlage im `samples`-Ordner.
