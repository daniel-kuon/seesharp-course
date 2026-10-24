# Sorted list where T : IComparable<T>

Read section **8.2.2, “Restricted Type Formal Parameters**,” in the book (page 593).

`SimpleSortedList<T>` keeps its elements sorted when inserting new elements. To do this, it must be able to compare elements; not every type can do that. Open `SimpleSortedList.cs`:

1. Declare cabinets of type `T`, `where T : IComparable<T>`. After that, the compiler recognizes `element.CompareTo(other)` (negative: less than, 0: equal to, positive: greater than). `Add` does not compile without this restriction.
2. `Add(T element)`: If the list is full, throw an `InvalidOperationException`. Otherwise, start at the end (`size - 1`) and move forward, shifting each `element` larger than element one position to the right; insert `element` into the resulting gap and increase `size`. This is an insertion step similar to that used in insertion sort.
3. The indexer returns `data[index]` and throws an `ArgumentOutOfRangeException` for indices outside the range `0 .. Count - 1`.

The tests use the list with `int` and with `string`; both types implement `IComparable<T>`. A reflection test checks that the constraint really is present in the class.
