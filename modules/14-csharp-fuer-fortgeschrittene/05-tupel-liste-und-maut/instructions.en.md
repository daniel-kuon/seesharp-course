# Tuple and List Patterns; Toll Calculator

Read in the book **15.2.6 Tuple patterns** (page 980) and **15.2.10 List patterns** (page 985) with **15.2.10.1 Discard and slice patterns**. The toll calculator is the closing example for pattern matching: it combines tuple, type, property, relational, and logical patterns with `when`.

Open `Spiele.cs` and `MautRechner.cs`. The types are defined in `Modell.cs`.

1. `SchereSteinPapier.Sieger(a, b)`: **One** `switch` expression over the tuple `(a, b)`. The three pairs in which the first player wins, `(var x, var y) when x == y` for a draw, and everything else is a win for the second player.
2. `Lauf.Langstrecke(minuten, maenner)`: Tuple patterns with relational patterns in the positions and `or` between the tuple patterns for men and women (limits in the `TODO` comments). Zero or fewer minutes throws `ArgumentOutOfRangeException`, as an arm of the `switch`.
3. `Listen.Beschreibe(int[])`: List patterns `[]`, `[var x]`, `[1, .., 9]`, `[_, _]`, and `[_, _, .. var rest]`; the order is specified in the comment.
4. `MautRechner`: `Band` divides the day using relational patterns. `FahrzeugZuschlag` distinguishes `Auto`, `Taxi`, `Bus`, and `Lieferwagen` with type and property patterns, using `when` for `Bus` (amounts in the `TODO` comments). `null` throws `ArgumentNullException`; any other vehicle type or invalid data (an `Auto` or `Taxi` with a negative number of people) throws `ArgumentException`. `ZeitZuschlag` is a tuple pattern over weekday, time band, and direction. `Berechne` adds the base fee and both surcharges.

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
