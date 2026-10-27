# SQL Basics with SQLite

Read **19.6 SQL** in the book, starting on page 1296 (especially 19.6.2 through 19.6.4). The book uses SQL Server, but we work with **SQLite**: no server, the database lives in memory. The commands are almost the same. The differences you will meet here (not in the book, given here):

| SQL Server (book) | SQLite |
|---|---|
| `INT IDENTITY(1,1)` as primary key | `INTEGER PRIMARY KEY` (counts up automatically) |
| Column types `NVARCHAR(50)`, `MONEY`, `DECIMAL` | `TEXT`, `REAL`, `INTEGER` |

Instead of `CONSTRAINT name FOREIGN KEY (column) REFERENCES ...` from 19.6.2.1 you may also write the constraints right after the column, for example `KategorieId INTEGER REFERENCES Kategorie (Id)` or `Preis REAL CHECK (Preis >= 0)`.

Open `Skripte.cs`. The static class `Skripte` contains SQL texts; you fill them in. The tests run them against a fresh database (with foreign keys enabled) and compare the results.

1. **`Schema`**: two tables.
   - `Kategorie(Id, Name)`: `Id` is the primary key; `Name` is text and never NULL (`NOT NULL`).
   - `Artikel(Id, Name, Preis, KategorieId)`: `Id` is the primary key, `Name` is text and never NULL, `Preis` is a floating-point number with `CHECK (Preis >= 0)`, and `KategorieId` is a foreign key that references `Kategorie(Id)`.
2. **`Daten`**: insert these rows using `INSERT` (the IDs are given):

   | Kategorie | Id | | Artikel | Id | Preis | KategorieId |
   |---|---:|---|---|---:|---:|---:|
   | Werkzeug | 1 | | Hammer | 1 | 12.50 | 1 |
   | Garten | 2 | | Zange | 2 | 9.90 | 1 |
   | Buero | 3 | | Saege | 3 | 18.00 | 1 |
   | Reserve | 4 | | Spaten | 4 | 24.90 | 2 |
   | | | | Harke | 5 | 11.00 | 2 |
   | | | | Giesskanne | 6 | 7.50 | 2 |
   | | | | Handschuhe | 7 | 5.90 | 2 |
   | | | | Locher | 8 | 4.20 | 3 |

3. **`TeureArtikel`**: columns `Name` and `Preis` of all items priced over 10, most expensive first.
4. **`ArtikelMitKategorie`**: columns `Kategorie` (category name) and `Name` (item name) via `JOIN`, sorted by category, then by item name.
5. **`AnzahlProKategorie`**: columns `Kategorie` and `Anzahl` (number of items) with `JOIN` and `GROUP BY`; sorted by `Anzahl` descending, then by `Kategorie`. Categories without items do not appear.
6. **`Preiserhoehung`**: an `UPDATE` that raises the prices of all items in the category `Garten` (Id 2) by 10%.

Then answer the quiz question.

Tests: `Schema_legt_beide_Tabellen_an`, `Schema_deklariert_Primaerschluessel_und_Fremdschluessel`, `Schema_weist_Artikel_mit_unbekannter_Kategorie_ab`, `Schema_weist_negative_Preise_ab`, `Schema_verlangt_Namen`, `Daten_fuegt_Kategorien_und_Artikel_ein`, `TeureArtikel_liefert_Artikel_ueber_10_absteigend`, `ArtikelMitKategorie_verknuepft_und_sortiert`, `AnzahlProKategorie_gruppiert_und_zaehlt`, `Preiserhoehung_erhoeht_nur_die_Kategorie_Garten`.

> **Deep Dive (optional):** These SQL parts are not in the book. The exercise is passed without them; their tests are extra.
>
> - `UNIQUE` after a column forbids duplicate values, a column constraint like `NOT NULL` and `CHECK`. Make `Kategorie.Name` unique (test `Schema_verlangt_eindeutige_Kategorienamen`).
> - `HAVING condition` follows `GROUP BY` and filters the **groups**; unlike in `WHERE`, the condition may contain aggregate functions. Write **`KategorienMitMehrerenArtikeln`** like `AnzahlProKategorie`, but only with categories that have more than one item (`HAVING COUNT(*) > 1`; test `KategorienMitMehrerenArtikeln_filtert_mit_HAVING`).
> - A **subquery** is a `SELECT` in parentheses inside another command. In `Preiserhoehung`, replace the fixed Id 2 with `(SELECT Id FROM Kategorie WHERE Name = 'Garten')` (same test as above).
> - `NOT EXISTS (SELECT ...)` is true if the subquery returns no row. Write **`LoescheLeereKategorien`**: a `DELETE` that removes all categories without items (test `LoescheLeereKategorien_entfernt_nur_Kategorien_ohne_Artikel`).
