# Strings and Formatting

Read sections **4.2.2, “Outputting a (Composite) String”** (page 176), and **4.2.3, “Formatted Output”** (page 176), in the book—especially 4.2.3.2 on string interpolation (page 178). For escape sequences, see **4.3.10.5** (page 208).

Open `Formatierung.cs`:

1. `SummeText()` should return `3 + 2 = 5`. The current version returns `3 + 2 = 32`. Figure out why, and fix it by adding a pair of parentheses.
2. The function `Bruchzeile(int zaehler, int nenner)` returns the text `zaehler/nenner` via interpolation; thus, `Bruchzeile(3, 4)` returns `3/4`.
3. `Ausgerichtet(int i, int j, int k, int m)` returns **a** string containing line breaks (`\n`) and tabs (`\t`) in exactly this format (the numbers right-aligned with a width of 4, then left-aligned with a width of 4):

   ```
   Rechtsbündig:
   	i = 4711
   	j =  471
   	k =   47
   	m =    4

   Linksbündig:
   	4711 (i)
   	471  (j)
   	47   (k)
   	4    (m)
   ```

   Every line except the first begins with a tab; there is no line break after the last line. There is a blank line between blocks.

The following tests must be passed:

- `FormatierungTests.SummeText_rechnet_in_Klammern`
- `FormatierungTests.Bruchzeile_interpoliert`
- `FormatierungTests.Ausgerichtet_rechts_und_linksbuendig`
