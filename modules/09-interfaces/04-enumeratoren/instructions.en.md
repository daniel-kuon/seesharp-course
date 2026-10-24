# IEnumerable<T> and a custom IEnumerator<T>

See section **9.5, “IEnumerable<T> and IEnumerator<T>,”** (page 647) along with **9.5.1 Collection Enumerators** (page 648) and **9.1.4.1** on the `IEnumerable<T>` and `IEnumerable` interfaces (page 631).

`foreach` works with any type that implements `IEnumerable<T>`: It retrieves an enumerator using `GetEnumerator()` and calls `MoveNext()` as long as the enumerator returns `true`; `Current` is the current element. In Section 9.5, the book has the compiler do this work (using `yield`; see the next exercise); here, you’ll write the enumerator by hand once to see how it works. Open `SimpleSortedList.cs`:

1. The nested `Enumerator` class keeps track of the list and a position that starts before the first element (`-1`). `MoveNext()` advances the position and returns `true` as long as it points to an element; at the end, it stops and returns `false`. `Current` returns `liste.data[position]` (the nested class is allowed to access the private array) and throws an `InvalidOperationException` if there is no current element. `Reset()` jumps back to the position before the first element.
2. `GetEnumerator()` returns a **new** enumerator each time it is called; two nested `foreach` loops over the same list must run independently.
3. The non-generic `IEnumerable.GetEnumerator()` is explicitly implemented and simply delegates to the generic version.

The collection initializer `new SimpleSortedList<int> { 11, 2 }` in `Program.cs` works because the class implements `IEnumerable` and has a `Add` method.
