# Connection, Commands, and Parameters

Read **sections 19.7.2 through 19.7.5** in the book, especially **19.7.5 DbCommand** (page 1323): `ExecuteNonQuery`, `ExecuteScalar`, parameters. The book uses `SqlConnection` for SQL Server; we use `SqliteConnection` from `Microsoft.Data.Sqlite` (the classes are derived from the same base classes, `DbConnection` and `DbCommand`, and the methods have the same names).

Open `Adressbuch.cs`. The `Adressbuch` class manages the `Kontakt` table (`Id`, `Name`, `Telefon`) via an **open connection that belongs to the caller**: You neither open nor close it here, but create a separate command in each method (in a `using` statement). All values go into the command as **parameters**, never via string concatenation.

1. `Erzeuge()`: `CREATE TABLE IF NOT EXISTS` (can be called multiple times).
2. `Hinzufuegen(name, telefon)`: `INSERT` with `@name` and `@telefon`. A `null` phone number is stored as **NULL** (`DBNull.Value`).
3. `Anzahl()`: `ExecuteScalar`; SQLite returns a `long` here.
4. `Aendere(name, neuesTelefon)` and `Entferne(name)` return the **number of affected rows** (`ExecuteNonQuery`).
5. `Telefon(name)`: `string?`. `ExecuteScalar` returns `null` if there is no row, and `DBNull.Value` if the row has a NULL number. Both are converted to `null`.
6. `ZaehleInDatei(dateipfad)`: a static method that opens its **own** connection to a database file (`Data Source=<Pfad>`) and releases it in a `using` statement. The path may contain spaces, umlauts, and commas.

The tests also store the name `Robert'); DROP TABLE Kontakt;--` and verify that the table is still there afterward and that the name was stored verbatim.

Then answer the two questions.

Tests: `Erzeuge_legt_die_Tabelle_an_und_ist_wiederholbar`, `Hinzufuegen_und_Anzahl_zaehlen_die_Kontakte`, `Telefon_liefert_die_gespeicherte_Nummer`, `Fehlende_Nummer_wird_als_NULL_gespeichert_und_als_null_gelesen`, `Telefon_eines_unbekannten_Kontakts_ist_null`, `Aendere_liefert_die_Zahl_der_geaenderten_Zeilen`, `Entferne_liefert_die_Zahl_der_geloeschten_Zeilen`, `Hinzufuegen_ist_gegen_SQL_Injection_sicher`, `Aendere_und_Entferne_sind_gegen_SQL_Injection_sicher`, `Adressbuch_schliesst_die_Verbindung_des_Aufrufers_nicht`, `ZaehleInDatei_oeffnet_eine_eigene_Verbindung_zu_einem_Pfad_mit_Sonderzeichen`.
