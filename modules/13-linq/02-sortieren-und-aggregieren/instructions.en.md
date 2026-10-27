# Sorting, Aggregates, and Subsequences

Read **18.2.7 Sorting** (page 1218) and **18.2.11 Additional LINQ Operators** (page 1228; `Chunk` on page 1234) in the book.

You already know the record `Produkt` from the previous exercise. Open `Statistik.cs`; all methods take an `IEnumerable<Produkt>` and leave the source unchanged:

1. `Teuerste(produkte, n)`: the `n` most expensive products, most expensive first; equal prices keep the source order (`OrderByDescending`, `Take`).
2. `NachKategorieDannPreis(produkte)`: by category in ascending order, then by price in descending order within each category (`OrderBy`, `ThenByDescending`).
3. `Seite(produkte, seite, groesse)`: a page of the list in the given order; page numbering starts at 0 (`Skip`, `Take`).
4. `Preisspanne(produkte)`: `(min, max, mittel)` of the prices (`Min`, `Max`, `Average`); if the sequence **is empty** `(0, 0, 0)` (otherwise `Average` throws an exception).
5. `Lagerwert(produkte)`: Sum of `Preis * Lager` (`Sum`).
6. `AnzahlTeurerAls(produkte, grenze)`: Number of products with a `Preis > grenze` (`Count` with a condition).
7. `Pakete(produkte, n)`: the products grouped into sets of at most `n` (`Chunk`).
8. `BisZumErstenLeeren(produkte)`: the products from the beginning, as long as `Lager > 0` (`TakeWhile`).

Tests: `Teuerste_sortiert_absteigend_und_behaelt_bei_Gleichstand_die_Quellreihenfolge`, `NachKategorieDannPreis_sortiert_zweistufig`, `Seite_liefert_die_gewuenschte_Seite`, `Preisspanne_liefert_Minimum_Maximum_und_Mittel`, `Preisspanne_einer_leeren_Quelle_ist_null`, `Lagerwert_summiert_Preis_mal_Lager`, `AnzahlTeurerAls_zaehlt_strikt_groesser`, `Pakete_teilt_in_Gruppen`, `BisZumErstenLeeren_endet_beim_ersten_Produkt_ohne_Lager`, `Die_Quelle_bleibt_unveraendert`.
