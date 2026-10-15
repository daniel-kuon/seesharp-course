# Constructors

Read section **5.4.3 Einsatzvorbereitung** (page 340) in the book, in particular
5.4.3.1.1 Standardkonstruktor (default constructor) and 5.4.3.1.2 Explizite
Konstruktoren (explicit constructors).

Open `Bruch.cs` and complete the class `Bruch` (fraction):

1. The constructor `Bruch(int zpar, int npar, string epar)` sets the numerator,
   the denominator and the label. Assign through the **properties**, not the
   fields, so the validation in the setters applies (a denominator of 0 is
   ignored, the label is cut to 40 characters).
2. `Kuerze()` reduces the fraction using the greatest common divisor (Euclid,
   modulo variant). A fraction with numerator 0 becomes 0/1.
3. `Addiere(Bruch b)` adds `b` to this fraction and reduces it afterwards.
4. `Addiere(int zpar, int npar, bool autokurz)` adds `zpar/npar`. When
   `npar == 0` nothing happens and the method returns `false`; otherwise it
   returns `true`, and with `autokurz` the result is reduced.

`Bruchrechnung.cs` contains a `Main` for trying things out; the tests only check
`Bruch`.
