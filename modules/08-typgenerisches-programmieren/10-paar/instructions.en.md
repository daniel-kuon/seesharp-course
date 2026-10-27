# Extra: A generic pair with two type parameters

Extra exercise: optional; it unlocks nothing. For further reading: **8.2.1 Generic Classes: Definition** (page 591) and **8.5 Generic Methods** (page 602).

A generic class can have multiple type parameters: `Paar<T1, T2>` holds two values of any type, even different types, such as `Paar<int, string>`. Open `Paar.cs`:

1. The constructor sets `Erstes` and `Zweites`; `ToString()` returns `"(erstes, zweites)"`, e.g. `"(1, eins)"`.
2. `Getauscht()` returns a **new** pair with the values swapped. The types are also swapped: `Paar<int, string>` becomes `Paar<string, int>`.
3. `MitErstem<TNeu>(TNeu neu)` is a generic method in a generic class: It has its own type parameter, `TNeu`, and returns a new pair in which the first value has been replaced—even with a value of a different type. The original pair remains unchanged.
4. The non-generic static class `Paar` (same name, but without type parameters—which is allowed) provides factory methods: `Paar.Von(1, "eins")` returns a `Paar<int, string>` without requiring you to specify the type arguments (type inference). `Paar.Geordnet(a, b)` returns a pair of two values of the same type, with the smaller one first; for this, `T` needs the constraint `where T : IComparable<T>`.

These tests must pass:

- `PaareTests.Paar_haelt_zwei_Werte_verschiedener_Typen`
- `PaareTests.ToString_zeigt_beide_Werte`
- `PaareTests.Getauscht_tauscht_Werte_und_Typen`
- `PaareTests.MitErstem_kann_den_Typ_wechseln`
- `PaareTests.Von_leitet_die_Typargumente_ab`
- `PaareTests.Geordnet_legt_den_kleineren_Wert_nach_vorn`
