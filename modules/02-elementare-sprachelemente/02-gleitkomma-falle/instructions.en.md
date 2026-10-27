# The Floating-Point Trap

Read sections **4.3.5, “Representation of Floating-Point Numbers in Memory”** (page 189), and **4.5.4, “Identity Check for Floating-Point Values”** (page 223), in the book. For the `Math` class, **4.5.2 "Method Calls"** (page 220) is sufficient.

Open `Gleitkomma.cs` and complete the following:

1. `SummeDouble()` returns `0.1 + 0.2` as a `double`.
2. `SummeDecimal()` returns `0.1 + 0.2` as a `decimal` (`m` literal suffix). A test verifies that the `double` sum is **not** equal to `0.3`, but the `decimal` sum is. Write both methods honestly, without tricks, and look at the result.
3. `EinsPlusZweiHochMinus(int i)` returns `1.0 + 2^-i` (using `Math.Pow`). When `i = 52`, the result is still greater than 1.0, but when `i = 53`, it is no longer greater than 1.0.
4. `IstUngefaehrGleich(double a, double b, double toleranz)` returns `true` if the distance (`Math.Abs`) is less than the tolerance. (In 4.5.4 the book generally recommends a threshold for the *relative* deviation; here the absolute one with a given tolerance is enough.)
5. `RundeKaufmaennisch(decimal betrag)` rounds to two decimal places, with `,005` being rounded up (`Math.Round` with `MidpointRounding.AwayFromZero`).

The following tests must be passed:

- `GleitkommaTests.Double_Summe_ist_nicht_0_3`
- `GleitkommaTests.Decimal_Summe_ist_0_3`
- `GleitkommaTests.Eins_plus_2_hoch_minus_52_ist_groesser_als_eins`
- `GleitkommaTests.Eins_plus_2_hoch_minus_53_ist_eins`
- `GleitkommaTests.Ungefaehr_gleich_mit_Toleranz`
- `GleitkommaTests.Ungefaehr_gleich_erkennt_Unterschied`
- `GleitkommaTests.Kaufmaennisch_runden`
