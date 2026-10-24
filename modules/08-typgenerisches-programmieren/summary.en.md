# Generic Programming

C# checks types during compilation. For a long time, a stack designed to hold "anything" had to choose between an `object` element type (with casts, boxing, and runtime errors) or a separate instance of the class for each element type. Generic types solve this problem (8.1, page 589): The class receives a **type parameter**, which is replaced by a concrete type only when the class is used.

## Generic Classes (8.2, page 591)

The `class SimpleStack<T>` class declares `T` as a placeholder; in the body, it stands for fields (`T[] data`), parameters (`Push(T element)`), and return types (`T Pop()`). `new SimpleStack<double>(10)` **instantiates** the class; `SimpleStack<double>` and `SimpleStack<string>` are therefore two different types, even at runtime (8.4, page 601). Value types are explicitly allowed as type arguments and are not boxed; therefore, `List<int>` is vastly superior to the old `ArrayList` (8.8, Exercise 2).

## Restrictions (8.2.2, page 593)

Without any additional specifications, the compiler knows only what each `object` can do based on `T`. With `where T : IComparable<T>`, the `class` is allowed to call `element.CompareTo(other)`, while at the same time excluding types that cannot do so. Other types: a base class, class, `struct`, `new()` (for `new T()`), `notnull`, `unmanaged`; multiple types are separated by commas, with `struct` or `class` first and `new()` last. The sorted list in the example shows the typical case: inserting at the correct position requires a comparison.

Generic classes can inherit from and be inherited by other classes (8.2.3, page 596); an open generic base type requires its own type formal parameter in the derived class. What does not work: `List<object> lo = new List<string>()`. Generic classes are **invariant**; otherwise, one could use `lo` to write an `int` into a list of strings. Variation exists only for interfaces and delegates (Levels 9 and 12).

## Nullable<T> (8.3, page 598)

`int?` is the shorthand for the generic type `Nullable<int>`: a value plus the `HasValue` flag. `wert ?? ersatz` returns the value or the default (8.3.2, page 600); `??=` assigns a value only if the variable is null. Do not confuse this with `string?`, the Nullable annotation for reference types from Level 14.

## Generic Methods and Type Inference (8.5, page 602)

Even a single method can have its own type formal parameter: `static T Max<T>(params T[] werte) where T : IComparable<T>`. When calling `Serie.Max(3, 9, 4)`, the compiler infers `T = int` from the arguments; you only need to specify it when the argument list is empty (`Serie.Max<int>()`). A method that simply uses the `T` of its class (`T Pop()`), on the other hand, is not generic (8.8 Exercise 1). Series parameters (`params T[]`) accept any number of values or an array.

## Generic Extension Members (8.6, page 604)

The extension block from Level 7 becomes generic: `extension<T>(T[] arr) where T : IComparable<T>` adds properties such as `MinFirst` to all arrays of comparable elements. The classic form is a generic method with a `this` parameter: `static bool? LeadingMin<T>(this T[] arr)`. The receiver is treated as the first argument during type inference.

## default (8.7, page 605)

`default(T)`, or `default` for short, returns the default value of a type: 0, `false`, or `null` for reference types and for `Nullable<T>`. This is needed by generic code that must initialize a `T` without knowing the type; an object simply creates `new T()` with the `new()` restriction.

Further reading in the book: Chapter 8 (pages 589–608); the exercises in 8.8 (page 607) provide the quiz and `Max<T>()` for this level. `Listenwerte` in the example folder measures the boxing overhead of `ArrayList`.
