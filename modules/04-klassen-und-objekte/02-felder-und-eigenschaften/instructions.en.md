# Fields, Properties, Validation

Read sections **5.2 "Instance Variables (Fields)"** (page 300), **5.3.1 "Method Definition"** (page 309), and **5.5 "Properties"** (page 361) in the book. Exercises 1 through 3 in Section **5.15** (page 424) correspond to this material.

Open *`Bruch.cs`*. The fields *`zaehler`*, *`nenner`*, and *`etikett`* are present. Complete the following:

1. The `Zaehler` property reads and writes the `zaehler` field.
2. `Nenner`'s setter ignores the value 0 (in which case the denominator remains unchanged).
3. `Etikett`'s setter accepts a maximum of 40 characters (`Substring`).
4. `Kuerze()` reduces the fraction using the GCD (Euclidean, modulo variant from Level 3, using `Math.Abs` for negative values). A fraction with a numerator of 0 becomes 0/1.
5. `Addiere(Bruch b)` adds `b` to this fraction and then simplifies it.

Then answer the question about the recursive getter.

The following tests must be passed:

- `BruchTests.Zaehler_liest_und_schreibt_das_Feld`
- `BruchTests.Nenner_ignoriert_null`
- `BruchTests.Nenner_uebernimmt_gueltige_Werte`
- `BruchTests.Etikett_wird_auf_40_Zeichen_gekuerzt`
- `BruchTests.Kuerze_teilt_durch_den_ggT`
- `BruchTests.Kuerze_macht_aus_null_Zaehler_null_durch_eins`
- `BruchTests.Kuerze_mit_negativem_Zaehler`
- `BruchTests.Addiere_addiert_und_kuerzt`
