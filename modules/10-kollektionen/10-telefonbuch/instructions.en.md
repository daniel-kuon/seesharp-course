# Extra: Phone Book

Read **section 11.6, “Managing (Key-Value) Pairs”** (page 714), again.

The `Telefonbuch` class in `Telefonbuch.cs` manages names and numbers in a private `Dictionary<string,string>`. Implement:

1. `Setze(name, nummer)` creates or overwrites an entry.
2. `Suche(name)` returns the number or `null` if the name is unknown.
3. The `Namen()` function returns all names sorted alphabetically.
4. `MitVorwahl(vorwahl)` returns all names whose numbers begin with the area code, sorted alphabetically (using `foreach` on the `KeyValuePair` entries).
5. `Entferne(name)` deletes the entry and returns `true` if it existed.

The tests cover the normal case and cases where a key is missing: `Suche_liefert_null_fuer_unbekannte_Namen`, `Setze_ueberschreibt_vorhandene_Eintraege`, `MitVorwahl_listet_passende_Namen_sortiert`, and `Entferne_meldet_ob_etwas_entfernt_wurde`.
