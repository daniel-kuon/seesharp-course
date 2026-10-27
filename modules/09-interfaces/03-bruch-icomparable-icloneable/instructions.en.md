# Bruch implements IComparable<T> and ICloneable

Read the book's **Section 9.2.1**, **"Example: IComparable<T>**" (page 640), **Section 9.2.3**, "**Advantages of Generic Interfaces**" (page 642), and Exercise 1 in **Section 9.6** (page 655).

The `Bruch` class from Level 5 receives two contracts:

1. Specify `: IComparable<Bruch>, ICloneable` after the class name.
2. `CompareTo(Bruch? b)` compares the **values** using cross-multiplication: `Zaehler · b.Nenner` versus `b.Zaehler · Nenner`. Perform the calculation in `long` so that large numerators do not overflow (`(long)Zaehler * b.Nenner`). Return a negative, 0, or positive value; `long` itself has a `CompareTo` method that handles this. If `b` is null, this fraction is considered larger. **Careful with negative denominators:** `Bruch` allows `1/-2`. Cross-multiplication multiplies both sides by `Nenner · b.Nenner`; if exactly one of the two denominators is negative, that product is negative and the comparison flips (as with inequalities: multiplying by a negative number reverses the sign). Reverse the result in that case.
3. `Clone()` is required by `ICloneable` as `object Clone()`. `MemberwiseClone()` (inherited from `Object`; not in the book, given here) returns a shallow copy, which is sufficient here because `Bruch` contains only value types and a string.

Afterwards, `Array.Sort(b)` sorts a `Bruch[]` by value, and `(Bruch) b.Clone()` returns a copy. The type-safe `Klone()` stays alongside it.
