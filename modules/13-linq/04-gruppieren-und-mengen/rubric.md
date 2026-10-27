# Rubrik — Gruppieren und Mengen (nur für die Betreuung)

- Kernidee: `GroupBy` liefert Gruppen (`IGrouping<TKey,T>`), die selbst
  Sequenzen sind; erst `Where`/`Select`/`Count` darauf macht daraus ein Ergebnis.
  Der zusammengesetzte Schlüssel `(Groesse, Hash)` ist ein Tupel mit
  Werte-Gleichheit; ein Record funktioniert genauso (Level 6).
- Der Dubletten-Test mischt die Eingabe und enthält gleichen Hash bei
  verschiedener Größe (keine Dublette): fängt Schlüssel nur aus dem Hash.
- Mengenoperatoren entfernen Wiederholungen; `Union` ohne `Distinct` genügt.
  Nachfrage: Wie vergleicht `Except` Records? (Wertgleichheit über `Equals` und
  `GetHashCode`; bei eigenen Klassen müssten beide überschrieben werden.)
- Bonus (Deep Dive): `CountBy`/`AggregateBy` (nicht im Buch, Tests
  `Haeufigkeiten_*` und `GroesseProEndung_*` sind Zusatz) ersetzen
  `GroupBy(...).Select(g => (g.Key, g.Count()))` bzw.
  `GroupBy(...).ToDictionary(g => g.Key, g => g.Sum(...))`.
- `Order(StringComparer.Ordinal)` (in der Aufgabe vorgegeben) macht die Ausgabe
  unabhängig von der Spracheinstellung des Rechners.

Modellantwort: `solution/` bzw. `samples/LINQ-to-Objects/GroupBy`, `FindDuplicate`.
