# Generic Extension Members

Read section **8.6, "Generic Extension Members"** (page 604), and review section **7.15.2, "Extension Blocks"** (page 583).

The `extension<T>(T[] arr) where T : IComparable<T>` extension block retrofits **all** arrays of comparable elements. Open `ArrayExt.cs`:

1. `MinFirst` (property in the block): `null` for an empty array; otherwise, `true` if no element is smaller than `arr[0]`.
2. `Groesstes()` (method in the block): the largest element using `CompareTo`; an empty array throws an `InvalidOperationException`. Do not sort.
3. `LeadingMin<T>(this T[] arr)`: the same logic as `MinFirst`, but in the classic form of a generic extension method; here the constraint comes after the parameter list.
4. `Umgekehrt<T>(this T[] arr)`: a new array in reverse order. Nothing is compared here, so no constraint.

When calling these methods, you never specify `<int>`: `zahlen.MinFirst`, `zahlen.LeadingMin()`, `woerter.Umgekehrt()`; the compiler infers `T` from the receiver.
