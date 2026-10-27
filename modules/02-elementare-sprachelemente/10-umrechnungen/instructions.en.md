# Extra: Conversions

Extra exercise: optional; it blocks nothing. Calculations with `double` and `decimal`, constants, and rounding — and two pitfalls that catch everyone out at least once in practice.

Read sections **4.3.9 "Constants"** (page 200) and **4.3.4 "Elementary Data Types**" (page 186) in the book regarding `decimal`, as well as Exercise 6 in **section 4.5.11** (page 242): In that section, a program converts German marks (DM) and pfennigs to euros and cents. The official exchange rate is 1 euro = 1.95583 DM.

Open `Umrechner.cs`:

1. `CelsiusInFahrenheit(double celsius)` calculates `celsius * 9 / 5 + 32`. Note: `9 / 5` alone is an integer division.
2. `FahrenheitInCelsius(double fahrenheit)` calculates `(fahrenheit - 32) * 5 / 9`.
3. In the class, declare a public constant named `DmProEuro` of type `decimal` with the value 1.95583 (suffix `m`) and use it in both DM methods.
4. `EuroInDm(decimal euro)` returns the amount in DM, commercially rounded to two decimal places: `Math.Round(wert, 2, MidpointRounding.AwayFromZero)` (not in the book, given here).
5. `DmInEuro(int dm, int pfennig)` converts an amount in marks and pfennigs (100 pfennigs = 1 DM) to euros, rounded to the nearest cent. 0 DM and 99 pfennigs equal 0.51 euros, not 0.
6. `Kassenbon(decimal betrag)` returns the text `12 Euro und 34 Cent` for `12.34m`. You get the euros by casting to `int`, and the cents with `* 100` and `%`. The amount is never negative and has at most two decimal places.

The following tests must be passed:

- `UmrechnerTests.Koerpertemperatur_in_Fahrenheit`
- `UmrechnerTests.Gefrierpunkt_und_Siedepunkt`
- `UmrechnerTests.Minus_40_Grad_sind_gleich`
- `UmrechnerTests.Kurs_ist_eine_decimal_Konstante`
- `UmrechnerTests.Euro_in_DM`
- `UmrechnerTests.Mark_und_Pfennig_in_Euro`
- `UmrechnerTests.Pfennige_gehen_nicht_verloren`
- `UmrechnerTests.Kassenbon_trennt_Euro_und_Cent`
