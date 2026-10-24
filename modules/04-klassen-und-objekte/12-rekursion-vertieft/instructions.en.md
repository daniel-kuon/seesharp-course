# Extra exercise: Recursion in Depth

This exercise is optional. It builds on the exercise **on recursion**; if necessary, review Section **5.9.2**, **“Recursive Methods”** (page 382).

Open `Rekursiv.cs`. Implement all five methods **recursively**, without using loops. For each one, first consider: What is the termination condition, and how does the problem become smaller when the method calls itself?

1. `Quersumme(n)`: A single-digit number is its own quersumme; otherwise, it is the last digit (`n % 10`) plus the quersumme of the remainder (`n / 10`).
2. `Potenz(basis, exponent)`, using **fast exponentiation**: `x⁰ = 1`; otherwise, compute `h = x^(n/2)` once and return `h * h`; if `n` is odd, compute `x` again. Thus, `2⁶²` requires only seven calls instead of 62.
3. `Binomial(n, k)` according to Pascal's triangle: at the edges (`k == 0` or `k == n`), the value is 1; otherwise, it is the sum of the two values above it, `Binomial(n-1, k-1) + Binomial(n-1, k)`.
4. `HanoiZuege(n)`: To move `n` discs, move `n-1` discs aside, move the largest one, and then move the `n-1` discs back on top of it. Zero discs need no move.
5. `Fibonacci(n, a, b)`: The version from the required exercise recalculates the same values over and over and is unbearably slow even for `F(45)`. Here, the parameters `a` and `b` carry the last two Fibonacci numbers along: `n == 0` returns `a`; otherwise the recursion continues with `(n - 1, b, a + b)`. It is called as `Fibonacci(n, 0, 1)`; `F(90)` returns immediately.

The following tests must be passed:

- `RekursivTests.Quersumme_einstellig_und_mehrstellig`
- `RekursivTests.Potenz_Sonderfaelle`
- `RekursivTests.Potenz_gerade_und_ungerade_Exponenten`
- `RekursivTests.Binomial_Rand_des_Dreiecks_ist_1`
- `RekursivTests.Binomial_im_Inneren`
- `RekursivTests.HanoiZuege_verdoppeln_sich_plus_eins`
- `RekursivTests.Fibonacci_Anfangswerte`
- `RekursivTests.Fibonacci_von_90_ist_schnell`
