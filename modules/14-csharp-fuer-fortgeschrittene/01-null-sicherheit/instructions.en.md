# Nullable Context and Null State Analysis

Read in the book **15.1.1 Explicit null (non-)admissibility** (page 949), **15.1.2 Null-state analysis** (page 953), and **15.1.4 Attributes supporting null-state analysis** (page 962).

The project contains `<Nullable>enable</Nullable>` and, in addition, `<WarningsAsErrors>nullable</WarningsAsErrors>`: Any unresolved null-state analysis warning breaks the build (15.1.3.3, page 961; the book lists the individual warning numbers there, `nullable` stands for all null warnings). `Reverse` is the method from exercise 1 in 15.7 (page 1012). This is why the starter project does not compile yet; do not modify the `.csproj` file—instead, fix the issues in the code. Open `PalindromReverse.cs` and `Kunde.cs`:

1. `PalindromReverse.Reverse`: The parameter may be `null`; in that case, the result is `null`. Otherwise, the result is the reversed text. Implement this using `string?` and `[return: NotNullIfNotNull(nameof(s))]` so that `string r = Reverse("abc");` compiles without a warning.
2. `PalindromReverse.TryFinde`: Returns `true` and the first entry that begins with `prefix` (`StringComparison.Ordinal`); otherwise, it returns `false` and `null`. The `out` parameter is of type `string?` with `[NotNullWhen(true)]`.
3. `PalindromReverse.ErstesVorhandenes`: The build fails at `First`. Resolve the warning by using a loop **or** by adding exactly one `!`, along with a comment explaining why the value cannot be `null` here. Having more than one `!` in the project is a sign that something is modeled incorrectly.
4. `Kunde`: `Name` is never `null` and is set in the constructor, `Spitzname` may be missing. `Anzeige()` returns `"Name (Spitzname)"` or just `"Name"`.

The following tests must be passed:

- `NullsicherheitTests.Reverse_kehrt_um`
- `NullsicherheitTests.Reverse_null_liefert_null`
- `NullsicherheitTests.Reverse_Parameter_ist_als_nullable_markiert`
- `NullsicherheitTests.Reverse_hat_NotNullIfNotNull`
- `NullsicherheitTests.TryFinde_findet_den_ersten_Treffer`
- `NullsicherheitTests.TryFinde_ohne_Treffer_liefert_false_und_null`
- `NullsicherheitTests.TryFinde_hat_NotNullWhen_true`
- `NullsicherheitTests.ErstesVorhandenes_ueberspringt_null`
- `NullsicherheitTests.ErstesVorhandenes_wirft_wenn_alles_null_ist`
- `NullsicherheitTests.Kunde_Name_ist_nicht_nullable_Spitzname_schon`
- `NullsicherheitTests.Anzeige_mit_Spitzname`
- `NullsicherheitTests.Anzeige_ohne_Spitzname`
