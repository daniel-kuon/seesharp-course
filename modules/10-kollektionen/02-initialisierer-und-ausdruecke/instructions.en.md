# Collection initializers and collection expressions

Read Section **11.3, “Collection Initializers and Collection Expressions”** (page 695), and skim **Section 11.2** (page 692) on the `ICollection<T>` and `IEnumerable<T>` interfaces.

Open `Sammler.cs`. The `Lager` class is provided and remains as is.

1. The `Wochentage()` method returns Monday through Sunday, built using a **collection initializer** (`new List<string> { ... }`).
2. `Zusammen(a, b)` and `MitRand(mitte, rand)` use a **collection expression** with a spread element (`[..a, ..b]`).
3. `Leer<T>()` returns an empty, read-only list `[]`.
4. `NeuesLager()` creates a `Lager` using an object initializer that populates the Artikel property with a nested collection initializer: `Artikel = { "...", "..." }`. The name and `Artikel` are specified in the comment in the code.
5. `FuelleAuf` writes to an `ICollection<int>` and is called by the tests with a `List<int>` and a `HashSet<int>`. `Zaehle<T>` uses `Count`; `Gesamt` only receives an `IEnumerable<int>` that does not support `Count` and must therefore enumerate it.

Then answer the question about which lines compile.

Tests: `Wochentage_sind_sieben_in_der_richtigen_Reihenfolge`, `Zusammen_haengt_b_hinter_a`, `MitRand_setzt_rand_vorn_und_hinten`, `Leer_liefert_eine_leere_Liste_jeden_Typs`, `NeuesLager_hat_Name_und_drei_Artikel`, `FuelleAuf_funktioniert_fuer_List`, `FuelleAuf_funktioniert_fuer_HashSet_und_Duplikate_fallen_weg`, `Zaehle_nutzt_ICollection` and `Gesamt_summiert_jede_Folge_auch_eine_ohne_Count`.
