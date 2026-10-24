# Rubrik — Größenvergleich (nur für die Betreuung)

- Mit Laufzeit: `<Name>.exe`, `.dll`, `.runtimeconfig.json`, `.deps.json`.
  Ohne Laufzeit: der gesamte eigenständige Ordner (ohne `PublishSingleFile`
  besteht er aus vielen Dateien).
- Größenordnung: unter 1 MB gegen grob 60 bis 70 MB (Buch 23.1.5: 130 MB beim
  Beispiel aus dem Buch; 23.1.6: 71,2 MB mit 191 Dateien). Der Trainee soll die
  Zahlen am eigenen Rechner erheben, nicht abschreiben.
- Entscheidungshilfe: Frameworkabhängig, wenn die Laufzeit gesichert ist und
  Updates über die Laufzeit gewünscht sind; eigenständig, wenn nichts
  vorinstalliert ist oder eine feste Laufzeitversion mitgeliefert werden soll.
