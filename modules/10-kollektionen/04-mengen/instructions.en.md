# Sets with HashSet<T>

Read section **11.5**, "**Collections**" (page 704), and pay particular attention to **11.5.2, "Hash Tables and the HashSet<T> Class**" (page 704).

The assignment consists of two files.

**`Mengenwerkzeuge.cs`**

1. `Duplikate` returns the values that appear more than once, each only once. `Add()` returns `false` if the element was already present.
2. `GemeinsameFreunde`, `NurLinks`, and `Alle` form the intersection, difference, and union as a **new** set using `IntersectWith`, `ExceptWith`, and `UnionWith`. The arguments must not change; the tests verify this. `IstTeilmenge` uses `IsSubsetOf`.
3. `ContainsAllListe` and `ContainsAllMenge` answer the same question ("Does every number being searched for appear in the list?"), the first using `List<int>.Contains` and the second using a `HashSet<int>`. Both must always return the same result. Time is not measured.

**`Punkt.cs`**

4. In the `Punkt` class, override the `Equals(object?)` and `GetHashCode()` methods (using `HashCode.Combine`). Afterward, a `HashSet<Punkt>` into which `(1, 2)` is added three times must contain exactly one element and return `true` for `Contains(new Punkt(1, 2))`. `Equals(null)` and `Equals("x")` must return `false`.

Important tests: `Duplikate_meldet_jeden_doppelten_Wert_einmal`, `Mengenoperationen_veraendern_die_Argumente_nicht`, `HashSet_von_Punkten_erkennt_gleiche_Punkte`, `Gleiche_Punkte_haben_gleiche_Hashwerte`, `Equals_ist_bei_null_und_fremden_Typen_false`, and `ContainsAll_Liste_und_Menge_stimmen_ueberein`.
