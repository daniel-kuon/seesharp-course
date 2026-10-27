# Data Types and Conversions

Read sections **4.3.4, "Elementary Data Types**" (page 186), and **4.5.7, "Type Conversion**" (page 229), in the book; for integer division, see section **4.5.1** (page 216).

Open `Typen.cs` and complete the five static methods:

1. `ZeichenCode(char c)` returns the Unicode code of the character as an `int` (implicit conversion; no cast required).
2. `Verschiebe(char c, int um)` returns the character located `um` positions after `c` (`'a'` plus 1 is `'b'`). A cast is required here.
3. `Abschneiden(double d)` returns the integer part via casting; `2.7` becomes `2`, `-2.7` becomes `-2` (no rounding).
4. `Mittelwert(int a, int b)` returns the average as a `double`; be aware of integer division—`Mittelwert(1, 2)` must equal `1.5`.
5. `Rest(int a, int b)` returns the remainder of an integer division.

`Program.cs` calls the methods so you can try them out.

The following tests must be passed:

- `TypenTests.ZeichenCode_von_A_ist_65`
- `TypenTests.Verschiebe_a_um_1_ist_b`
- `TypenTests.Abschneiden_rundet_nicht`
- `TypenTests.Abschneiden_negativ_geht_Richtung_null`
- `TypenTests.Mittelwert_von_1_und_2_ist_1_5`
- `TypenTests.Rest_von_17_durch_5_ist_2`
