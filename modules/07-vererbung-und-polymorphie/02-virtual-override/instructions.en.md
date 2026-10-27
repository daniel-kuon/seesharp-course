# Polymorphism: virtual and override

Read sections **7.9 “Polymorphism (Overriding Methods)”** (page 566) and **7.10 “Sealed Methods and Classes”** (page 570) in the book. For comparison, take a look at **7.6.1 Hiding Methods** (page 555): the starter still uses the `new` described there.

In the Starter, `Kreis` hides the members `Name`, `Wo()`, and `Skaliere()` with `new`. This only works as long as you access it via a `Kreis` reference; if you access it via a `Figur` reference, the base version runs. The tests access it via `Figur` references.

1. In `Figur`, mark the three members `Name`, `Wo()`, and `Skaliere()` as `virtual`.
2. In `Kreis`, replace `new` with `override`. `Wo()` continues to use `base.Wo()` for the first line and appends the second line.
3. Override the same three members in `Rechteck`: `Name` returns `"Rechteck"`, `Wo()` adds `"\nUnten Rechts: (x + breite; y + hoehe)"` (numbers in the format `{wert:0}` as shown in `Figur`), and `Skaliere` multiplies the width and height. `Wo()` is also marked as `sealed` so that subclasses of `Rechteck` can no longer override it.

The `Beschreibe()` method in `Figur` is intentionally **not** virtual: It calls `Name` and `Wo()`, yet still gets the behavior of the derived class because these calls are resolved as virtual.
