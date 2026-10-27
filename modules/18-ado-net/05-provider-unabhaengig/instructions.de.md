# Provider-unabhängiger Code, DataTable und LINQ-to-DataSet

Lies im Buch **19.7.3 Provider-offener Quellcode** (Seite 1314), danach
**19.7.9** zu `DataSet`/`DataTable` (Seite 1343) und **19.7.17 LINQ-to-DataSet**
(Seite 1365). Statt gegen `SqliteConnection` programmierst du gegen die Basisklassen
`DbConnection`, `DbCommand` und `DbDataReader`. Eine `DbProviderFactory` erzeugt die
passenden Objekte des jeweiligen Providers.

Öffne `Zugriff.cs`. Das Projekt `Datenzugriff` darf **keine** Referenz auf
`Microsoft.Data.Sqlite` haben (ein Test prüft das); die Tests übergeben
`SqliteFactory.Instance` von außen.

1. `OeffneVerbindung(fabrik, verbindungsstring)`: `fabrik.CreateConnection()`,
   Zeichenfolge setzen, `Open()`. Liefert die Fabrik `null`, wirf eine
   `InvalidOperationException`.
2. `LiesTabelle(verbindung, sql)`: Befehl ausführen und das Ergebnis mit
   `DataTable.Load(leser)` in eine `DataTable` laden. Befehl und Leser gibst du frei.
3. `Verbindungsstring(fabrik, datei)`: Das Buch zeigt den `DbConnectionStringBuilder` in
   19.7.4.2 provider-spezifisch (`new SqlConnectionStringBuilder()`). Provider-unabhängig
   liefert ihn die Fabrik (nicht im Buch, hier vorgegeben):
   `var builder = fabrik.CreateConnectionStringBuilder()!;` Darin die Schlüssel
   `builder["Data Source"] = datei;` und `builder["Mode"] = "ReadOnly";` setzen und
   `ConnectionString` zurückgeben. Der Builder maskiert Sonderzeichen im Pfad selbst.
4. LINQ-to-DataSet über `AsEnumerable()` und `Field<T>(spaltenname)`:
   - `TeureArtikel(tabelle)`: Zeilen mit `Preis` über 10 (die Spalte ist `double`, weil
     SQLite `REAL` speichert),
   - `Namen(tabelle)`: die Spalte `Name` als Liste,
   - `Summe(tabelle, spalte)`: Summe einer `double`-Spalte.

Beantworte danach die Quizfrage.

Tests: `Der_Datenzugriffscode_kennt_keinen_Provider`,
`OeffneVerbindung_liefert_eine_offene_DbConnection_des_Providers`,
`LiesTabelle_laedt_Zeilen_und_Spalten_in_eine_DataTable`,
`LiesTabelle_mit_Filter_liefert_nur_passende_Zeilen`,
`Verbindungsstring_wird_vom_Builder_der_Fabrik_gebaut`,
`Verbindungsstring_oeffnet_die_Datei_nur_lesend`, `TeureArtikel_filtert_mit_LINQ_to_DataSet`,
`Namen_projiziert_die_Spalte_Name`, `Summe_addiert_eine_Spalte`,
`Summe_einer_leeren_Tabelle_ist_null`.
