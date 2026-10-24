# Span<T>, ReadOnlySpan<T>, and ref returns

See sections **15.3 "Methods with ref Variables and ref Return Values**" (page 988) and **15.4 "Span<T> and ReadOnlySpan<T>"** (page 991), including **15.4.1 “Extracting a Memory Segment Without Object Creation or Copying”** and **15.4.3 “Premium Language Support for Span Types Since C# 14”** (page 994).

Open `Spans.cs`; `Messpunkt.cs` is a deliberately large structure (four `double` values). The signatures are provided; you write the bodies:

1. `Summe(ReadOnlySpan<int>)` performs summation without copying. The test calls it with an array, a slice (`a.AsSpan(2, 3)`), and a `stackalloc` buffer: one parameter type, many sources.
2. `ZaehleWoerter(ReadOnlySpan<char>)` counts words separated by spaces (multiple consecutive spaces are not counted twice). Split the text using substrings (`TrimStart`, `IndexOf`, `text[ende..]`), not with `Split` or `Substring`.
3. `SpiegleInPlace(Span<int>)` reverses the elements. If a range is specified, only that portion of the array is modified.
4. `Hoechster(int[])` returns a **reference** to the largest element (`ref int`): `Hoechster(a) = 0;` sets it to 0 in the array. You can use a local `ref` variable (`ref int m = ref a[0];`) to keep track of the location.
5. `Hellster(Messpunkt[])` returns a `ref readonly` reference to the measurement point with the highest brightness, without copying the structure.
6. `SpanErweiterungen`: The `extension` block (C# 14) makes `IstPalindrom()` a member of `ReadOnlySpan<char>`. Because strings and `char` arrays are implicitly converted to Spans, the test calls it on `"anna"` and on a `char[]`.

The following tests must be passed:

- `SpanUndRefTests.Summe_nimmt_Spans_entgegen`
- `SpanUndRefTests.Summe_ueber_Array_Ausschnitt_und_stackalloc`
- `SpanUndRefTests.ZaehleWoerter_zaehlt_Woerter`
- `SpanUndRefTests.ZaehleWoerter_arbeitet_auch_auf_einem_Ausschnitt`
- `SpanUndRefTests.SpiegleInPlace_aendert_das_Array`
- `SpanUndRefTests.SpiegleInPlace_wirkt_nur_auf_den_Ausschnitt`
- `SpanUndRefTests.Hoechster_gibt_einen_Verweis_zurueck`
- `SpanUndRefTests.Hoechster_kann_zugewiesen_werden`
- `SpanUndRefTests.Hellster_liefert_einen_schreibgeschuetzten_Verweis`
- `SpanUndRefTests.IstPalindrom_auf_String_und_Array`
