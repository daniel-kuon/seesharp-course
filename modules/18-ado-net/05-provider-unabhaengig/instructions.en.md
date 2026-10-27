# Provider-independent code, DataTable, and LINQ to DataSet

Read section **19.7.3**, **“Provider-independent source code”** (page 1314), then **section 19.7.9** on DataSet and `DataTable` (page 1343), and **section 19.7.17, “LINQ to** `DataSet`**”** (page 1365). Instead of programming against `SqliteConnection`, you program against the base classes `DbConnection`, `DbCommand`, and `DbDataReader`. A `DbProviderFactory` creates the appropriate objects for the respective provider.

Open `Zugriff.cs`. The `Datenzugriff` project must **not** have a reference to `Microsoft.Data.Sqlite` (a test checks this); the tests pass `SqliteFactory.Instance` from outside.

1. `OeffneVerbindung(fabrik, verbindungsstring)` : `fabrik.CreateConnection()`, set the string, `Open()`. If the factory returns `null`, throw an `InvalidOperationException`.
2. `LiesTabelle(verbindung, sql)`: Execute the command and load the result into a `DataTable` using `DataTable.Load(leser)`. Release the command and the reader.
3. `Verbindungsstring(fabrik, datei)`: The book shows the `DbConnectionStringBuilder` in 19.7.4.2 provider-specifically (`new SqlConnectionStringBuilder()`). Provider-independently, the factory supplies it (not in the book, given here): `var builder = fabrik.CreateConnectionStringBuilder()!;` Set the keys `builder["Data Source"] = datei;` and `builder["Mode"] = "ReadOnly";` and return `ConnectionString`. The builder escapes special characters in the path itself.
4. LINQ to DataSet using `AsEnumerable()` and `Field<T>(spaltenname)`:
   - `TeureArtikel(tabelle)`: Rows with a `Preis` over 10 (the column is `double` because SQLite stores `REAL`),
   - `Namen(tabelle)`: the `Name` column as a list,
   - `Summe(tabelle, spalte)`: Sum of a `double` column.

Then answer the quiz question.

Tests: `Der_Datenzugriffscode_kennt_keinen_Provider`, `OeffneVerbindung_liefert_eine_offene_DbConnection_des_Providers`, `LiesTabelle_laedt_Zeilen_und_Spalten_in_eine_DataTable`, `LiesTabelle_mit_Filter_liefert_nur_passende_Zeilen`, `Verbindungsstring_wird_vom_Builder_der_Fabrik_gebaut`, `Verbindungsstring_oeffnet_die_Datei_nur_lesend`, `TeureArtikel_filtert_mit_LINQ_to_DataSet`, `Namen_projiziert_die_Spalte_Name`, `Summe_addiert_eine_Spalte`, `Summe_einer_leeren_Tabelle_ist_null`.
