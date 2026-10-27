# Extra: A cache with a size limit

Extra exercise: optional; it unlocks nothing. For further reading: **8.2.2 Restricted Type Formal Parameters** (page 593) and **8.7 The default Operator** (page 605).

A cache stores computationally expensive values under a key, but only a limited number of them. When it is full, an entry must be evicted—specifically, the one that has **not** been **used for the longest time** (least recently used, LRU). `Cache<TKey, TValue>` has two type parameters and stores keys and values in two parallel arrays. The order in the arrays reflects the order of use: index 0 is the one that has been unused the longest, and index `anzahl - 1` is the one most recently used. Open `Cache.cs`:

1. Keys must be comparable. Constrain `TKey` with `where TKey : IComparable<TKey>` and compare using `CompareTo(...) == 0`. A test verifies this constraint.
2. Constructor: A capacity less than 1 throws an `ArgumentOutOfRangeException`. `Count` and `Kapazitaet` are computed properties.
3. Two private helper methods eliminate duplicate code: `Suche(key)` returns the index of the key or -1; `NachHinten(index)` moves the entry at `index` to the end (shifting the entries that follow it one position forward).
4. `Setze(key, wert)`: If the key exists, its value is replaced; otherwise, a new entry is added. If the cache is full, the new entry replaces the one at index 0. In either case, the entry is then considered the most recently used.
5. `HoleOderDefault(key)`: the value; the entry is considered to be the most recently used; an unknown key returns the `default` value (0, `null`, ...). `Enthaelt(key)` only checks and **does not** count as a use.
6. `Schluessel()` returns the keys in order from the one that has been unused the longest to the one that was used most recently.

These tests must pass:

- `CacheTests.TKey_ist_auf_IComparable_eingeschraenkt`
- `CacheTests.Ungueltige_Kapazitaet_wirft`
- `CacheTests.Setze_und_Hole`
- `CacheTests.Unbekannter_Schluessel_liefert_default`
- `CacheTests.Setze_ersetzt_einen_vorhandenen_Eintrag`
- `CacheTests.Voller_Cache_verdraengt_den_am_laengsten_unbenutzten`
- `CacheTests.Hole_zaehlt_als_Benutzung`
- `CacheTests.Enthaelt_zaehlt_nicht_als_Benutzung`
