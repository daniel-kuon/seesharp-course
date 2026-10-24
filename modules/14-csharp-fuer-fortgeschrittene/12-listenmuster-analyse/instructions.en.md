# Extra: Patterns in Data Series

Extra exercise: optional; it unlocks nothing. For further reading: **15.2.10 List Patterns** (page 985) along with **15.2.10.1 Committee and Area Patterns** and **15.2.8 Relational Patterns** (page 983).

In `Messreihe.cs`, you define measurement series using only patterns:

1. `Trend(int[] werte)`: a `switch` expression whose branches are listed in the following order: `[]` returns `"leer"`; a single value returns `"einzeln"`; three strictly ascending values (`[var a, var b, var c] when a < b && b < c`) return `"steigend"`; a sequence of any length whose last value is greater than 100 (`[.., > 100]`) returns `"Ausreißer am Ende"`; everything else returns `"sonstige"`.
2. `Kopf(List<string>)`: Returns the first element and the number of remaining elements as a tuple using `[var kopf, .. var rest]`; for an empty list, it returns `(null, 0)`.

The following tests must be passed:

- `MessreiheTests.Trend_leer_und_einzeln`
- `MessreiheTests.Trend_steigend_bei_drei_streng_aufsteigenden_Werten`
- `MessreiheTests.Trend_steigend_hat_Vorrang_vor_dem_Ausreisser`
- `MessreiheTests.Trend_Ausreisser_am_Ende`
- `MessreiheTests.Kopf_zerlegt_die_Liste`
