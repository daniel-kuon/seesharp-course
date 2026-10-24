# SQL Basics with SQLite

Read Chapter **19.6**, "**SQL,"** starting on page 1296 (especially sections 19.6.2 through 19.6.4). The book uses SQL Server, but we’re working with **SQLite**: no server—the database is stored in memory. The commands are almost the same. Here are some differences you’ll encounter:

| SQL Server (Book) | SQLite |
|---|---|
| `INT IDENTITY(1,1) PRIMARY KEY` | `INTEGER PRIMARY KEY` (incremented automatically; `AUTOINCREMENT` is usually unnecessary) |
| `SELECT TOP 3 ...` | `SELECT ... LIMIT 3` |
| Column types: `NVARCHAR(50)`, `MONEY`, `DECIMAL` | `TEXT`, `REAL`, `INTEGER` (SQLite uses loose typing) |

Open `Skripte.cs`. The static class `Skripte` contains SQL statements; you fill them in. The tests run them against a fresh database (with foreign keys enabled) and compare the results.

1. **`Schema`**: two tables.
   - `Kategorie(Id, Name)`: `Id` is the primary key; `Name` is text, never empty, and unique (`UNIQUE`).
   - `Artikel(Id, Name, Preis, KategorieId)`: `Id` is the primary key, `Name` is text and never empty, `Preis` is a floating-point number with a `CHECK (Preis >= 0)` constraint, and `KategorieId` is a foreign key that references `Kategorie(Id)`.
2. **`Daten`**: Insert these rows using `INSERT` (the IDs are predefined):

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

3. **`TeureArtikel`**: Columns `Name` and `Preis` for all items priced over 10, sorted from most expensive to least expensive.
4. **`ArtikelMitKategorie`**: Columns `Kategorie` (category name) and `Name` (article name) via `JOIN`, sorted by category, then by article name.
5. **`AnzahlProKategorie`**: `Kategorie` and `Anzahl` columns with `GROUP BY`; only categories with more than one item (`HAVING`); sorted by `Anzahl` in descending order, then by `Kategorie`.
6. **`Preiserhoehung`**: an `UPDATE` that increases the prices of all items in the `Garten` category by 10%. Don't enter the ID 2; instead, search for it by name (subquery).
7. **`LoescheLeereKategorien`**: a `DELETE` statement that removes all categories without articles (`NOT EXISTS`).

Then answer the quiz question.

Tests: `Schema_legt_beide_Tabellen_an`, `Schema_deklariert_Primaerschluessel_und_Fremdschluessel`, `Schema_weist_Artikel_mit_unbekannter_Kategorie_ab`, `Schema_weist_negative_Preise_ab`, `Schema_verlangt_Namen_und_eindeutige_Kategorienamen`, `Daten_fuegt_Kategorien_und_Artikel_ein`, `TeureArtikel_liefert_Artikel_ueber_10_absteigend`, `ArtikelMitKategorie_verknuepft_und_sortiert`, `AnzahlProKategorie_gruppiert_und_filtert_mit_HAVING`, `Preiserhoehung_erhoeht_nur_die_Kategorie_Garten`, `LoescheLeereKategorien_entfernt_nur_Kategorien_ohne_Artikel`.
