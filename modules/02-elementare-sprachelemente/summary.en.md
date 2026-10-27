# Basic Language Elements

Chapter 4 of the book (starting on page 161) lays the foundation for everything that follows: program structure, output, variables and data types, input, and operators. This level covers sections 4.1 through 4.5; control structures (4.6 and 4.7) will be covered in the next level. Four of the five exercises are short, but there’s one—the floating-point trap—that you shouldn’t overlook: It explains errors that you might otherwise encounter years later in financial calculations.

## Program Structure and Names (4.1, page 161)

A C# program consists of classes with methods; the entry point class contains the `Main()` method. Using top-level statements (4.1.2, page 163), the compiler generates this class automatically. The exercises in SeeSharp almost always use an explicit class with static methods because the tests need to call methods. Identifiers (4.1.6, page 171) consist of letters, digits, and underscores; they must not begin with a digit and must not be keywords; umlauts are allowed but uncommon. Convention: `PascalCase` for classes, methods, and properties; `camelCase` for local variables and parameters.

## Output and Formatting (4.2, page 175)

`Console.WriteLine()` prints a line, while `Write()` does not cause a line break. Strings are concatenated using `+`, but be careful: `"3 + 2 = " + 3 + 2` results in `3 + 2 = 32` because `+` is evaluated from left to right and, starting with the first string, only concatenates. Enclosing the calculation in parentheses resolves this. **Interpolation** (4.2.3.2, page 178) is clearer: `$"{i} und {j}"`. The expression can be followed by a width, such as `{i,8}` for right-justified and `{i,-8}` for left-justified, and a format such as `{d:f2}` for two decimal places. Escape sequences such as `\n` (newline) and `\t` (tab) are valid in normal string literals; `@"..."` disables them.

## Variables and Data Types (4.3, page 180)

C# is strictly typed: Every variable has a fixed type and must be declared and initialized before use. The basic types (4.3.4, page 186) are `int` and `long` for integers, `double` and `float` for binary floating-point numbers, `decimal` for decimal floating-point numbers, `bool`, and `char`. Suffixes determine the type of a literal: `3.5f` for `float`, `3.5m` for `decimal`, `10L` for `long`; without a suffix, `3.5` is a `double` and `10` is an `int`. `var` allows the compiler to infer the type from the initializer; the variable remains strictly typed nonetheless. `const` defines a constant that must be fixed at compile time. A local variable is valid only within the block in which it was declared (4.3.8, page 198).

**Floating-point representation (4.3.5, page 189):** `double` stores numbers in binary with a 52-bit mantissa. Many decimal fractions such as 0.1 cannot be represented exactly in binary, which is why `0.1 + 0.2 == 0.3` is false. The distance to the next representable number at 1.0 is 2^-52; if you add at most half of that (2^-53), the result is rounded to 1.0. For monetary amounts, use `decimal`: slower, but exact in decimal. Comparisons on floating-point values are done with a tolerance (4.5.4, page 223).

## Type Conversion (4.5.7, page 229)

Widening conversions happen implicitly: `int` to `long`, `int` to `double`, `char` to `int` (the character's Unicode code). Narrowing conversions require an explicit cast `(int)d`, which truncates decimal places rather than rounding. The `Math` class provides `Round`, `Abs`, `Sqrt`, `Pow`, and more.

## Operators (4.5, page 215)

Arithmetic with `+ - * / %`: Two `int` operands result in **integer division**; `7 / 2` is `3`. As soon as one operand is a `double`, the calculation is performed using floating-point arithmetic. `%` returns the remainder. Comparisons (`<`, `==`, `!=`) return `bool`; logical operators `&&`, `||`, `!` combine truth values; `&&` and `||` evaluate the right-hand operand only if necessary. `i++` returns the old value and then increments it; `++i` increments first. Compound assignments `+=` and `*=` are shorthand for `i = i + x`. The conditional operator `b ? x : y` selects one of two values. The order of operations (4.5.10, page 236) determines what is evaluated first; use parentheses when in doubt. De Morgan’s laws help with negating compound conditions: `!(a || b)` is the same as `!a && !b`.

Further Reading: Chapter 4, Sections 4.1 through 4.5 (pages 161 through 243).
