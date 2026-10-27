# LINQ-to-Objects

**LINQ** (Language Integrated Query) ist eine Sammlung von
Erweiterungsmethoden auf `IEnumerable<T>` (Klasse `System.Linq.Enumerable`),
die Lambda-Ausdrücke als eingespritzte Funktionalität erwarten (Kapitel 18,
Seite 1209). Weil jede Methode wieder eine Sequenz liefert, lassen sich die
Aufrufe zu einer **Fluent-API** verketten:
`produkte.Where(...).OrderBy(...).Select(...)` (18.2.1 bis 18.2.3, Seite 1211
bis 1213). Voraussetzungen sind Lambdas und `Func<>` aus Level 12 sowie
`IEnumerable<T>` und Erweiterungsmethoden aus früheren Levels.

## Zurückgestellte und sofortige Ausführung (18.2.4, Seite 1215)

`Where`, `Select`, `OrderBy` und die meisten anderen Operatoren bauen nur
eine **Abfrage** (ein Rezept) und lesen die Quelle erst, wenn jemand sie
aufzählt (`foreach`) oder ein **sofortiger** Operator sie abholt:
`ToList()`, `ToArray()`, `ToDictionary()`, `Count()`, `Sum()`, `First()`.
Jede Aufzählung führt die Abfrage neu aus; Änderungen an der Quelle zwischen
Bauen und Aufzählen sind sichtbar. Wer ein Ergebnis mehrfach braucht,
materialisiert es einmal mit `ToList()`.

## Filtern, Sortieren, Projizieren (18.2.6 bis 18.2.8, Seite 1217 bis 1222)

`Where` filtert, `OfType<T>()` filtert nach Laufzeittyp, `Select` formt in
einen neuen Elementtyp um, auch in Tupel oder anonyme Typen. `OrderBy`,
`ThenBy` und die `...Descending`-Varianten sortieren (18.2.7, Seite 1218);
zwei `OrderBy` hintereinander sortieren neu, weitere Kriterien hängt man mit
`ThenBy` an (Seite 1219). `SelectMany` flacht eine Sequenz von Sequenzen ab (18.2.8.2,
Seite 1220).

## Gruppieren und Verknüpfen (18.2.9 und 18.2.10, Seite 1222 bis 1228)

`GroupBy` liefert Gruppen (`IGrouping<TKey, T>`), die selbst Sequenzen sind
und ihren Schlüssel in `Key` tragen. `Join` ist ein innerer Join; `GroupJoin`
hängt jedem Element der äußeren Sequenz die (auch leere) Gruppe seiner Partner
an (das Buch nennt das einen Left Outer Join, Seite 1228). `Zip` paart zwei Sequenzen elementweise
(18.2.8.3, Seite 1221).

## Weitere Operatoren (18.2.11, Seite 1228)

Quantoren (`Any`, `All`, `Contains`), Elementoperatoren (`First`,
`FirstOrDefault`, `Single`, `Last`, `ElementAt`), Mengenoperatoren
(`Distinct`, `Union`, `Intersect`, `Except`), Aggregate (`Count`, `Sum`,
`Average`, `Min`, `Max`; auf einer leeren Zahlenfolge werfen `Average`, `Min`
und `Max`, `Sum` und `Count` liefern 0) und
Teilfolgen (`Take`, `Skip`, `TakeWhile`, `Chunk`, Seite 1234). Häufigkeiten
zählt man mit `GroupBy(f).Select(g => (g.Key, g.Count()))`; kürzere Wege
siehe Deep Dive.

## Abfragesyntax und Unterabfragen (18.3 und 18.4, Seite 1235 bis 1244)

`from x in quelle where ... orderby ... select ...` ist eine andere
Schreibweise für dieselben Methodenaufrufe; der Compiler übersetzt sie. Dazu
gehören `group ... by`, `join ... on ... equals ...` (mit `into` für den
`GroupJoin`), `let` für Zwischenwerte und `into` für Folgeabfragen. Zwei
`from`-Klauseln werden zu `SelectMany`. Was kein Schlüsselwort hat (`Take`,
`Count`, `Distinct`), hängt man als Methode an den geklammerten Ausdruck.
Eine **Unterabfrage** steht innerhalb einer anderen Abfrage, wird aber für
jedes Element erneut ausgewertet: teure Teile berechnet man vorher einmal.

## Eigene Operatoren

Eine Erweiterungsmethode auf `IEnumerable<T>` mit `yield return` verhält
sich wie die eingebauten Operatoren: zurückgestellt und auch auf unendlichen
Quellen brauchbar. PLINQ (18.5) gehört zum Wahlmodul Multithreading.

Vertiefung im Buch: Kapitel 18 (Seite 1209 bis 1256); die Übungsaufgaben in
18.6 (Seite 1255) liefern die Quizfragen und die Dublettensuche dieses Levels.

## Deep Dive (optional)

> Nicht im Buch. Diese Themen sind optional – Beispiele dafür, was du dir als Nächstes ansehen kannst.

- **Stabile Sortierung:** `OrderBy` und `OrderByDescending` sind stabil:
  Elemente mit gleichem Schlüssel behalten ihre Quellreihenfolge. .NET
  garantiert das, `List<T>.Sort` dagegen nicht.
- **Neuere Operatoren:** Das Buch ist auf dem Stand .NET 8. `CountBy(f)`
  (ab .NET 9) zählt je Schlüssel in einem Durchlauf und ersetzt
  `GroupBy(f).Select(g => (g.Key, g.Count()))`; `AggregateBy` verdichtet je
  Schlüssel zu einem beliebigen Wert; `Index()` liefert Paare (Position,
  Element). Seit .NET 10 gibt es `LeftJoin` für den Left Outer Join als flache
  Folge. `Order()` (ab .NET 7) sortiert nach den Elementen selbst
  (wie `OrderBy(x => x)`), `MaxBy`/`MinBy` liefern das Element mit dem
  größten bzw. kleinsten Schlüssel.
- **Vergleicher beim Sortieren:** `OrderBy`, `ThenBy` und `Order` haben
  Überladungen mit einem Vergleicher, z. B.
  `OrderBy(t => t, StringComparer.Ordinal)`; dann zählen die Zeichencodes, nicht
  die Spracheinstellung des Rechners. `FirstOrDefault(standard)` liefert statt
  des Typ-Standardwerts einen selbst gewählten Wert.
