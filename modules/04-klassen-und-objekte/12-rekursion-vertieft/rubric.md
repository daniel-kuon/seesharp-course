# Rubrik — Zusatzaufgabe Rekursion vertieft (nur für die Betreuung)

- Bei jeder Methode nach Abbruchbedingung und "kleinerem Problem" fragen.
- `Potenz`: Wer `Potenz(basis, exponent / 2)` zweimal aufruft, statt das
  Ergebnis in einer Variablen zu halten, bekommt wieder exponentiellen
  Aufwand (der Test bleibt grün, die Idee ist verfehlt). Im Review zeigen
  lassen. Ausblick: `long` läuft bei `2⁶³` über (Level 2, Überlauf).
- `Binomial` ist absichtlich naiv: `Binomial(20, 10)` braucht schon rund
  370 000 Aufrufe. Gleiche Schwäche wie die naive Fibonacci-Fassung; der
  Ausweg (Zwischenergebnisse merken) braucht Arrays aus Level 6.
- `Fibonacci(n, a, b)` ist endrekursiv: Der Selbstaufruf ist das Letzte,
  was passiert. Nachfrage: Wie viele Aufrufe braucht `F(90)`? (91.)
  Vergleich mit der iterativen Fassung im Sample `Klassen und Objekte/Rekursion`.
- `HanoiZuege` liefert `2ⁿ − 1`; gute Gelegenheit, eine Rekursionsformel in
  eine geschlossene Formel zu übersetzen.

Modellantwort: `solution/Rekursion/Rekursiv.cs`.
