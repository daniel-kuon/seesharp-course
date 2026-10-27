# Verbindung, Befehle und Parameter

Lies im Buch **19.7.2 bis 19.7.5**, besonders **19.7.5 DbCommand** (Seite 1323):
`ExecuteNonQuery`, `ExecuteScalar`, Parameter. Das Buch benutzt `SqlConnection`
für den SQL Server; wir verwenden `SqliteConnection` aus `Microsoft.Data.Sqlite`
(die Klassen sind von denselben Basisklassen `DbConnection` und `DbCommand`
abgeleitet, die Methoden heißen gleich).

Öffne `Adressbuch.cs`. Die Klasse `Adressbuch` verwaltet die Tabelle `Kontakt`
(`Id`, `Name`, `Telefon`) über eine **geöffnete Verbindung, die dem Aufrufer
gehört**: Du öffnest und schließt sie hier nicht, sondern erzeugst pro Methode
einen eigenen Befehl (in einer `using`-Anweisung). Alle Werte kommen als
**Parameter** in den Befehl, nie per Textverkettung. Das Buch legt einen Parameter mit
`Parameters.Add("@name", SqlDbType...)` an und setzt danach `Value` (19.7.5.2). Kürzer
geht es in einem Schritt (nicht im Buch, hier vorgegeben):
`befehl.Parameters.AddWithValue("@name", name);`

1. `Erzeuge()`: `CREATE TABLE IF NOT EXISTS Kontakt (...)` (mehrfach aufrufbar; nicht im
   Buch, hier vorgegeben, das Gegenstück zu `DROP TABLE IF EXISTS` aus 19.6.2.2).
2. `Hinzufuegen(name, telefon)`: `INSERT` mit `@name` und `@telefon`. Ein
   `null` als Telefonnummer wird als **NULL** gespeichert (`DBNull.Value`).
3. `Anzahl()`: `ExecuteScalar`; SQLite liefert hier ein `long`.
4. `Aendere(name, neuesTelefon)` und `Entferne(name)` liefern die **Zahl der
   betroffenen Zeilen** (`ExecuteNonQuery`).
5. `Telefon(name)`: `string?`. `ExecuteScalar` liefert `null`, wenn es keine
   Zeile gibt, und `DBNull.Value`, wenn die Zeile eine NULL-Nummer hat. Beides
   wird zu `null`.
6. `ZaehleInDatei(dateipfad)`: statische Methode, die ihre **eigene** Verbindung
   zu einer Datenbankdatei öffnet (`Data Source=<Pfad>`) und sie in einer
   `using`-Anweisung wieder freigibt. Der Pfad darf Leerzeichen, Umlaute und
   Kommas enthalten.

Die Tests speichern auch den Namen `Robert'); DROP TABLE Kontakt;--` und prüfen,
dass die Tabelle danach noch da ist und der Name wörtlich gespeichert wurde.

Beantworte danach die beiden Fragen.

Tests: `Erzeuge_legt_die_Tabelle_an_und_ist_wiederholbar`,
`Hinzufuegen_und_Anzahl_zaehlen_die_Kontakte`, `Telefon_liefert_die_gespeicherte_Nummer`,
`Fehlende_Nummer_wird_als_NULL_gespeichert_und_als_null_gelesen`,
`Telefon_eines_unbekannten_Kontakts_ist_null`, `Aendere_liefert_die_Zahl_der_geaenderten_Zeilen`,
`Entferne_liefert_die_Zahl_der_geloeschten_Zeilen`, `Hinzufuegen_ist_gegen_SQL_Injection_sicher`,
`Aendere_und_Entferne_sind_gegen_SQL_Injection_sicher`,
`Adressbuch_schliesst_die_Verbindung_des_Aufrufers_nicht`,
`ZaehleInDatei_oeffnet_eine_eigene_Verbindung_zu_einem_Pfad_mit_Sonderzeichen`.
