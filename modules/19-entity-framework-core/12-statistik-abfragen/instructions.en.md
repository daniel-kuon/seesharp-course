# Extra: Sales Statistics

Reread **Section 20.9.4**, "**Statistical Analysis Methods (Aggregate Operators)**" (page 1454). The `Verkauf` (`Id`, `Produkt`, `Menge`, `Preis`, `Datum`), `VerkaufContext`, and the `record ProduktUmsatz(Produkt, Umsatz)` are given. The **database** should perform all calculations, not your C# code.

1. `GesamtUmsatz()`: sum of `Menge * Preis` over all sales (`Sum`); `0` if there are no sales.
2. `ProProduktAbfrage(kontext)`: Revenue per product, highest first: `GroupBy`, `OrderByDescending` by total, then `Select` on `ProduktUmsatz` with `Sum`. Returns the `IQueryable` that has not yet been executed; the test uses `ToQueryString()` to verify that `SUM`, `GROUP BY`, and `ORDER BY` are included in the SQL. `ProProdukt()` executes it (provided).
3. `TopProdukte(n)`: the `n` products with the highest sales (`Take` on the sorted query).

Tests: `GesamtUmsatz_summiert_Menge_mal_Preis`, `GesamtUmsatz_ohne_Verkaeufe_ist_null`, `ProProdukt_gruppiert_summiert_und_sortiert_absteigend`, `ProProduktAbfrage_wird_vom_Server_berechnet`, `TopProdukte_liefert_die_umsatzstaerksten`.
