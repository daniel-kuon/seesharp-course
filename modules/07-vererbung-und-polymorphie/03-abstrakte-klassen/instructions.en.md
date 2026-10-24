# Abstract Classes and Members

Read Section **7.13, “Abstract Methods and Classes”** (page 577), and Section **7.14, “The Liskov Substitution Principle”** (page 579), for context.

In the starter, `Figur` is a concrete class with meaningless default implementations: `Skaliere` does nothing, and `Inhalt` and `Breite` return 0. This is misleading; a "shape in and of itself" has no area. It is better to require the base class to ensure that every concrete subclass provides these members:

1. Make `Figur` `abstract` and declare `Skaliere`, `Inhalt`, and `Breite` as abstract members without a body (`public abstract double Inhalt { get; }`). `Wo()` stays virtual with an implementation.
2. Implement the three members: a `Kreis` (area `π·r²`, width `2·r`) and a `Rechteck` (area `b·h`, width `b`); `Skaliere` ignores negative factors.
3. `Figur.Gesamtflaeche(Figur[])` sums the Inhalt across all figures. This is only possible because every figure is guaranteed to have a `Inhalt`.

Note that `new Figur(...)` in `Program.cs` no longer compiles, but `Figur[]` is still allowed as a type.
