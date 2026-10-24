# Bruch implements IComparable<T> and ICloneable

Read the book's **Section 9.2.1**, **"Example: IComparable<T>**" (page 640), **Section 9.2.3**, "**Advantages of Generic Interfaces**" (page 642), and Exercise 1 in **Section 9.6** (page 655).

The `Bruch` class from Level 5 receives two contracts:

1. Specify `: IComparable<Bruch>, ICloneable` after the class name.
2. `CompareTo(Bruch? b)` compares the **values** using cross-multiplication: `Zaehler · b.Nenner` versus `b.Zaehler · Nenner`. Perform the calculation in `long` to prevent large numerators from overflowing `(long)Zaehler * b.Nenner`). Return a negative, 0, or positive value; `long` itself has a `CompareTo` method that handles this. If `b` is zero, this fraction is considered larger.
3. `Clone()` is required by `ICloneable` as `object Clone()`. `MemberwiseClone()` (inherited from `Object`) returns a shallow copy, which is sufficient here because `Bruch` contains only value types and a string.

Accordingly, `Array.Sort(b)` sorts a `Bruch[]` by value, and `(Bruch) b.Clone()` returns a copy. The type-safe `Klone()` remains unchanged.
