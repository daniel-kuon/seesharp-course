# Override ToString

Read Section **7.16 Exercises for Chapter 7** in the book, Exercise 5 (page 588), and, for context, the beginning of **7.9 Polymorphism** (page 566): `ToString()` is declared as `virtual` in `Object` and may be replaced with `override` in any class. You do not need any more inheritance here yet.

Open `Bruch.cs`. The `ToString()` method is already defined with `override`, but it is empty. It should return `"Zaehler/Nenner"`, i.e., `"7/8"` for `new Bruch(7, 8, "")`. The label is not included, and the fraction is not reduced.

Next, in the `Bruchrechnung.cs` file, try out what `Console.WriteLine(b)`, `$"Bruch: {b}"`, and `b + "!"` output: all three call `ToString()` without you having to write it out.
