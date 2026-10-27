# Queries with LINQ to Entities

Read the section in the book titled **“20.9 Queries,”** starting with **20.9.2 “Retrieving Multiple Entities”** (page 1452) through **20.9.6**, for information on server-side and client-side evaluation. You’re familiar with LINQ for in-memory collections; for a `DbSet<T>`, EF Core translates the same expression into **SQL**, which the database then executes. The query runs only when `ToList()`, `Count()`, `FirstOrDefault()`, and similar methods are called.

The context `BeitragContext`, which contains the entity `Beitrag` (`Id`, `Titel`, `Inhalt`, `Datum`), is predefined. Open `BlogAbfragen.cs`:

1. `MitTitel(teil)`: Posts whose titles contain `teil` (`Where` and `Contains`), by ID.
2. `Neueste(n)`: the `n` latest posts, newest first (`OrderByDescending`, `Take`).
3. `Finde(id)` using `Find`; `ErsterMit(teil)` using `FirstOrDefault` (smallest ID, `null` if there is no match).
4. `TitellisteAbfrage(kontext)`: uses `Select` to project onto the title and returns an `IQueryable<string>` that has not yet been executed; the test uses `ToQueryString()` to examine the SQL and requires that only the `Titel` column be retrieved, not the `Inhalt`.
5. `StatistikAbfrage(kontext)`: Number and average length of the content in **a server-side** query: `GroupBy(b => 1)` groups all rows into a single group (not in the book, given here); `Select` calculates `Count()` and `Average()`. The test requires `COUNT` and `AVG` in SQL. `Statistik()` returns the result; for an empty table, it returns `(0, 0)`.
6. `ClientAuswertung()`—the same result, but intentionally **on the client side**: first `AsEnumerable()` (all posts, including their content, are loaded), then C# performs the calculation. This is the contrast described in section 20.9.6 of the book.

Then answer the quiz question.

Tests: `MitTitel_filtert_mit_Where_und_Contains`, `Neueste_liefert_die_n_neuesten_Beitraege_absteigend`, `Finde_liefert_den_Beitrag_oder_null`, `ErsterMit_liefert_den_ersten_Treffer_oder_null`, `Titelliste_liefert_alle_Titel_nach_Id`, `TitellisteAbfrage_waehlt_nur_die_Spalte_Titel_aus`, `Statistik_berechnet_Anzahl_und_Durchschnitt`, `StatistikAbfrage_rechnet_auf_dem_Server_mit_COUNT_und_AVG`, `Statistik_einer_leeren_Tabelle_ist_null_null`, `ClientAuswertung_liefert_dasselbe_Ergebnis_wie_die_Serverabfrage`.
