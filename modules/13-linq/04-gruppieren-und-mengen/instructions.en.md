# Grouping, Counting, and Set Operators

Read **18.2.9 GroupBy()** (page 1222) in the book and the exercise **18.6 Task 2** (page 1255, duplicate search). The file system is replaced here by entries in memory; you will find the real program in the sample `LINQ-to-Objects/FindDuplicate`. `CountBy` and `AggregateBy` (from .NET 9) are not in the book: `CountBy(schluessel)` returns pairs (key, count), `AggregateBy(schluessel, startwert, funktion)` condenses each key to one value.

Open `Auswertung.cs` (Record `Dateieintrag(Pfad, Groesse, Hash)`):

1. `Duplikate(eintraege)`: Groups of entries with the same `(Groesse, Hash)`, each containing more than one entry, as a `List<List<string>>` of the **sorted** paths (`StringComparer.Ordinal`); the groups are sorted by their first path (`GroupBy`, `Where`, `Select`, `OrderBy`).
2. `SpeicherProEndung(eintraege)`: For each file extension (`Path.GetExtension`, lowercase), the sum of the sizes, with the largest sum listed first; in case of a tie, sorted by extension (`Ordinal`).
3. `Haeufigkeiten(werte)`: `Dictionary<string, int>` with `CountBy`.
4. `GroesseProEndung(eintraege)`: `Dictionary<string, long>` with `AggregateBy`.
5. `NeueTags(alt, neu)`: Tags from `neu` that are missing from `alt` (`Except`); `AlleTags(a, b)` (`Union`); `GemeinsameTags(a, b)` (`Intersect`). All three return a **sorted** list with no duplicates (`Order`).

Tests: `Duplikate_findet_gleiche_Groesse_und_Hash`, `Duplikate_ohne_Treffer_ist_leer`, `SpeicherProEndung_summiert_und_sortiert`, `SpeicherProEndung_bricht_Gleichstand_nach_Endung`, `Haeufigkeiten_zaehlen_je_Wert`, `GroesseProEndung_verdichtet_je_Schluessel`, `Mengenoperatoren_auf_Tags`.
