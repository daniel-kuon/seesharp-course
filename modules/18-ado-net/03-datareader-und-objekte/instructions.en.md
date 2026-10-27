# DataReader and Object Mapping

Read **19.7.15 DbDataReader** in the book (page 1363). A reader returns the result of a query row by row: `Read()` moves to the next row and returns `false` when there are no more rows. The book reads the columns through the indexer (`leser["Name"]` or `leser[0]`), which returns an `object`; a NULL arrives there as `DBNull.Value`.

Typed methods are more convenient (not in the book, given here): `int spalte = leser.GetOrdinal("Name");` returns the column number for a name, `leser.GetInt32(spalte)`, `leser.GetString(spalte)` and `leser.GetDecimal(spalte)` read the value directly in the right type, and `leser.IsDBNull(spalte)` asks whether the column contains NULL. The typed methods cannot handle NULL (they throw an exception), so you ask `IsDBNull` first. You may also stay with the indexer.

Open `ArtikelRepository.cs`. The `record Artikel` record is predefined (`Kategorie` is a `string?`). You map database rows to these objects. The connection belongs to the caller; you release readers and commands using the `using` statement.

1. `Alle()` returns all items, sorted by `Id`. The predefined query `Auswahl` joins the category using a `LEFT JOIN` (not in the book, given here: unlike `INNER JOIN`, it also keeps items without a category). Those items have NULL in that field and must remain `null` in C#.
2. `Suche(teil)`: Articles whose names contain `teil`, sorted by name. The search text is passed as **a parameter** in a `LIKE` expression. Append the percent signs to the **parameter value** (`"%" + teil + "%"`), not to the SQL text.
3. `NachKategorie()`: a `Dictionary<string, List<Artikel>>` where the category name serves as the key; items without a category are listed under `"(ohne)"`.
4. `LagerwertPerSql()` and `LagerwertPerCsharp()`: Have the database calculate the sum of `Preis * Bestand` once (`SUM`, `ExecuteScalar`) and once in C# using the items from `Alle()`. Both must return the same result, even if the table is empty (`SUM` returns NULL in that case, i.e., `DBNull`; the result should be 0).

All methods must release the connection: The tests verify after each call that no reader is still open.

Then answer the quiz question.

Tests: `Alle_liefert_alle_Artikel_nach_Id`, `Alle_laesst_fehlende_Kategorie_null`, `Alle_auf_leerer_Tabelle_liefert_leere_Liste`, `Suche_findet_Teiltext_ohne_Beachtung_der_Gross_Kleinschreibung_und_sortiert_nach_Name`, `Suche_mit_leerem_Text_liefert_alle`, `Suche_ist_gegen_SQL_Injection_sicher`, `NachKategorie_gruppiert_und_sammelt_Artikel_ohne_Kategorie_unter_ohne`, `Lagerwert_per_SQL_und_per_Csharp_stimmen_ueberein`, `Lagerwert_einer_leeren_Tabelle_ist_null`, `Leser_werden_freigegeben_Alle`, `Leser_werden_freigegeben_Suche`, `Leser_werden_freigegeben_NachKategorie`.
