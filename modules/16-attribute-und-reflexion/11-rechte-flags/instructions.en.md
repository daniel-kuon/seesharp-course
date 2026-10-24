# Extra: Permissions with Flags

Extra exercise: optional; it unlocks nothing. For further reading: **14.5.4 Bit Fields Using FlagsAttribute** (page 937) and the section on enumeration types (6.4) in the book.

A user can have multiple roles at the same time. Instead of four `bool` properties, a single bit field is sufficient: each role is represented by a bit, and a combination is the OR operation.

1. `Rolle.cs`: Turn the enumeration with `[Flags]` into a bit field. The values (1, 2, 4, 8) are already powers of two; without `[Flags]`, `Rolle.Leser | Rolle.Autor` would be output as `3`.
2. `Benutzer.cs`: Implement
   - `Vergib(rolle)`: Set bits (`|=`),
   - `Entziehe(rolle)`: Clear bits (`&= ~`),
   - `Darf(benoetigt)`: Are **all** the required bits set?
   - `Beschreibung()`: the roles as text, e.g., `"Leser, Autor"`,
   - `Parse(text)`: the alternative approach using `Enum.Parse<Rolle>`, case-insensitive; an unknown name throws an `ArgumentException`.

The following tests must be passed:

- `RechteFlagsTests.Rolle_ist_ein_Bitfeld`
- `RechteFlagsTests.Neuer_Benutzer_hat_keine_Rolle`
- `RechteFlagsTests.Vergib_fuegt_Rollen_hinzu_und_behaelt_die_vorhandenen`
- `RechteFlagsTests.Entziehe_nimmt_nur_die_genannten_Rollen_weg`
- `RechteFlagsTests.Darf_verlangt_alle_benoetigten_Rollen`
- `RechteFlagsTests.Beschreibung_zaehlt_die_Rollen_auf`
- `RechteFlagsTests.Parse_liest_einzelne_und_kombinierte_Rollen`
- `RechteFlagsTests.Parse_wirft_bei_unbekanntem_Namen`
- `RechteFlagsTests.Beschreibung_und_Parse_sind_umkehrbar_fuer_alle_16_Kombinationen`
