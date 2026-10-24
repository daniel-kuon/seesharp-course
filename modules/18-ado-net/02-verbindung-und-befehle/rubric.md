# Rubrik: Verbindung, Befehle und Parameter (nur für die Betreuung)

- **Kernidee:** Befehl und Daten getrennt halten. Der SQL-Text enthält nur
  Platzhalter (`@name`), die Werte reisen als `SqliteParameter` mit. Dann gibt es
  keine SQL-Injection, keine Probleme mit Hochkommas und keine Formatfragen.
  Außerdem: jedes `DbCommand` und jede `DbConnection` sind `IDisposable` und
  gehören in `using`.
- Typische Fehler:
  - SQL per `$"... '{name}'"` gebaut (der Injection-Test schlägt fehl, oder die
    Tabelle ist weg: Genau das zeigt der Test);
  - `Parameters.AddWithValue("@telefon", telefon)` mit `null`: Der Provider wirft
    eine `InvalidOperationException` (Parameterwert nicht gesetzt). Richtig ist
    `(object?)telefon ?? DBNull.Value`;
  - `(string)befehl.ExecuteScalar()` bei einer NULL-Nummer: `InvalidCastException`
    (DBNull ist ein eigener Typ, kein `null`);
  - `Anzahl()` mit `(int)` statt `(long)`: ebenfalls `InvalidCastException`
    (das Objekt ist ein geboxtes `long`; der Cast muss zum Boxtyp passen). `Convert.ToInt32`
    ist eine gültige Alternative;
  - die übergebene Verbindung in `using` gesetzt oder `Close()` aufgerufen: Der
    Aufrufer hat dann eine geschlossene Verbindung (Test
    `Adressbuch_schliesst_die_Verbindung_des_Aufrufers_nicht`);
  - bei `ZaehleInDatei` kein `using`: Die Verbindung bleibt bis zur Garbage
    Collection offen. Im Code prüfen, der Test kann das wegen des Connection-Poolings
    von `Microsoft.Data.Sqlite` nicht erkennen (Frage: Was ist das Pooling, warum
    räumen die Tests mit `ClearAllPools` auf?).
- Gesprächsfrage: Warum liefert `ExecuteNonQuery` bei `UPDATE` die Zahl der Zeilen und
  bei `CREATE TABLE` etwas Bedeutungsloses (`0`/`-1`)? Wozu nutzt man die Zahl
  (Prüfung, ob der Kontakt überhaupt existierte)?
- Zur offenen Frage: `DBNull.Value` ist das Singleton, mit dem ADO.NET „kein Wert in der
  Datenbank“ darstellt, weil `null` in ADO.NET „Parameter nicht gesetzt“ bzw. „keine
  Zeile“ bedeutet. In C# wird beim Lesen `IsDBNull`/`is DBNull` geprüft und zu `null`
  übersetzt; beim Schreiben `?? DBNull.Value`.
- Modellantwort: `solution/`; Vorlagen `samples/ADO.NET/Einstieg`,
  `Parametrisierte Abfragen`, `Temporäre Verbindung` (dort mit dem SQL Server).
