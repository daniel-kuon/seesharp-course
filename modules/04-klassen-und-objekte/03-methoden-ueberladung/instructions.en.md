# Overloading Methods

Read Section **5.3.5, “Overloading Methods**” (page 334), in the book, and, as a refresher, **Section 5.3.2, “Method Calls and Actual Parameters”** (page 324).

Open `Bruch.cs`. The properties and `Kuerze()` are complete. Complete the two methods with the same name:

1. `Addiere(Bruch b)` adds `b` to this fraction and then simplifies it (as in the previous exercise).
2. `Addiere(int zpar, int npar, bool autokurz)` adds the fraction `zpar/npar`. If `npar` is 0, nothing happens and the method returns `false`; otherwise, it returns `true` and reduces only if `autokurz` is set.

The compiler uses the arguments to determine which overloaded method to call. Try both calls in `Bruchrechnung.cs`.

The following tests must be passed:

- `BruchTests.Addiere_Bruch_addiert_und_kuerzt`
- `BruchTests.Addiere_Zahlen_mit_autokurz`
- `BruchTests.Addiere_Zahlen_ohne_autokurz_kuerzt_nicht`
- `BruchTests.Addiere_mit_Nenner_null_liefert_false_und_aendert_nichts`
- `BruchTests.Beide_Ueberladungen_sind_aufrufbar`
