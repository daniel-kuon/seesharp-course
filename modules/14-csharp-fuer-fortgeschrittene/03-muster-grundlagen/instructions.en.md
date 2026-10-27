# Patterns: Constant, Type, Relational, Logical

Read in the book **15.2.1 Constant patterns** (page 973), **15.2.3 Type and declaration patterns** (page 975), **15.2.8 Relational patterns** (page 983), and **15.2.9 Combinators and logical patterns** (page 984). Exercise 2 in 15.7 (page 1012) also sorts ages into categories by pattern matching, but with different boundaries.

Open `Muster.cs`. Write each method as **a** `switch` expression or `is` expression, without using `if`:

1. `Alterskategorie(int alter)`: 0 to 12 `Kind`, 13 to 17 `Jugendlicher`, 18 to 64 `Erwachsener`, 65 to 150 `Senior`, negative values and anything over 150 `Ungueltig`. Use relational patterns (`< 13`) and `or`. The order of the arms matters: The first match wins.
2. `Beschreibe(object? o)`: `null` returns `"null"`; an `int` returns `"Ganzzahl 5"`; a `string` returns `"Text mit 4 Zeichen"`; a `double`, `float`, or `decimal` returns `"Dezimalzahl"`; everything else returns `"unbekannt"`. A declaration pattern (`int i`) immediately assigns the value to a variable.
3. `IstIdentifierZeichen(char c)`: `a` through `z`, `A` through `Z`, and `_`, in an `is` expression with `>=`, `<=`, `and`, and `or`.
4. `IstPositiv(int? x)`: `x is not null and > 0`.

The following tests must be passed:

- `MusterTests.Alterskategorie_an_den_Grenzen`
- `MusterTests.Beschreibe_erkennt_null_und_Ganzzahlen`
- `MusterTests.Beschreibe_erkennt_Text`
- `MusterTests.Beschreibe_erkennt_Dezimalzahlen`
- `MusterTests.Beschreibe_kennt_den_Rest_nicht`
- `MusterTests.IstIdentifierZeichen_prueft_die_Bereiche`
- `MusterTests.IstPositiv_behandelt_null_und_Grenzwerte`
