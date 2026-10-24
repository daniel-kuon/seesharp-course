# Where, Select, and Chaining

Read **Example 18.2.1** (page 1211), **18.2.3 Fluent API** (page 1213), and **18.2.6.1 Where()** (page 1217) in the book.

LINQ consists of extension methods on `IEnumerable<T>`; the lambda expressions provide the conditions and transformations. Open `Abfragen.cs` (the `Produkt` record and the `Euro` helper method are already provided):

1. `Guenstige(produkte, max)`: all products with a `Preis <= max` (`Where`).
2. `Namen(produkte)`: the names (`Select`).
3. `Etiketten(produkte)`: a list of tuples `(Name, Preis)`, where the price is a text string in `Euro`, e.g., `"12,50 EUR"` (`Select` with tuples, `ToList()`).
4. `VorraetigeGuenstige(produkte, max)`: Names of products with `Lager > 0` and `Preis <= max`; two `Where` clauses and one `Select` clause in succession.
5. `Preisliste(produkte)`: `Dictionary<string, decimal>` Name -> Price (`ToDictionary`).
6. `Schnappschuss(produkte)`: an array containing the products (`ToArray`).

The source list must never be altered. Then answer the two questions about types.

Tests: `Guenstige_filtert_nach_Preis`, `Namen_liefert_alle_Namen_in_Reihenfolge`, `Etiketten_formatieren_den_Preis`, `VorraetigeGuenstige_verkettet_Where_und_Select`, `Preisliste_ist_ein_Woerterbuch`, `Schnappschuss_ist_ein_Array_und_entkoppelt_von_der_Quelle`, `Die_Quellliste_bleibt_unveraendert`.
