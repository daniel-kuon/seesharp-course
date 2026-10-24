# Rubrik: throw-Ausdrücke und Validierung im SimpleStack (nur für die Betreuung)

- **Kernidee:** Jede Ausnahme drückt aus, **was** falsch war:
  `ArgumentOutOfRangeException` (Argument außerhalb des erlaubten Bereichs),
  `ArgumentNullException` (null nicht erlaubt), `InvalidOperationException`
  (der Aufruf passt nicht zum Zustand des Objekts). Die Prüfung steht **vor**
  der Änderung, damit der Zustand nach einem Fehler gültig bleibt.
- Häufiger Fehler bei `Pop`: erst `--anzahl`, dann prüfen. Dann ist `Count`
  negativ, der Test `…_und_ueberlebt` schlägt fehl. Gleiches bei `Push` mit
  `anzahl++` vor der Prüfung.
- `throw` als Ausdruck: In `a ?? throw …` und `cond ? x : throw …` steht
  `throw` dort, wo ein Wert erwartet wird. Als Anweisung geht das nicht. Der
  Test kann nicht prüfen, ob Peek als Ausdruck geschrieben wurde; bitte kurz
  im Code ansehen. Alternative `if … throw` ist testgleich und akzeptabel, wenn
  der Teilnehmer den Ausdruck erklären kann.
- `ThrowIfNull(quelle)`: Der Parametername kommt automatisch aus dem
  Aufrufausdruck (`CallerArgumentExpression`). Das ist Absicht und spart
  `nameof`.
- Nachfragen: Warum `InvalidOperationException` und nicht
  `ArgumentException` für `Pop` auf leerem Stapel? (Es gibt kein Argument, das
  falsch wäre.) Warum prüft der Konstruktor, statt einen Standardwert zu nehmen?
  (Fehler früh und laut melden, die Aufgabe 13.8/4 verlangt es.)
- Modellantwort: `solution/`; Vorlagen `samples/Ausnahmebehandlung/SimpleStackEx`
  und `throw-Ausdruck`.
