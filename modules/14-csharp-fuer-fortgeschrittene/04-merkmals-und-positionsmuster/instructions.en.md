# Property, Positional, and var Patterns

Read in the book **15.2.4 Property patterns** (page 976), **15.2.5 var patterns** (page 978), and **15.2.7 Positional or deconstruction patterns** (page 981). Exercise 3 in 15.7 (page 1012) is `Zugelassen`.

Open `Muster.cs`. The records are defined in `Modell.cs`; because they have positional properties (`record Punkt(int X, int Y)`), the compiler also generates `Deconstruct`, which positional patterns need.

1. `Zugelassen(PKW? p)`: A car is admitted with at least three passengers **or** as an electric car. One property pattern combined with `or`; `null` yields `false`.
2. `Gebuehr(Fahrzeug f, int jahr)`: A `switch` expression with nested property patterns. In this order: owner from Germany **and** electric costs 0; owner from Germany and vehicle older than 20 years (`jahr - Baujahr > 20`, via `when`) costs 40; owner from Germany costs 20; everything else, including no owner, costs 50. The extended property pattern `{ Halter.Land: "DE" }` saves the nested braces.
3. `Quadrant(Punkt p)`: Positional patterns on the record: `(0, 0)` is `"Ursprung"`, then `"I"` to `"IV"` with relational patterns, and `"Achse"` on an axis.
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
