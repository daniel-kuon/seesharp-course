# Query Syntax with `let`, `into`, and `join`

Read **18.3 Query Syntax** (pages 1235–1244) in the book and take a look at the samples under `LINQ-to-Objects/Abfragesyntax/{Einstieg, let, into, Join}`.

The project contains two classes. `Methodensyntax` (in `Methodensyntax.cs`) is complete and covered by tests; it shows the same queries in method syntax. In `Abfragesyntax` (in `Abfragesyntax.cs`), you rewrite each query **in query syntax**; the result must be the same:

1. `TeuerQ(produkte, grenze)`: `from ... where ... orderby ... select`; the names of the products above the threshold, in alphabetical order.
2. `MitMehrwertsteuerQ(produkte)`: with `let brutto = p.Preis * 1.19m`, which is used in `where` and `select`; `(Name, Brutto)` for all products with a gross price over 20.
3. `GroessteKategorienQ(produkte)`: `group p by p.Kategorie into g`, then `where g.Count() > 1` (follow-up query with `into`); `(Kategorie, Anzahl)`, largest count first; in case of a tie, sort by category.
4. `KundenMitBestellungQ(kunden, bestellungen)`: `join ... on ... equals ...`; `(Name, Betrag)` per order.
5. `KundenSummenQ(kunden, bestellungen)`: `join ... on ... equals ... into bs` (group join); `(Name, Summe)` for each customer, even if there are no orders (total 0).

An expression in query syntax is usually enclosed in parentheses so that you can append `.ToList()`.

Tests: `Methodensyntax_Teuer`, `Methodensyntax_MitMehrwertsteuer`, `Methodensyntax_GroessteKategorien`, `Methodensyntax_Kunden`, `TeuerQ_wie_Methodensyntax`, `MitMehrwertsteuerQ_wie_Methodensyntax`, `GroessteKategorienQ_wie_Methodensyntax`, `KundenMitBestellungQ_wie_Methodensyntax`, `KundenSummenQ_enthaelt_auch_Kunden_ohne_Bestellung`.
