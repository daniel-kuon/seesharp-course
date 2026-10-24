# Extra: Reading Numbers

Read **section 13.3.1.2**, "**Exception Handling Using a catch Block**" (page 891), again.

Open `Einleser.cs`. The `LeseErgebnis` class, with the `Werte` and `Fehler` lists, is already defined.

1. `LiesZahlen(text)` splits a text such as `"10;abc;99999999999;20"` into parts based on semicolons (empty parts are skipped) and converts each part using `int.Parse`. Valid numbers are stored in `Werte`. For each part that fails, there is an entry in `Fehler`:
   - `FormatException`: `"abc: keine Zahl"`
   - `OverflowException`: `"99999999999: zu groß"`

   A faulty part doesn't stop the others: The `try` belongs inside the loop.
2. `Mittelwert(ergebnis)` returns the average of the valid numbers or `double.NaN` if there are none.

Tests: `LiesZahlen_meldet_Teile_die_keine_Zahl_sind`, `LiesZahlen_meldet_zu_grosse_Zahlen`, `LiesZahlen_mit_gemischter_Eingabe`, and `Mittelwert_ohne_gueltige_Zahl_ist_NaN`.
