# Extra: A Generic Ring Buffer

Extra exercise: optional; it unlocks nothing. For further reading: **8.2.1 Generic Classes: Definition** (page 591) and **8.7 default operator** (page 605).

A circular buffer is a fixed-size queue: first-in, first-out. When it is full, a new element **overwrites** the oldest one. For example, a measuring device always stores the last 100 measurement values. Internally, everything is stored in an array `T[]`; `anfang` points to the oldest element, and the indices loop around using `% data.Length` instead of shifting elements. Open `Ringpuffer.cs`:

1. The constructor creates the array; a capacity less than 1 throws an `ArgumentOutOfRangeException`. `Kapazitaet`, `Count`, and `IstVoll` are calculated properties.
2. `Hinzufuegen(element)` writes to the position after the most recent element. If the buffer is full, the oldest element is overwritten, and `anfang` moves one position forward.
3. `Entnehmen()` removes the oldest element and returns it; an empty buffer throws an `InvalidOperationException`. Overwrite the freed space with `default` so that the buffer does not retain references to old objects.
4. If the buffer is empty, `EntnehmenOderDefault()` returns `default(T)` instead of throwing an exception: 0 for `int`, `null` for `string`.
5. The indexer starts counting from the oldest element (`[0]` is the oldest); indices outside the range `0 .. Count - 1` throw an `ArgumentOutOfRangeException`. `AlsArray()` returns all elements from the oldest to the newest.

The following tests must be passed:

- `RingpufferTests.Neuer_Puffer_ist_leer`
- `RingpufferTests.Ungueltige_Kapazitaet_wirft`
- `RingpufferTests.Entnehmen_liefert_das_aelteste_zuerst`
- `RingpufferTests.Voller_Puffer_ueberschreibt_das_aelteste`
- `RingpufferTests.Indexer_zaehlt_ab_dem_aeltesten`
- `RingpufferTests.Leerer_Puffer_wirft_oder_liefert_default`
- `RingpufferTests.Viele_Runden_ueber_das_Arrayende`
