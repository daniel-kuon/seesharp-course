# Log2 with ArgumentOutOfRangeException

Read section **13.6, “Throwing Exceptions,”** in the book (page 913), along with sections **13.1** and **13.2** (pages 886 and 888) on error prevention and unhandled exceptions, and then exercise **13.8**, **No. 3** (page 920).

The `Dualog.Log2` method currently returns `NaN` or `-Infinity` for invalid arguments. Such special values pass through the program unnoticed and only reveal the error several steps later. Open `Dualog.cs`:

1. `Log2(double x)` throws an `ArgumentOutOfRangeException` for `x <= 0`. The parameter name is `"x"`; the message is a custom German message (constructor with `paramName`, `actualValue`, and `message`). Valid arguments yield the logarithm: `Log2(1) = 0`, `Log2(8) = 3`.
2. `Wurzel(double x)` throws the same exception for negative `x`.
3. `Fakultaet(int n)` throws an exception for `n < 0` (parameter name `"n"`) and otherwise returns `n!` as a `long`. Valid values for `n` range from 0 to 20; for larger numbers, the result no longer fits into a `long`, which is not part of the tests.

Then answer the two questions. For the first one, you'll need this stack monitoring:

## Question About Batch Monitoring

```text
Unbehandelte Ausnahme: System.ArgumentOutOfRangeException: Der duale Logarithmus ist nur für Zahlen größer als 0 definiert. (Parameter 'x')
Der tatsächliche Wert war -1.
   bei Dualog.Log2(Double x) in C:\Kurs\Rechner\Dualog.cs:Zeile 9.
   bei Messung.Dezibel(Double verhaeltnis) in C:\Kurs\Rechner\Messung.cs:Zeile 14.
   bei Programm.Main() in C:\Kurs\Rechner\Programm.cs:Zeile 6.
```

Tests: `Log2_wirft_fuer_Argumente_kleiner_gleich_null`, `Log2_hat_eine_eigene_Meldung`, `Wurzel_wirft_fuer_negative_Zahlen`, `Fakultaet_wirft_fuer_negative_n`, and the tests for valid values (`Log2_liefert_den_Logarithmus_gueltiger_Argumente`, `Fakultaet_liefert_n_Fakultaet`).
