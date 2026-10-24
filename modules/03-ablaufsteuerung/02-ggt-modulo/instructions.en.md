# GCD with Modulo

Read Exercise 6 in Section **4.7.4** (page 282), which includes the statement about `u % v` and the steps of the modulo operation; for the `do` loop, see Section **4.7.3.3** (page 275).

Open `Euklid.cs`:

1. `GgtModulo(int a, int b)` calculates the GCD using the modular version of Euclid's algorithm: Find the remainder of `a % b`, then set `b` to the new `a` and the remainder to the new `b`, and repeat until the remainder is 0. Use a `do … while` loop that calculates the remainder at least once. Both numbers are positive.
2. `Kgv(int a, int b)` returns the least common multiple (GCD): `a / ggT * b`.

The following tests must be passed:

- `EuklidTests.Ggt_von_12_und_18_ist_6`
- `EuklidTests.Ggt_von_1071_und_462_ist_21`
- `EuklidTests.Ggt_von_teilerfremden_Zahlen_ist_1`
- `EuklidTests.Ggt_wenn_b_Teiler_von_a_ist`
- `EuklidTests.Kgv_von_4_und_6_ist_12`
