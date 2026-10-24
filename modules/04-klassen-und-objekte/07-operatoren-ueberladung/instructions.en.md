# Overloading Operators

Read Section **5.9.3, "Overloading Operators"** (page 385), in the book, including the section on the instance operator `+=` (new in C# 14).

Open `Bruch.cs`. The class now has automatic properties using `field` and an instance counter named `Anzahl`. Complete the following:

1. `Kuerze()`, `Addiere(Bruch)`, and `Addiere(int, int, bool)`, as in the previous exercise.
2. `DuplWerte(Bruch bc)` copies the numerator and denominator **to** `bc`; the label of `bc` is retained.
3. `Klone()` returns an independent copy with the same values.
4. The `static Bruch operator +(Bruch b1, Bruch b2)` returns a **new**, simplified fraction labeled `"b1 + b2"` (the labels of the operands joined with `" + "`). The operands remain unchanged.
5. `void operator +=(Bruch b)` modifies **this** object: adds, appends a label, or truncates. A new object must not be created.

Tip: The `operator +` operator can reuse `Klone()` and `Addiere()`.
