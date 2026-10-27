# Exception Handling

If a method cannot perform its task, it reports this by throwing an **exception**: an object that describes the error and travels upward from the point of the error through the callers until someone handles it (Chapter 13, page 885). If no one catches the exception, the runtime terminates the program and outputs the message and the stack trace (in the book: the call sequence, or the `StackTrace` property) (13.1 and 13.2, pages 886 and 888). The top entry in the stack trace lists the method in which the exception was thrown; the subsequent entries list the callers.

The most important rule: **Error prevention takes precedence over exception handling.** If you check whether the divisor is zero before performing the division, you don't need to catch a `DivideByZeroException`. Exceptions are intended for errors that cannot be reasonably ruled out in advance.

## The try Statement (13.3.1, page 890)

```csharp
try { /* risky code */ }
catch (FormatException ex) { /* handle */ }
catch (ArithmeticException) { /* broader, so it comes further down */ }
finally { /* runs (almost) always */ }
```

* `catch` blocks are checked from top to bottom: **specific classes before general ones**. Placing a general block before a specific one results in a compiler error.
* The variable (`ex`) provides access to `Message`, `StackTrace`, `InnerException`, and `Data`; `ex.GetType().Name` returns the type name.
* An **exception filter** (in the book: `when` clause) `catch (IOException ex) when (...)` only catches the exception if the condition is met (13.3.1.2, page 891).
* The `finally` block runs **almost always**: after a normal termination, after a `return`, and after an exception. Only an endless loop or `Environment.Exit()` can prevent it. This is where you clean up, such as closing files (13.3.1.3, page 895). In nested `try` statements, the exception propagates upward, and every `finally` block along the way is executed (13.3.2).

## Error Communication (13.4, page 905)

A method can report errors via a return value or an exception. The caller must check return codes; they make the code hard to follow and are easy to ignore. Exceptions cannot be overlooked, and they automatically travel to the best-equipped method. The choice depends on the **probability of an error**: Frequent errors (mistyped input, end of file) are reported via a return value, rare ones via an exception. The **Try pattern** `bool TryParse(string s, out int ergebnis)` returns success as the return value and the result via `out`; it never throws.

## BCL Exception Classes (13.5, page 911)

All of them extend `Exception`. The most important ones are: `ArgumentException` and its subclasses `ArgumentNullException` and `ArgumentOutOfRangeException` (incorrect argument), `InvalidOperationException` (object in an invalid state), `NotSupportedException`, `FormatException`, `ArithmeticException` (including `DivideByZeroException` and `OverflowException`), `IndexOutOfRangeException`, and `KeyNotFoundException`. `checked` arithmetic (Level 3, book 4.6.1) throws `OverflowException` on overflow; `int.Parse()` throws `FormatException` for invalid text and `OverflowException` for numbers that are too large.

## Throwing Exceptions (13.6, page 913)

* `throw new ArgumentOutOfRangeException(nameof(x), x, "…")` throws an exception. As an expression, `throw` can also be used in `a ?? throw …` or `cond ? x : throw …`. `ArgumentNullException.ThrowIfNull(arg)` is the shorthand for null checks.
* In a `catch`, **`throw;`** rethrows the same exception and preserves the stack trace. `throw ex;` throws it anew and overwrites the origin: a classic error.
* If you wrap the cause in a more descriptive exception, pass the original exception as an **`InnerException`**: `throw new InvalidOperationException("…", ex);`

## Custom Exceptions (13.7, page 916)

You subclass `Exception` (or an appropriate subclass), provide the `()`, `(string)`, and `(string, Exception)` constructors, and add properties for additional information. For a single detail, the `Data` collection of a BCL exception is often sufficient. The exercises at the end of the chapter (13.8, page 920) review all of this: the syntax diagram for `try`, the effect of `OverflowException` in the `Sequenzen` example, `Log2` with argument validation, and the `SimpleStack` with `ArgumentOutOfRangeException`.
