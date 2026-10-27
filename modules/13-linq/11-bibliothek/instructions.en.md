# Extra: Library Information

Read **18.2.10 Linking Two Sequences** (page 1224) in the book and review `Join` and `GroupJoin` from Exercise 13/05. `OrderBy` with `StringComparer.Ordinal` as a second argument is known from Exercise 13/04 (not in the book).

The records `Autor(Id, Name)`, `Buch(Id, Titel, AutorId)`, and `Ausleihe(BuchId, Leser)` are predefined. `Auskunft` receives the three sequences in its constructor; write the following in `Auskunft.cs`:

1. `BuecherMitAutor()`: `(Titel, Autor)` for every book whose author is known, sorted by title (`Join`, `Select`, `StringComparer.Ordinal`).
2. `Ausleihen(leser)`: Titles of the books the reader has checked out, sorted by title (`Join` of loans and books, `Where`).
3. `NieAusgeliehen()`: Titles of books that have never been checked out, sorted by title (`GroupJoin`; the group of checkouts is empty).

Tests: `BuecherMitAutor_laesst_Buecher_ohne_bekannten_Autor_weg`, `Ausleihen_eines_Lesers`, `NieAusgeliehen_findet_Buecher_ohne_Ausleihe`, `Ohne_Ausleihen_sind_alle_Buecher_nie_ausgeliehen`.
