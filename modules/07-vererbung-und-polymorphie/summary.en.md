# Inheritance and Polymorphism

Chapter 7 (starting on page 543) introduces the second major principle of object-oriented programming: A class can **inherit** from another class, adopting, extending, and modifying its members. The standard example is a shape hierarchy consisting of a `Figur` (figure), a `Kreis` (circle), and a `Rechteck` (rectangle); all the exercises in this level use this hierarchy.

## Derived Classes and Constructors (7.3 through 7.5, pages 547 through 554)

`class Kreis : Figur` makes `Kreis` a subclass: Every `Kreis` object contains all the fields of `Figur` and can be used anywhere a `Figur` is expected (7.2, the general type system, page 545). Every constructor calls a base constructor before its own body runs; with `: base(x, y)` you choose which one (7.4.1, page 549). Only the field initializers of the derived class run even earlier (7.4.2, page 550). Without `: base(...)`, the compiler calls the parameterless base constructor; if there is none, compilation fails (7.16 Exercise 1). Private members are inherited but not accessible in the subclass; `protected` opens them to heirs and nobody else (7.5, page 554).

## Base Class References and Type Checks (7.7 and 7.8, pages 561 and 563)

A variable of type `Figur` may point to a `Kreis`; this allows you to manage mixed collections such as `Figur[]`. The `GetType()` method reveals the object's actual type; you can access it safely using the type check `if (f is Kreis k)`, which immediately returns a suitable reference.

## Hiding versus Overriding (7.6 and 7.9, pages 555 and 566)

If a subclass declares a member with the same signature, it **hides** the inherited member (`new`); this only applies to references of the subclass’s type; a `Figur` reference continues to call the base version. **Overriding** with `virtual` in the base class and `override` in the subclass, on the other hand, replaces the method for the object regardless of which reference is used to access it: the dynamic type is what matters. This is polymorphism. `base.Wo()` calls the base version from within the override. `sealed` seals an overridden method or an entire class against further modification (7.10, page 570). Overloading (same name, different parameters) is a third, independent concept; static methods can be overloaded and hidden, but not overridden (7.16 Exercise 3).

## Abstract Classes (7.13, page 577)

An `abstract` class cannot be instantiated; abstract members have no body and must be implemented with `override` in the first concrete subclass. This way the base class forces every figure to supply an area, instead of specifying a meaningless 0. The Liskov Substitution Principle (7.14, page 579) states the obligation of subclasses: Wherever a `Figur` is expected, every subclass must behave like a figure.

## Record Hierarchies (6.7.4, page 502; 7.16 Exercise 4)

Records inherit too. A positional record passes its parameters on to the primary constructor of the base with `: Figur(X, Y)`; if the argument list is missing, the parameterless base constructor runs and the values are lost (warning CS8907). Value equality takes the exact type into account (`EqualityContract`): A circle is never equal to a figure with the same position.

## Extension Members (7.15, page 581)

Extension members retrofit third-party types—including sealed types—without modifying them: `pi.High(2)` is actually `DoubleExtensions.High(pi, 2)`. The classic form is a static method with a `this` parameter (7.15.3, page 585). Since C# 14, an **extension block** `extension(double arg) { … }` bundles methods and properties and also allows static members and operators; since those need no receiver, the book puts them in a separate block `extension(double) { … }` without a receiver parameter (7.15.2, page 583). Real members always take precedence over extensions, and extensions have no access to private members of the extended type (7.15.1, page 582). This material is new; many sources on the web only know the classic form with `this`.

Further study in the book: Chapter 7, Sections 7.1 through 7.15 (pages 543 through 586); the exercises in 7.16 (page 586) provide the correction, quiz, and record exercise for this level.
