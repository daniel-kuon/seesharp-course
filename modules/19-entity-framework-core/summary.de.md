# Entity Framework Core (mit SQLite)

Mit ADO.NET schreibst du SQL-Texte und liest Zeilen von Hand. **Entity Framework Core**
(EF Core, Kapitel 20, Seite 1399) bildet stattdessen Klassen auf Tabellen ab: Du arbeitest
mit Objekten und LINQ, EF Core erzeugt das SQL. Hier verwenden wir das Paket
`Microsoft.EntityFrameworkCore.Sqlite` mit einer SQLite-Datenbank im Speicher statt des
SQL Servers. Kenntnisse aus dem Wahlmodul ADO.NET sind nicht nötig.

## Entitäten und Kontext (20.1, Seite 1399; 20.2, Seite 1402; 20.4, Seite 1414)

Eine **Entitätsklasse** beschreibt eine Zeile: Eigenschaften werden zu Spalten, `Id`
(oder `<Klasse>Id`) ist per Konvention der Primärschlüssel. Der **`DbContext`** ist die
Brücke zur Datenbank. Er hat je Tabelle ein `DbSet<T>` und bekommt seine Konfiguration
(Provider, Verbindung) als `DbContextOptions`. Ein Kontext ist eine kurze Arbeitseinheit:
erzeugen, benutzen, mit `using` freigeben. `Database.EnsureCreated()` legt das Schema an
(kommt im Buch nicht vor, das dafür Migrationen benutzt, 20.3; für Tests ist es der kürzere Weg),
`Add` merkt Entitäten zum Einfügen vor, `SaveChanges()` schreibt alle Änderungen.

## Abbildung und Konfiguration (20.5, Seite 1420 bis 1435)

Das Schema ergibt sich aus Konventionen und lässt sich auf zwei Wegen ändern:
**Annotationen** an den Klassen (`[Required]`, `[MaxLength]`, `[Key]`) und die **Fluent API**
in `OnModelCreating` (Beziehungen, Indizes, Löschverhalten, **Wertkonverter** wie
`HasConversion<string>()` für Aufzählungen). Welche Regeln durchgesetzt werden, bestimmt das
Datenbanksystem: SQLite erzwingt `NOT NULL`, aber keine Textlängen. Eine **1:n-Beziehung**
besteht aus einem Fremdschlüssel (`BlogId`) und Navigationseigenschaften (20.5.11, Seite 1429).

## Abfragen mit LINQ-to-Entities (20.9, Seite 1451 bis 1465)

LINQ-Ausdrücke auf einem `DbSet` übersetzt EF Core in SQL (`Where`, `OrderBy`, `Take`,
`Select`, `Count`, `Sum`, `Average`). Die Abfrage läuft erst bei `ToList()`, `First...`
und ähnlichen Aufrufen; `ToQueryString()` zeigt das erzeugte SQL. `AsEnumerable()` beendet die
serverseitige Auswertung: Alles Weitere läuft in C# (20.9.6). Aggregate und Projektionen
gehören nach Möglichkeit auf den Server. Assoziierte Entitäten lädt EF Core nicht von
selbst: **`Include`** (Eager Loading) holt sie mit (20.9.7).

## Ändern, Löschen, Nachverfolgung (20.10 und 20.11, Seite 1466 bis 1478)

Der Kontext **verfolgt** geladene Entitäten **nach** und kennt ihren `EntityState`
(`Added`, `Unchanged`, `Modified`, `Deleted`, `Detached`). Ändern genügt also: Eigenschaft setzen,
`SaveChanges()`. Mit `AsNoTracking()` geladene Entitäten werden nicht verfolgt (schneller,
aber Änderungen werden nicht gespeichert). `Remove` löscht; das **Löschverhalten** einer
Beziehung (`Cascade`, `SetNull`, `Restrict`) steht im Schema. `ExecuteUpdate` und `ExecuteDelete`
(20.15.2, Seite 1492) ändern oder löschen viele Zeilen mit einem Befehl, ohne sie zu laden.

## Konflikte und Transaktionen (20.13 und 20.14, Seite 1482 bis 1490)

EF Core arbeitet **optimistisch**: Zwei Benutzer können dieselbe Zeile laden. Ein
**Concurrency Token** (`[ConcurrencyCheck]` auf einer Versionsspalte) lässt `SaveChanges`
eine `DbUpdateConcurrencyException` werfen, wenn die Zeile inzwischen geändert wurde; das
Programm entscheidet, ob es neu lädt und wiederholt. `SaveChanges` ist für sich atomar;
mehrere Schritte fasst `Database.BeginTransaction()` mit `Commit` und `Rollback` zusammen.

## Migrationen (20.3, Seite 1404)

Wächst das Modell, ändern **Migrationen** (`dotnet ef migrations add`) das Schema schrittweise
und versioniert. `EnsureCreated` und Migrationen schließen sich auf derselben Datenbank aus.
Migrationen sind nicht automatisch prüfbar und werden in einer Review-Aufgabe geübt.

## Übungen

1. Der erste `DbContext`: Entität, Kontext, `EnsureCreated`, `Add`, `SaveChanges`.
2. Abfragen mit LINQ-to-Entities, serverseitig und clientseitig.
3. Ändern, Löschen und Änderungsnachverfolgung, `ExecuteUpdate`/`ExecuteDelete`.
4. Beziehungen: `Include`, Kaskade und Fluent API.
5. Wertkonverter, Concurrency Token, Transaktion; Review: erste Migration.
