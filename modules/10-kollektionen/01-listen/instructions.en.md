# Manage Lists

Read section **11.4.1**, "**List<T> Class with Array Underlying Structure"** (page 697), and also section 11.1 (page 691) for the difference between lists and arrays.

Open `Listenwerkzeuge.cs` and implement the five methods. The signatures remain unchanged.

1. `RemoveEvens` removes all even numbers from the list itself. The tests use lists containing several even numbers in a row: A `foreach` loop with `Remove()` terminates prematurely, while a forward loop skips elements.
2. `InsertSorted` inserts a value into an ascendingly sorted list in such a way that the list remains sorted.
3. `MoveToFront` creates an entry at index 0. If it does not exist, it is inserted; it must never appear twice.
4. `Top3` returns a **new** list containing the three largest values, with the largest value first. The argument remains unchanged.
5. `Rotate` returns a new array that is rotated `k` positions to the left. Use a `List<int>` as a working array and return it using `ToArray()`.

Then answer the question about the `foreach` loop with `Remove()`.

The tests are named, among others, `RemoveEvens_entfernt_auch_aufeinanderfolgende_gerade_Zahlen`, `InsertSorted_haelt_die_Liste_aufsteigend`, `MoveToFront_verschiebt_vorhandenen_Eintrag_ohne_Duplikat`, `Top3_veraendert_das_Argument_nicht`, and `Rotate_dreht_nach_links_und_laesst_das_Original_unveraendert`.
