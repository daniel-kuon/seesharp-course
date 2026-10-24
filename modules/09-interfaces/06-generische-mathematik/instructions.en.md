# Generic Mathematics: IAdditionOperators and operator checked +

Read sections **9.1.2** "**Static Members**" (page 622, especially 9.1.2.2 "Abstract Executable Members," page 623), **9.1.3 "Generic Mathematics**" (page 625), and Exercise 3 in **9.6** (page 655). As a reminder regarding `checked`, see Level 3 (4.6).

Since C# 11, interfaces have been allowed to require **static abstract** members, including operators. The generic mathematics of the BCL is built on this: A type that implements `IAdditionOperators<T, T, T>` promises a plus operator, and generic code can write `a + b`. `Bruch` already satisfies this interface via `operator +` from Level 4.

1. In `Bruch.cs`: Add `public static Bruch operator checked +(Bruch b1, Bruch b2)`. It evaluates the numerator and denominator using `checked(...)`, thereby throwing an `OverflowException` instead of silently overflowing; labeled `"b1 + b2"`, result truncated. Similarly, `public void operator checked +=(Bruch b)`. In a `checked` block, the compiler selects these variants.
2. In `Rechner.cs`: `Summe<T>(T first, params T[] rest)` performs summation using `+=`; the `where T : IAdditionOperators<T, T, T>` constraint makes this possible for `int`, `double`, `decimal`, and `Bruch` alike.
3. `IKombinierbar<TSelf>` is a custom interface with a `static abstract TSelf operator +`. Implement the operator in `Glas` (combine stickers with spaces) and `Gras` (add sizes), and write `Kombinierer.Combine<T>(params T[])`, which concatenates all elements with `+`.
