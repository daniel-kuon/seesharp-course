# Dictionaries

Read **11.6 Managing (Key-Value) Pairs** (page 714) in the book. That section also includes the `DictionaryDemo` example, which counts characters.

Open `Woerterbuecher.cs`. The `Woerter(string)` method (which splits a text into lowercase words) and the `Eintrag` class in `Eintrag.cs` are provided. Implement the remaining seven methods:

1. `Haeufigkeiten(text)` returns a `Dictionary<string,int>` containing the frequency of each word. It uses `StringComparer.OrdinalIgnoreCase` for comparison, so `d["DER"]` and `d["der"]` find the same entry.
2. `Nachschlagen(telefonbuch, name)` returns the number or `"unbekannt"`. Use `TryGetValue`; the indexer throws an exception if the key is missing.
3. `Eintragen(telefonbuch, name, nummer)` creates the entry or overwrites it (the second entry wins).
4. `Umkehren(haeufigkeiten)` returns a `Dictionary<int, List<string>>`: for each frequency, all words that occur that many times.
5. `Haeufigste(haeufigkeiten, n)` returns the `n` most frequent words, highest count first, alphabetical on ties. Build a `List<Eintrag>` and call `Sort()`: `Eintrag` brings its own ordering.
6. `Summe` adds up all frequencies (`foreach` over `KeyValuePair`).
7. `Schluessel` lists all keys from `Keys` in alphabetical order.

The order in which a `Dictionary` lists its entries is not guaranteed; the tests never rely on it.

Tests: `Haeufigkeiten_zaehlt_Woerter_ohne_Beachtung_der_Schreibweise`, `Haeufigkeiten_findet_Schluessel_in_jeder_Schreibweise`, `Nachschlagen_liefert_Nummer_oder_unbekannt`, `Eintragen_legt_an_und_ueberschreibt_beim_zweiten_Mal`, `Umkehren_gruppiert_Woerter_nach_Haeufigkeit`, `Haeufigste_sortiert_nach_Anzahl_dann_alphabetisch`, `Summe_addiert_alle_Haeufigkeiten` and `Schluessel_sind_alphabetisch_sortiert`.
