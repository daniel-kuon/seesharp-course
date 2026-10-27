# Generic Programming

C# checks types during compilation. For a long time, a stack meant to hold "anything" had to choose between an `object` element type (with casts, boxing and runtime errors) and a separate copy of the class for each element type. Generic types solve this (8.1, page 589): the class gets a **type parameter** (the book: *Typformalparameter*), which is replaced by a concrete type only when the class is used.

## Generic Classes (8.2, page 591)

`class SimpleStack<T>` declares `T` as a placeholder; in the body it stands for fields (`T[] data`), parameters (`Push(T element)`) and return types (`T Pop()`). `new SimpleStack<double>(10)` **makes the class concrete** (a closed constructed type); `SimpleStack<double>` and `SimpleStack<string>` are then two different types, even at run time (8.4, page 601). Value types are explicitly allowed as type arguments and are not boxed; that is why `List<int>` is far superior to the old `ArrayList` (8.8, Exercise 2).

## Constraints (8.2.2, page 593)

Without a constraint, all the compiler knows about `T` is what every `object` can do. With `where T : IComparable<T>`, the class may call `element.CompareTo(other)`, and at the same time types that cannot do this are ruled out. Other kinds: a base class, `class`, `struct`, `new()` (for `new T()`); `notnull` comes in Chapter 15 (15.1.1, page 952). Several are combined with commas, `struct` or `class` first, `new()` last. The sorted list in this level shows the typical case: inserting at the right position needs a comparison.

Generic classes can inherit from other classes and be inherited from (8.2.3, page 596); an open generic base needs its own type parameter in the derived class. What does not work: `List<object> lo = new List<string>()`. Generic classes are **invariant**; otherwise one could use `lo` to write an `int` into a list of strings. Generic variance exists only for interfaces and delegates (Levels 9 and 12). Arrays, by contrast, are covariant (`object[] oa = new string[2];` compiles), and the book shows the consequence: a wrong element type is only caught at run time, as an `ArrayTypeMismatchException` (page 597).

## Nullable<T> (8.3, page 598)

`int?` is the short form of the generic struct `Nullable<int>`: a value plus the flag `HasValue`. `wert ?? ersatz` returns the value or the replacement (8.3.2, page 600); `??=` assigns only if the variable is null. Do not confuse this with `string?`, the nullable annotation for reference types from Level 14.

## Generic Methods and Type Inference (8.5, page 602)

A single method can also have its own type parameter: `static T Max<T>(params T[] werte) where T : IComparable<T>`. For the call `Serie.Max(3, 9, 4)` the compiler infers `T = int` from the arguments; you only have to name it when nothing can be inferred from the arguments, for example with an empty argument list (`Serie.Max<int>()`). A method that merely uses the `T` of its class (`T Pop()`), on the other hand, is not generic (8.8, Exercise 1). Series parameters (`params T[]`) accept any number of values or an array.

## Generic Extension Members (8.6, page 604)

The extension block from Level 7 becomes generic: `extension<T>(T[] arr) where T : IComparable<T>` retrofits all arrays of comparable elements with properties such as `MinFirst`. The classic form is a generic method with a `this` parameter: `static bool? LeadingMin<T>(this T[] arr)`. In type inference the receiver counts as the first argument.

## default (8.7, page 605)

`default(T)`, or `default` for short, returns the default value of a type: 0, `false`, `null` for reference types and for `Nullable<T>`. Generic code needs this when it has to initialize a `T` without knowing the type; only `new T()` with the constraint `new()` creates an object.

Further reading in the book: Chapter 8 (pages 589–607); the exercises in 8.8 (page 607) provide the quiz and `Max<T>()` for this level. `Listenwerte` in the sample folder measures the boxing overhead of `ArrayList`.

## Deep Dive (optional)

> Not in the book. These topics are optional – examples of what to look into next.

- The constraint `where T : unmanaged` allows only value types that contain no references (in any of their fields either), such as `int`, `double` or structs made of such fields. The book only names `unmanaged` in its list of keywords.
