# Editing, Deleting, and Tracking Changes

Read sections **20.10 "Tracking**" and **20.11 "Creating, Modifying, and Deleting Entities**" in the book, especially **20.11.2 "Modifying Entities"** (page 1474), as well as **20.15.2** (page 1492) on bulk updates. The context **tracks** loaded entities: It keeps track of their state (`EntityState`: `Added`, `Unchanged`, `Modified`, `Deleted`, `Detached`), and `SaveChanges` writes exactly the differences.

`Produkt` (`Id`, `Name`, `Preis`, `Angelegt`), `ProduktContext`, and the `Aktion` enumeration are predefined. Open `Verwaltung.cs`:

1. `Umbenennen(id, neu)`: `Find`, change name, `SaveChanges()`; returns its return value (the number of rows written). If the product does not exist, returns `0`. You do not need an `Update`.
2. `Entfernen(id)`: `Find`, `Remove`, `SaveChanges`; `true` if there was something to delete.
3. `ZustandNach(aktion, id)`: executes the action (new with `Add`; without loading with `Attach`; load and rename; load and `Remove`; load with `AsNoTracking`) and returns `kontext.Entry(produkt).State`. Expected: `Added`, `Unchanged`, `Modified`, `Deleted`, `Detached`. Nothing is saved.
4. `UmbenennenOhneNachverfolgung(id, neu)`: loads using `AsNoTracking`, changes the name, calls `SaveChanges`, and returns the result. It returns `0`: The context does not recognize the entity, so nothing is saved.
5. `ErhoehePreise(kontext, faktor)`: **Bulk update** using `ExecuteUpdate` and `SetProperty` without loading a product; returns the number of rows updated. `LoescheAlte(kontext, grenze)`: Same as above, but using `ExecuteDelete` for products created before `grenze`. The test verifies that the context does not track anything afterward.

Then answer the quiz question.

Tests: `Umbenennen_aendert_die_verfolgte_Entitaet_und_speichert_eine_Zeile`, `Umbenennen_eines_unbekannten_Produkts_schreibt_nichts`, `Entfernen_loescht_das_Produkt_und_meldet_ob_es_eines_gab`, `ZustandNach_meldet_den_EntityState`, `ZustandNach_speichert_nichts`, `Ohne_Nachverfolgung_speichert_SaveChanges_nichts`, `ErhoehePreise_aendert_alle_Zeilen_ohne_Entitaeten_zu_laden`, `LoescheAlte_loescht_per_ExecuteDelete_ohne_zu_laden`.
