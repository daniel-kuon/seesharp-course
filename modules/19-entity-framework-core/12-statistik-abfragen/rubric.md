# Rubrik: Zusatz: Umsatzstatistik (nur für die Betreuung)

- **Kernidee:** Aggregate (`Sum`, `Count`, `Average`) und Gruppierung gehören in die
  Abfrage, damit die Datenbank nur das Ergebnis liefert. Wer erst `ToList()` und dann in C#
  summiert, überträgt alle Zeilen. Das Ergebnis ist gleich, die Tests auf das erzeugte SQL
  (`ToQueryString`) zeigen den Unterschied.
- Typische Fehler: `ToList()` oder `AsEnumerable()` vor `GroupBy`/`Sum` (das SQL enthält dann
  kein `SUM`); `OrderByDescending(x => x.Umsatz)` erst nach dem `Select` auf das Record: EF Core kann diese Kombination nicht übersetzen (`InvalidOperationException`), die Sortierung nach `g.Sum(...)` gehört vor das `Select`;
  `Take` vor der Sortierung; `Sum` auf leerer Menge in der clientseitigen Variante.
- Gesprächsfrage: Warum liefert `Sum` über eine leere Tabelle hier `0`, obwohl SQL
  `NULL` meldet? (EF Core ergänzt `COALESCE`.) Wann reicht `ToQueryString()` zur Kontrolle,
  wann braucht man Protokollierung?
- Modellantwort: `solution/`; keine Vorlage im `samples`-Ordner.
