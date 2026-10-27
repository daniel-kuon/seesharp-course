# Rubrik: Der erste DbContext (nur für die Betreuung)

- **Kernidee:** Entitätsklassen beschreiben die Daten, der `DbContext` ist die
  Arbeitseinheit, die Änderungen beobachtet (Nachverfolgung) und mit `SaveChanges`
  gesammelt in die Datenbank schreibt. Bis dahin sieht kein anderer Kontext sie. Ein
  Kontext lebt kurz und wird mit `using` freigegeben. Konventionen (Eigenschaft `Id`
  = Schlüssel, Name der `DbSet`-Eigenschaft = Tabelle, 20.5.2) und Annotationen steuern das Schema.
- Typische Fehler:
  - Konstruktor ohne `base(options)`: Fehlermeldung „No database provider has been
    configured“; im Gespräch erklären, wofür die Optionen da sind;
  - `DbSet` als readonly oder ohne `set`: EF Core befüllt die Eigenschaft, `{ get; set; } = null!;`
    ist das übliche Muster;
  - ein `BlogContext` als Feld im Repository (Test `Alle_verwendet_bei_jedem_Aufruf_einen_frischen_Kontext`
    schlägt fehl: gleiche Instanz, veraltete Daten);
  - `SaveChanges` vergessen (Id bleibt 0, nichts wird gespeichert);
  - `EnsureCreated` mit Migrationen verwechseln: Es legt das Schema nur an, wenn die Datenbank
    noch leer ist, und aktualisiert nie (Thema von 19/05).
- Quizfrage (20.5.5): `[MaxLength(200)]` wird beim SQL Server zu `nvarchar(200)`, `[MinLength]`
  wirkt sich nicht auf das Schema aus.
- Bonus (Deep Dive), nicht im Buch: SQLite legt Textspalten als `TEXT` an und erzwingt `NOT NULL`,
  aber keine Längen; ein Name mit 150 Zeichen wird trotz `[MaxLength(100)]` gespeichert.
- `EnsureCreated` steht nicht im Buch und ist in der Aufgabe vorgegeben.
- Hinweis: Die Tests übergeben eine offene Verbindung im Speicher. Würde jeder Kontext
  seine eigene `Data Source=:memory:`-Verbindung öffnen, wäre die Datenbank pro Kontext leer.
- Modellantwort: `solution/`; Vorlagen `samples/Entity Framework Core/Erster Eindruck`,
  `Blogging-Beispiel`.
