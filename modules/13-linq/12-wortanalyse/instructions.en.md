# Extra: Word Analysis

Read **18.2.9 GroupBy()** (page 1222) and **18.2.8.2 SelectMany()** (page 1220) in the book. `CountBy` (available starting with .NET 9) is not covered in the book: It returns the count for each key.

Write the code in `Wortanalyse.cs` (the separators `Trenner` are provided); words are converted to lowercase using `ToLowerInvariant()`:

1. `Woerter(text)`: all words in the text in order, including repetitions. The text has multiple lines: First split it at `'\n'`, then flatten with `SelectMany`.
2. `Haeufigste(text, n)`: the `n` most frequent words as `(Wort, Anzahl)`, most frequent first; if the count is the same, sorted alphabetically (`StringComparer.Ordinal`) (`CountBy`, `OrderByDescending`, `ThenBy`).
3. `ProAnfangsbuchstabe(text)`: `Dictionary<char, List<string>>`: for each first letter the **distinct** words, sorted alphabetically (`GroupBy`).
4. `LaengsteWoerter(text)`: all unique words with the greatest length, sorted alphabetically; empty text: empty list.

Tests: `Woerter_flacht_alle_Zeilen_ab`, `Haeufigste_ordnet_nach_Anzahl_und_Alphabet`, `ProAnfangsbuchstabe_gruppiert_verschiedene_Woerter`, `LaengsteWoerter_liefert_alle_mit_der_groessten_Laenge`.
