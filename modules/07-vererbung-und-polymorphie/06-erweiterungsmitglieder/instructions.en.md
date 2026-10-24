# Extension Members (C# 14)

Read section **7.15**, "**Extension Members"** (page 581): 7.15.1 General Rules (page 582), 7.15.2 Extension Blocks Starting with C# 14 (page 583), and 7.15.3 Extension Methods with a `this` Parameter (page 585). This is new material from C# 14; there isn’t much about it online yet—the book is the primary source.

With extension members, you can extend third-party types, even sealed ones like `double` or `string`. Open `DoubleExtensions.cs`; the blocks are already there, but the bodies are missing:

1. In the `extension(double arg)` block (instance members; `arg` is the receiver): `High(expo)` returns `Math.Pow(arg, expo)`; `NumEquals(other)` checks whether the relative deviation `|arg − other| / |arg|` is less than `double.DiffThreshold`; `EqualsPi` uses `NumEquals` with `Math.PI`.
2. In the `extension(double)` block (static members, no receiver): `DiffThreshold` is `1.0e-14`, `NumEqualsPi(arg)` calls `arg.NumEquals`, and the `^` operator raises the argument to a power (`2.0 ^ 3.0` equals 8).
3. In `StringExtensions`: `Empty(this string? arg)` is a classic extension method (`true` only for an empty, non-null string); `NullOrEmpty` in the extension block is `true` for `null` or empty.

Note: `s.Empty()` also works when `s` is null, because it actually calls `StringExtensions.Empty(s)`.
