# Rubrik — Wortanalyse (Zusatzaufgabe, nur für die Betreuung)

- Kernidee: `SelectMany` flacht Zeilen zu Wörtern ab, `GroupBy` (Bonus
  (Deep Dive): `CountBy`) verdichtet, `OrderBy`/`ThenBy` bringen eine stabile, nachvollziehbare
  Reihenfolge.
- Typische Fehler: Wörter nicht klein geschrieben (Der/der zählen getrennt),
  `\r` im Text (die Trennzeichen enthalten es deshalb), `Max` auf leerem Text
  (wirft) statt Abfangen.
- `LaengsteWoerter`: zwei Durchläufe (Länge bestimmen, dann filtern) sind
  in Ordnung. Bonus (Deep Dive): `GroupBy(Length).MaxBy(g => g.Key)` (nicht im Buch).

Modellantwort: `solution/`.
