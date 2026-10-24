# Recursion

Read Section **5.9.2**, **“Recursive Methods”** (page 382), in the book. The factorial is Exercise 5 in **Section 5.15** (page 425).

Open `Bruch.cs`. `Kuerze()` already calls `GgtRekursiv()`, which is still missing. Complete the three static methods **recursively**, that is, without a loop:

1. `GgtRekursiv(int a, int b)`: If `a % b` equals 0, then `b` is the GCD; otherwise, the result is the GCD of `b` and `a % b`.
2. `Fakultaet(int n)`: `0! = 1`, otherwise `n * (n-1)!`. Return type `long` so that `20!` still fits.
3. `Fibonacci(int n)`: `F(0) = 0`, `F(1) = 1`, otherwise `F(n-1) + F(n-2)`.

Every method needs a termination condition, which is checked first. Set a breakpoint in `GgtRekursiv` and look at the call stack in the debugger.

The following tests must be passed:

- `BruchTests.GgtRekursiv_von_10_und_6_ist_2`
- `BruchTests.GgtRekursiv_wenn_b_Teiler_ist`
- `BruchTests.Kuerze_nutzt_den_rekursiven_ggT`
- `BruchTests.Fakultaet_von_0_ist_1`
- `BruchTests.Fakultaet_von_5_ist_120`
- `BruchTests.Fakultaet_von_20_passt_in_long`
- `BruchTests.Fibonacci_Anfangswerte`
- `BruchTests.Fibonacci_von_30`
