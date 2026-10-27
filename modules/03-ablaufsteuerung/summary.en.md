# Control Flow

Up to this point, programs have run from top to bottom. Section 4.7 of the book (starting on page 252) introduces the statements that allow a program to make decisions and repeat: `if`, `switch`, `while`, `do`, `for`, and `foreach`. Section 4.6 (page 244), which comes before it, covers overflows and underflows; be sure to read it as well, even though it’s only mentioned in passing at this level. Four exercises: two variations of the Euclidean algorithm, a debugging exercise, and a prime number test.

## Branches (4.7.2, page 253)

`if (bedingung) anweisung else anweisung` branches; multiple cases are chained together as an `else if` sequence. The condition must be a `bool`, so `if (b = false)` is not a comparison but an assignment that returns `false` and overwrites `b` in the process; the compiler only issues a warning. The **dangling** `else` is the second classic pitfall: An else always belongs to the nearest `if` without an `else`, regardless of how the code is indented. Curly braces make the intent unambiguous.

The `switch` statement compares a value to multiple constants; each case ends with a stopper, usually `break` (`return` and `goto` are also allowed). The **switch expression** (as of C# 8, 4.7.2.4, page 268) returns a value directly: `tag switch { 1 => "Montag", …, _ => "ungültig" }`. For mappings such as days of the week or categories, it is shorter and more readable than a chain of `if` statements.

## Loops (4.7.3, page 270)

The `for` loop (4.7.3.1, page 271) is a counter-driven loop: initialization, condition, and increment all on a single line. `foreach` (4.7.3.2, page 273) iterates over all elements of a collection—such as the characters of a string—without an index. `while` (4.7.3.3, page 275) checks the condition before each iteration, whereas `do … while` checks it afterward, so it runs at least once. A loop whose condition never evaluates to false is an infinite loop; a treacherous cause is a semicolon immediately following the loop header—`while (i < 100);`—which, as an empty statement, replaces the entire loop body.

`break` exits the loop immediately, while `continue` jumps to the next iteration (4.7.3.6, page 278). Both are allowed, but often a loop can be written more clearly without them: using a condition that expresses the termination, or by using `return` from a method.

## Methods with Parameters

All exercises in this level delegate the logic to static methods with parameters, such as `GgtModulo(int a, int b)`. This goes beyond what the book does at this point (the examples there work directly in `Main` with console input), but there is a reason for it: Only a method that accepts values and returns a result can be tested. A method that returns a `bool` value and answers a question (`IstPrim`) is called a predicate.

## Euclid's Algorithm, twice (4.7.4, Problem 6, page 282)

The greatest common divisor of two numbers can be determined by repeated subtraction: As long as the numbers differ, subtract the smaller from the larger; in the end both equal the GCD. This is the variant from Chapter 1. The modulo variant replaces the many subtractions with the remainder of the division: The GCD of `a` and `b` is the GCD of `b` and `a % b`; when the remainder becomes 0, the last divisor is the result. For numbers that differ greatly, this is orders of magnitude faster. You will need both variants later in the `Bruch` class.

## Overflow (4.6, page 244)

Integer types have a fixed range of values. Written as a constant expression, `int.MaxValue + 1` is already rejected by the compiler (CS0220). With variables at run time (`x = x + 1` when `x == int.MaxValue`) there is no error: the value silently wraps around to the negative boundary. If you cannot estimate intermediate results, use `long` or use `checked` to trigger an exception. There is no specific exercise on this topic in this level; keep this in mind when calculating factorials in Level 4.

Further Study: Sections 4.6 and 4.7 (pages 244–285); the exercises in 4.7.4 (page 281) serve as the basis for this level.
