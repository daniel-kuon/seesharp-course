# Extra: Collatz Sequence

Extra exercise: optional; it blocks nothing. A sequence with a simple rule that, to this day, no one has been able to prove always terminates.

The rule: Start with a positive number `n`. If `n` is even, it becomes `n / 2`; otherwise `3 * n + 1`. Repeat until `n` equals 1. Starting from 6: 6, 3, 10, 5, 16, 8, 4, 2, 1 — that is **8 steps**.

Read **section 4.7.3.3**, "**Conditional Loops"** (page 275), in the book.

Open `Collatz.cs`:

1. `Schritte(long n)` counts the number of steps until the sequence reaches 1. `Schritte(1)` is 0, `Schritte(6)` is 8. Use a `while` loop with an `if`/`else` statement in the body.
2. `Hoechstwert(long n)` returns the largest value reached by the sequence (including `n` itself). For 6, this is 16.
3. `LaengsterStartBis(int grenze)` searches among the starting values 1 through `grenze` for the one with the most steps. In case of a tie, the smaller starting value wins. Call `Schritte()` in a loop (`for` if you're already familiar with it from 4.7.3.1, otherwise `while`).

Why `long`? Starting at 27, the sequence climbs to over 9,000; with larger starting values, it quickly exceeds the range of an `int`.

The following tests must be passed:

- `CollatzTests.Von_1_aus_null_Schritte`
- `CollatzTests.Von_6_aus_acht_Schritte`
- `CollatzTests.Von_27_aus_111_Schritte`
- `CollatzTests.Hoechstwert_von_6_ist_16`
- `CollatzTests.Hoechstwert_von_27_ist_9232`
- `CollatzTests.Hoechstwert_einer_Zweierpotenz_ist_der_Start`
- `CollatzTests.Laengster_Start_bis_10_ist_9`
- `CollatzTests.Laengster_Start_bis_100_ist_97`
