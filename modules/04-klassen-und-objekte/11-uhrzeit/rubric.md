# Rubrik — Zusatzaufgabe Uhrzeit (nur für die Betreuung)

- Kernidee: ein einziges Feld als interne Darstellung, alles andere wird
  berechnet. Wer `stunde` und `minute` als zwei Felder speichert, muss an
  jeder Stelle doppelt normieren und verliert leicht einen Übertrag. Im
  Gespräch vergleichen.
- `Normiere` ist der Knackpunkt: Der `%`-Operator liefert in C# ein Ergebnis
  mit dem Vorzeichen des linken Operanden. `((m % 1440) + 1440) % 1440` ist
  ebenfalls richtig.
- In `Addiere(int minuten)` verdeckt der Parameter das Feld; `this.minuten`
  ist nötig. Gute Gelegenheit, `this` noch einmal zu erklären.
- `operator +` darf das Original nicht verändern (Test prüft das). Vergleich
  mit `operator +=` aus der Bruch-Übung.
- Nachfrage: Warum liefert `operator -` hier einen `int` und keine
  `Uhrzeit`? (Eine Zeitdauer ist etwas anderes als ein Zeitpunkt; die BCL
  trennt das in `TimeOnly` und `TimeSpan`.)

Modellantwort: `solution/Uhrzeit/Uhrzeit.cs`.
