# Rekursion

Lies im Buch Abschnitt **5.9.2 Rekursive Methoden** (Seite 382). Die
Fakultät ist Aufgabe 5 in **5.15** (Seite 425).

Öffne `Bruch.cs`. `Kuerze()` ruft bereits `GgtRekursiv()` auf, das noch fehlt.
Vervollständige die drei statischen Methoden **rekursiv**, also ohne
Schleife:

1. `GgtRekursiv(int a, int b)`: Ist `a % b` gleich 0, ist `b` der ggT; sonst
   ist das Ergebnis der ggT von `b` und `a % b`.
2. `Fakultaet(int n)`: `0! = 1`, sonst `n * (n-1)!`. Rückgabetyp `long`, damit
   `20!` noch passt.
3. `Fibonacci(int n)`: `F(0) = 0`, `F(1) = 1`, sonst `F(n-1) + F(n-2)`.

Jede Methode braucht eine Abbruchbedingung, die zuerst geprüft wird. Setze
einen Haltepunkt in `GgtRekursiv` und sieh dir im Debugger den Aufrufstapel
(Call Stack) an.

Diese Tests müssen bestehen:

- `BruchTests.GgtRekursiv_von_10_und_6_ist_2`
- `BruchTests.GgtRekursiv_wenn_b_Teiler_ist`
- `BruchTests.Kuerze_nutzt_den_rekursiven_ggT`
- `BruchTests.Fakultaet_von_0_ist_1`
- `BruchTests.Fakultaet_von_5_ist_120`
- `BruchTests.Fakultaet_von_20_passt_in_long`
- `BruchTests.Fibonacci_Anfangswerte`
- `BruchTests.Fibonacci_von_30`
