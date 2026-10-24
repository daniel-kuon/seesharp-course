# Extra: Conditions as Expressions

Extra exercise: optional; it blocks nothing. In the operator quiz, you evaluated expressions in your head; now you'll write some yourself. Each method consists of **a single `return` statement**—`if` isn't introduced until Level 3; here, `&&`, `||`, `!`, and `?:` are sufficient.

Read sections **4.5.5 "Logical Operators"** (page 225), **4.5.9 "Conditional Operator"** (page 235), and the operator table in **4.5.10** (page 236) in the book.

Open `Bedingungen.cs`:

1. `IstSchaltjahr(int jahr)`: A year is a leap year if it is divisible by 4 but not by 100—unless it is divisible by 400. 2024 and 2000 are leap years, but 1900 and 2023 are not.
2. `ImBereich(int x, int min, int max)`: `true` if `min <= x <= max`.
3. `AusserhalbBereich(int x, int min, int max)`: the opposite of `ImBereich`—write it **without `!`** by applying De Morgan's theorem to the condition.
4. `Vorzeichen(int x)`: `-1` for negative numbers, `0` for 0, `1` for positive numbers — with two nested `?:` operators.
5. `Maximum(int a, int b, int c)`: the largest of the three numbers, but with `?:` (not `Math.Max`).

The following tests must be passed:

- `BedingungenTests.Schaltjahre`
- `BedingungenTests.Keine_Schaltjahre`
- `BedingungenTests.Im_Bereich_einschliesslich_Grenzen`
- `BedingungenTests.Ausserhalb_ist_das_Gegenteil`
- `BedingungenTests.Vorzeichen`
- `BedingungenTests.Maximum_egal_an_welcher_Stelle`
