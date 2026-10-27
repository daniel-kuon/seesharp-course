# Extra: ASCII Banners

Extra exercise: optional; it blocks nothing. You're free to structure this however you like; the tests only check the format.

Read **section 3.1.5**, **"Execution"** (page 74), in the book again. If you want to write multi-line text in a single literal, you'll find the raw string literal (`"""`) discussed in advance in **section 4.3.10.5**, **"String Literals**" (page 208 ff.). Also a preview: `+` joins strings together, and `"\n"` stands for a line break; both come in **section 4.2.2, "Output of a (Composite) String"** (page 176).

Open `Banner.cs` and complete the three static methods:

1. `Rahmenlinie()` returns a line like `+--------------------+`: a `+` at the beginning and end, with only minus signs in between, for a total of at least 10 characters.
2. `Titelzeile()` returns a line like `|  Hallo, SeeSharp!  |`: a `|` at the beginning and end, the word `SeeSharp` somewhere in the middle, and **exactly as wide as your border line**. You choose the text in between yourself.
3. `Komplett()` returns everything in a single string consisting of three lines: border line, title line, border line. You can either construct the lines using `+` and `"\n"` from the other two methods, or you can write a raw string literal.

`Main()` already displays the banner. Run the program and take a look.

The following tests must be passed:

- `BannerTests.Rahmenlinie_hat_Plus_an_den_Enden_und_Minus_dazwischen`
- `BannerTests.Rahmenlinie_ist_mindestens_10_Zeichen_breit`
- `BannerTests.Titelzeile_steht_zwischen_senkrechten_Strichen`
- `BannerTests.Titelzeile_nennt_SeeSharp`
- `BannerTests.Titelzeile_ist_so_breit_wie_die_Rahmenlinie`
- `BannerTests.Banner_besteht_aus_Linie_Titel_Linie`
