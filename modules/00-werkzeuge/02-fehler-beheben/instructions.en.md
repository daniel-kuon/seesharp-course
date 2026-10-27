# Fixing Compiler Errors

Read Section **3.1.6, "Program Errors"** (page 76), in the book to learn about syntax and logic errors.

The `Reparatur` project won't build. There are **four errors** in `Hallo.cs`. Build the project in Rider (`Ctrl+F5` or Build > Build Solution), read the error list from top to bottom, and fix one error at a time. Pay attention to the line, column, and error code (`CS…`); rebuild after each correction, because some errors only appear once the previous ones have been fixed.

In the end, the program should print `Moin, SeeSharp!` and the function `Gruss()` should return this text. Change only what is necessary; the text itself remains the same.

The following tests must be passed:

- `ReparaturTests.Gruss_liefert_Moin_SeeSharp`
