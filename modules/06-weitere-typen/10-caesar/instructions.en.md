# Extra exercise: Cracking the Caesar cipher

This exercise is optional. It provides practice in working with characters, the `StringBuilder`, and a counting array. For further reading: **6.3 Classes for Strings** (page 472), especially **6.3.2 StringBuilder** (page 479), and **6.2 Arrays** (page 455).

The Caesar cipher shifts each letter by a fixed number of places in the alphabet: With a key of 3, A becomes D and X becomes A.

Open `Caesar.cs` and implement the four static methods:

1. `Verschluessele(text, schluessel)`: Uppercase letters `A`–`Z` and lowercase letters `a`–`z` are shifted; everything else (spaces, digits, punctuation, umlauts, ß) remains unchanged. Use the position in the alphabet: `c - 'A'` yields 0 to 25; after shifting, use `% 26` to return to the range and `(char)('A' + pos)` to get back to the character. The key may be negative or greater than 26; normalize it beforehand to 0 to 25 (Note: `-3 % 26` is `-3` in C#). Construct the result using a `StringBuilder`.
2. `Entschluessele(geheim, schluessel)`: Encrypt using the negative key.
3. `Haeufigkeiten(text)`: an `int[26]` array where index 0 counts how many times A or a occurs, index 1 counts B and b, and so on.
4. `Knacke(geheim)`: In German texts, E is almost always the most frequent letter. Find the index with the highest frequency; its difference from E (index 4) is the key, normalized to a range of 0 to 25.

The following tests must be passed:

- `CaesarTests.Verschluessele_verschiebt_Gross_und_Kleinbuchstaben`
- `CaesarTests.Verschluessele_laeuft_am_Alphabetende_herum`
- `CaesarTests.Andere_Zeichen_bleiben_unveraendert`
- `CaesarTests.Negative_und_grosse_Schluessel`
- `CaesarTests.Entschluessele_hebt_Verschluessele_auf`
- `CaesarTests.Haeufigkeiten_zaehlt_ohne_Gross_Kleinschreibung`
- `CaesarTests.Knacke_findet_den_Schluessel`
- `CaesarTests.Knacke_liefert_Werte_von_0_bis_25`
