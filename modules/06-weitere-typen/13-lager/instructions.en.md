# Extra exercise: A warehouse of records

This exercise is optional. It practices `with` expressions, the value equality of records, and tuples as return values. For further reading: **6.7.3 Copy Constructors and `with` Expressions** (page 499) and **6.6.5 Tuples as Return Types of Methods** (page 493).

An `Artikel` is a positional record with `Name`, `Preis` (`decimal`), and `Bestand`. It is immutable: Every "change" returns a copy. The tests compare `Artikel` instances with `Assert.Equal`, that is, by value equality, which the compiler generates for records.

Open `Lager.cs` and implement the static methods:

1. `Einlagern(a, menge)`: Copy with `Bestand + menge` using `a with { ... }`. If `menge <= 0`, `a` itself is returned.
2. `Reduziere(a, prozent)`: Copy with a reduced price, rounded to the nearest cent: `Math.Round(wert, 2, MidpointRounding.AwayFromZero)`. 0.55 € minus 50% equals 0.28 €.
3. `Gesamtwert(artikel)`: sum of price times `Bestand`.
4. `Preisstatistik(artikel)` returns the **named tuple** `(Min, Max, Schnitt)` of the prices, with the average rounded to the nearest cent. For an empty array, `(0, 0, 0)`.
5. `Nachbestellen(artikel, mindestbestand)`: returns a **new** array. Items with a quantity below the minimum stock level are copied into the new array with `Bestand = mindestbestand`; all others remain unchanged (same object). The original array remains as is.

The following tests must be passed:

- `LagerTests.Einlagern_liefert_Kopie_mit_hoeherem_Bestand`
- `LagerTests.Einlagern_mit_ungueltiger_Menge_aendert_nichts`
- `LagerTests.Reduziere_rundet_auf_Cent`
- `LagerTests.Gesamtwert_summiert_Preis_mal_Bestand`
- `LagerTests.Preisstatistik_liefert_benanntes_Tupel`
- `LagerTests.Preisstatistik_laesst_sich_dekonstruieren`
- `LagerTests.Nachbestellen_fuellt_auf_und_liefert_neues_Array`
- `LagerTests.Nachbestellen_uebernimmt_ausreichende_Artikel_unveraendert`
