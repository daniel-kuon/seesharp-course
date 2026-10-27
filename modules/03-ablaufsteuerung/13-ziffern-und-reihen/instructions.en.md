# Extra: Numbers and Sequences with Loops

Extra exercise: optional; it blocks nothing. In Level 2, you broke down three-digit numbers using `/` and `%`; with a loop, you can do this for numbers of any length.

Read **sections 4.7.3.1, "Counter-Controlled Loops (for)**" (page 271), and **4.7.3.3**, "**Conditional Loops**" (page 275), in the book.

Open `Zahlenreihen.cs`:

1. `Einmaleins(int zahl)` returns the multiplication table for `zahl` times 1 through `zahl` times 10, separated by spaces: `Einmaleins(7)` returns `7 14 21 28 35 42 49 56 63 70` (`for` loop).
2. `Quersumme(long n)` returns the sum of the digits of any number starting from 0: `Quersumme(9045)` is 18. As long as there are still digits remaining: add the last digit, then truncate (`while` loop).
3. `Umgedreht(long n)` reverses the digits: `1234` becomes `4321`, and `1230` becomes `321`.
4. `IstPalindrom(long n)` returns `true` if the number is the same forward and backward (`12321`). Use `Umgedreht()`.
5. `Potenz(int basis, int exponent)` calculates `basis` to the power of `exponent` for `exponent >= 0` by repeated multiplication, without using `Math.Pow`. The result is a `long`; `Potenz(2, 40)` no longer fits into an `int`.

The following tests must be passed:

- `ZahlenreihenTests.Einmaleins_von_7`
- `ZahlenreihenTests.Einmaleins_von_1`
- `ZahlenreihenTests.Quersumme_beliebig_langer_Zahlen`
- `ZahlenreihenTests.Umgedreht_beliebig_langer_Zahlen`
- `ZahlenreihenTests.Palindrome`
- `ZahlenreihenTests.Keine_Palindrome`
- `ZahlenreihenTests.Potenzen`
- `ZahlenreihenTests.Potenz_groesser_als_int`
