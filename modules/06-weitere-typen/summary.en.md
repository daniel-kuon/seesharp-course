# Other types: Structures, arrays, strings, enums, tuples, records

After covering classes, you’ll learn about the remaining building blocks of the type system in Chapter 6 (starting on page 431). The central theme is the question **of value versus reference**: When assigning a value, is the value copied, or is only a reference passed? This determines what a method can change about an argument and when two things are considered “equal.”

## Structures and Boxing (6.1, page 431)

A `struct` looks like a class but is a **value type**: `var p3 = p1;` copies all fields, and a method with a struct parameter works on a copy (6.1.1, page 434). Structures are suited for small, value-like things such as a point. If you assign a struct to an `object` variable, it is **boxed**, i.e. copied into a heap object (6.1.6, page 450); that is why two boxed `1` values are unequal with `==` but equal with `Equals`.

## Arrays (6.2, page 455)

An array has a fixed length and a fixed element type; `new int[49]` returns all zeros, and `Length` and the index ranging from 0 to `Length - 1` control the loop. Arrays are **reference types**: `Mische(vektor, rnd)` can modify the caller’s array without returning anything. The `Array` class provides `IndexOf`, `Sort`, and `BinarySearch` (6.2.6, page 463), plus `Resize` (6.2.2, page 458). You should be able to implement three algorithms from the exercises in 6.10 by hand: the **Sieve of Eratosthenes** using a `bool[]`, **Fisher-Yates** for shuffling, and **Selection Sort**. Multidimensional arrays (`float[,]`, 6.2.9, page 467) are rectangular; the two-dimensional indexer `m[i, j]` makes working with matrices convenient. A `Random` with a fixed initial value (seed) always produces the same sequence, which makes randomness testable (6.2.4, page 459).

## Strings (6.3, page 472)

A `string` is **immutable**: `s.ToUpper()` does not modify `s` but returns a new string; `s += c` in a loop copies the entire text each time. `StringBuilder` with `Append` is available for constructing long texts (6.3.2, page 479). In 6.3.1.2 (page 473) the book shows, among others, `IndexOf`, `Substring`, `Replace`, `StartsWith`, `ToUpper`/`ToLower`, and `CompareTo`; `Split`, `Insert`, and `Trim` used in the exercises are not in the book but in the BCL documentation. `foreach (char c in s)` iterates through the characters, and a `char` is treated directly as an `int`.

## Enumerations (6.4, page 480)

An `enum` assigns names to a handful of integers. The cast `(Temperament)13` always succeeds, even if no such value exists; `Enum.IsDefined` checks for this, and a validating setter prevents it. `(int)t` retrieves the number. Beyond the book: `ToString()` returns the name, and `Enum.Parse` and `TryParse` read it (with `ignoreCase`).

## Tuples (6.6, page 486)

A tuple `(string First, string Last, bool FirstPalin, bool LastPalin)` returns multiple values from a method without declaring a class (6.6.5, page 493). When receiving it, you **deconstruct** it: `var (_, last, _, pal) = AnalyzeName(...)` (6.6.4, page 491); `_` discards an element. A class can also be deconstructed in this way using its own `Deconstruct(out …)` method (6.6.6, page 494). The tuple assignment `(a, b) = (b, a)` swaps two variables without using an auxiliary variable.

## Records (6.7, page 495)

`public record Artikel(string Name, int Menge)` creates, in a single line, a constructor, `init` properties, `Deconstruct`, **value equality** (`==`, `Equals`, `GetHashCode`), a readable `ToString()`, and the basis for `with` expressions (6.7.2 and 6.7.3, pages 498 and 499): `this with { Menge = 5 }` returns a modified copy and leaves the original unchanged. Records are reference types that behave like value types; `record struct` (6.7.5) turns them into true value types. Their inheritance is covered in Level 7.

## Anonymous Classes and `using` Aliases (6.5 and 6.8, pages 483 and 504)

`new { Name = "Otto", Alter = 35 }` creates an object of an anonymous class whose name is assigned by the compiler (it cannot be written in C#), with read-only properties; the variable must be declared as `var`. This is intended for short-lived intermediate results; you'll see it all the time in Level 13 (LINQ). `using Koordinate = (double X, double Y);` gives a long type a short name for a file without creating a new type.

Further reading in the book: 6.1 through 6.8 (pages 431 through 505); 6.9 (RSS reader with WPF) is not part of the course. The exercises in 6.10 (page 537) serve as templates for the sieve, lotto, matrix, lucky number, and line wrapping.
