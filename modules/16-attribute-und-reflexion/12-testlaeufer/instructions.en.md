# Extra: A Mini Test Runner

Extra exercise: optional; it unlocks nothing. For further reading: **14.2 Evaluating Attributes via Reflection** (page 924) and the `PersistenceHelper` example in **14.7.1** (page 942).

The testing tool that SeeSharp uses to check your tasks works essentially the same way as the one you're building here: It uses reflection to find all methods with a specific attribute, calls them, and collects the results. The attribute `[MeinTest]` is predefined; `Beispiel.cs` contains a test class you can use to try it out.

`Laeufer.Starte(Type t)` executes all tests in class `t`:

1. **One** instance of `t` is created (`Activator.CreateInstance`), and all tests run on it.
2. Tests are the public instance methods without parameters that carry `[MeinTest]`. All other methods are ignored.
3. They run in the order of their names (using `StringComparer.Ordinal`).
4. If a method throws an exception, the test fails and the remaining tests continue to run. `MethodInfo.Invoke` wraps the exception in a `TargetInvocationException`: Catch it.
5. The result is a list consisting of `(Name, Bestanden)`; without any tests, the list is empty.

The following tests must be passed:

- `TestlaeuferTests.Liefert_pro_Test_Name_und_Ergebnis_nach_Namen_sortiert`
- `TestlaeuferTests.Nur_oeffentliche_parameterlose_Instanzmethoden_mit_Attribut_zaehlen`
- `TestlaeuferTests.Alle_Tests_laufen_auf_derselben_Instanz_in_Namensreihenfolge`
- `TestlaeuferTests.Eine_Ausnahme_bricht_die_uebrigen_Tests_nicht_ab`
- `TestlaeuferTests.Eine_Klasse_ohne_Tests_ergibt_eine_leere_Liste`
