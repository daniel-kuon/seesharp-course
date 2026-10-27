# Manage Lists

Read **11.4.1 The List<T> Class with an Underlying Array** (page 697) in the book, and also 11.1 (page 691) for the difference from arrays.

Open `Listenwerkzeuge.cs` and implement the five methods. The signatures stay unchanged.

1. `RemoveEvens` removes all even numbers from the list itself. The tests use lists with several even numbers in a row: a `foreach` with `Remove()` fails, and a forward loop skips elements.
2. `InsertSorted` inserts a value into an ascending sorted list so that it stays sorted.
3. `MoveToFront` moves an entry to index 0. If it is missing, it is inserted; it must never appear twice.
4. `Top3` returns a **new** list with the three largest values, largest first; with fewer than three values, all of them are returned. The argument stays unchanged.
5. `Rotate` returns a new array rotated `k` positions to the left; the argument stays unchanged. `k` may be larger than the length, and an empty array stays empty. Use a `List<int>` as your working tool and return it with `ToArray()`.

Then answer the question about `foreach` with `Remove()`.

The tests include `RemoveEvens_entfernt_auch_aufeinanderfolgende_gerade_Zahlen`, `InsertSorted_haelt_die_Liste_aufsteigend`, `MoveToFront_verschiebt_vorhandenen_Eintrag_ohne_Duplikat`, `Top3_veraendert_das_Argument_nicht` and `Rotate_dreht_nach_links_und_laesst_das_Original_unveraendert`.
