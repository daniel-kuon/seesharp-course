# Concepts: What is OOP? What is .NET?

This level does not include a programming exercise. Chapters 1 and 2 of the book (pages 1 through 60) explain the concepts that all subsequent chapters will build upon. If you get a solid grasp of them now, you won’t have to guess what an assembly or a namespace is later on when you’re programming. Three short quizzes will test whether you’ve mastered the concepts.

## Classes, Objects, Messages (1.3, page 9)

From an object-oriented perspective, a **program** is a set of objects that communicate with one another. A **class** is the blueprint: It defines what data its objects contain (**fields**) and what operations can be performed on them (**methods**). An **object** is a concrete instance created at runtime using the `new` keyword. The book introduces this concept using the example of the `Bruch` class, which stores the numerator and denominator and can simplify itself.

**Encapsulation** means that fields are protected from direct external access. Other classes interact with the object through public methods or **properties**: a pair of read and write accesses that behaves like a field in the source code but can enforce rules (a denominator must never be 0). A method call such as `b.Kuerze()` is a **message** to the object `b`: the caller specifies what should happen, and the object decides how.

**Inheritance** allows a class to adopt and extend the fields and methods of a base class; **polymorphism** allows the same method call to perform different actions depending on the actual object type. Both topics are covered in detail in Chapter 7; for now, it is sufficient to be able to match the terms.

## Entry Class and Main (1.5, page 12)

Every program needs exactly one entry point: the static `Main()` method of a startup class. Objects are created and methods are called from there. Starting with C# 9, the compiler can generate this class itself from top-level statements; the principle remains the same.

## Compilers, IL, and Assemblies (2.3 and 2.4, pages 25 and 30)

The C# compiler does not generate machine code, but rather **IL** (Intermediate Language), a processor-independent intermediate language. The IL code, along with **metadata**, is stored in a file called an **assembly** (`.dll` or `.exe`). The metadata describes the types contained within, the version, the culture, and dependencies on other assemblies. An assembly is therefore the unit that is built, deployed, and versioned.

A **namespace** is something else: a logical prefix for type names that prevents name collisions (e.g., `System.Console`). An assembly can contain types from many namespaces, and a namespace can span many assemblies. The `using` directive imports a namespace, not an assembly; assemblies are included via project references.

## CLR, JIT, and AOT (2.5, page 42)

The **Common Language Runtime** executes IL code. Its **JIT** (Just-In-Time) **compiler** translates each method into machine code for the local CPU the first time it is called. In addition, the CLR handles automatic memory deallocation (**garbage collection**), exception handling, type safety, and multithreading; because of this support, IL code is also referred to as **managed code**. Alternatively, you can compile to machine code at build time (**AOT**, Ahead-Of-Time): this results in a faster startup, but the code is platform-specific and has limitations.

## BCL (2.6, page 47)

The **Base Class Library** is the included collection of assemblies containing basic types such as `String`, `Console`, and `Math`. It is part of the runtime environment and is platform-independent; GUI libraries such as WPF are extensions that run only on Windows. The BCL is primarily written in C# itself, and because all .NET languages generate the same IL code, C# libraries can also be used from VB.NET or F#.

## .NET Implementations (2.2, page 21)

The classic **.NET Framework** is Windows-specific and is no longer being developed. Today's **.NET** (without any qualifiers; Version 10 in this course) is cross-platform and the right choice for new projects, even if they are intended to run only on Windows.

Further Study: Chapter 1 (starting on page 1) and Chapter 2 (starting on page 19); the summaries in 1.7 and 2.7 are good for review.
