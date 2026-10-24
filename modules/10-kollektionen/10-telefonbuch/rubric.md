# Rubrik: Zusatz Telefonbuch (nur für die Betreuung)

- **Kernidee:** Ein `Dictionary` kapselt man hinter einer kleinen Klasse, die
  genau die Operationen anbietet, die gebraucht werden. `Suche` verwendet
  `TryGetValue` und liefert `null` statt der `KeyNotFoundException`;
  `Entferne` gibt das `bool` von `Dictionary.Remove` weiter.
- Häufiger Fehler: `Setze` mit `Add` statt mit dem Indexer (zweiter Eintrag
  für denselben Namen löst eine Ausnahme aus).
- Sortieren: Schlüssel in eine `List<string>` kopieren und `Sort()` rufen;
  ein `Dictionary` selbst ist nicht sortierbar. Die Tests nutzen nur
  ASCII-Namen, die Sortierung hängt dort nicht von der Kultur ab.
- Modellantwort: `solution/`.
