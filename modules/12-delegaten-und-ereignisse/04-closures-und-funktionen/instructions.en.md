# Closures, Func, and Action

Read the section in Chapter **10.1.5**, **“Creating Delegate Objects Using Anonymous Functions”** (page 665), specifically the section on variable capture, and complete Exercise **10.3, Task 3** (page 688, `ListLE(k)`).

A lambda can use variables from the environment; these variables then exist for as long as the delegate object (closure). Open `Fabrik.cs`:

1. `KleinerGleich(k)`: returns a `Predicate<int>` for values `<= k`.
2. `Zaehler()` returns a `Func<int>` that returns 1, 2, 3, ... on each call. Each call to `Zaehler()` has its own state.
3. `Addierer(n)`: `Func<int, int>` that adds `n`.
4. `Komponiere(f, g)`: returns the function `x => g(f(x))`.
5. `FuehreAus(aktionen)`: Calls all `Action` delegates in sequence.
6. `ErzeugeAktionen(sb, n)`: returns `n` actions; action `i` appends `i` to `sb` (`i` = 0 to `n - 1`). The tests run them in reverse order. Careful: Which variable does the lambda capture?
7. `Merke(f)`: returns a function that calls `f` at most once for each argument and remembers the results.

Tests: `KleinerGleich_erzeugt_passende_Praedikate`, `Zaehler_zaehlt_ab_eins`, `Zaehler_haben_getrennten_Zustand`, `Addierer_addiert`, `Komponiere_wendet_erst_f_dann_g_an`, `FuehreAus_ruft_alle_Aktionen_auf`, `Aktionen_fangen_ihren_eigenen_Index_ein`, `Merke_ruft_f_pro_Argument_einmal_auf`.
