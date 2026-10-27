# Rubrik — Join, GroupJoin, Zip (nur für die Betreuung)

- Kernidee: `Join` ist ein innerer Join (nur Paare); `GroupJoin` hängt jedem
  Element der linken Seite die Gruppe seiner Partner an (auch leer) und ist
  die Grundlage von „links außen“ und Master-Details.
- Typischer Fehler in `BestellungenProKunde`: `Join` statt `GroupJoin` (Kunden
  ohne Bestellung fehlen) oder `Sum` ohne Bedacht auf leere Gruppen — `Sum`
  einer leeren Folge ist 0 (anders als `Average`).
- `Join(inner, outerKey, innerKey, resultSelector)`: Die Reihenfolge der
  Parameter ist ein typischer Stolperstein; die Ergebnisreihenfolge folgt der
  äußeren Sequenz (Kunden), innerhalb eines Kunden der inneren.
- `Zip` stoppt bei der kürzeren Folge ohne Fehler (seit .NET Core 3.0 gibt es
  auch die Überladung ohne Ergebnisfunktion, die Tupel liefert).
- `TopKunde`: Eine Schleife mit `>` oder `OrderByDescending(...).FirstOrDefault()`
  liefert bei Gleichstand den ersten Kunden. Bonus (Deep Dive): Bei der
  LINQ-Variante liegt das daran, dass `OrderByDescending` stabil sortiert (nicht im Buch).

Modellantwort: `solution/` bzw. `samples/LINQ-to-Objects/Join`, `GroupJoin`, `Zip`.
