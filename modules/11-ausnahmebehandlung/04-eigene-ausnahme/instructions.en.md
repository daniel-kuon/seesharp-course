# Custom exception class with additional information

Read Section **13.7, “Defining Exceptions”** (page 916), which includes the examples of `BadFaculArgException` and the variant using the `Data` collection, as well as **Section 13.5** (page 911) on the `InnerException` and `Data` properties.

The factorial is not defined for negative numbers, and starting at 21, the result no longer fits into a `long`. A caller should be able to detect both conditions and be notified of the invalid argument.

1. Open `FakultaetArgumentException.cs`. The class should inherit from `ArgumentException` and have an `Argument` property holding the invalid value. The constructor `(int argument)` sets the message to `"Fakultät nicht definiert für <argument>"`. The constructor `(int argument, Exception innerException)` sets the message to `"Fakultät von <argument> ist zu groß"` and passes the inner exception to the base class.
2. In `Mathe.cs`, the `Fakultaet(int n)` method is already defined (with `checked`). Add the following: For `n < 0`, it throws the new exception. If the calculation triggers an `OverflowException`, it is caught and passed as an `InnerException` in a `FakultaetArgumentException`.
3. `FakultaetMitData(int n)` solves the problem without creating its own class: For `n < 0` and `n > 20`, it throws a standard `ArgumentException` (specifically this class) and stores the argument under the key `"Argument"` in `ex.Data`.

Tests: `Eigene_Ausnahme_erbt_von_ArgumentException`, `Konstruktor_mit_Argument_setzt_Eigenschaft_und_Standardmeldung`, `Konstruktor_mit_innerer_Ausnahme_behaelt_sie`, `Fakultaet_wirft_fuer_negative_Zahlen_die_eigene_Ausnahme`, `Fakultaet_verpackt_den_Ueberlauf_als_InnerException`, `Wer_ArgumentException_faengt_faengt_auch_die_eigene_Ausnahme`, and `FakultaetMitData_wirft_eine_gewoehnliche_ArgumentException_mit_Data`.
