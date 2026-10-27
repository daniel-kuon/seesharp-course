# Generic Math: IAdditionOperators and operator checked +

Read sections **9.1.2** "**Static Members**" (page 622, especially 9.1.2.2 "Abstract Executable Members," page 623), **9.1.3 "Generic Math**" (page 625), and Exercise 3 in **9.6** (page 655). As a reminder regarding `checked`, see Level 3 (4.6).

Since C# 11, interfaces have been allowed to require **static abstract** members, including operators. The generic math of the BCL is built on this: A type that implements `IAdditionOperators<T, T, T>` promises a plus operator, and generic code can write `a + b`. `Bruch` already satisfies this interface via `operator +` from Level 4.

1. In `Bruch.cs`: Add `public static Bruch operator checked +(Bruch b1, Bruch b2)`. It evaluates the numerator and denominator using `checked(...)`, thereby throwing an `OverflowException` instead of silently overflowing; the label is built as in the normal `+` (`$"{b1.Etikett} + {b2.Etikett}"`), and the result is reduced. In a `checked` block, the compiler selects this variant.
2. In `Rechner.cs`: `Summe<T>(T first, params T[] rest)` performs summation using `+=`; the `where T : IAdditionOperators<T, T, T>` constraint makes this possible for `int`, `double`, `decimal`, and `Bruch` alike.
3. `IKombinierbar<TSelf>` is a custom interface with a `static abstract TSelf operator +`. Implement the operator in `Glas` (combine stickers with spaces) and `Gras` (add sizes), and write `Kombinierer.Combine<T>(params T[])`, which concatenates all elements with `+`.

> **Deep Dive (optional):** The checked version of the instance operator `+=` is not in the book; it combines `void operator +=` from 5.9 (page 387) with the checked variant from 9.6. In `Bruch.cs`, add `public void operator checked +=(Bruch b)`, which updates the numerator and denominator with `checked(...)`. Without it, the compiler picks the normal `+=` even in a `checked` block, and an overflow goes unnoticed. The test `GenerischeMathematikTests.Checked_PlusGleich_wirft_bei_Ueberlauf` checks this; it is extra and not needed to pass the exercise.
