# Rubrik: Abfragen mit LINQ-to-Entities (nur für die Betreuung)

- **Kernidee:** Eine LINQ-Abfrage auf einem `DbSet` ist ein Ausdrucksbaum, den der
  Provider in SQL übersetzt (`IQueryable`), keine Schleife im Speicher. Filtern,
  Sortieren, Projizieren und Aggregieren gehören auf den Server, damit nur das Nötige
  über die Leitung kommt. `AsEnumerable()`/`ToList()` zieht die Grenze: Alles danach
  läuft in C#.
- Typische Fehler:
  - `ToList()` zu früh (`kontext.Beitraege.ToList().Where(...)`): richtig im Ergebnis, aber
    alles wird geladen; die Tests auf `ToQueryString()` erkennen das nur bei den
    `...Abfrage`-Methoden, im Code prüfen;
  - `Titelliste` mit `Select` *nach* `ToList()`: Das SQL holt alle Spalten
    (Test `TitellisteAbfrage_waehlt_nur_die_Spalte_Titel_aus`);
  - `Statistik` mit zwei Abfragen (`Count()` und `Average()` getrennt): richtig, aber zwei Fahrten;
    die Aufgabe verlangt eine (Test auf `COUNT` und `AVG` in einer SQL-Anweisung);
  - `Average` einer leeren Menge wirft clientseitig `InvalidOperationException`; serverseitig
    gibt es mit `GroupBy` gar keine Gruppe (`FirstOrDefault` liefert `null`);
  - `Find` mit Prädikat verwechselt: `Find` sucht nur über den Primärschlüssel und schaut zuerst
    in den Zwischenspeicher des Kontexts, `FirstOrDefault` fragt immer die Datenbank;
  - `FirstOrDefault` ohne `OrderBy`: Die Reihenfolge ist nicht zugesichert.
- Gesprächsfrage: Was zeigt `ToQueryString()` (das erzeugte SQL), und warum braucht die
  statische `...Abfrage`-Methode einen Kontext von außen? (Die `IQueryable` ist an einen
  noch lebenden Kontext gebunden; mit `using` im selben Methodenrumpf wäre er bei der
  Ausführung schon freigegeben.)
- `Contains` wird für SQLite zu `instr(...)`, die Suche ist daher hier abhängig von
  Groß-/Kleinschreibung; beim SQL Server ist sie es meist nicht (Sortierung der Datenbank).
- Modellantwort: `solution/`; Vorlagen `samples/Entity Framework Core/LINQ-to-Entities/Einfache Beispiele`,
  `AsEnumerable`, `Ausdrucksbäume`.
