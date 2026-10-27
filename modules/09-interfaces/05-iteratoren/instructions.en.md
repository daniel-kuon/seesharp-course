# Iterators with `yield`: RangeItUpDown

Read sections **9.5.2, “Algorithm Enumerators”** (page 651), and **9.5.3, “Named Collection Enumerators”** (page 652), as well as Exercise 4 in section **9.6** (page 655).

In the previous exercise, you wrote an enumerator by hand. With `yield return`, the compiler takes care of that: A method that returns `IEnumerator<T>` or `IEnumerable<T>` and contains `yield` becomes a state machine that runs until the next `yield` on every `MoveNext()`. Open `SimpleSortedList.cs`:

1. `GetEnumerator()`: Loop over `data[0]` to `data[size - 1]` using `yield return`.
2. `RangeIt(first, last)`: returns the elements from `first` to `last`, inclusive; if the range is out of bounds (`first < 0` or `last >= size`), `yield break` terminates the iterator without returning anything.
3. `DownIt`: an iterator as **a property**, with all elements in descending order.
4. `RangeItUpDown(first, last)` (textbook exercise): Same as `RangeIt`, but if `first > last`, it counts down. Check the range using `int.Min` and `int.Max` before choosing the direction (not in the book, given here: `int.Min(first, last)` returns the smaller number, `int.Max(first, last)` the larger one).

Note that iterators are **lazy**: `si.RangeIt(1, 99)` doesn't throw anything and doesn't perform any checks as long as no one iterates over it. The test `Iteratoren_sind_faul` demonstrates this.
