# default(T) and Nullable<T>

Read section **8.7, “default Operator”** (page 605), **8.5 Generic Methods** (page 602) and **8.3 `Nullable<T>` as an example of generic structures** (page 598), along with 8.3.2 on the null-coalescing operators (page 600).

A generic method has its own type parameter: `BeschreibeDefault<T>()` is called with `Werte.BeschreibeDefault<int>()`. Open `Werte.cs`:

1. `BeschreibeDefault<T>()`: `default(T)` returns the default value of the type: 0 for numbers, `false` for `bool`, `null` for reference types and for `Nullable<T>`. Return `"null"` if the value is null; otherwise, return the value's `ToString()`.
2. `ErstesOderDefault<T>(T[] arr)`: the first element or `default` if the array is empty. Here, the literal `default` is sufficient; the compiler knows `T`.
3. `Summe(int?[] werte)`: `int?` is `Nullable<int>`, a structure with `HasValue` and `Value`. Sum only the values that exist.
4. `OderErsatz(int? wert, int ersatz)`: The null-coalescing operator `??` does this in a single line.

When calling `ErstesOderDefault([5, 6])`, you don't need to specify `<int>`: The compiler infers `T` from the argument (type inference).

The signature `T? ErstesOderDefault<T>` is given. The `?` after an unconstrained `T` does **not** make it a `Nullable<T>`: for `T = int` the return type stays `int`. What exactly it means comes in Chapter 15 (15.1.1, page 952); you do not need it for this exercise.
