# Abstract Classes and Members

Read Section **7.13, “Abstract Methods and Classes”** (page 577), and Section **7.14, “The Liskov Substitution Principle”** (page 579), for context.

In the starter, `Figur` is a concrete class with meaningless default implementations: `Skaliere` does nothing, and `Inhalt` and `Breite` return 0. This is dishonest; a "shape as such" has no area. It is better for the base class to force every concrete subclass to provide these members:

1. Make `Figur` `abstract` and declare `Skaliere`, `Inhalt`, and `Breite` as abstract members without a body (`public abstract double Inhalt { get; }`). `Wo()` stays virtual with an implementation.
2. Implement the three members in `Kreis` (area `π·r²`, width `2·r`) and `Rechteck` (area `b·h`, width `b`); `Skaliere` ignores negative factors.
3. `Figur.Gesamtflaeche(Figur[])` sums `Inhalt` across all figures. This is only possible because every figure is guaranteed to have an `Inhalt`.

Afterwards, try out that a line `new Figur(1.0, 2.0)` in `Program.cs` no longer compiles, while `Figur[]` is still allowed as a type.
