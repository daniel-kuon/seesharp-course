# GCD by Subtraction

Read Section **4.7.2.1, "if Statement"** (page 254), and Section **4.7.3.3, "Conditional Loops"** (page 275), in the book. The algorithm is described in Section **1.4** (page 11) and in Exercise 6 of Section **4.7.4** (page 282).

Open `Euklid.cs`:

1. `GgtDifferenz(int a, int b)` calculates the greatest common divisor of two positive numbers by repeatedly subtracting: as long as `a` and `b` are different, the smaller is subtracted from the larger. Use a `while` loop with an `if`/`else` statement in the body.
2. The `GroessterExponent()` function uses a loop to determine the largest integer exponent `i` for which `1.0 + 2^-i`, as a `double`, is still greater than `1.0` (Exercise 5 in 4.7.4, page 282). Start with `eps = 1.0` and halve it until `1.0 + eps` is no longer greater than `1.0`. No `Math.Pow` is needed.

The following tests must be passed:

- `EuklidTests.Ggt_von_12_und_18_ist_6`
- `EuklidTests.Ggt_von_teilerfremden_Zahlen_ist_1`
- `EuklidTests.Ggt_gleicher_Zahlen_ist_die_Zahl`
- `EuklidTests.Ggt_von_100_und_75_ist_25`
- `EuklidTests.Groesster_Exponent_ist_52`
