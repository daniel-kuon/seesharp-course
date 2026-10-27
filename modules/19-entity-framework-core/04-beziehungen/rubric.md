# Rubrik: Beziehungen: Include, Kaskade und Fluent API (nur für die Betreuung)

- **Kernidee:** EF Core bildet eine Beziehung über den Fremdschlüssel und die
  Navigationseigenschaften ab. Was beim Löschen geschieht, legt das Löschverhalten
  fest (`Cascade`: abhängige Zeilen mitlöschen, `SetNull`: Fremdschlüssel auf NULL, `Restrict`:
  verbieten). Es steht als `ON DELETE ...` im Schema, die Datenbank setzt es durch, auch
  für Zeilen, die der Kontext nie geladen hat. Assoziierte Daten lädt man nur mit
  `Include` (oder getrennten Abfragen).
- Konventionen: Ein nicht-nullbarer Fremdschlüssel ergibt von selbst `Cascade`; ein
  nullbarer ergibt `ClientSetNull` (nur der Kontext setzt NULL, und nur für geladene Beiträge,
  die Datenbank verweigert das Löschen sonst). Deshalb braucht `SetNull` eine ausdrückliche
  Konfiguration, die Kaskade steht nur zur Verdeutlichung da (der Test auf das Modell
  prüft beides).
- Typische Fehler:
  - `Include` fehlt: leere Liste statt Fehler;
  - Eindeutigkeit des Blognamens fehlt (keine Konvention dafür), der Test auf doppelte Namen
    schlägt fehl;
  - `SetNull` vergessen: `LoescheAutor` wirft eine `DbUpdateException` wegen des Fremdschlüssels;
  - `Blog` zum Löschen vorher mit `Include` laden und die Beiträge einzeln entfernen: richtig im
    Ergebnis, aber überflüssig, die Kaskade erledigt es;
  - Konfiguration per Annotation statt Fluent API: Das geht auch (`[Index(nameof(Name), IsUnique = true)]`
    an der Klasse, vgl. 20.5.13, und `[DeleteBehavior(DeleteBehavior.SetNull)]` an der
    Navigationseigenschaft `Beitrag.Autor`, seit EF Core 7), die Aufgabe verlangt aber die Fluent API (Gesprächsfrage: Wann nimmt man Annotationen, wann die Fluent API?
    Eine `IEntityTypeConfiguration<T>`-Klasse hält `OnModelCreating` übersichtlich).
- Die Tests schalten `PRAGMA foreign_keys` ein; ohne Fremdschlüsselprüfung würde SQLite auch
  ein falsches `OnDelete` nicht bemerken.
- Modellantwort: `solution/`; Vorlagen `samples/Entity Framework Core/Master-Details - Beziehung`,
  `Laden assoziierter Entitäten/Eager Loading`, `Datenbankaktualisierung/Entitäten löschen/*`,
  `EntityTypeConfiguration`.
