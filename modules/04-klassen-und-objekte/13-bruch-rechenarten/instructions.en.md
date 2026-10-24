# Extra exercise: Fractions with all basic arithmetic operations

This exercise is optional. It builds on **operator overloading**; if necessary, review Section **5.9.3**, **“Operator Overloading”** (page 385).

Open `Bruch.cs`. This version of `Bruch` simplifies the fraction right in the constructor and always keeps the denominator positive (`2/-4` becomes `-1/2`). The `operator +` operator is ready as an example. All operators return **new** fractions; the operands remain unchanged.

1. The **unary** operator `-` (one parameter): `-(3/4)` is `-3/4`.
2. The binary operator `-`. Hint: `b1 - b2` is `b1 + (-b2)`.
3. The `*` operator: numerator times numerator, denominator times denominator.
4. `Kehrwert()`: `3/4` becomes `4/3`, `-2/5` becomes `-5/2`. A fraction with a numerator of 0 has no reciprocal; in that case, the method returns `null`. The return type `Bruch?` says exactly that.
5. The operator `/`: `b1` times the reciprocal of `b2`. If `b2` is equal to 0, it returns `null`.
6. `Vergleiche(b)`: -1 if this fraction is less than `b`, 0 if they are equal, otherwise 1. Hint: `a/b < c/d` if and only if `a·d < c·b`, because both denominators are positive.

The following tests must be passed:

- `BruchTests.Vorzeichenwechsel_liefert_neuen_Bruch`
- `BruchTests.Subtraktion_kuerzt_und_laesst_Operanden_unveraendert`
- `BruchTests.Multiplikation_kuerzt`
- `BruchTests.Kehrwert_vertauscht_und_behaelt_das_Vorzeichen_im_Zaehler`
- `BruchTests.Kehrwert_von_null_ist_null`
- `BruchTests.Division_multipliziert_mit_dem_Kehrwert`
- `BruchTests.Division_durch_null_liefert_null`
- `BruchTests.Vergleiche_liefert_minus_eins_null_oder_eins`
