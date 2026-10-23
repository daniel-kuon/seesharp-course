# Zusatzaufgabe: Rekursion vertieft

Diese Aufgabe ist freiwillig. Sie setzt die Übung **Rekursion** fort; lies
bei Bedarf noch einmal **5.9.2 Rekursive Methoden** (Seite 382).

Öffne `Rekursiv.cs`. Löse alle fünf Methoden **rekursiv**, ohne Schleife.
Überlege bei jeder zuerst: Wie lautet die Abbruchbedingung, und wie wird das
Problem beim Selbstaufruf kleiner?

1. `Quersumme(n)`: eine einstellige Zahl ist ihre eigene Quersumme; sonst
   letzte Ziffer (`n % 10`) plus Quersumme vom Rest (`n / 10`).
2. `Potenz(basis, exponent)` mit **schneller Potenzierung**: `x⁰ = 1`;
   sonst `h = x^(n/2)` einmal berechnen und `h * h` liefern, bei ungeradem
   `n` noch mal `x`. So braucht `2⁶²` nur sieben Aufrufe statt 62.
3. `Binomial(n, k)` nach dem Pascalschen Dreieck: am Rand (`k == 0` oder
   `k == n`) steht 1, sonst die Summe der beiden Werte darüber,
   `Binomial(n-1, k-1) + Binomial(n-1, k)`.
4. `HanoiZuege(n)`: Um `n` Scheiben umzusetzen, verschiebt man `n-1`
   Scheiben zur Seite, setzt die größte um und holt die `n-1` Scheiben
   wieder darauf. Null Scheiben brauchen keinen Zug.
5. `Fibonacci(n, a, b)`: Die Fassung aus der Pflichtübung rechnet dieselben
   Werte immer wieder neu und ist schon bei `F(45)` unerträglich langsam.
   Hier tragen die Parameter `a` und `b` die beiden letzten Fibonacci-Zahlen
   mit: `n == 0` liefert `a`, sonst geht es mit `(n - 1, b, a + b)` weiter.
   Aufgerufen wird mit `Fibonacci(n, 0, 1)`; `F(90)` kommt sofort.

Diese Tests müssen bestehen:

- `RekursivTests.Quersumme_einstellig_und_mehrstellig`
- `RekursivTests.Potenz_Sonderfaelle`
- `RekursivTests.Potenz_gerade_und_ungerade_Exponenten`
- `RekursivTests.Binomial_Rand_des_Dreiecks_ist_1`
- `RekursivTests.Binomial_im_Inneren`
- `RekursivTests.HanoiZuege_verdoppeln_sich_plus_eins`
- `RekursivTests.Fibonacci_Anfangswerte`
- `RekursivTests.Fibonacci_von_90_ist_schnell`
