# Extra: Counting and Factoring Prime Numbers

Extra exercise: optional; it blocks nothing. You wrote the prime number test in the exercise "Prime Number Test, switch Statement, foreach"; here, it's already provided, and you'll build on it.

Read **sections 4.7.3.1, "Counter-Controlled Loops (for)**" (page 271), and **4.7.3.3, "Conditional Loops**" (page 275), in the book to learn about the `do` loop.

Open `Primzahlen.cs`. `IstPrim(int n)` is complete; do not change it. Complete the following:

1. `AnzahlBis(int n)` counts the prime numbers from 2 up to and including `n` (`for` loop). There are 4 prime numbers up to 10 (2, 3, 5, 7), and 25 up to 100.
2. `NaechsteNach(int n)` returns the smallest prime number **greater** than `n`: 13 is followed by 17, and 1 is followed by 2. Use a `do … while` loop: First increment by one, then check.
3. `SindZwillinge(int n)` returns `true` if `n` and `n + 2` are both prime (11 and 13 are, 7 and 9 are not).
4. `Primfaktoren(int n)` breaks a number from 2 upward into its prime factors, in ascending order and separated by ` * `: `12` yields `2 * 2 * 3`, `13` yields `13`. Idea: Start with the divisor 2. As long as `n` is greater than 1: if the divisor divides `n`, note it down and divide `n` by it; otherwise increase the divisor by 1. A single `while` loop is enough for this.

The following tests must be passed:

- `PrimzahlenTests.Anzahl_bis_10_ist_4`
- `PrimzahlenTests.Anzahl_bis_100_ist_25`
- `PrimzahlenTests.Anzahl_unter_2_ist_0`
- `PrimzahlenTests.Naechste_Primzahl`
- `PrimzahlenTests.Primzahlzwillinge`
- `PrimzahlenTests.Keine_Zwillinge`
- `PrimzahlenTests.Primfaktoren_zusammengesetzter_Zahlen`
- `PrimzahlenTests.Primfaktoren_einer_Primzahl`
