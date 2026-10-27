# Strings: Line Break, Lucky Number, StringBuilder

Read Section **6.3**, **"Classes for Strings"** (page 472), in the book: 6.3.1 `String` (page 472) with its methods (6.3.1.2, page 473) and 6.3.2 `StringBuilder` (page 479). Exercises 5 and 6 in Section **6.10** (page 541) describe “Lucky Number” and “Line Break.”

Open `StringUtil.cs` and implement the four static methods:

1. `WrapLine(text, ncol = 72, hypSep = false)` splits the text at spaces (`text.Split(' ', StringSplitOptions.RemoveEmptyEntries)`, from the tip for exercise 6 in 6.10, page 542: returns the words without empty entries) and fills lines with no more than `ncol` characters: If the next word still fits (including the separating space), it is placed on the same line; otherwise, a new line begins. A word longer than `ncol` is split hard. The lines are returned as a `string[]` without trailing spaces. If `hypSep == true`, the text may also be split after a hyphen that appears between two non-space characters (`Schmal-Zeile` → `Schmal-` / `Zeile`); there is no space after such a split. Tip (from the book's sample solution): Before the `Split`, mark such hyphens with a placeholder like `{opt}` followed by a space.
2. `Glueckszahl(vorname, nachname)`: Seed = code of the first letter of the first name + code of the last letter of the last name, both in uppercase (a `char` can be used directly as an `int`); result: `new Random(seed).Next(100) + 1`.
3. `ZaehleVokale(s)`: Iterate through the string character by character (using `foreach` on the string) and count the occurrences of a, e, i, o, and u in upper and lower case.
4. `Umkehren(s)`: Build the result with a `StringBuilder`, from the last character to the first.

Remember: Strings are immutable. `text.Replace(...)` or `ToUpper()` return new strings; the original remains unchanged.
