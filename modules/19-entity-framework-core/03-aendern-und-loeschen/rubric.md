# Rubrik: Ändern, Löschen und Änderungsnachverfolgung (nur für die Betreuung)

- **Kernidee:** Der `DbContext` führt Buch über jede Entität, die er geladen oder
  angemeldet hat (`ChangeTracker`). `SaveChanges` vergleicht den aktuellen Zustand mit dem
  gemerkten und erzeugt `INSERT`, `UPDATE`, `DELETE` für genau die Unterschiede. Wer
  nicht nachverfolgt (`AsNoTracking`), muss selbst `Update`/`Attach` aufrufen. Für
  Massenänderungen laden `ExecuteUpdate`/`ExecuteDelete` nichts und wirken sofort,
  ohne `SaveChanges`.
- Typische Fehler:
  - `kontext.Update(produkt)` nach dem Ändern (funktioniert, ist aber überflüssig und
    markiert alle Spalten als geändert);
  - `UmbenennenOhneNachverfolgung`: Schüler wundern sich, dass nichts gespeichert wird: das
    ist die Lehre. Frage: Wie würde man die Änderung doch speichern? (`Update`, `Attach` mit
    `Modified` oder neu laden);
  - `Remove` ohne `SaveChanges`: nichts passiert;
  - `ExecuteUpdate` mit `ToList()` davor, dann `foreach` und `SaveChanges`: gleiches Ergebnis,
    aber alle Zeilen werden geladen (der Test prüft `ChangeTracker.Entries()`);
  - `ExecuteDelete` wirkt ohne `SaveChanges` sofort und umgeht den Change Tracker: bereits
    geladene Entitäten im Kontext bleiben dort veraltet (Gesprächsfrage).
- `Entry(produkt).State` entdeckt Änderungen selbst (`DetectChanges`), deshalb ist der
  Zustand `Modified` ohne `SaveChanges` sichtbar.
- Hinweis zu `decimal`: SQLite kennt keinen Decimal-Typ, EF Core speichert `TEXT` und
  rechnet in `ExecuteUpdate` über eigene Funktionen. Für die Übung unwichtig, für echte
  Projekte erwähnenswert.
- Modellantwort: `solution/`; Vorlagen `samples/Entity Framework Core/Datenbankaktualisierung/Entitäten ändern`,
  `EntityState`, `Massenaktualisierung`, `Nachverfolgung und Identitätsauflösung/Tracking`.
