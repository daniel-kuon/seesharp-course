# Property, Positional, and var Patterns

Read sections **15.2.4 "Feature Patterns**" (page 976), **15.2.5 "var Patterns**" (page 978), and **15.2.7 "Position or Deconstruction Patterns"** (page 981) in the book. Exercise 3 in Section 15.7 (page 1012) is `Zugelassen`.

Open `Muster.cs`. The records are defined in `Modell.cs`; for each record, the compiler also generates `Deconstruct`, which the position pattern needs.

1. `Zugelassen(PKW? p)`: A car is registered with at least three passengers **or** as an electric car. A feature pattern combined with `or`; returns `false` for `null`.
2. `Gebuehr(Fahrzeug f, int jahr)`: A `switch` expression with nested attribute patterns. In this order: Owners from Germany **with** electric vehicles pay 0; owners from Germany with vehicles over 20 years old (`jahr - Baujahr > 20`, as of `when`) pay 40; owners from Germany pay 20; all others, including those without an owner, pay 50. The extended attribute pattern `{ Halter.Land: "DE" }` eliminates the need for nested parentheses.
3. `Quadrant(Punkt p)`: Position patterns on the record: `(0, 0)` is the `"Ursprung"`, followed by `"I"` through `"IV"` with relational patterns, on an axis `"Achse"`.
4. `Beschreibe(Punkt p)`: Use `(var x, var y) when x == y` to capture the coordinates and check them: `"Diagonale 3"`, otherwise `"(2|5)"`.
5. `AufYAchse(Punkt? p)`: `p is { X: 0 }`.

The following tests must be passed:

- `MusterTests.Zugelassen_bei_drei_Passagieren_oder_Elektro`
- `MusterTests.Zugelassen_null_ist_false`
- `MusterTests.Gebuehr_Elektro_aus_Deutschland_ist_frei`
- `MusterTests.Gebuehr_Deutschland_kostet_20_und_ab_ueber_20_Jahren_40`
- `MusterTests.Gebuehr_andere_Laender_und_fehlender_Halter_kosten_50`
- `MusterTests.Quadrant_nach_Positionsmuster`
- `MusterTests.Beschreibe_erkennt_die_Diagonale_mit_var_Muster`
- `MusterTests.AufYAchse_behandelt_null`
