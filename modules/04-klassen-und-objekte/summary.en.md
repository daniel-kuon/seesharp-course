# Classes and objects

A **class** describes which data its objects carry (fields) and what can be done
with them (methods, properties). An **object** is a concrete instance, created
with `new`. In this level we build a class `Bruch` (fraction) step by step,
exactly as the book does in chapter 5 (from page 285): first fields and
properties with validation, then overloaded methods, constructors, static
members, recursion and finally overloaded operators. Every exercise builds on
the state of the previous one; the book's sample folder `Bruch/b0` to `b7` is
the template.

## Terms (5.1, page 286; 5.15 exercise 7, page 428)

Before you write code you should be able to name what you see in the source:
instance variable (field), class variable (static field), constructor, instance
and class method, instance and static property, local variable, method call,
object creation, operator overloading. The first quiz of this level asks
exactly that.

## Fields and properties (5.2 and 5.5, pages 300 and 361)

Fields are private and are initialised automatically when the object is
created (`int` to 0, references to `null`); an initialiser such as `nenner = 1`
sets a different start value. To the outside the class exposes **properties**
with `get` and `set`. The setter validates (`Nenner` must never become 0,
`Etikett` is cut to 40 characters); the getter must not access the property
itself, otherwise it calls itself endlessly until the stack overflows (5.15
exercise 3, page 425). Automatically implemented properties (`{ get; set; }`)
save you the field; since C# 14 the `field` keyword allows a validating setter
in them too (5.5.2.2, page 365).

## Methods and overloading (5.3, page 308; 5.3.5, page 334)

An **instance method** works with the state of the object: `Kuerze()` changes
numerator and denominator, `Addiere(Bruch b)` combines a second object. Several
methods may share a name as long as their parameter lists differ
(**overloading**); the return type is not part of the signature.
`Addiere(int, int, bool)` is the second overload, which reports through `bool`
whether the operation was valid.

## Constructors (5.4.3, page 340)

A constructor carries the class name and initialises the object. Several
constructors with different parameter lists are allowed; whoever writes an
explicit constructor loses the automatic default constructor and has to declare
it when needed. Assign through the properties in the constructor, not through
the fields, so the validation applies. Object initialisers
(`new Bruch { Zaehler = 3, Nenner = 7 }`) set properties right after the
constructor call.

## References, copies, static members (5.4.4, 5.8, pages 352 and 373)

A variable of a class type holds a **reference**. Two variables can point to the
same object; a real copy needs a method such as `Klone()`. Static members belong
to the class, not to the object: an instance counter `Anzahl`, a factory method
`BenDef()` or a **static constructor**, which runs once on the first access to
the class and sets defaults.

## Recursion (5.9.2, page 382)

A method may call itself. This works when every call shrinks the problem and a
directly solvable case (the base case) ends the chain: the gcd of `a` and `b` is
the gcd of `b` and `a % b` until the remainder is 0. Without a base case the
stack overflows. Factorial and Fibonacci numbers are the classic examples; the
recursive Fibonacci variant also shows that recursion can get expensive.

## Overloading operators (5.9.3, page 385)

`operator +` is a static method that returns a new object and leaves its
operands unchanged. Since C# 14, `+=` can be overloaded separately as an
instance operator that changes the existing object and creates no new instance.

Further reading in the book: chapter 5, sections 5.1 to 5.9 (pages 286 to 388);
the exercises in 5.15 (page 424) are the template for the quiz and the
recursion exercise.
