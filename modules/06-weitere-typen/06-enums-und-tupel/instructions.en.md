# Enumerations and Tuples

Read sections **6.4, “Enumeration Types”** (page 480), and **6.6, “Tuples”** (page 486), in the book—especially 6.6.4 (Deconstruction, page 491), 6.6.5 (Tuples as Return Types, page 493), and 6.6.6 (Deconstruction of Custom Types, page 494).

Open `Temperament.cs`. The `Temperament` enum is declared; the `Person` class uses it for the `Temp` property.

1. `Temp`'s setter should only accept defined values: `(Temperament)13` is a valid cast, but not a valid value; `Enum.IsDefined(value)` checks this. Invalid values are ignored.
2. `Person.Deconstruct(out vn, out nn)` returns the first name and last name so that `var (vn, nn) = person;` works.
3. `Analyse.Wert(t)` returns the integer behind the value (a cast is sufficient).
4. `Analyse.AnalyzeName("Otto Rentner")` splits the string at the first space (`IndexOf`, `Substring`) and returns a **named tuple** `(First, Last, FirstPalin, LastPalin)`; the palindrome check is a local method that compares from both ends, ignoring case (`"Otto"` is a palindrome).

> **Deep Dive (optional):** `Analyse.ParseTemperament(text)` converts the name of a value into the enum value without regard to case and throws an `ArgumentException` if the text is unknown. The book does not show the way from the name to the value; the BCL offers `Enum.TryParse(text, true, out Temperament t)`, which returns `true` and the value in `t`. Note: `TryParse` also accepts numbers such as `"7"`; additionally check the result using `Enum.IsDefined`. Conversely, `ToString()` returns the name of an enum value. The test `EnumsTupelTests.ParseTemperament_ignoriert_die_Schreibweise` belongs to this part and is an extra; the other five tests count towards passing.
