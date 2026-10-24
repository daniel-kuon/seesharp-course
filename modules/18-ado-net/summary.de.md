# SQL und ADO.NET (mit SQLite)

Programme speichern ihre Daten meist in einer **relationalen Datenbank**. Kapitel 19
des Buches (Seite 1257) führt in Datenbanken und in **ADO.NET** ein, die .NET-Bibliothek
für Datenbankzugriffe. Das Buch arbeitet mit dem SQL Server (`Northwind.mdf`); die
Übungen hier verwenden **SQLite** im Speicher mit dem Paket `Microsoft.Data.Sqlite`.
Es braucht keinen Server, und jeder Test bekommt seine eigene frische Datenbank. Die
Kapitel zu SSMS und Azure Data Studio (19.3 bis 19.5) entfallen.

## Relationale Datenbanken und SQL (19.2, Seite 1264; 19.6, Seite 1296)

Daten liegen in **Tabellen** aus Zeilen und Spalten. Ein **Primärschlüssel**
identifiziert eine Zeile eindeutig; ein **Fremdschlüssel** verweist auf den
Primärschlüssel einer anderen Tabelle und hält so Beziehungen konsistent. Zusätzliche
Einschränkungen (`NOT NULL`, `UNIQUE`, `CHECK`) gehören ins Schema, damit die
Datenbank fehlerhafte Daten selbst abweist.

**SQL** hat drei Teile: Datendefinition (`CREATE TABLE`), Datenmanipulation
(`INSERT`, `UPDATE`, `DELETE`) und Abfragen mit `SELECT`. Abfragen filtert man mit
`WHERE`, sortiert mit `ORDER BY`, verknüpft Tabellen mit `JOIN ... ON` und wertet mit
Aggregatfunktionen (`COUNT`, `SUM`, `AVG`) und `GROUP BY` aus; `HAVING` filtert die
Gruppen (19.6.4, Seite 1302). Dialekte unterscheiden sich: SQLite schreibt
`LIMIT 3` statt `TOP 3` und kommt mit `INTEGER PRIMARY KEY` ohne `IDENTITY` aus.

## ADO.NET und das Providermodell (19.7.1 und 19.7.2, Seite 1307)

ADO.NET besteht aus wenigen Grundbausteinen: **Verbindung** (`DbConnection`),
**Befehl** (`DbCommand`), **Leser** (`DbDataReader`) und **Adapter** für `DataSet`s.
Jedes Datenbanksystem hat einen **Provider** mit eigenen Ableitungen
(`SqlConnection` für den SQL Server, `SqliteConnection` für SQLite). Die Grundklassen
stehen in `System.Data.Common`.

## Verbindungen und Befehle (19.7.4 und 19.7.5, Seite 1319 und 1323)

Eine Verbindung wird mit einer **Verbindungszeichenfolge** geöffnet (`Open()`) und
gehört wie jeder Befehl in eine `using`-Anweisung, damit sie wieder freigegeben wird.
Befehle führt man je nach Ergebnis aus:

- `ExecuteNonQuery` für Änderungen, liefert die Zahl der betroffenen Zeilen,
- `ExecuteScalar` für einen Einzelwert (z. B. `COUNT(*)`),
- `ExecuteReader` für Ergebniszeilen.

Werte gehören als **Parameter** (`@name`) in den Befehl, nie per Textverkettung in den
SQL-Text: Sonst kann ein Benutzer mit einer Eingabe wie `'; DROP TABLE ...` eigenes SQL
einschleusen (**SQL-Injection**). Ein fehlender Wert ist in der Datenbank `NULL`, in
ADO.NET `DBNull.Value`: Beim Schreiben wird aus `null` ein `DBNull.Value`, beim Lesen
fragt man mit `IsDBNull` oder `is DBNull` und macht wieder `null` daraus.

## DbDataReader und Objekte (19.7.15, Seite 1363)

Ein `DbDataReader` liefert Zeilen vorwärts: `Read()` rückt vor, `GetOrdinal` nennt
die Spaltennummer, `GetInt32`, `GetString`, `GetDecimal` lesen typisiert. Aus jeder
Zeile erzeugt man ein Objekt (Abbilden, *Mapping*). Den Leser gibt man sofort wieder
frei.

## Transaktionen (19.7.7 und 19.7.8, Seite 1332 bis 1343)

Eine `DbTransaction` fasst mehrere Befehle zusammen: Mit `Commit()` werden sie
gemeinsam bestätigt, mit `Rollback()` gemeinsam zurückgenommen (ACID). Das übliche
Muster ist `BeginTransaction`, `try { ...; Commit }`, `catch { Rollback; throw; }`.
Alle Befehle müssen der Transaktion zugeordnet werden. `TransactionScope` ist die
implizite Variante, die ohne `Complete()` zurückrollt; hier wird sie nur als Konzept
besprochen.

## Provider-unabhängiger Code und DataTable (19.7.3, 19.7.9, 19.7.17)

Wer gegen `DbConnection`, `DbCommand` und `DbProviderFactory` programmiert (19.7.3,
Seite 1314), kann das Datenbanksystem an einer Stelle austauschen. Einen
`DbConnectionStringBuilder` baut die Fabrik; er setzt Verbindungszeichenfolgen
sicher zusammen. Eine `DataTable` (19.7.9, Seite 1343) hält ein Ergebnis im Speicher,
mit `Load(leser)` füllt man sie; **LINQ-to-DataSet** (19.7.17, Seite 1365) fragt sie
über `AsEnumerable()` und `Field<T>("Spalte")` ab.

## Übungen

1. SQL-Grundlagen mit SQLite: Schema, Daten, Abfragen als SQL-Texte.
2. Verbindung, Befehle und Parameter: ein Adressbuch mit `ExecuteNonQuery`,
   `ExecuteScalar`, Parametern und `DBNull`.
3. DataReader und Objektabbildung.
4. Transaktionen: Überweisungen mit Commit und Rollback.
5. Provider-unabhängiger Code, `DataTable` und LINQ-to-DataSet.
