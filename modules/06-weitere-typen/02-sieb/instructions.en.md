# Eratosthenes' Sieve

Read sections **6.2 "Arrays"** (page 455) through 6.2.3 (page 459) in the book, as well as Exercise 3 in **6.10** (page 539), which explains the procedure step by step.

In Level 3, you checked individual numbers for primality. The sieve finds **all** prime numbers up to a limit in a single pass: A `bool` array remembers for each number whether it is still a candidate; starting with base 2, all proper multiples are crossed out, then the next number that has not been crossed out is taken as the base, until the base is greater than the square root of the limit.

Open `Primzahlen.cs` and implement the following:

1. `BisZu(int grenze)`: Create a `bool[grenze + 1]` array (index = number), set entries starting at 2 to `true`, run the sieve, then copy the remaining numbers in ascending order into an `int[]` of the appropriate length. Return an empty array if `grenze < 2`.
2. `Anzahl(int grenze)`: the number of prime numbers up to `grenze` (there are 168 up to 1000).

Tip: You can start crossing out the multiples of a base `b` at `b * b`; smaller multiples have already been eliminated. You only need bases up to the square root of the limit. The tests also check the limit 1,000,000; without these shortcuts that takes noticeably longer.
