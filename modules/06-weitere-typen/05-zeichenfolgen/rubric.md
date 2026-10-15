# Rubrik — Zeichenfolgen (nur für die Betreuung)

- `WrapLine` ist die anspruchsvollste Methode des Levels. Der Test mit
  festen Erwartungswerten verlangt gieriges Füllen; die Hyphen-Variante ist
  optional schwer. Wer sie nicht schafft, soll trotzdem die anderen Tests
  grün haben; der Rest ist Gesprächsstoff.
- Hat der Trainee `List<string>` für die Zeilen genommen? Das ist erlaubt
  (Level 10 vertieft es), aber `ToArray()` am Ende muss er erklären können.
- `Glueckszahl`: `char` + `char` ergibt `int`; wer `Convert.ToInt32`
  braucht, hat 4.3.11/4 (Level 2) vergessen.
- Quizfrage zur Unveränderlichkeit ist der Klassiker `s.ToUpper();` ohne
  Zuweisung; im Code-Review darauf achten.

Modellantwort: `solution/` bzw. `samples/Weitere .NETte Typen/Zeichenfolgen/StringUtil` und `PerZuf`.
