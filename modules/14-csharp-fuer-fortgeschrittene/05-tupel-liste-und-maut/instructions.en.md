# Tuple and List Patterns; Toll Calculator

Read sections **15.2.6 "Tuple Patterns**" (page 980) and **15.2.10 "List Patterns**" (page 985), along with **15.2.10.1 "Exclusion and Range Patterns**." The toll calculator is the concluding example for pattern matching: It combines tuple, type, attribute, relational, and logical patterns with the `when` keyword.

Open `Spiele.cs` and `MautRechner.cs`. The types are defined in `Modell.cs`.

1. `SchereSteinPapier.Sieger(a, b)`: **A** `switch` expression over the tuple `(a, b)`. The three winning pairs take first place; `(var x, var y) when x == y` indicates a tie; the rest take second place.
2. `Lauf.Langstrecke(minuten, maenner)`: Tuple patterns with relational patterns in the positions and `or` between the tuple patterns for men and women (limits specified in the `TODO` comments). Zero or fewer minutes throws a `ArgumentOutOfRangeException`, as the branch of the `switch`.
3. `Listen.Beschreibe(int[])`: List patterns `[]`, `[var x]`, `[1, .., 9]`, `[_, _]`, and `[_, _, .. var rest]`; the order is specified in the comment.
4. `MautRechner`: `Band` divides the day using relational patterns. `FahrzeugZuschlag` distinguishes `Auto`, `Taxi`, `Bus`, and `Lieferwagen` with type and property patterns, using `when` for `Bus`. `ZeitZuschlag` is a tuple pattern over weekday, time band, and direction. `Berechne` adds the base fee and both surcharges.

The following tests must be passed:

- `TupelListeMautTests.Sieger_in_allen_neun_Faellen`
- `TupelListeMautTests.Langstrecke_unterscheidet_Geschlecht_und_Zeit`
- `TupelListeMautTests.Langstrecke_lehnt_unsinnige_Zeiten_ab`
- `TupelListeMautTests.Listenmuster_Beschreibe`
- `TupelListeMautTests.Band_teilt_den_Tag_ein`
- `TupelListeMautTests.FahrzeugZuschlag_fuer_Auto_und_Taxi`
- `TupelListeMautTests.FahrzeugZuschlag_fuer_Bus_und_Lieferwagen`
- `TupelListeMautTests.FahrzeugZuschlag_Fehlerfaelle`
- `TupelListeMautTests.ZeitZuschlag_Tabelle_mit_zwoelf_Faellen`
- `TupelListeMautTests.Berechne_addiert_Grundgebuehr_Fahrzeug_und_Zeit`
