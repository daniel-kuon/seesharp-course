# Rubrik — Zusatzaufgabe Bibliothek (nur für die Betreuung)

- Unterschied zur `PersList`: Der `string`-Indexer liefert hier `null`
  statt zu werfen. Im Gespräch abwägen, wann welches Verhalten sinnvoll ist
  (Suche mit erwartbarem Fehlschlag vs. Programmierfehler).
- `Ausleihen`/`Zurueckgeben` sollten `this[titel]` aufrufen statt die Liste
  ein zweites Mal von Hand zu durchlaufen.
- `Verfuegbar` als berechnete Eigenschaft: Wer ein Zählerfeld pflegt, muss
  es in `Ausleihen` und `Zurueckgeben` aktualisieren und vergisst den Fall,
  dass jemand `buch.Ausgeliehen` direkt setzt. Nachfragen.
- `VonAutor` per String-Verkettung ist hier in Ordnung; in Level 6 kommt
  `StringBuilder` bzw. `string.Join`.
- Der `int`-Indexer ist O(n); für eine Bibliothek mit wenigen Büchern egal.
  Ausblick auf `List<T>` in Level 10.

Modellantwort: `solution/Bibliothek/`.
