# Implementing an Interface

Read the introduction to Chapter **9, “Interfaces”** (page 609), **9.1 “Defining Interfaces”** (page 614, only 9.1.1.1), **9.2 Implementing Interfaces** (page 640), and **9.3 Interfaces as Reference Data Types** (page 644), including the boxing case in 9.3.2 (page 645).

`IForm` requires a shape to have a name, an area, a perimeter, and a scale. Open `IForm.cs`:

1. Implement the four members of *`Kreis`* (a class; area `π·r²`, circumference `2·π·r`; scaling multiplies the radius).
2. Implement it in `Quadrat` (a structure; area `s²`, perimeter `4·s`). Structures may implement interfaces, but may not inherit from them.
3. `Formen.Gesamt(IForm[])` sums the contents; `Formen.Groesste(IForm[])` returns the name of the form with the largest content (empty array: `""`). Both methods recognize only the interface, not the specific types.

Take a look at the boxing case in `Program.cs`: `IForm geboxt = q;` copies the structure to the heap. `q.Skaliere(3)` modifies `q`, not the copy in `geboxt`. The last test verifies exactly that.
