# Rubrik: Verständnisfragen Entity Framework Core (nur für die Betreuung)

Die Multiple-Choice-Fragen `mc-abfrage-serverseitig` (richtig: Option 3), `mc-loeschen` (Option 2) und
`mc-eager-loading` (Option 2) wertet das Programm selbst aus. Die Code-Listings wurden mit
`Microsoft.EntityFrameworkCore.Sqlite` 10.0 in einer In-Memory-Datenbank ausgeführt; die Ausgaben unten sind echt.

## dbcontext-rolle

Wesentlich:
- `DbContext` ist die Brücke zur Datenbank (Konfiguration über `DbContextOptions`: Provider, Verbindung); er hat je Tabelle
  ein `DbSet<T>`, über das man Entitäten abfragt, hinzufügt und entfernt.
- `Add` merkt die Entität nur zum Einfügen vor (Zustand `Added`); erst `SaveChanges()` schickt alle vorgemerkten
  Änderungen als SQL (`INSERT`, `UPDATE`, `DELETE`) an die Datenbank (und ist für sich atomar).
- Der Kontext ist eine kurze Arbeitseinheit: Er verfolgt alle geladenen Entitäten nach und hält sie im Speicher; ein
  langlebiger Kontext wächst, liefert veraltete Daten (die Zeilen hat inzwischen jemand anderes geändert) und behält
  fehlgeschlagene Änderungen bei sich. Er ist außerdem nicht für nebenläufigen Zugriff gedacht. Deshalb: erzeugen,
  benutzen, mit `using` freigeben.

Typische Fehlvorstellungen: `Add` schreibe sofort in die Datenbank; der Kontext sei eine Datenbankverbindung, die man
einmal öffnet und dann behält; ein `DbSet` sei eine Liste im Speicher mit allen Zeilen.

## code-verzoegerung

Ausgabe: `2 3`.

Wesentlich:
- `Where` allein führt nichts aus: `teuer` ist nur die Beschreibung einer Abfrage (verzögerte Ausführung). Erst `ToList()` und
  `Count()` schicken sie an die Datenbank.
- `ToList()` hat zu dem Zeitpunkt zwei Zeilen (Heft 6, Mappe 8) in eine Liste kopiert; diese Momentaufnahme ändert sich nicht mehr.
- `teuer.Count()` fragt die Datenbank **neu**, jetzt sind es drei Zeilen mit Preis über 5 (auch Atlas mit 9).

Typische Fehlvorstellungen: `2 2` oder `3 3` (die Abfrage wird einmal ausgeführt und das Ergebnis gemerkt; oder die Liste
aktualisiert sich von selbst); „Count() zählt die Liste" (es ist eine neue SQL-Abfrage `SELECT COUNT(*) … WHERE Preis > 5`).

## nachverfolgung-und-zustaende

Wesentlich:
- Der Kontext merkt sich jede Entität, die er geladen (oder hinzugefügt) hat, samt ursprünglichen Werten; er vergleicht
  beim Speichern und erzeugt nur für tatsächlich Geändertes SQL. Darum genügt zum Ändern: Eigenschaft setzen, `SaveChanges()`.
- Zustände: `Added` (INSERT), `Unchanged` (nichts), `Modified` (UPDATE), `Deleted` (DELETE), `Detached` (dem Kontext unbekannt, nichts passiert).
- `AsNoTracking()` für reine Leseabfragen, etwa Anzeigen und Berichte: schneller und speicherschonend, weil der Kontext die
  Entitäten nicht verfolgt. Änderungen an solchen Objekten werden von `SaveChanges()` **nicht** gespeichert: Zum Ändern muss man
  mit Nachverfolgung laden (oder die Entität dem Kontext anschließend bekannt machen).

Typische Fehlvorstellungen: Man müsse zum Ändern eine `Update`-Methode aufrufen (bei nachverfolgten Entitäten nicht nötig); `AsNoTracking`
sei „sicherer" oder ändere die Abfrage; `SaveChanges` speichere alle Objekte im Programm (nur die dem Kontext bekannten).

## code-nachverfolgung

Ausgabe:

```
Modified / Detached
Stift=3, Heft=10, Mappe=8
```

Wesentlich:
- `heft` wurde mit Nachverfolgung geladen; die Änderung von `Preis` macht den Zustand `Modified`, `SaveChanges()` schreibt 10.
- `stift` kam über `AsNoTracking()` und ist dem Kontext unbekannt (`Detached`); die Änderung auf 99 betrifft nur das Objekt im
  Speicher, `SaveChanges()` übergeht sie, in der Datenbank bleibt 3.
- Die zweite Zeile liest in einem **frischen** Kontext: Sie zeigt, was wirklich gespeichert wurde.

Typische Fehlvorstellungen: Beide Preise seien gespeichert (`Stift=99`); es werde eine Ausnahme geworfen; `Entry(stift).State` sei `Modified`
(der Zustand eines nicht verfolgten Objekts wird nicht durch Zuweisen von Eigenschaften zu `Modified`).

## beziehungen-include-kaskade

Wesentlich:
- 1:n besteht aus einem Fremdschlüssel in der „n"-Klasse (`Post.BlogId`) und Navigationseigenschaften: `Blog.Posts` (Liste) und
  `Post.Blog` (Verweis zurück). Konvention oder Fluent API (`HasMany`/`WithOne`, `HasForeignKey`).
- EF Core lädt zugehörige Entitäten nicht von selbst (sonst würde jede Abfrage viele Tabellen lesen); ohne `Include` bleibt die
  Liste leer. `Include(b => b.Posts)` (Eager Loading) lässt EF Core die Beiträge mit in dieselbe Abfrage (JOIN) laden.
- Löschen: Beim Löschverhalten `Cascade` werden die Beiträge mit gelöscht, bei `Restrict` verhindert die Datenbank das Löschen des Blogs,
  bei `SetNull` wird der Fremdschlüssel auf NULL gesetzt. Das steht im Schema und wird per Konvention oder Fluent API
  (`OnDelete(DeleteBehavior…)`) festgelegt.

Typische Fehlvorstellungen: `Include` sei nur für Geschwindigkeit; die Liste fülle sich beim ersten Zugriff automatisch (das wäre Lazy
Loading, das hier nicht aktiviert ist); Kaskade sei „Fehler beim Löschen".

## code-include

Ausgabe:

```
0
2
```

Wesentlich:
- Die erste Abfrage lädt nur die Zeile aus `Blogs`; die Navigationseigenschaft wird nicht gefüllt, die mit `new()` vorbelegte
  leere Liste bleibt leer: 0.
- Die zweite Abfrage mit `Include` holt die Beiträge mit: 2.
- (Zusatz, nicht verlangt: Beide Abfragen laufen im selben Kontext, der Blog ist dasselbe verfolgte Objekt. Dass `ohne.Posts` nach der zweiten
  Abfrage ebenfalls zwei Einträge hätte, ist erwähnenswert, aber nicht erforderlich.)

Typische Fehlvorstellungen: `2` und `2` (EF Core lade zugehörige Daten automatisch); `null`-Ausnahme (die Liste ist durch `= new()` nie `null`).

## konflikte-und-transaktion

Wesentlich:
- Optimistisch heißt: Niemand sperrt die Zeile beim Lesen; zwei Benutzer dürfen sie gleichzeitig laden, und erst beim Speichern wird
  geprüft, ob jemand dazwischen geändert hat.
- Concurrency Token (Versionsspalte): EF Core hängt jedem `UPDATE` ein `WHERE Version = <geladener Wert>` an. Hat ein anderer die Zeile inzwischen
  geändert (und die Version erhöht), trifft das keine Zeile, und `SaveChanges` wirft die `DbUpdateConcurrencyException`, statt die fremde
  Änderung stillschweigend zu überschreiben (Lost Update). Bei SQLite zählt der Code die Version von Hand hoch.
- Reaktion: Aktuelle Werte neu laden (`Reload`), die Änderung erneut anwenden und wiederholen (oder dem Benutzer den Konflikt anzeigen).
- `BeginTransaction()` braucht man, wenn **mehrere** `SaveChanges`-Aufrufe oder Befehle zusammengehören (Überweisung: Abbuchen
  speichern, Gutschreiben speichern; bei Fehler `Rollback`).

Typische Fehlvorstellungen: Optimistisch heiße, dass keine Konflikte vorkämen; das Token verhindere den gleichzeitigen Zugriff (es erkennt den
Konflikt erst beim Speichern); eine Transaktion löse Konflikte zwischen Benutzern (sie bündelt nur Schritte).

## code-konflikt

Ausgabe:

```
Konflikt
110
```

Wesentlich:
- Beide Kontexte laden dasselbe Konto (Saldo 100, Version 1). `a` speichert zuerst: `UPDATE … WHERE Id = 1 AND Version = 1` trifft die Zeile, danach Saldo 110, Version 2.
- `b` will mit dem alten Wert Version 1 speichern: Das `WHERE` trifft keine Zeile mehr; `SaveChanges` wirft eine
  `DbUpdateConcurrencyException`, der `catch`-Block schreibt „Konflikt".
- Die Änderung von `b` (+20) ist nicht gespeichert; in der Datenbank steht 110. Ohne Concurrency Token hätte `b` still 120
  geschrieben und die +10 von `a` überschrieben.

Typische Fehlvorstellungen: `gespeichert` und `130` (beide Änderungen addieren sich); `gespeichert` und `120` (der Token wird nicht erkannt); die
Ausnahme komme schon bei `a.SaveChanges()`.
