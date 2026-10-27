# Grouping, Counting, and Set Operators

Read **18.2.9 GroupBy()** (page 1222) in the book and the exercise **18.6 Task 2** (page 1255, duplicate search). The file system is replaced here by entries in memory; you will find the real program in the sample `LINQ-to-Objects/FindDuplicate`.

Not in the book, given here: `OrderBy` and `ThenBy` take a comparer as a second argument, e.g. `OrderBy(p => p, StringComparer.Ordinal)` (character codes instead of language settings). `Order(StringComparer.Ordinal)` is the short form of `OrderBy(p => p, StringComparer.Ordinal)`.

Open `Auswertung.cs` (Record `Dateieintrag(Pfad, Groesse, Hash)`):

1. `Duplikate(eintraege)`: Groups of entries with the same `(Groesse, Hash)`, each containing more than one entry, as a `List<List<string>>` of the **sorted** paths (`StringComparer.Ordinal`); the groups are sorted by their first path (`GroupBy`, `Where`, `Select`, `OrderBy`).
2. `SpeicherProEndung(eintraege)`: for each file extension (`Path.GetExtension(pfad)` returns it including the dot, e.g. `".PNG"`; lowercased; level 15 covers the `Path` class in detail), the sum of the sizes, with the largest sum listed first; in case of a tie, sorted by extension (`Ordinal`).
3. `NeueTags(alt, neu)`: Tags from `neu` that are missing from `alt` (`Except`); `AlleTags(a, b)` (`Union`); `GemeinsameTags(a, b)` (`Intersect`). All three return a **sorted** list with no duplicates (`Order`).

> **Deep Dive (optional):** `CountBy` and `AggregateBy` (from .NET 9) are not in the book. `CountBy(schluessel)` returns pairs (key, count), `AggregateBy(schluessel, startwert, funktion)` condenses each key to one value; the results have `Key` and `Value`.
>
> - `Haeufigkeiten(werte)`: `Dictionary<string, int>` with `CountBy`.
> - `GroesseProEndung(eintraege)`: `Dictionary<string, long>` extension (as in 2.) -> sum of sizes, with `AggregateBy`.
>
> The tests `Haeufigkeiten_zaehlen_je_Wert` and `GroesseProEndung_verdichtet_je_Schluessel` are extra; the exercise passes without them.

Tests: `Duplikate_findet_gleiche_Groesse_und_Hash`, `Duplikate_ohne_Treffer_ist_leer`, `SpeicherProEndung_summiert_und_sortiert`, `SpeicherProEndung_bricht_Gleichstand_nach_Endung`, `Mengenoperatoren_auf_Tags`; extra (Deep Dive): `Haeufigkeiten_zaehlen_je_Wert`, `GroesseProEndung_verdichtet_je_Schluessel`.
