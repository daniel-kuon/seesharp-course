# Max<T>() with a generic series parameter

Read Section **8.5, “Generic Methods”** (page 602), and Exercise 3 in Section **8.8** (page 607). For more on series parameters (`params`), see **5.3.1.3.3** (page 321); the types of constraints are listed in **8.2.2** (page 593).

In Section 8.5, the book presents a method `Max<T>(T x, T y)` for two values. The exercise calls for a version that handles any number of values. Open `Serie.cs`:

1. `Max<T>(params T[] werte)` and `Min<T>(params T[] werte)`: Call with `Serie.Max(3, 9, 4)` or with an array. Iterate through the series using `CompareTo`; if the series is empty, throw an `ArgumentException`.
2. `MaxOderNull<T>(params T[] werte)` returns `null` instead of throwing an exception. For `T?` to be a `Nullable<T>`, `T` must be a value type: Add the constraint `where T : struct, IComparable<T>` (the order is required: `struct` first). The test checks the constraint using reflection.
3. `Klemme<T>(wert, min, max)` clamps a value to a range.

In `Program.cs`, try calling `Serie.MaxOderNull("a", "b")`: The compiler will reject the call because `string` is not a value type.
