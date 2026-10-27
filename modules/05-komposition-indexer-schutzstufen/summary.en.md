# Composition, Indexers, Access Levels

Level 4 explored the `Bruch` class from the inside out. This level examines the interaction **between multiple** classes: objects that contain other objects, classes nested within classes, classes that behave like arrays, and the question of what a class exposes to the outside world and what it keeps to itself. Sections 5.10 through 5.13 (pages 388 through 400) are the required reading; in addition, there are two exercises from sections 5.15 and 7.16.

## Aggregation and Composition (5.10, page 388)

An object can hold other objects as fields. The `Aufgabe` class has three `Bruch` objects: two arguments and the solution. It does not perform calculations itself but **delegates them**: `lsg.Addiere(b2)`. The book distinguishes between loose aggregation (the part could exist independently of the whole) and tight composition (the part is created and destroyed along with the whole); in C#, both look the same—namely, as a field of a class type. A `readonly` field only locks the reference, not the object behind it: `NeueWerte()` may modify the fractions, but cannot create new ones.

## Override ToString (7.16 Exercise 5, page 588)

Every class inherits `ToString()` from `Object`; the inherited version returns only the type name. You can override it with `public override string ToString()`, and `Console.WriteLine(b)`, `$"{b}"`, and `"x" + b` automatically use the new version. This is your first introduction to `virtual` and `override`; Level 7 explains the mechanism in full.

## Nested Classes (5.11, page 391)

A class may be declared inside another class. The inner class has access to all members of the outer class, including private ones, but requires a reference to an object of the outer class (`f.name`) to access instance members. Without a modifier, a nested class is private and invisible from the outside; with the `public` modifier, it becomes accessible as `Familie.Sohn`. `class Sohn(Familie f, string name, int alter)` primary constructors save boilerplate code; in the book's example the parameters are explicitly copied into `readonly` fields (unlike records, no properties are created from them, see 5.4.3.2, page 344).

## Indexer (5.12, page 393)

An indexer is a property with parameters: `public Person this[int i] { get … set … }`. This allows you to access your own collection as if it were an array (`pl[1]`, `pl[1] = …`). The book illustrates this using a singly linked list whose nodes are a private nested class `Element`. Indexers may be overloaded (5.12.2, page 397): `pl["Ilse"]` searches by first name. Multiple parameters are also allowed (5.12.3): the matrix in Level 6 uses `this[int zeile, int spalte]`.

## Access Levels (5.13, page 398)

For non-nested classes, the only options are `public` and `internal`; if no access modifier is specified, the default is `internal` (5.13.1). For members, `private` (default), `protected`, and combinations are also available (5.13.2, page 399). `internal` means **“internal to the assembly**”: Another project cannot see the member, even if it references the library. This is exactly what you’ll practice with `FractionLib`: The `Bruch` class is moved into a class library (Library project type, no `Main` method), a console project sets a project reference, and imports the `de.bebagoe.fraction` namespace using `using`. A helper method like `Ggt` is made `internal` so that the library’s interface remains small.

## Calculated Properties and Pure Methods (5.15 Exercise 4, page 425)

The vector class `R2Vek` repeats Level 4 with a new subject and introduces two patterns that recur constantly: A **computed property** such as `Laenge` does not have a field but is recalculated each time it is read; thus, it can never become outdated. And the difference between a method that modifies the object (`Addiere`) and one that returns a new object and leaves the operands unchanged (`Plus`). The latter is also the behavior of the `operator +` from Level 4 and of records in Level 6.

Further study in the textbook: Sections 5.10 through 5.13 (pages 388 through 400); Section 5.14 (WPF interface for fractions, page 400) is not required for this course.
