# Collections: Lists, Sets, Dictionaries

Arrays have a fixed size: If you want to insert or remove an element, you have to create a new array yourself and copy the elements over. The collection classes in the `System.Collections.Generic` namespace take this work off your hands; they grow dynamically and provide ready-made methods for searching, inserting, and removing elements (Chapter 11, page 691; 11.1 Arrays versus Collections). All generic collections implement `IEnumerable<T>` and `ICollection<T>` (11.2). By declaring parameters using these interfaces instead of `List<T>`, you write code that works equally well for lists, sets, and arrays.

## Initializers and Collection Expressions (11.3, page 695)

A collection initializer populates a collection upon creation (`new List<string> { "a", "b" }`); behind the scenes, this involves an `Add()` call for each element. In object initializers, a collection property can be populated as follows: `Artikel = { "A", "B" }`. The collection expression `[1, 2, 3]` requires a target type (`int[]`, `List<int>`, `IReadOnlyList<int>`); the spread operator `..` is used to insert an entire sequence: `[rand, ..mitte, rand]`. `var x = [];` does not work because the target type is missing.

## Lists, Queues, Stacks, Linked Lists (11.4, pages 697–703)

`List<T>` is based on an array that is resized as needed. It provides `Add`, `Insert`, `Remove`, `RemoveAt`, `RemoveAll`, `Contains`, `IndexOf`, `Sort`, `Reverse`, `GetRange`, and `ToArray`; the indexer provides fast access. Important: You must not modify the list during a `foreach` loop; doing so will throw an exception at runtime. A safe way to do this is to use `RemoveAll()` or a loop that runs in reverse. `Queue<T>` (queue, FIFO: `Enqueue`, `Dequeue`, `Peek`) and `Stack<T>` (stack, LIFO: `Push`, `Pop`, `Peek`) are specializations designed for precisely this order. `LinkedList<T>` connects nodes (`LinkedListNode<T>`) in both directions; inserting and removing at a known position incurs almost no overhead (11.4.2, page 700).

## Quantities (11.5, pages 704–714)

`HashSet<T>` manages elements in a hash table: no duplicates, no fixed order, very fast existence checks. `Add()` returns `false` if the element already exists. Set operations such as `UnionWith`, `IntersectWith`, `ExceptWith`, and `IsSubsetOf` modify the set or query relationships. Custom element types require appropriate `Equals()` and `GetHashCode()` methods; otherwise, two identical elements are considered different (11.5.2, page 704). `SortedSet<T>` stores elements in a balanced binary tree, is always sorted in ascending order, and supports `Min`, `Max`, and `GetViewBetween()` (11.5.3, page 711).

## Dictionaries (11.6, page 714)

`Dictionary<TKey,TValue>` associates a value with each key. The indexer sets or reads; a missing key during a read operation triggers an exception, which is why you should use `TryGetValue()` or `ContainsKey()` to check for the key. A `foreach` loop returns `KeyValuePair` objects; there are also `Keys` and `Values`. You should not rely on the order of the iteration. To collect multiple values per key, use `Dictionary<K, List<V>>`.

## Read-only and immutable (11.7, page 716)

`AsReadOnly()` and `IReadOnlyList<T>` provide only a **view**: The recipient cannot make any changes, but can see subsequent changes made by the owner. `ImmutableList<T>` from `System.Collections.Immutable`, on the other hand, is truly immutable; `Add()` returns a new list and leaves the old one unchanged. This eliminates the need for synchronization when multiple threads are reading from it.

## Choosing the Right Collection (August 11, page 723)

Question regarding the requirements: Order and index-based access (`List<T>`), waiting in a queue (`Queue<T>`), backtracking (`Stack<T>`), existence checks and set theory (`HashSet<T>`), sorted without duplicates (`SortedSet<T>`), access via key (`Dictionary<K,V>`). `Contains()` takes O(n) time in a list and O(1) time in a `HashSet<T>`; with large amounts of data, that’s the difference between seconds and milliseconds. The exercises at the end of the chapter (11.8, page 723) test precisely this knowledge.
