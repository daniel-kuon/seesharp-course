# Lotto: Fisher-Yates and Selection Sort

Read Exercise 2 in Section **6.10** (page 538), which describes both methods, as well as **Section 6.2.4** on the `Random` class (page 459) and **Section 6.2.6 on Searching and Sorting** (page 463) for the built-in capabilities of the `Array` class.

Open `Lotto.cs`. All three methods are static; there is no state:

1. `Mische(int[] vektor, Random rnd)` shuffles the array **in place** using Fisher-Yates: For `i` from `Length - 1` down to 1, pick a random index `k` from `0..i` (inclusive, so `rnd.Next(i + 1)`) and swap the elements `k` and `i`. The caller sees the change because arrays are reference types.
2. `SortiereAuswahl(int[] a)` sorts in ascending order by selection: For each position `i`, swap the smallest element from the remainder to the front.
3. `Ziehe(int seed)`: Fill an array with numbers from 1 to 49, shuffle it using `new Random(seed)`, copy the first 6 numbers into a new array (`Array.Copy`), sort them, and return the result.

A fixed seed makes the draw reproducible; that is exactly why the test can predict the result. Do not use built-in methods such as `rnd.Shuffle` or `Array.Sort`—the tests are designed to evaluate the algorithm itself.
