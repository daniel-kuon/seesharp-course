# Extra: Address Book with Search

Reread **19.7.5 DbCommand** (page 1323) and **19.7.15 DbDataReader** (page 1363). In `Kontaktdienst.cs`, you manage the `Kontakt(Id, Name, Telefon)` table via an open connection that belongs to the caller. The `record Kontakt` record is predefined; `Telefon` is of type `string?`.

1. `Neu(name, telefon)`: Insert a contact and return the **new ID** (not in the book, given here: after the `INSERT`, `SELECT last_insert_rowid()` via `ExecuteScalar` returns the Id as a `long`).
2. `Aendern(id, name, telefon)`: `UPDATE`; `true` if the contact existed.
3. `Loeschen(id)`: `DELETE`; `true` if the contact existed.
4. `Suche(teil)`: all contacts whose name contains `teil`, sorted by name, including those without a phone number (`null`).

All values must be included as parameters in the command, never in the SQL text. A `null` for the phone number becomes `DBNull.Value`; a NULL in the database becomes `null` again when read.

Tests: `Neu_liefert_die_neue_Id_und_speichert_den_Kontakt`, `Neu_ohne_Telefon_speichert_NULL`, `Neu_vertraegt_Hochkommas_und_SQL_Zeichen_im_Namen`, `Aendern_aendert_Name_und_Telefon_und_meldet_ob_es_den_Kontakt_gab`, `Aendern_kann_das_Telefon_auf_NULL_setzen`, `Loeschen_entfernt_nur_den_einen_Kontakt`, `Suche_findet_Teiltext_und_sortiert_nach_Name`, `Suche_liefert_auch_Kontakte_ohne_Telefon`, `Suche_ohne_Treffer_und_mit_SQL_Zeichen_liefert_leere_Liste`, `Suche_mit_leerem_Text_liefert_alle_sortiert`.
