# Extra: Forum with Topics and Answers

Read **20.5.11 Master-Details Relationship** (page 1429) once more. A `Thema` has many `Antwort` objects (1:n). The classes and the `ForumContext` are in `Datenmodell.cs`; `ThemaAnlegen` and `Antworten` in `ForumDienst.cs` are provided.

1. In `OnModelCreating` (Fluent API): A topic has many replies, and each reply belongs to a topic (`ThemaId`); when a topic is deleted, its replies are also deleted (`DeleteBehavior.Cascade`).
2. `ThemaMitAntworten(id)`: the topic along with its replies, `Include`, or `null`.
3. `LoescheThema(id)`: Deletes the thread; the replies are also deleted as part of the cascade, but those from other threads remain.
4. `AntwortenProThema()`: a `Dictionary<string, int>` containing the number of replies for each topic title, including `0` for topics with no replies. Let the database count them (`Select(t => new { t.Titel, Anzahl = t.Antworten.Count })`).

Tests: `ThemaMitAntworten_laedt_die_Antworten_mit_Include`, `ThemaMitAntworten_liefert_null_oder_leere_Liste`, `LoescheThema_entfernt_auch_die_Antworten`, `LoescheThema_ohne_Antworten_und_unbekanntes_Thema`, `AntwortenProThema_zaehlt_je_Titel_auch_Nullen`, `Das_Modell_loescht_Antworten_per_Kaskade`.
