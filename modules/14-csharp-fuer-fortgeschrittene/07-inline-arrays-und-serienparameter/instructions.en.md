# Inline Arrays and Series Parameters with Collection Types

Read sections **15.5 "Inline Array**" (page 1005) and **15.6 "Sequence Parameters with Collection Type**" (page 1008), along with subsections **15.6.1** and **15.6.2** (Overloads for All Cases, page 1010).

Open `Puffer.cs` and `Serie.cs`.

1. `Puffer8` is a structure with an `int` array. Use the `[InlineArray(8)]` attribute to turn it into an inline array for eight `int` values (32 bytes, directly within the structure, not an array object). It can then be indexed like an array (`p[i]`) and assigned to a `Span<int>`.
2. `Puffer8Werkzeuge.Fuelle(ref Puffer8, int start)` writes `start`, `start + 1`, ... into the eight slots. `Summe(in Puffer8)` sums over a span (`ReadOnlySpan<int> s = p;`). `Lies(in Puffer8, int)` reads via the indexer.
3. `Serie` still has two overloads each: a `params` array and a variant for existing collections. Since C# 13, `params` can also take a collection type. Replace the overloads with **one** method each: `Summe(params ReadOnlySpan<int>)`, `Verbinde(params IEnumerable<string>)` (join the parts with `-`), and `Zaehle<T>(params List<T>)`. Then calls with none, one, and many arguments work, as do calls with an existing array or list and with a collection expression (`Summe([1, 2, 3])`). Solve the bodies first, then the signatures: The tests check both.

The following tests must be passed:

- `InlineUndParamsTests.Puffer8_ist_ein_Inline_Array_mit_32_Byte`
- `InlineUndParamsTests.Fuelle_schreibt_aufsteigende_Werte`
- `InlineUndParamsTests.Summe_addiert_alle_acht_Werte`
- `InlineUndParamsTests.Puffer8_hat_Wertsemantik`
- `InlineUndParamsTests.Lies_ausserhalb_wirft`
- `InlineUndParamsTests.Summe_mit_null_einem_und_vielen_Argumenten`
- `InlineUndParamsTests.Summe_mit_Array_und_Kollektionsausdruck`
- `InlineUndParamsTests.Verbinde_mit_allen_Aufrufformen`
- `InlineUndParamsTests.Zaehle_mit_allen_Aufrufformen`
- `InlineUndParamsTests.Serienparameter_haben_Kollektionstypen`
