# Declare, create, and call delegates

Read **10.1.1 Defining Delegate Types** (page 659) and **10.1.2 Creating and Calling Delegate Objects** (page 660) in the book.

A delegate type describes a method signature; a delegate object refers to a matching method (and, in the case of an instance method, to its target object). Open `Operation.cs` and `Rechner.cs`:

1. `Operation.cs` contains the declaration `public delegate double Operation(double a, double b);` Read it carefully, along with the description in the comment.
2. `Rechner`: Implement the static methods `Addiere`, `Subtrahiere`, `Multipliziere`, and `Dividiere` and the instance method `Potenz` that match the delegate type. `Potenz` calculates `(a + b)` to the power of `Exponent`. `Dividiere` uses ordinary `double` arithmetic: dividing by 0 yields infinity, not an exception.
3. `Anwenden(op, a, b)` calls the delegate; `Reduziere(op, werte)` reduces a non-empty array from left to right using `op` to produce a single value (empty array: `ArgumentException`).
4. `Waehle(zeichen)` returns the appropriate delegate for `+ - * /` (using a switch expression with method groups); otherwise, it returns `null`. `PotenzDelegat()` returns a delegate to the instance method `Potenz` of this object.
5. Next, complete the review task (second delegate type: `Bedingung`).

Tests: `Anwenden_ruft_statische_Methoden`, `Dividiere_durch_null_liefert_Unendlich`, `Reduziere_faltet_von_links`, `Reduziere_leeres_Array_wirft`, `Waehle_liefert_den_passenden_Delegaten`, `Waehle_unbekanntes_Zeichen_liefert_null`, `Instanzdelegat_behaelt_sein_Zielobjekt`, `Zwei_Rechner_zwei_Ziele`.
