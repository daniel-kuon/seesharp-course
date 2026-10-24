# Rubrik: Zusatz Zahlen einlesen (nur für die Betreuung)

- **Kernidee:** Zwei verschiedene Probleme beim Umwandeln (kein Zahlenformat,
  Zahl außerhalb des Bereichs) haben zwei verschiedene Ausnahmeklassen und
  damit zwei catch-Blöcke mit eigenen Meldungen. Das `try` steht in der
  Schleife, damit ein Fehler nur einen Teil betrifft.
- Häufige Fehler: ein einziges `try` um die ganze Schleife (stoppt beim ersten
  Fehler, die späteren Zahlen fehlen); `catch (Exception)` statt der beiden
  spezifischen Klassen (besteht die Tests, verfehlt aber die Übung: auch
  Programmierfehler würden als "keine Zahl" gemeldet).
- Nachfragen: Wäre `int.TryParse` hier besser? (Ja, bei vielen
  Tippfehlern; die Übung will bewusst die Ausnahmen üben. Siehe Aufgabe
  `ausnahmen-fehlerkommunikation`.)
- Modellantwort: `solution/`.
