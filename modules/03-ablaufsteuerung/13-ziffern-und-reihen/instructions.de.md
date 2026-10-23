# Zusatz: Ziffern und Reihen mit Schleifen

Zusatzaufgabe: freiwillig, sie blockiert nichts. In Level 2 hast du
dreistellige Zahlen mit `/` und `%` zerlegt; mit einer Schleife geht das für
Zahlen beliebiger Länge.

Lies im Buch **4.7.3.1 Zählergesteuerte Schleife (for)** (Seite 271) und
**4.7.3.3 Bedingungsabhängige Schleifen** (Seite 275).

Öffne `Zahlenreihen.cs`:

1. `Einmaleins(int zahl)` liefert die Einmaleins-Reihe von `zahl` mal 1 bis
   `zahl` mal 10, durch Leerzeichen getrennt: `Einmaleins(7)` ist
   `7 14 21 28 35 42 49 56 63 70` (`for`-Schleife).
2. `Quersumme(long n)` liefert die Ziffernsumme einer beliebigen Zahl ab 0:
   `Quersumme(9045)` ist 18. Solange noch Ziffern übrig sind: letzte Ziffer
   addieren, abschneiden (`while`-Schleife).
3. `Umgedreht(long n)` dreht die Ziffern um: `1234` wird `4321`, `1230`
   wird `321`.
4. `IstPalindrom(long n)` liefert `true`, wenn die Zahl vorwärts und
   rückwärts gleich ist (`12321`). Benutze `Umgedreht()`.
5. `Potenz(int basis, int exponent)` berechnet `basis` hoch `exponent` für
   `exponent >= 0` durch wiederholtes Multiplizieren, ohne `Math.Pow`.
   Das Ergebnis ist ein `long`; `Potenz(2, 40)` passt nicht mehr in ein `int`.

Diese Tests müssen bestehen:

- `ZahlenreihenTests.Einmaleins_von_7`
- `ZahlenreihenTests.Einmaleins_von_1`
- `ZahlenreihenTests.Quersumme_beliebig_langer_Zahlen`
- `ZahlenreihenTests.Umgedreht_beliebig_langer_Zahlen`
- `ZahlenreihenTests.Palindrome`
- `ZahlenreihenTests.Keine_Palindrome`
- `ZahlenreihenTests.Potenzen`
- `ZahlenreihenTests.Potenz_groesser_als_int`
