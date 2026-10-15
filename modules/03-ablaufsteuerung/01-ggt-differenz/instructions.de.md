# ggT per Subtraktion

Lies im Buch Abschnitt **4.7.2.1 if-Anweisung** (Seite 254) und **4.7.3.3
Bedingungsabhängige Schleifen** (Seite 275). Der Algorithmus steht in
**1.4** (Seite 11) und in Aufgabe 6 von **4.7.4** (Seite 282).

Öffne `Euklid.cs`:

1. `GgtDifferenz(int a, int b)` berechnet den größten gemeinsamen Teiler
   zweier positiver Zahlen durch wiederholtes Subtrahieren: Solange `a` und
   `b` verschieden sind, wird die kleinere von der größeren abgezogen. Nimm
   eine `while`-Schleife mit `if`/`else` im Körper.
2. `GroessterExponent()` bestimmt mit einer Schleife den größten ganzzahligen
   Exponenten `i`, für den `1.0 + 2^-i` in `double` noch größer als `1.0` ist
   (Aufgabe 5 in 4.7.4, Seite 282). Beginne mit `eps = 1.0` und halbiere, bis
   `1.0 + eps` nicht mehr größer als `1.0` ist. Kein `Math.Pow` nötig.

Diese Tests müssen bestehen:

- `EuklidTests.Ggt_von_12_und_18_ist_6`
- `EuklidTests.Ggt_von_teilerfremden_Zahlen_ist_1`
- `EuklidTests.Ggt_gleicher_Zahlen_ist_die_Zahl`
- `EuklidTests.Ggt_von_100_und_75_ist_25`
- `EuklidTests.Groesster_Exponent_ist_52`
