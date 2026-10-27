# Library and Consumer: FractionLib

Read Section **5.13**, **“Access Levels for Classes and Their Members”** (page 398), including 5.13.1 (Classes) and 5.13.2 (Members). For information on project references, see **3.3.10.1 “Project References”** (page 128) if you no longer recall the structure.

This time, there are two projects:

- `FractionLib` is a **class library** (an `OutputType` library; it does not have a `Main` method). It contains the predefined `Bruch` class in the `de.bebagoe.fraction` namespace.
- `Bruchrechnung` is a console project that **references** `FractionLib` (see `Bruchrechnung.csproj`).

Tasks:

1. In `FractionLib/Bruch.cs`, the helper method `Ggt` is incorrectly marked as `public`. It is not part of the library's interface: Change the access modifier to `internal` so that only code within `FractionLib` can access it. Then, in `Bruchrechnung`, verify that `Bruch.Ggt(…)` no longer compiles there.
2. Take a look at the `using` directive in `Bruchrechnung/Rechner.cs`: Without `using de.bebagoe.fraction;`, the console project does not recognize the `Bruch` type, even though the project reference is set (namespace and assembly are two different things; see Level 1).
3. `Rechner.Summe(params Bruch[] brueche)` starts with `new Bruch(0, 1, "Summe")`, adds all fractions using `+=`, and returns the result with the label `"Summe"` (set it again after adding, because `+=` appends labels). The passed-in fractions remain unchanged.
4. `Rechner.Mittel(...)`: Calculate the sum, multiply the denominator by the number, simplify, label `"Mittel"`.

`params Bruch[] brueche` is a **parameter array** (5.3.1.3.3, page 321): the caller passes any number of fractions, `Rechner.Summe(a, b, c)`. In the method body you go through them as in the book example `PrintSum` with `foreach (Bruch b in brueche)`. The number of fractions is `brueche.Length`. That `brueche` is an array is covered in detail only in chapter 6.2; you need nothing beyond these two forms here.

The test project references both projects and uses Reflection to verify that `Ggt` is not public.
