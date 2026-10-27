# Delegates, lambda expressions, and events

A **delegate** is a type for method references (Chapter 10, page 657): It describes a signature, and an object of this type points to a method with exactly that signature. This allows behavior to be passed along, stored, and called later, just like a value. In this level, you’ll learn about delegates, the shorthand notation using lambda expressions, and, building on that, events.

## Delegates (10.1.1 and 10.1.2, pages 659–663)

`delegate double Operation(double a, double b);` declares a delegate type. For compatibility, the parameter list and return type matter; the names do not. A delegate object is created from a **method group** (`Operation op = Rechner.Addiere;` without parentheses) and is called like a method (`op(2, 3)`, equivalent to `op.Invoke(2, 3)`). If it points to an instance method, it stores the target object; delegate objects are immutable. Because a delegate is a regular parameter, a method such as `Reduziere(Operation op, double[] werte)` can have its behavior determined from the outside.

## Multicast delegates (10.1.3 and 10.1.4, pages 663–665)

Using `+=` and `-=`, a delegate's **invocation list** grows or shrinks; each change creates a new object. The invocation starts all targets in the order they were registered; if a return value is present, only the **last** target counts. To retrieve all results, you have to call the targets one by one (see Deep Dive). If the list is empty, the variable is `null`; so a null check precedes the call (page 664), or, shorter, `aktion?.Invoke(...)` (null-conditional operator, a preview of 15.1.5.2, page 971). Whether to choose a delegate or an interface as the callback mechanism is a design decision (10.1.4): A delegate specifies exactly one method—the method name doesn’t matter—and a lambda performs the task on the spot. An interface can require multiple related capabilities.

## Anonymous Functions, Lambdas, and Closures (10.1.5, pages 665–675)

Instead of writing a named method, you create the delegate inline: as **an anonymous method** (`delegate (int x) { ... }`, older) or as **a lambda expression**: `x => x * 2` (expression body) or `(a, b) => { ...; return ...; }` (statement block). The target type determines which delegate type is created. The predefined generic delegates cover almost everything: `Func<..., TResult>` with a return value, `Action<...>` without one, and `Predicate<T>` for conditions. `List<T>` uses them: `FindAll(Predicate<T>)` (page 670 and Exercise 2 in Section 10.3, page 688) and `Sort(Comparison<T>)` (10.1.4, page 664); for more list methods, see Deep Dive.

A lambda can use variables from the enclosing method. It **captures the variable**—not its value—and keeps it alive for as long as the delegate object (**closure**) exists. Each call to the factory method creates its own variable and thus its own state (`Zaehler()`). You need to be careful with loops: If a lambda captures the variable of a `for` loop, all lambdas share it; creating a copy for each iteration or using `foreach` solves this.

## Covariance and Contravariance (10.1.6, pages 675–677)

As with interfaces (Level 9), the following applies to generic delegates: `Func<out T>` is covariant (`Func<string>` works as `Func<object>`), while `Action<in T>` and `Comparison<in T>` are contravariant (`Action<object>` works as `Action<string>`).

## Events (10.2, pages 678–688)

An **event** (`event`) is a class member that protects a delegate: It is backed by a private delegate variable, and only `+=` and `-=` are exposed externally (10.2.1). External classes can therefore subscribe and unsubscribe, but they can neither raise the event nor replace it by assignment (`=`). A public delegate field allows both, so it is not a substitute. The standard pattern: `EventHandler<TEventArgs>` as the type, a custom `EventArgs` derivation for user data, and a `protected virtual void OnXyz(...)` method that triggers the event with `Xyz?.Invoke(this, e)`; derived classes override it to control when the event is raised (10.2.3, pages 687–688). A handler method takes the parameters `(object? sender, TEventArgs e)` (10.2.2, page 682); `sender` is the event source and can be cast back if multiple objects use the same method. Anyone who subscribes should unsubscribe: Through the invocation list, the provider keeps the subscriber alive. A lambda can only be unsubscribed if the same delegate object has been retained.

Further study in the book: Chapter 10 (pages 657–689); the exercises in 10.3 (pages 688–689) supply the quiz questions and `ListLE(k)` of this level.

## Deep Dive (optional)

> Not in the book. These topics are optional – examples of what to look into next.

- `GetInvocationList()` returns a delegate's invocation list as an array. It gives you each target separately, for example to count the targets (Exercise 02) or to collect all return values.
- More `List<T>` methods that take delegates (Exercises 03 and 11): `Exists(Predicate<T>)`, `Find(Predicate<T>)` (first matching element or `default`), `RemoveAll(Predicate<T>)` (removes from the list itself and returns the count), and `ForEach(Action<T>)`.
- `string.CompareOrdinal(a, b)` compares strings character by character by their numeric codes, independent of language and culture.
- `EventArgs.Empty` is a ready-made empty `EventArgs` object for events without payload.
