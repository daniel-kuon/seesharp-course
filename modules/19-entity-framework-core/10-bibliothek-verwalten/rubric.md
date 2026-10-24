# Rubrik: Zusatz: Bücherverwaltung (nur für die Betreuung)

- **Kernidee:** Die vier Grundoperationen mit EF Core: Hinzufügen (`Add`), Ändern (geladene
  Entität ändern, kein `Update` nötig), Löschen (`Remove`), Abfragen (LINQ). Gespeichert wird
  erst mit `SaveChanges`. Jeder Aufruf hat einen eigenen, kurzlebigen Kontext.
- Typische Fehler: `SaveChanges` vergessen; einen Kontext als Feld aufbewahren (veraltete Daten,
  wächst ohne Ende); `Ausleihen` ohne Prüfung auf „schon ausgeliehen“ (Rückgabewert falsch);
  `Suche` ohne `OrderBy`; nach `Remove` einer unbekannten Id eine `NullReferenceException`
  (`Find` liefert `null`).
- Gesprächsfrage: Was passiert, wenn zwei Benutzer gleichzeitig dasselbe Buch ausleihen? (Beide
  sehen `Ausgeliehen == false`: Lösung wäre ein Concurrency Token, Thema von 19/05.)
- Modellantwort: `solution/`; keine Vorlage im `samples`-Ordner.
