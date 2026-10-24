# Rubrik: DataReader und Objektabbildung (nur für die Betreuung)

- **Kernidee:** Ein `DbDataReader` ist ein Vorwärts-Cursor über das Ergebnis: Zeile
  für Zeile, nichts wird im Speicher gehalten, solange man nicht selbst sammelt.
  Er belegt die Verbindung (und bei manchen Providern sperrt er sie), deshalb wird er
  sofort zu Ende gelesen und mit `using` freigegeben. Das „Abbilden“ (*Mapping*) ist
  dann eine Schleife, die pro Zeile ein Objekt (hier ein `record`) erzeugt. Die
  Spaltennummern ermittelt man einmal vor der Schleife mit `GetOrdinal`.
- Typische Fehler:
  - `GetString` ohne `IsDBNull` (Ausnahme bei Artikel ohne Kategorie; der Test
    `Alle_laesst_fehlende_Kategorie_null` zeigt es);
  - Suchtext in den SQL-Text gebaut (`LIKE '%` + teil + `%'`): Der
    Injection-Test schlägt fehl; Prozentzeichen gehören in den Parameterwert;
  - `GetOrdinal` in jeder Schleifenrunde (funktioniert, ist aber unnötig; im
    Gespräch ansprechen);
  - Leser nicht freigegeben: Die Tests erkennen unfertig gelesene Abfragen (ein
    `DROP TABLE` scheitert dann); im Code zusätzlich `using` prüfen;
  - `SUM` auf leerer Tabelle: `(decimal)befehl.ExecuteScalar()` wirft
    (`DBNull` bzw. falscher Typ). Außerdem liefert SQLite für `SUM(REAL * INTEGER)` ein
    `double`; `Convert.ToDecimal` ist der passende Weg. Alternative: `COALESCE(SUM(...), 0)` in SQL.
- Gesprächsfragen: Welche Vor- und Nachteile hat die Berechnung in SQL (weniger Daten
  über die Leitung, die Datenbank kann Indizes nutzen) gegenüber C# (Logik an einer
  Stelle, mit Tests in C#)? Warum ist `decimal` für Geld richtig, obwohl SQLite hier
  `REAL` (Gleitkomma) speichert? (Im echten Projekt würde man Cent als `INTEGER` speichern.)
- `LIKE` ist in SQLite für ASCII-Zeichen unabhängig von Groß-/Kleinschreibung, für
  Umlaute nicht. Das Zeichen `%` im Suchtext wirkt als Platzhalter; echtes Escapen
  (`ESCAPE`) ist hier nicht verlangt.
- Modellantwort: `solution/`; Vorlage `samples/ADO.NET/DataReader` (dort mit dem SQL Server).
