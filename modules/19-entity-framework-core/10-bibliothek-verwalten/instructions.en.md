# Extra: Book Management

Read **section 20.11, “Creating, Modifying, and Deleting Entities”** (page 1472), again. `Buch` (`Id`, `Titel`, `Autor`, `Jahr`, `Ausgeliehen`) and `BuchContext` are predefined. In `Buecherei.cs`, you manage the books; **each call uses a new context** within a `using` statement.

1. `Aufnehmen(titel, autor, jahr)`: create the schema with `kontext.Database.EnsureCreated();` if needed (not in the book, given as in exercise 1), `Add`, `SaveChanges`; returns the new `Id`.
2. `Ausleihen(id)`: Sets `Ausgeliehen = true`. Returns `false` if the book does not exist or is already checked out.
3. `Entfernen(id)`: deletes the book; returns `true` if one existed.
4. `Suche(teil)`: Books whose titles contain `teil`, sorted by title.

Tests: `Aufnehmen_speichert_das_Buch_und_liefert_die_Id`, `Aufnehmen_legt_das_Schema_bei_Bedarf_an`, `Ausleihen_markiert_das_Buch_als_ausgeliehen`, `Ausleihen_scheitert_bei_schon_ausgeliehenem_oder_unbekanntem_Buch`, `Entfernen_loescht_genau_das_Buch`, `Suche_findet_Teiltext_und_sortiert_nach_Titel`, `Suche_mit_leerem_Text_liefert_alle_sortiert`.
