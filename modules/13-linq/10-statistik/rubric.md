# Rubrik — Notenstatistik (Zusatzaufgabe, nur für die Betreuung)

- Kernidee: Aggregate (`Average`) auf gefilterten Folgen, `GroupBy` mit
  Auswertung je Gruppe und mehrstufiges Sortieren (`OrderBy`/`ThenBy`).
- `Average` wirft bei leerer Folge: Der Test `Durchschnitt_ohne_Pruefung_ist_null`
  prüft die Absicherung (`Any` oder `Select(...).Cast<double?>().Average()`).
- Gleichstand bei `Bestenliste` (zweimal Anna 1,0): Reihenfolge ist durch
  die Sortierung festgelegt, nicht Zufall.
- Fließkommavergleich in den Tests mit Genauigkeit, nicht mit `==`.

Modellantwort: `solution/`.
