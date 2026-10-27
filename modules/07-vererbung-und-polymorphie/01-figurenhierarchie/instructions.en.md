# A Shape Hierarchy

Read sections **7.3 “Defining a Derived Class”** (page 547), **7.4 “Constructors and Inheritance”** (page 549), **7.5 The `protected` Access Modifier** (page 554), **7.7 Managing Objects via Base Class References** (page 561), and **7.8 Type-Test Operators** (page 563).

`Figur` is finished: position `xpos`/`ypos` (as `protected`), a validating constructor, the property `Wo`. `Kreis` and `Rechteck` are meant to inherit from it:

1. Both classes already derive from `Figur` with `: Figur`; look at how little is needed for that, and everything they inherit as a result.
2. In the constructor, pass `x` and `y` to the base constructor using `: base(x, y)`; only use the radius, width, and height if they are not negative (otherwise, the default values remain 75 and 50 × 50, respectively).
3. `UntenRechts` calculates the lower-right corner based on the inherited `protected` fields: circle `(xpos + 2·radius, ypos + 2·radius)`, rectangle `(xpos + breite, ypos + hoehe)`.
4. `Figur.SummeRadien(Figur[] figuren)` iterates over an array of base class references and adds the radii of all circles. The type check with the pattern declaration `if (f is Kreis k)` returns the appropriate reference.

`Program.cs` creates a `Figur[]` containing a mix of figures and demonstrates that each figure knows its runtime type (`GetType().Name`).
