# Rubrik — Zusatzaufgabe Bruch-Rechenarten (nur für die Betreuung)

- Unärer und binärer Operator `-` sind zwei Überladungen desselben
  Operators; der Compiler unterscheidet sie an der Parameterzahl.
- Wer `operator -` per `b1 + -b2` und `/` per `b1 * kehrwert` baut, hat die
  Idee verstanden: vorhandene Operatoren wiederverwenden statt neu rechnen.
- `Kehrwert` über den Konstruktor `new Bruch(Nenner, Zaehler)` erledigt das
  Vorzeichen automatisch, weil `Kuerze()` den Nenner positiv macht. Wer
  Vorzeichen von Hand umdreht, hat mehr Code als nötig.
- `null` als "kein Ergebnis": Nachfragen, wie der Aufrufer damit umgehen
  muss (Program.cs prüft `q != null`). Ausnahmen kommen erst in Level 11.
- `Vergleiche` kann bei großen Zählern überlaufen (`int`-Produkt). Wer
  `long` für die Kreuzprodukte nimmt, bekommt Extralob.
- `==` wurde bewusst nicht überladen: Ohne `Equals`/`GetHashCode` gibt es
  Warnungen, und das Thema gehört zu Level 7/9.

Modellantwort: `solution/Rechenarten/Bruch.cs`.
