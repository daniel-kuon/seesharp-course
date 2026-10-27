# Collection initializers and collection expressions

Read **11.3 Collection Initializers and Collection Expressions** (page 695) in the book and skim **11.2** (page 693) on the `ICollection<T>` and `IEnumerable<T>` interfaces.

Open `Sammler.cs`. The `Lager` class is provided and stays as it is.

1. `Wochentage()` returns Monday to Sunday, built with a **collection initializer** (`new List<string> { ... }`).
2. `Zusammen(a, b)` and `MitRand(mitte, rand)` use a **collection expression** with a spread element (`[..a, ..b]`; the book calls `..` the range operator, "Bereichsoperator").
3. `Leer<T>()` returns an empty read-only list using `[]`.
4. `NeuesLager()` creates a `Lager` with an object initializer that fills the `Artikel` property with a nested collection initializer: `Artikel = { "...", "..." }`. The name and the articles are given in the comment in the code.
5. `FuelleAuf` is written against `ICollection<int>`; the tests call it with a `List<int>` and a `HashSet<int>`. `Zaehle<T>` uses `Count`; `Gesamt` only gets an `IEnumerable<int>`, which has no `Count`, and therefore has to enumerate.

Then answer the question about which lines compile.

Tests: `Wochentage_sind_sieben_in_der_richtigen_Reihenfolge`, `Zusammen_haengt_b_hinter_a`, `MitRand_setzt_rand_vorn_und_hinten`, `Leer_liefert_eine_leere_Liste_jeden_Typs`, `NeuesLager_hat_Name_und_drei_Artikel`, `FuelleAuf_funktioniert_fuer_List`, `FuelleAuf_funktioniert_fuer_HashSet_und_Duplikate_fallen_weg`, `Zaehle_nutzt_ICollection` and `Gesamt_summiert_jede_Folge_auch_eine_ohne_Count`.
