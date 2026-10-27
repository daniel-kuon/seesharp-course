# Return code, exception, or try pattern

Read section **13.4**, **“Exception Objects Compared to Error Communication via Return Values**” (page 905), especially **13.4.4** (page 910) on choosing based on error probability, and **13.5, “Exception Classes in the BCL”** (page 911). Exercise **13.8**, **No. 1** (page 920) is the open-ended question at the end.

The file `Bruch.cs`, which contains an immutable fraction class (`Bruch`), is provided (a denominator of 0 triggers an `ArgumentException` there). Open `BruchParser.cs` and implement the same task in several ways:

1. `Parse(string s)` converts `"3/4"` into a `Bruch`. An invalid format (`"3/"`, `"a/b"`, `""`, no slash or more than one) throws a `FormatException`; a denominator of 0 (`"1/0"`) throws an `ArgumentException` (which comes from the `Bruch` constructor); and numbers outside the `int` range throw an `OverflowException` (which comes from `int.Parse`).
2. `TryParse(string? s, out Bruch? ergebnis)` is the **Try pattern**: It returns `true` and the result, or `false` and `null`. It does not throw an exception for **any** input, not even for `null`, numbers that are too large, or `"1/0"`. The tests try many invalid inputs.
3. `TeileRc(a, b, out ergebnis)` returns a **status code**: `0` for success, `1` for division by zero (in which case `ergebnis` is 0). `Teile(a, b)` simply performs the calculation and throws a `DivideByZeroException` when `b == 0`.
4. `ParseAlleMitAusnahmen(string[])` and `ParseAlleMitTry(string[])` count valid and invalid inputs—the first using `Parse` and `try`/`catch`, the second using `TryParse`. Both must return the same result. You can see which of the two keeps the code clearer and which generates many exception objects when there are many errors. Time is not measured.

Then answer the following questions: Which technique applies to each of the five scenarios, which BCL exception applies to each of the five situations, and the open-ended question about the `try` syntax diagram.

Tests: `Parse_wirft_FormatException_bei_ungueltigem_Format`, `Parse_wirft_ArgumentException_bei_Nenner_null`, `TryParse_liefert_false_und_wirft_nie`, `TeileRc_meldet_Division_durch_null_mit_1`, `Teile_liefert_das_Ergebnis_und_wirft_bei_null`, and `ParseAlle_zaehlt_gueltige_und_ungueltige_Eingaben`.
