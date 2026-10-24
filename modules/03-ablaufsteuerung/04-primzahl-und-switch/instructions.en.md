# Prime Number Test, switch Expression, foreach

Read sections **4.7.3.1 "Counter-Controlled Loop (for)"** (page 271) and **4.7.3.2 "foreach"** (page 273) in the book, **4.7.3.6 “Terminating Loops Early”** (page 278, which includes the prime number program) and the section on the switch expression in **4.7.2** (page 253 ff.). The template is Exercise 3 in **4.7.4** (page 282).

Open `Schleifen.cs`:

1. `IstPrim(long n)` returns `true` if `n` is a prime number. Numbers below 2 are not prime. Check divisors from 2 up to the square root of `n` in a `for` loop **without `break` and without `continue`**: build the termination condition into the loop header (for example, with a `bool` variable).
2. `Wochentag(int tag)` returns `"Montag"` for 1 through `"Sonntag"` for 7 using a `switch` expression, and `"ungültig"` otherwise.
3. `AnzahlVokale(string text)` uses a `foreach` loop to count the vowels a, e, i, o, u (case-insensitive).

The following tests must be passed:

- `SchleifenTests.Primzahlen_werden_erkannt`
- `SchleifenTests.Nicht_Primzahlen_werden_abgelehnt`
- `SchleifenTests.Wochentag_1_ist_Montag`
- `SchleifenTests.Wochentag_7_ist_Sonntag`
- `SchleifenTests.Wochentag_ausserhalb_ist_ungueltig`
- `SchleifenTests.Vokale_werden_gezaehlt`
- `SchleifenTests.Vokale_ohne_Treffer`
