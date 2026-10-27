# Extra: Number Ranges and Infinite Sequences with `yield`

Extra exercise: optional; it unlocks nothing. For further reading: **9.5.2 Algorithm Enumerators** (page 651) and **9.5.3 Named Collection Enumerators** (page 652).

An iterator doesn't have to iterate through a collection; it can also calculate its values. `Bereich` only stores the start, end, and step values, and only returns the numbers in between when someone requests them using `foreach`. Open `Bereich.cs`:

1. `Bereich(start, ende, schritt = 1)`: The values range from `Start` to `Ende` (inclusive) at most: `new Bereich(1, 10, 3)` returns 1, 4, 7, 10. With a negative step size, the values decrease: `new Bereich(5, 1, -2)` returns 5, 3, 1. If the step size points in the wrong direction, the range is empty. A step size of 0 throws an `ArgumentOutOfRangeException`.
2. `Count` and `Enthaelt(zahl)` **calculate** instead of iterating through the values: How many whole steps fit between the start and the end? Is `zahl` on a step, and is it one of the first `Count` steps?
3. `GetEnumerator()` returns the values using `yield return`; the non-generic `IEnumerable.GetEnumerator()` is implemented explicitly and delegates (it's already there).
4. Named iterators: `Rueckwaerts` (property) returns the same values in reverse order, `Vielfache(teiler)` (method) only the values divisible by `teiler`; for `teiler == 0`, `yield break` ends the iterator immediately.
5. `Folgen.Quadratzahlen()` is an **infinite** sequence: 1, 4, 9, 16, ... (`long`). This works only because iterators are lazy: don’t store the values in an array, otherwise the program will run forever. `Folgen.Erste(quelle, anzahl)` returns at most the first `anzahl` values of any sequence and then terminates with `yield break`. This turns the infinite sequence into a finite one.

The following tests must pass:

- `BereicheTests.Bereich_ist_mit_foreach_durchlaufbar`
- `BereicheTests.Schrittweite_auf_und_ab`
- `BereicheTests.Schrittweite_0_wirft`
- `BereicheTests.Count_und_Enthaelt_rechnen`
- `BereicheTests.Rueckwaerts_ist_ein_Iterator_als_Eigenschaft`
- `BereicheTests.Vielfache_filtert_und_bricht_bei_0_ab`
- `BereicheTests.Erste_holt_aus_einer_unendlichen_Folge`
- `BereicheTests.Zwei_Durchlaeufe_sind_unabhaengig`
