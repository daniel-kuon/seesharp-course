# Interfaces

An interface is a declaration of commitment: it lists the methods, properties, indexers (and events) that a type must provide, without implementing them itself (Chapter 9, page 609). Anyone who declares adherence to an interface—such as `class Bruch : IComparable<Bruch>`—must fulfill that commitment and will be accepted wherever the interface is specified as a type. The BCL is full of examples: `String` implements eight interfaces, `Array.Sort` requires `IComparable<T>`, and `foreach` requires `IEnumerable<T>`.

## Define and Implement (9.1 through 9.3, pages 614 through 646)

Interface members are implicitly `public` and abstract; there are no instance fields. A class or **structure** can implement any number of interfaces, but inherits from only one base class. This is the answer to the question in the book about the difference between interfaces and abstract classes (9.6, Exercise 2): Abstract classes pass state and code down a hierarchy, while interfaces describe a capability that cuts across all hierarchies. As a reference type, an interface allows mixed arrays (e.g., `IForm[]` containing circles and squares); when a structure is assigned to an interface variable, it is **boxed**, and changes to the original are not reflected in the copy (9.3.2, page 645). Since C# 8, interfaces may contain concrete members with default implementations (9.1.1.2, page 616).

## Explicit Implementation (9.4, page 646)

If two interfaces require members with the same name but different meanings, or if a member is not supposed to appear in the class’s public interface, you implement it **explicitly**: `int IMesser.Wert() => 2;` without any modifiers. The method can then only be called via a reference of the interface type. The BCL does this all the time: The non-generic `IEnumerable.GetEnumerator()` is usually explicit so that only the generic version remains visible.

## IComparable<T> and ICloneable (9.2, page 640; 9.6, Exercise 1)

`CompareTo` returns a negative, zero, or positive value and enables `Array.Sort` and `List<T>.Sort`; `Bruch` performs a comparison using cross-multiplication (in `long` to prevent overflow). Generic interfaces are preferable to the old non-generic ones: type-safe, no casting, no boxing for structures (9.2.3, page 642). `ICloneable` is one such legacy case: its `object Clone()` method requires a cast, so the custom, type-safe `Klone()` method remains useful alongside it; `MemberwiseClone()` returns a shallow copy.

## IEnumerable<T>, IEnumerator<T>, and yield (9.5, page 647)

`foreach` uses `GetEnumerator()` to obtain an enumerator and calls `MoveNext()` until it returns `false`; `Current` is the current element. The protocol shows how to write an enumerator by hand (a nested class with Position, `MoveNext`, `Current`, and `Reset`); using `yield return`, the compiler generates the state machine itself (9.5.2, page 651). Iterators can also be named methods or properties (`RangeIt`, `DownIt`, `RangeItUpDown`; 9.5.3, page 652); `yield break` terminates them prematurely. Important: Iterators are **lazy**; their body is not executed until the iteration begins. LINQ in Level 13 is built entirely on this concept.

## Static Abstract Members and Generic Mathematics (9.1.2, 9.1.3, pages 622–630)

Since C# 11, an interface can require static members and even operators (`static abstract TSelf operator +`). The BCL uses this for `IAdditionOperators<T, T, T>`, `INumber<T>`, and related interfaces: Generic code may write `a + b` as long as `T` implements the interface, and this applies equally to `int`, `double`, `decimal`, and custom types such as `Bruch`. The `checked` variant of an operator (`operator checked +`) is selected in `checked` contexts and is intended to throw an `OverflowException` in case of overflow when called with `checked(...)`; the default implementation in the interface does not do this (9.6 Exercise 3).

## Covariance and Contravariation (9.1.5, page 634)

Generic classes are invariant (Level 8). Generic interfaces may mark type formal parameters as `out` (output only) or `in` (input only): `IEnumerable<out T>` is **covariant**; a sequence of circles is treated as a sequence of figures (9.1.5.1); `IComparable<in T>` is **contravariant**; a comparer for figures also sorts circles (9.1.5.2). If `T` appears in both positions (`IList<T>`), only invariance remains.

Further reading in the book: Chapter 9 (pages 609–656); the exercises in 9.6 (page 655) cover `IComparable`, `ICloneable`, the `operator checked +` operator, and `RangeItUpDown` for this level. Static polymorphism (CRTP, 9.1.2.3) is supplementary material.
