# Extra: Safe Input Handling

Extra exercise: optional; it unlocks nothing. For further reading: **15.1.5 null operators** (page 968) and **15.1.2 Null-state analysis** (page 953).

Real-world input is often `null`, empty, or incomplete. The three methods in `Eingaben.cs` only work with clean data. Make them robust without a single `!`; the project has `<WarningsAsErrors>nullable</WarningsAsErrors>`, so any unresolved null warning will break the build.

1. `Bereinige(string? s)`: Removes leading and trailing whitespace; if nothing remains (or if `s` is `null`), the result is `"(leer)"`.
2. `ErstesWort(string? s)`: the first word (separated by spaces; ignore empty parts); `""` if `null`, empty text, or only spaces.
3. `Alter(Dictionary<string, string>? daten)`: the `"alter"` entry as a number; `0` if there is no dictionary, no entry, or no number.

The following tests must be passed:

- `EingabenTests.Parameter_sind_als_nullable_markiert`
- `EingabenTests.Bereinige_trimmt_und_ersetzt_Leeres`
- `EingabenTests.Bereinige_null_ist_leer`
- `EingabenTests.ErstesWort_findet_das_erste_Wort`
- `EingabenTests.ErstesWort_null_ist_leer`
- `EingabenTests.Alter_liest_den_Eintrag`
- `EingabenTests.Alter_hat_den_Vorgabewert_null`
