# ggT mit Modulo

Lies in **4.7.4** die Aufgabe 6 (Seite 282) mit dem Satz über `u % v` und
den Ablauf des Modulo-Verfahrens; zur `do`-Schleife **4.7.3.3** (Seite 275).

Öffne `Euklid.cs`:

1. `GgtModulo(int a, int b)` berechnet den ggT mit der Modulo-Variante von
   Euklid: Rest von `a % b` bilden, dann `b` zum neuen `a` und den Rest zum
   neuen `b` machen, bis der Rest 0 ist. Nimm eine `do … while`-Schleife, die
   den Rest mindestens einmal berechnet. Beide Zahlen sind positiv.
2. `Kgv(int a, int b)` liefert das kleinste gemeinsame Vielfache über den ggT:
   `a / ggT * b`.

Diese Tests müssen bestehen:

- `EuklidTests.Ggt_von_12_und_18_ist_6`
- `EuklidTests.Ggt_von_1071_und_462_ist_21`
- `EuklidTests.Ggt_von_teilerfremden_Zahlen_ist_1`
- `EuklidTests.Ggt_wenn_b_Teiler_von_a_ist`
- `EuklidTests.Kgv_von_4_und_6_ist_12`
