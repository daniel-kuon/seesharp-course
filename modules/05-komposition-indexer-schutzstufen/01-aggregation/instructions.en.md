# Aggregation: an `Aufgabe` Owns Its Fractions

Read Section **5.10**, **“Aggregation and Composition”** (page 388), in the book.

Until now, `Bruch` stood alone. Now a second class, `Aufgabe`, is added, which owns three `Bruch` objects as fields: the two arguments `b1` and `b2` and the solution `lsg`. An `Aufgabe` does not calculate by itself, but asks its `Bruch` objects to do so.

Open `Bruch.cs` and `Aufgabe.cs` and complete the following:

1. `Bruch.Multipliziere(Bruch b)`: Multiply the numerator by the numerator and the denominator by the denominator, then simplify (the counterpart to `Addiere`).
2. The constructor of `Aufgabe` creates `b1` and `b2` with the labels `"1. Argument:"` and `"2. Argument:"`, creates `lsg` with the values of `b1` and the label `"Resultat"`, and calls `Init()`.
3. `Init()` performs calculations with `lsg` and `b2`: if `Op == '+'`, use `Addiere`; if `'*'`, use `Multipliziere`.
4. `Pruefe(zaehler, nenner)` converts the answer into a fraction, simplifies it, and compares the numerator and denominator with `lsg`. `2/4` is therefore a correct answer to `1/2`.
5. `NeueWerte(...)` only changes the values of the existing fractions (no `new`) and calls `Init()` again. The test checks `Bruch.Anzahl` before and after.

`Bruchrechnung.cs` contains a small console program you can try out.
