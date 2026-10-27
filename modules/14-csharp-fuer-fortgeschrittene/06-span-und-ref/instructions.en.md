# Span<T>, ReadOnlySpan<T>, and ref returns

Read in the book **15.3 Methods with ref variables and ref return values** (page 988) and **15.4 Span<T> and ReadOnlySpan<T>** (page 991) with **15.4.1 Extracting a memory segment without object creation and copying** and **15.4.3 Premium language support for the span types since C# 14** (page 994).

Open `Spans.cs`; `Messpunkt.cs` is a deliberately large struct (four `double` values). The signatures are given; you write the bodies:

1. `Summe(ReadOnlySpan<int>)` sums without copying. The test calls it with an array, a slice (`a.AsSpan(2, 3)`), and a `stackalloc` buffer: one parameter type, many sources. (`stackalloc` into a `Span<T>` does not need an `unsafe` context, even though the book suggests otherwise in 15.5.)
2. `ZaehleWoerter(ReadOnlySpan<char>)` counts words separated by spaces (several consecutive spaces do not count twice). Take the text apart with slices (`TrimStart`, `IndexOf`, `text[ende..]`), not with `Split` or `Substring`. `text.TrimStart()` on spans is not in the book, given here: it returns the slice without leading spaces, without copying anything.
3. `SpiegleInPlace(Span<int>)` reverses the elements. If a slice is passed, only that part of the underlying array changes.
4. `Hoechster(int[])` returns a **reference** to the largest element (`ref int`; if the maximum occurs more than once, to the first one): `Hoechster(a) = 0;` sets it to 0 in the array. A local `ref` variable (`ref int m = ref a[0];`) keeps track of the location.
5. `Hellster(Messpunkt[])` returns a `ref readonly` reference to the measurement point with the highest brightness (the first one on a tie), without copying the struct.
6. `SpanErweiterungen`: The `extension` block (C# 14) makes `IstPalindrom()` a member of `ReadOnlySpan<char>`. Case matters (`"Anna"` is not one), and the empty text is a palindrome. Because strings and `char` arrays convert implicitly to spans, the test calls it on `"anna"` and on a `char[]`.

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
