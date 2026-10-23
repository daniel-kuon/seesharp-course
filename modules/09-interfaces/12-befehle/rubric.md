# Rubrik — Zusatz Befehle (nur für die Betreuung)

- Entwurfsmuster "Befehl" (Command) und "Kompositum" (`Makro` ist ein
  `IBefehl` aus `IBefehl`s), ohne die Namen vorauszusetzen. Im Gespräch
  benennen; beide tauchen in Level 12 (Delegaten) wieder auf.
- Der `Rechner` darf keinen Typtest auf `Addiere` usw. enthalten. Frage:
  Was muss sich am Rechner ändern, wenn morgen `Quadriere` dazukommt?
  (Nichts, solange der Befehl umkehrbar ist; `Quadriere` ist es nicht, das
  Vorzeichen geht verloren. Gute Vertiefung: Wie könnte ein Befehl den alten
  Wert selbst speichern?)
- `Makro.Rueckgaengig` in umgekehrter Reihenfolge: Test mit `Addiere 2`
  und `Multipliziere 3`; vorwärts zurücknehmen liefert ein falsches
  Ergebnis.
- Die zwei Arrays mit Zähler sind Stapel (Level 8, `SimpleStack<T>`). Wer
  `SimpleStack<IBefehl>` aus Level 8 einkopiert, hat es richtig gemacht;
  `Stack<T>` kommt in Level 10.

Modellantwort: `solution/`.
