# Fix: Base Constructor and Private Inherited Members

Read Exercises 1 and 2 in Section **7.16 of the book**, Chapter 7 (page 586); see the explanations in **7.4.1 “base constructors”** (page 549) and **7.5 “the protected access modifier”** (page 554).

The starter **doesn't compile**. Build the project, read the two error messages, and fix them:

1. `Basisklasse.cs`: `Abgeleitet` does not declare a constructor, so the compiler generates a parameterless one that calls `base()`. That does not exist because `Basisklasse` only has `Basisklasse(int)`. Add a constructor `Abgeleitet(int i) : base(i)` to `Abgeleitet`. The base class remains unchanged; the test verifies this.
2. `Figur.cs`: `Kreis` accesses `xpos` and `ypos` in its constructor. The fields are inherited (every `Kreis` has them), but they are `private` and therefore invisible in `Kreis`. You could make them `protected`; it is nicer to leave the position check to the base constructor with `: base(x, y)` and only check the radius in `Kreis`. With an invalid position, the default of 100/100 stays in place, as in `Figur`.

Finally, answer the open-ended question in your own words; it will be discussed during the review.
