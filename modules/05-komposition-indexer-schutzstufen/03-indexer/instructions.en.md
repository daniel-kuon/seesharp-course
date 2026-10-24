# Indexer: Accessing a list of people as if it were an array

Read Section **5.12, “Indexers”** (page 393), in the book, including subsections 5.12.1 (linked list as an example) and 5.12.2 (overloading indexers, page 397).

`PersList` is a singly linked list: each `Element` knows its person (`VP`) and its successor (`Next`); the list keeps track of `first`, `last`, and `Count`. The nested `Element` class is complete; you’ll handle the list itself. Open `PersList.cs` and complete the following:

1. `Add(Person neu)`: Append a new element. For the first person, `first` and `last` are the same element; otherwise, `last.Next` is set and `last` is incremented. Increment `Count`.
2. `FindElement(int i)`: Start at `first` and go to `i` times to `Next`.
3. The `this[int i]` indexer: the getter returns the person at position `i` or throws a `ArgumentOutOfRangeException`; the setter replaces the person in the element if the index is valid, and does nothing otherwise.
4. The overloaded indexer `this[string vn]` returns the **first** person with that first name; if none exists, it throws an `ArgumentException`. Tip: You can reuse the `int` indexer for this.

`PersListDemo.cs` shows how to use it: `pl[1]`, `pl[1] = …`, `pl["Ilse"]`.
