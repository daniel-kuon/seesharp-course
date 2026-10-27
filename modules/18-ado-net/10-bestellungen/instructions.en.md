# Extra: Analyzing Orders (SQL)

Read section **19.6.4**, **"SELECT Queries**" (page 1302), paying particular attention to `JOIN`, `GROUP BY`, and the aggregate functions. The tests create a schema with three tables and populate it:

- `Kunde(Id, Name)`
- `Bestellung(Id, KundeId, Datum)`
- `Position(Id, BestellungId, Produkt, Menge, Preis)`

Open `Auswertungen.cs` and write three queries (SQL statements in the constants; the schema is included in the comment):

1. **`UmsatzProKunde`** (Revenue per Customer): Columns `Kunde` (Name) and `Umsatz` (Total of `Menge * Preis` across all items in all of the customer's orders), only customers with orders, sorted by highest revenue first.
2. **`KundenOhneBestellung`** (Customers Without Orders): Column `Name` listing customers who have never placed an order, sorted by name. Tip: Use a `LEFT JOIN` with `Bestellung`, followed by `WHERE ... IS NULL`. Unlike the `INNER JOIN` from 19.6.4.3, a `LEFT JOIN` keeps every row of the left table; where nothing matches on the right, the right table's columns are NULL.
3. **`Top3Produkte`**: List the `Produkt` and `Menge` (total quantity ordered) for the three most frequently ordered products; if the quantity is the same, sort by product name. SQLite uses `LIMIT 3` instead of `TOP 3`.

Tests: `UmsatzProKunde_summiert_Menge_mal_Preis_und_sortiert_absteigend`, `KundenOhneBestellung_findet_Carl_und_Dora`, `KundenOhneBestellung_aendert_sich_mit_neuen_Bestellungen`, `Top3Produkte_liefert_die_drei_meistbestellten_Produkte`.
