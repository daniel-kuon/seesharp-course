# Rubrik: Verständnisfragen SQL und ADO.NET (nur für die Betreuung)

Die Multiple-Choice-Fragen `mc-insert-parameter` (richtig: Option 1), `mc-null-lesen` (Option 1) und
`mc-transaktion` (Option 1) wertet das Programm selbst aus. Die Code-Listings wurden mit
`Microsoft.Data.Sqlite` 10.0 in einer In-Memory-Datenbank ausgeführt; die Ausgaben unten sind echt.

## schema-regeln

Wesentlich:
- Primärschlüssel: Spalte (oder Spaltenkombination), die jede Zeile eindeutig identifiziert, nicht NULL.
- Fremdschlüssel: Spalte, die auf den Primärschlüssel einer anderen Tabelle verweist; die Datenbank
  verhindert dann Verweise ins Leere und hält die Beziehung konsistent.
- Einschränkungen im Schema, weil die Datenbank sie **immer** durchsetzt, egal welches Programm, welches
  Skript oder welcher Mensch schreibt; Prüfungen nur in C# lassen sich umgehen oder vergessen.

Typische Fehlvorstellungen: „Der Fremdschlüssel ist einfach eine zweite ID-Spalte" ohne den Bezug zur anderen
Tabelle; „Die Prüfung im C#-Code reicht, die Datenbank muss nichts wissen"; Primärschlüssel mit
„Zahl, die hochzählt" gleichsetzen (das ist nur eine Möglichkeit).

## code-zeilen-und-count

Ausgabe: `2 / 3`.

Wesentlich:
- `ExecuteNonQuery` liefert die Zahl der betroffenen Zeilen: Das `UPDATE` trifft nur Heft (3) und Block (4),
  also 2 (Stift mit 1,5 und Mappe mit NULL erfüllen `Preis > 2` nicht; ein Vergleich mit NULL ist nie wahr).
- `COUNT(Preis)` zählt nur Zeilen, in denen `Preis` nicht NULL ist: 3 (Stift, Heft, Block), nicht 4. `COUNT(*)` hätte 4 geliefert.
- `ExecuteScalar` gibt den ersten Wert der ersten Zeile als `object` zurück (hier ein `long`).

Typische Fehlvorstellungen: Ausgabe `4 / 4` oder `2 / 4` (COUNT(Spalte) zählt NULL mit); Ausgabe `3 / 3`
(das UPDATE zählt alle Zeilen mit Preis); Verwechslung mit Summe der Preise.

## execute-varianten

Wesentlich:
- `ExecuteNonQuery` für Befehle ohne Ergebniszeilen (`INSERT`, `UPDATE`, `DELETE`, `CREATE TABLE`); Rückgabe:
  Zahl der betroffenen Zeilen (`int`).
- `ExecuteScalar` für genau einen Einzelwert, etwa `SELECT COUNT(*) …` oder `SELECT SUM(Preis) …`; Rückgabe
  `object` (bei keiner Zeile oder bei NULL: `null` bzw. `DBNull.Value`, also vorher prüfen).
- `ExecuteReader` für mehrere Zeilen/Spalten, etwa `SELECT Name, Preis FROM Artikel`; Rückgabe ein
  `DbDataReader`, den man mit `Read()` durchläuft.

Typische Fehlvorstellungen: `ExecuteScalar` für ein `SELECT` mit mehreren Zeilen benutzen (liefert nur den ersten Wert);
`ExecuteNonQuery` für `SELECT` (liefert keine Daten); die Rückgabe von `ExecuteScalar` ungeprüft in einen
`int` casten (es ist ein `long` bei SQLite).

## code-injection

Ausgabe: `3`, dann `0`.

Wesentlich:
- Verkettet entsteht `… WHERE Name = 'nobody' AND Passwort = '' OR '1'='1'`. `AND` bindet stärker als `OR`,
  der Ausdruck ist wegen `'1'='1'` für jede Zeile wahr: 3 Treffer, obwohl es den Benutzer nicht gibt. Die Eingabe
  ist als SQL-Code interpretiert worden (SQL-Injection).
- Mit Parametern wird die Eingabe als **Wert** übergeben, nie als SQL-Text geparst: Es wird nach dem Passwort
  `' OR '1'='1` gesucht, das niemand hat, also 0.
- Folgerung: Werte immer als Parameter (`@name`) übergeben, nie in den SQL-Text verketten.

Typische Fehlvorstellungen: „Es gibt 0 Treffer, weil der Benutzer nicht existiert" bei der ersten Ausgabe;
Parameter nur als „Komfort beim Quoting" sehen, ohne den Sicherheitsaspekt; die Idee, Apostrophe per
`Replace` selbst zu entschärfen.

## code-dbnull-lesen

Ausgabe:

```
Ida: unbekannt
Max: 1990
```

Wesentlich:
- Ein fehlender Wert ist in der Datenbank NULL und kommt in ADO.NET als `DBNull` an; `IsDBNull(1)` ist für
  Ida `true`, also wird `GetInt32` gar nicht aufgerufen.
- `GetInt32` auf einem NULL-Wert würde eine `InvalidOperationException` werfen; deshalb fragt man vorher.
- `int?` (Nullable) bildet den fehlenden Wert in C# ab, `?.ToString() ?? "unbekannt"` macht daraus den Text.

Typische Fehlvorstellungen: Man erwartet `Ida: 0` (GetInt32 liefere bei NULL 0) oder eine Ausnahme; man glaubt, `ORDER BY`
ändere die Reihenfolge Max/Ida (Ida kommt alphabetisch vor Max, die Ausgabe stimmt also).

## leser-und-abbilden

Wesentlich:
- Der Leser liefert die Ergebniszeilen **vorwärts**, eine nach der anderen: `Read()` rückt zur nächsten Zeile
  vor und liefert `false`, wenn keine mehr kommt; Spalten liest man typisiert (`GetString`, `GetInt32`,
  `GetDecimal`), die Position mit `GetOrdinal(spaltenname)` oder direkt als Zahl.
- Abbilden (Mapping): in der Schleife aus jeder Zeile ein Objekt (Klasse oder Record) erzeugen und in eine Liste legen;
  NULL-Spalten vorher mit `IsDBNull` abfangen.
- Leser und Verbindung gehören in `using`: Eine offene Verbindung hält Ressourcen (bei Dateidatenbanken eine
  Sperre, auf Servern begrenzte Verbindungen); solange ein Leser offen ist, ist die Verbindung belegt.
  Vergisst man die Freigabe, bleibt die Ressource bis zur Müllabfuhr belegt, und später können Sperren oder erschöpfte Verbindungen
  Fehler auslösen.

Typische Fehlvorstellungen: Man könne mit dem Leser zurückspringen oder wahlfrei auf Zeilen zugreifen; der Leser
enthalte alle Daten im Speicher (das ist die `DataTable`); `Dispose` sei „nur Aufräumen aus Höflichkeit".

## transaktion-erklaeren

Wesentlich:
- Eine Transaktion fasst mehrere Befehle zu einer Einheit zusammen: Entweder werden alle wirksam (`Commit`) oder
  keiner (`Rollback`); (ACID: atomar, konsistent, isoliert, dauerhaft; mindestens die Atomarität soll genannt werden).
- Überweisung: Abbuchen und Gutschreiben sind zwei Befehle; bricht nach dem ersten etwas ab, wäre Geld verschwunden.
  Mit Transaktion wird der Abbuchungsschritt zurückgenommen.
- Muster: `BeginTransaction`, die Befehle der Transaktion zuordnen (`befehl.Transaction = tx`), `try { …; tx.Commit(); }`,
  `catch { tx.Rollback(); throw; }`. Die Ausnahme wird weitergeworfen, damit der Aufrufer den Fehler sieht.

Typische Fehlvorstellungen: `Commit` vergessen (dann wird beim Schließen der Verbindung alles verworfen); `Commit` nach jedem Befehl;
die Ausnahme nach dem Rollback verschlucken; denken, eine Transaktion verhindere den Fehler selbst (sie macht nur
das Ergebnis konsistent).

## code-rollback

Ausgabe:

```
Fehler
100 50
```

Wesentlich:
- Das erste `UPDATE` (Konto 2 auf 130) gelingt, das zweite verletzt `CHECK (Stand >= 0)` (100 − 150 < 0) und löst
  eine `SqliteException` aus; der `catch`-Block ruft `Rollback()` auf, **beide** Änderungen werden zurückgenommen.
- Ausgabe „Fehler" kommt zuerst, danach die unveränderten Stände 100 und 50.
- Die Datenbank hat die Regel selbst durchgesetzt; die Transaktion sorgt dafür, dass der halbe Vorgang nicht stehenbleibt.

Typische Fehlvorstellungen: `100 130` (nur der fehlerhafte Befehl werde zurückgenommen); `-50 130` (CHECK wird nicht durchgesetzt);
Das Programm stürzt ab (die Ausnahme wird gefangen).

## provider-unabhaengig

Wesentlich:
- Ein Provider ist die Bibliothek eines Datenbanksystems mit eigenen Ableitungen der ADO.NET-Grundklassen
  (`SqlConnection` für SQL Server, `SqliteConnection` für SQLite, …).
- Programmiert man gegen die Basisklassen aus `System.Data.Common` (`DbConnection`, `DbCommand`, `DbDataReader`) und lässt eine
  `DbProviderFactory` die Objekte erzeugen, kennt der Code den Provider nicht; das Datenbanksystem lässt sich an einer Stelle
  (Fabrik, Verbindungszeichenfolge) austauschen, und Tests können eine andere Datenbank einsetzen.
- Nicht austauschbar: der SQL-Dialekt und Besonderheiten (z. B. `LIMIT 3` bei SQLite gegenüber `TOP 3` beim SQL Server,
  `IDENTITY` gegenüber `AUTOINCREMENT`), sowie die Verbindungszeichenfolge selbst.

Typische Fehlvorstellungen: „Man kann dann jedes SQL unverändert auf jeder Datenbank laufen lassen"; Provider und
Datenbankserver verwechseln; die Fabrik für ein Entwurfsmuster ohne Zweck halten.
