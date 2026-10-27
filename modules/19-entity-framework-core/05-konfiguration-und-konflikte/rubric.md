# Rubrik: Wertkonverter, Konflikte, Transaktionen, Migrationen (nur für die Betreuung)

- **Kernidee:** (1) Ein Wertkonverter übersetzt zwischen Programm- und Datenbanktyp
  (hier Enum <-> Text), damit die Datenbank lesbar bleibt und Umordnen der Enum-Werte
  nichts zerstört. (2) EF Core arbeitet **optimistisch**: Es sperrt nichts, sondern prüft beim
  Speichern über das Concurrency Token, ob die Zeile noch so ist wie beim Laden. Der Konflikt
  ist ein fachliches Ereignis, das das Programm entscheiden muss (verwerfen, neu laden und
  wiederholen, Benutzer fragen). (3) Eine Transaktion macht mehrere `SaveChanges` zu
  einer Einheit.
- Typische Fehler:
  - `[ConcurrencyCheck]` fehlt oder `Version` wird nicht hochgezählt (dann ändert sich das Token
    nicht: Der zweite Schreiber bemerkt nichts; der Test erzeugt einen Konflikt nur, wenn beide
    Seiten `Version++` tun);
  - Konfliktlöser wiederholt, ohne neu zu laden (der Konflikt bleibt bestehen) oder lädt neu, wendet
    die Änderung aber nicht erneut an (die eigene Änderung geht verloren, Saldo 110 statt 115);
  - Wiederholung in einer Schleife ohne Grenze (Test `..._gibt_nach_dem_zweiten_Konflikt_auf`);
  - `Ueberweisung` ohne Transaktion: Die Abbuchung bleibt stehen, wenn das Zielkonto fehlt;
  - `Rollback` ohne `throw;`;
  - Transaktion und `SaveChanges`: Auch ein einzelnes `SaveChanges` ist schon atomar; die
    ausdrückliche Transaktion lohnt, wie hier, bei mehreren `SaveChanges` oder wenn mehrere
    Kontexte oder Roh-SQL beteiligt sind (Gesprächsfrage).
- Review-Aufgabe: Die Betreuung prüft, ob der Ordner `Migrations` mit der Migration `Anfang`
  und `KontoContextModelSnapshot` vorhanden ist, und lässt erklären:
  - Zweck der Migrationen: Das Schema entwickelt sich mit dem Modell weiter, ohne Daten zu
    verlieren, und die Änderungen liegen versioniert im Code.
  - Bonus (Deep Dive), nicht im Buch, nicht verlangt: `EnsureCreated` legt das Schema direkt an und kennt keine Migrationsverfolgung
    (`__EFMigrationsHistory`). Existiert die Datenbank schon, tut es nichts. Danach schlägt
    `Migrate()` fehl, weil die erste Migration Tabellen anlegen will, die es schon gibt. Entweder `EnsureCreated` (Tests, Prototypen) oder
    Migrationen (echte Projekte, die sich weiterentwickeln), nie beides auf derselben Datenbank.
- Hinweis: Das Scratch-Projekt (`Microsoft.EntityFrameworkCore.Design`, `dotnet-ef`) braucht
  eine Netzwerkverbindung für NuGet und wird nicht benotet.
- Modellantwort: `solution/`; Vorlagen `samples/Entity Framework Core/Wertkonverter`,
  `Zugriffskonflikte/ConcurrencyCheck`, `Explizite Transaktion/*`, `Migration per Programm`.
