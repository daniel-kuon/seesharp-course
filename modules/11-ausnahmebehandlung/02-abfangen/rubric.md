# Rubrik: Ausnahmen abfangen (nur für die Betreuung)

- **Kernidee:** Die Ausnahmeklassen bilden eine Hierarchie
  (`Exception` > `SystemException` > `ArithmeticException` >
  `OverflowException`/`DivideByZeroException`). Die catch-Blöcke werden von
  oben nach unten geprüft und der erste passende gewinnt; darum stehen
  **spezifische vor allgemeinen** Klassen, und der Compiler verbietet
  die falsche Reihenfolge (CS0160).
- Der Starter hat zwei Fehler in einem: `catch (Exception)` vorn (Compilerfehler,
  weil die folgenden Blöcke unerreichbar wären) und dieser Block verschluckt
  außerdem die `ArgumentException` des unbekannten Operators. Wer ihn nur ans
  Ende schiebt, besteht die Operator-Tests nicht. Frage: Warum ist ein
  `catch (Exception)` meist falsch? (Fängt auch Programmierfehler und Dinge,
  die man gar nicht behandeln kann.)
- `ArithmeticException` am Ende: Der Test kann sie nicht auslösen; im Gespräch
  die Hierarchie zeichnen lassen. Der Block ist trotzdem Teil der Lösung.
- `token`-Variable: Sie merkt sich, welcher Text gerade umgewandelt wird, damit
  die Meldung den richtigen nennt. Eine zweite Lösung mit zwei eigenen
  `try`-Blöcken ist ebenfalls in Ordnung.
- `SummeAusText`: Ein `try` **um** die ganze Schleife bricht beim ersten
  Fehler ab (Test mit `"10;abc;99999999999;5;1,5"` zeigt es). Das `try` gehört
  in die Schleife. `ex.GetType().Name` ist die Anwendung der catch-Variable.
- Quizfrage Sequenzen: Der Ablauf bei `3000000000` lautet `try-Block von
  Main()`, `try-Block von Calc()`, `finally-Block von Calc()`, `ArithmeticException-
  Handler in Main()`, `finally-Block von Main()`, `Nach der try-Anweisung in
  Main()`. Die Zeile "Nach der try-Anweisung in Calc()" fehlt.
- Modellantwort: `solution/`; Vorlagen `samples/Ausnahmebehandlung/catch` und
  `Sequenzen`.
