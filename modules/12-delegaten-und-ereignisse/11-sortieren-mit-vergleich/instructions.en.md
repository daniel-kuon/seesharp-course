# Extra: Sorting with a Comparison Lambda

Read **10.3 Exercises for Chapter 10** (page 688) in the book and review the `Sort`, `FindAll`, and `RemoveAll` methods using lambdas from Exercise 12/03. `RemoveAll`, `ForEach` and `string.CompareOrdinal` are not in the book; Exercise 12/03 describes them.

A `Person` is a record (`Name`, `Alter`). In `Sortierer.cs`:

1. `NachAlter(liste)`: Sorts the list itself in ascending order by age (expression lambda for `Comparison<Person>`).
2. `NachNameDannAlter(liste)`: first by name (`string.CompareOrdinal`), then by age if the names are equal.
3. `AelterAls(liste, grenze)`: a new list containing all people whose age is **greater** than `grenze` (`FindAll`).
4. `EntferneMinderjaehrige(liste)`: Removes everyone under 18 from the list itself using `RemoveAll`; returns the number removed.
5. `Juengste(liste)`: the youngest person (in the event of a tie, the first person on the list) or `null` if the list is empty. Use `ForEach` with a lambda that includes **a statement block** and stores the current minimum in a local variable.

Tests: `NachAlter_sortiert_aufsteigend`, `NachNameDannAlter_bricht_Gleichstand_nach_Alter`, `AelterAls_ist_strikt_groesser`, `EntferneMinderjaehrige_veraendert_die_Liste`, `Juengste_nimmt_bei_Gleichstand_die_erste`, `Juengste_einer_leeren_Liste_ist_null`, `Juengste_bei_einer_Person`.
