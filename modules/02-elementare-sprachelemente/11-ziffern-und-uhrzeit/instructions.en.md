# Extra: Numbers and Time

Extra exercise: optional; it blocks nothing. Using `/` and `%`, you can break numbers down into their parts—without using any loops. Loops are introduced in Level 3, where there's a continuation of this exercise for numbers of any length.

Read section **4.5.1**, "**Arithmetic Operators**" (page 216), on integer division and modulo, and section **4.2.3, "Formatted Output**" (page 176), on the `d` format specifier with precision (`{x:d2}` outputs at least two digits, i.e., `07`; what the precision does with `d` is not in the book, given here).

Open `Ziffern.cs`:

1. `Quersumme(int n)` returns the sum of the digits of a number from 0 to 999. `Quersumme(472)` is `13`. Tip: `n % 10` is the last digit; `n / 10` truncates it.
2. `Umgedreht(int n)` reverses a three-digit number: `472` becomes `274`, and `120` becomes `21`.
3. `IstGerade(int n)` returns `true` for even numbers, including negative ones.
4. `Uhrzeit(int sekunden)` converts the number of seconds since midnight (0 to 86399) into the text `hh:mm:ss`: `3725` becomes `01:02:05`.

The following tests must be passed:

- `ZiffernTests.Quersumme_dreistellig`
- `ZiffernTests.Quersumme_kleiner_Zahlen`
- `ZiffernTests.Umgedreht_dreistellig`
- `ZiffernTests.Umgedreht_mit_Null_am_Ende`
- `ZiffernTests.Gerade_und_ungerade`
- `ZiffernTests.Uhrzeit_mit_fuehrenden_Nullen`
- `ZiffernTests.Uhrzeit_Grenzen`
