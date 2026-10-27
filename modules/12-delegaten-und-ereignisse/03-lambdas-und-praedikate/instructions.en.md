# Lambda Expressions and Predicates

Read **Section 10.1.5.2, “Lambda Expressions”** (page 667), and Exercise **10.3, Problem 2** (page 688) in the book regarding `Predicate<T>` and `FindAll`.

The `FindAll`, `Exists`, `Find`, `RemoveAll`, `Sort`, and `ForEach` methods of `List<T>` expect delegates; lambda expressions provide them in place. Open `Filter.cs`:

1. `LangeWoerter`: Words with more than 5 characters (`FindAll`, expression lambda).
2. `OhneLeere`: Use `RemoveAll` to remove entries that are `null`, empty, or consist only of whitespace from the list itself; Return value: Number of entries removed.
3. `Existiert`: Is the value in the list (`Exists`)?
4. `ErstesMit`: the first word that begins with the character (`Find`); otherwise, `null`. The list may contain empty words.
5. `SortiereNachLaenge`: Sorts the list using `Sort` and a **lambda expression with a statement block**: first by length, and if the lengths are the same, using `string.CompareOrdinal`.
6. `Summe`: adds up all values with `ForEach` and a local variable that the lambda modifies.

Then answer the questions about the types of lambda delegates.

Tests: `LangeWoerter_filtert_nach_Laenge`, `LangeWoerter_aendert_die_Quelle_nicht`, `OhneLeere_entfernt_in_der_Liste_selbst`, `OhneLeere_ohne_Treffer`, `Existiert_findet_Werte`, `ErstesMit_findet_das_erste_Wort`, `ErstesMit_ohne_Treffer_ist_null`, `Sortiere_nach_Laenge_dann_alphabetisch`, `Summe_addiert_alle_Werte`.
