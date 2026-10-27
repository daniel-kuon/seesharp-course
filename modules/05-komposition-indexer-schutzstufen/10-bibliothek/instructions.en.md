# Extra exercise: A library with indexers

This exercise is optional. It reviews indexers, nested classes, and `ToString` using a new example. For further reading: **5.12 Indexers** (page 393) and **5.11 Nested Classes** (page 391).

The `Bibliothek` stores its books in a linked list, similar to the `PersList` from the Indexer exercise. The node is a private nested class; from the outside, you can only see `Buch` objects.

1. `Buch.ToString()` returns `"Der Process (Kafka, 1925)"`.
2. `Bibliothek.Add(buch)` adds a node and increments `Anzahl`.
3. The `this[int i]` indexer returns the book at position `i` and throws an `ArgumentOutOfRangeException` if the index is invalid. It is read-only.
4. The overloaded indexer `this[string titel]` returns the first book with exactly that title, or `null` if there isn't one (return type `Buch?`).
5. `Ausleihen(titel)` and `Zurueckgeben(titel)` change `Ausgeliehen` and return `true` if successful. If the book is missing, already checked out, or not checked out at all, they return `false`. Use the `string` indexer.
6. A calculated property is `Verfuegbar`: It counts the number of books that are not checked out each time it is read.
7. `VonAutor(autor)` returns the author's titles in the order they were entered, separated by `", "`, that is `"Der Process, Das Schloss"`. If no matches are found, it returns `""`.

Tip: You can easily iterate through a list using `for (Knoten? k = erster; k != null; k = k.Next)`.

The following tests must be passed:

- `BibliothekTests.ToString_zeigt_Titel_Autor_und_Jahr`
- `BibliothekTests.Add_erhoeht_Anzahl`
- `BibliothekTests.Int_Indexer_liefert_Buecher_in_Einfuegereihenfolge`
- `BibliothekTests.Int_Indexer_wirft_bei_ungueltigem_Index`
- `BibliothekTests.String_Indexer_findet_das_Buch_oder_liefert_null`
- `BibliothekTests.Ausleihen_nur_einmal`
- `BibliothekTests.Zurueckgeben_nur_wenn_ausgeliehen`
- `BibliothekTests.Verfuegbar_zaehlt_nicht_ausgeliehene_Buecher`
- `BibliothekTests.VonAutor_listet_Titel_mit_Komma`
