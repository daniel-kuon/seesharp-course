# Extra: Extension members for `string`

Extra exercise: optional; it unlocks nothing. For further reading: **7.15.2 Extension Blocks (C# 14 and later)** (page 583) and **7.15.3 Extension Methods with a `this` Parameter** (page 585).

`string` is sealed, so you can't create a subclass. However, you can still add properties, methods, and even an operator using extension members. Open `TextExtensions.cs`; the blocks and signatures are already there:

1. In the `extension(string text)` block (instance members):
   - `IstPalindrom` (property): `true` if the text is the same when read forward and backward. Case does not matter, and only letters and digits (`char.IsLetterOrDigit`) are counted: `"Ein Esel lese nie."` is a palindrome. So is an empty string.
   - `AnzahlWoerter` (property): Words are separated by spaces; multiple consecutive spaces count as one (`Split(' ', StringSplitOptions.RemoveEmptyEntries)`).
   - `Umgedreht()`: the text in reverse (a `StringBuilder` helps).
   - `WortanfaengeGross()`: Every letter at the beginning of the text or after a space is capitalized; everything else remains unchanged: `"hallo  welt"` becomes `"Hallo  Welt"`.
2. In the `extension(string)` block (static members):
   - `string.Wiederhole(text, anzahl)`: Repeats the text `anzahl` times in a row; if `anzahl <= 0`, returns `""`.
   - `operator *`: `"ab" * 3` equals `"ababab"`; use `Wiederhole`.
3. Classic extension method `Zaehle(this string text, char zeichen)`: How often does the character occur?

The following tests must be passed:

- `TextwerkzeugeTests.IstPalindrom_ignoriert_Gross_und_Satzzeichen`
- `TextwerkzeugeTests.AnzahlWoerter_ueberspringt_mehrfache_Leerzeichen`
- `TextwerkzeugeTests.Umgedreht_liefert_den_Text_rueckwaerts`
- `TextwerkzeugeTests.WortanfaengeGross_aendert_nur_Wortanfaenge`
- `TextwerkzeugeTests.Wiederhole_ist_ein_statisches_Erweiterungsmitglied`
- `TextwerkzeugeTests.Operator_Mal_wiederholt_den_Text`
- `TextwerkzeugeTests.Zaehle_ist_eine_klassische_Erweiterungsmethode`
