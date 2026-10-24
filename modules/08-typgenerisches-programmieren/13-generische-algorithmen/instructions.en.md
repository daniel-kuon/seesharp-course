# Extra: Generic Algorithms for Sorted Arrays

Extra exercise: optional; it unlocks nothing. For further reading: **8.5 Generic Methods** (page 602) and **8.2.2 Restricted Type Formal Parameters** (page 593).

Classic algorithms do not depend on the element type; they only require that elements be comparable. Once written generically, they work for `int`, `double`, `string`, and any custom type that implements `IComparable<T>`. Open `Algorithmen.cs`. The methods do **not** yet have **any** restrictions; add `where T : IComparable<T>` to each one as soon as you need `CompareTo` (a test checks for this):

1. `IstSortiert(werte)`: `true` if each element is at most as large as the element following it. Empty arrays and arrays with a single element are considered sorted.
2. `BinaereSuche(sortiert, gesucht)`: Search in a sorted array using the binary search method: Compare with the middle element and continue searching to the left or right. Returns the index or -1. Non-linear search: The test counts the number of comparisons made.
3. `Zusammenfuehren(a, b)`: Merge two sorted arrays into a new sorted array. Iterate through both arrays simultaneously using two indices, and select the smaller element each time (the merge step from mergesort). Do not simply concatenate them and then sort the result.
4. `MinMax(params T[] werte)`: Returns the smallest and largest elements as a tuple `(Min, Max)` in **a single** pass; an empty array throws an `ArgumentException` exception.

When calling the function, you don't specify any type arguments: `Algorithmen.MinMax(3, 1, 2)`.

The following tests must be passed:

- `AlgorithmenTests.Alle_Methoden_sind_auf_IComparable_eingeschraenkt`
- `AlgorithmenTests.IstSortiert_prueft_die_Reihenfolge`
- `AlgorithmenTests.BinaereSuche_findet_den_Index`
- `AlgorithmenTests.BinaereSuche_halbiert_den_Bereich`
- `AlgorithmenTests.Zusammenfuehren_verschmilzt_zwei_sortierte_Arrays`
- `AlgorithmenTests.MinMax_liefert_ein_Tupel`
