# Extra: Analyzing Orders (SQL)

Read section **19.6.4**, **"SELECT Queries**" (page 1302), paying particular attention to `JOIN`, `GROUP BY`, and the aggregate functions. The tests create a schema with three tables and populate it:

- `Kunde(Id, Name)`
- `Bestellung(Id, KundeId, Datum)`
- `Position(Id, BestellungId, Produkt, Menge, Preis)`

Open `Auswertungen.cs` and write the queries (SQL texts in the constants; the schema is in the comment):

1. **`UmsatzProKunde`**: columns `Kunde` (name) and `Umsatz` (sum of `Menge * Preis` over all items of all the customer's orders), only customers with orders, highest revenue first.
2. **`Top3Produkte`**: columns `Produkt` and `Menge` (total quantity ordered) of the three most ordered products; for equal quantities by product name. In SQLite, `LIMIT 3` at the end of the query limits the number of rows (not in the book, given here; SQL Server writes `SELECT TOP 3 ...`).

Tests: `UmsatzProKunde_summiert_Menge_mal_Preis_und_sortiert_absteigend`, `Top3Produkte_liefert_die_drei_meistbestellten_Produkte`.

> **Deep Dive (optional):** `LEFT JOIN` is not in the book. Unlike the `INNER JOIN` from 19.6.4.3, a `LEFT JOIN` keeps every row of the left table; where nothing matches on the right, the right table's columns are NULL. Use it to write **`KundenOhneBestellung`**: column `Name` of the customers who never ordered, sorted by name (`LEFT JOIN` on `Bestellung`, then `WHERE ... IS NULL`). The tests `KundenOhneBestellung_findet_Carl_und_Dora` and `KundenOhneBestellung_aendert_sich_mit_neuen_Bestellungen` are extra; the exercise is passed without them.
