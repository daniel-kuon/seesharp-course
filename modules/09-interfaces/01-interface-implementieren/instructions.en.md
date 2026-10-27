# Implementing an Interface

Read the introduction to Chapter **9, “Interfaces”** (page 609), **9.1 “Defining Interfaces”** (page 614, only 9.1.1.1), **9.2 Implementing Interfaces** (page 640), and **9.3 Interfaces as Reference Data Types** (page 644), including the boxing case in 9.3.2 (page 645).

`IForm` requires a shape to have a name, an area, a perimeter, and a scaling method. Open `IForm.cs`:

1. Implement the four members in `Kreis` (a class; area `π·r²`, perimeter `2·π·r`; scaling multiplies the radius).
2. Implement them in `Quadrat` (a structure; area `s²`, perimeter `4·s`; scaling multiplies the side). Structures may implement interfaces, but cannot inherit from a base class.
3. `Formen.Gesamt(IForm[])` sums the areas; `Formen.Groesste(IForm[])` returns the name of the shape with the largest area (empty array: `""`). Both methods know only the interface, not the concrete types.

Take a look at the boxing case in `Program.cs`: `IForm geboxt = q;` copies the structure to the heap. `q.Skaliere(3)` modifies `q`, not the copy in `geboxt`. The last test verifies exactly that.
