# Rubrik: Provider-unabhängiger Code, DataTable und LINQ-to-DataSet (nur für die Betreuung)

- **Kernidee:** Programmiere gegen die abstrakten Basisklassen (`DbConnection`,
  `DbCommand`, `DbDataReader`) und lass die Fabrik die konkreten Objekte erzeugen.
  Dann steckt die Wahl des Datenbanksystems an einer einzigen Stelle (Fabrik und
  Verbindungszeichenfolge). `DataTable` ist ein getrennt vom Server arbeitender
  Zwischenspeicher; mit `AsEnumerable()` und `Field<T>` lässt er sich wie jede andere
  Sammlung mit LINQ abfragen.
- Typische Fehler:
  - `using Microsoft.Data.Sqlite` im Datenzugriffsprojekt oder Casts auf `SqliteConnection`
    (Test `Der_Datenzugriffscode_kennt_keinen_Provider`; der Starter besteht ihn
    absichtlich schon, er schützt die Musterlösung vor dem Abkürzen);
  - Verbindungszeichenfolge per `$"Data Source={datei};Mode=ReadOnly"` verkettet:
    funktioniert nur, solange der Pfad kein `;` oder Anführungszeichen enthält. Der
    Builder maskiert (Gesprächsfrage: Welche Pfade würden die Verkettung brechen?);
  - `Field<decimal>` auf einer `REAL`-Spalte: `InvalidCastException`, die Spalte ist
    `double`. Auch `r["Preis"]` mit Cast `(decimal)` scheitert. `Field<T>` prüft
    außerdem `DBNull` (liefert `null` für Nullable-Typen, wirft sonst);
  - `LiesTabelle` ohne `Load`, stattdessen Leser in einer Schleife zu Fuß befüllt
    (geht, ist aber länger; nach den Spaltentypen fragen);
  - Leser oder Befehl nicht freigegeben.
- Gesprächsfrage: Der Code ist provider-unabhängig, die SQL-Texte aber nicht
  (`LIMIT` gegen `TOP`). Was nützt die Unabhängigkeit dann noch, was nicht?
- Der Tipp zu `Mode=ReadOnly` ist SQLite-spezifisch; im Provider-offenen Code kommt solch
  ein Schlüssel aus Konfiguration oder dem Builder des gewählten Providers.
- Hinweis: Plan und Aufgabe nennen `decimal`-Preise; mit SQLite ist die Spalte `double`.
- Modellantwort: `solution/`; Vorlagen `samples/ADO.NET/DbProviderFactory`,
  `ConnectionStringBuilder`, `LINQ-to-DataSet`, `DataSetTableRowColumn`.
