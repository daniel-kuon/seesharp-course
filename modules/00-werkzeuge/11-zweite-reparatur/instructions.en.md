# Extra: Second Repair

Extra exercise: optional; it blocks nothing. Go through the error list one more time, this time with different error codes and an error that the compiler doesn't detect at all.

Read section **3.1.6**, "**Program Errors"** (page 76): The compiler reports syntax errors, but not logical errors.

The `Abschied` project cannot be built. The `Abschied.cs` file contains **four compiler errors** and **one logic error**. Build the project, read the error list from top to bottom, and for each error, note down the code (`CS…`) and what it means before you fix it. Rebuild after each correction.

Once the project builds, the following must hold:

- `Text()` returns `Tschüss, SeeSharp!`
- `Unterschrift()` returns `Bis morgen!` (with an exclamation point; only the test detects this error)
- `Main()` prints both lines.

Change only what is necessary.

The following tests must be passed:

- `AbschiedTests.Text_liefert_Tschuess_SeeSharp`
- `AbschiedTests.Unterschrift_liefert_Bis_morgen`
