# Extra exercise: Time using overloading and operators

This exercise is optional. It practices method overloading and operator overloading on a class that has nothing to do with fractions. For further reading: **5.3.5 Overloading Methods** (page 334) and **5.9.3 Overloading Operators** (page 385).

The `Uhrzeit` class stores only **one** private field: the number of minutes since midnight, always between 0 and 1439. The hour and minute are calculated from this value. This ensures that the state can never become invalid.

Open `Uhrzeit.cs` and complete it:

1. `Normiere(m)`: normalizes any number of minutes to the range 0 to 1439. Note: In C#, `-1 % 1440` equals `-1`; a negative remainder requires an additional `1440`.
2. Both constructors normalize the values: `new Uhrzeit(25, 70)` is 02:10, `new Uhrzeit(-1, 0)` is 23:00, and `new Uhrzeit(1500)` is 01:00.
3. `Stunde` and `Minute` calculate their values from the field (integer division and remainder).
4. Two overloads of the `Addiere` function: one with minutes and one with hours and minutes. The second one calls the first.
5. `Text()` returns `"07:05"`. Tip: `$"{Stunde:D2}"` pads with zeros (not in the book, given here).
6. The `operator +(Uhrzeit, int)` returns a **new** time; the original remains unchanged.
7. The `operator -(Uhrzeit a, Uhrzeit b)` operator returns the number of minutes that elapse from `b` to `a`, counted forward: from 10:45 p.m. to 1:15 a.m., it is 150.

The following tests must be passed:

- `UhrzeitTests.Konstruktor_mit_gueltigen_Werten`
- `UhrzeitTests.Konstruktor_normiert_Ueberlauf`
- `UhrzeitTests.Konstruktor_normiert_negative_Werte`
- `UhrzeitTests.Konstruktor_aus_Minuten_seit_Mitternacht`
- `UhrzeitTests.Text_mit_fuehrenden_Nullen`
- `UhrzeitTests.Addiere_Minuten_ueber_Mitternacht`
- `UhrzeitTests.Addiere_negative_Minuten`
- `UhrzeitTests.Addiere_Stunden_und_Minuten`
- `UhrzeitTests.Plus_liefert_neues_Objekt_und_laesst_das_Original_in_Ruhe`
- `UhrzeitTests.Minus_liefert_Minuten_vorwaerts_auch_ueber_Mitternacht`
