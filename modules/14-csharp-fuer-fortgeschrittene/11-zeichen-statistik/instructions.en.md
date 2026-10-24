# Extra: Character Count Without Copies

Extra exercise: optional; it unlocks nothing. For further reading: **15.4 Span<T> and ReadOnlySpan<T>** (page 991), including **15.4.1 Extracting a Memory Segment Without Creating an Object or Making a Copy**.

The `Statistik` class in `Zeichenstatistik.cs` accepts its data as ranges so that strings, arrays, and slices of them all work equally well, and does not generate any substrings in the process.

1. `ZaehleVokale(ReadOnlySpan<char>)`: counts `a`, `e`, `i`, `o`, `u`, `ä`, `ö`, `ü`—both uppercase and lowercase.
2. `ErstesWort(ReadOnlySpan<char>)`: Returns the first word as **a substring** of the input text (skipping leading spaces). The test verifies that the return span points to the same memory location.
3. `Teilsumme(ReadOnlySpan<int>, int von, int bis)`: Sum of the values from index `von` (inclusive) to `bis` (exclusive). Invalid bounds throw a `ArgumentOutOfRangeException`.

The following tests must be passed:

- `StatistikTests.ZaehleVokale_in_String_Array_und_Ausschnitt`
- `StatistikTests.ErstesWort_liefert_den_Ausschnitt`
- `StatistikTests.ErstesWort_kopiert_nichts`
- `StatistikTests.Teilsumme_ueber_Array_und_Ausschnitt`
- `StatistikTests.Teilsumme_lehnt_ungueltige_Grenzen_ab`
