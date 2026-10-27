# Extra exercise: Palindromes, anagrams, run lengths

This exercise is optional. It helps you practice working with individual characters, `StringBuilder`, and the `Array` class. For further reading: **6.3 Classes for Strings** (page 472) and **6.2.6 Searching and Sorting** (page 463).

Open `Wortspiele.cs` and implement the four static methods:

1. `IstPalindrom(s)`: A string is a palindrome if it reads the same forward and backward. Only letters (`char.IsLetter`) are counted, and case is ignored (`char.ToLower`); both methods are not in the book and are given here. Thus, `"Eine güldne, gute Tugend: Lüge nie!"` is also a palindrome. Iterate with two indices starting from both ends and moving toward each other, skipping non-letters. An empty string is a palindrome.
2. `IstAnagramm(a, b)`: Two texts are anagrams if they consist of exactly the same letters (again, only letters, with no distinction between uppercase and lowercase). Tip: Collect the lowercase letters in a `char[]`, sort them using `Array.Sort`, and compare them using `new string(...)` (turns a `char[]` into a string; not in the book, given here).
3. `Kodiere(s)`: Run-length encoding. Each run of identical characters is converted to a number and a character: `"AAABCC"` becomes `"3A1B2C"`. The text contains no digits.
4. `Dekodiere(code)`: the reverse operation. The number can have multiple digits (`"12x"`); collect the digits (`char.IsDigit`, not in the book, given here; `c - '0'`) into a number until a non-digit character is encountered. `StringBuilder.Append(c, anzahl)` appends a character multiple times (not in the book, given here).

The following tests must be passed:

- `WortspieleTests.Einfache_Palindrome`
- `WortspieleTests.Palindrom_ignoriert_Satzzeichen_Leerzeichen_und_Grossschreibung`
- `WortspieleTests.Anagramme_werden_erkannt`
- `WortspieleTests.Anagramm_ignoriert_Grossschreibung_und_Nicht_Buchstaben`
- `WortspieleTests.Keine_Anagramme`
- `WortspieleTests.Kodiere_zaehlt_Laeufe`
- `WortspieleTests.Dekodiere_mit_mehrstelligen_Zahlen`
- `WortspieleTests.Dekodiere_hebt_Kodiere_auf`
