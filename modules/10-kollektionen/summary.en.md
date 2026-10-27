# Collections: Lists, Sets, Dictionaries

Arrays have a fixed size: if you want to insert or remove an element, you have to create a new array yourself and copy the elements over. The collection classes in the `System.Collections.Generic` namespace take this work off your hands; they grow as needed and provide ready-made methods for searching, inserting and removing (chapter 11, page 691; 11.1 Arrays versus Collections). All generic collections implement `IEnumerable<T>`, most of them also `ICollection<T>` (11.2, page 693; `Queue<T>` and `Stack<T>` do not). If you declare parameters with these interfaces instead of `List<T>`, your code works equally well for lists, sets and arrays.

## Initializers and Collection Expressions (11.3, page 695)

A collection initializer fills a collection when it is created (`new List<string> { "a", "b" }`); behind it is one `Add()` call per element. In object initializers, a collection property can be filled with `Artikel = { "A", "B" }`. The collection expression `[1, 2, 3]` needs a target type (`int[]`, `List<int>`, `IReadOnlyList<int>`); the spread element `..` (the book calls it the range operator, "Bereichsoperator") inserts a whole sequence: `[rand, ..mitte, rand]`. `var x = [];` does not work because the target type is missing.

## Lists, Queues, Stacks, Linked Lists (11.4, pages 697–702)

`List<T>` is built on an array that is enlarged as needed. It provides `Add`, `Insert`, `Remove`, `RemoveAt`, `Contains`, `IndexOf`, `Sort`, `Reverse`, `GetRange` and `ToArray`; the indexer gives fast access. Important: you must not modify the list during a `foreach`; that throws an `InvalidOperationException` at run time (4.7.3.2, page 275). The safe way is a `for` loop that runs backward (`RemoveAll()` needs a lambda expression, which only comes in level 12). `Queue<T>` (queue, FIFO: `Enqueue`, `Dequeue`, `Peek`) and `Stack<T>` (stack, LIFO: `Push`, `Pop`, `Peek`) are specialized for exactly this order; the book only mentions them briefly in 11.4 (page 697). `LinkedList<T>` links nodes (`LinkedListNode<T>`) in both directions; inserting and removing at a known position costs next to nothing (11.4.2, page 700).

## Sets (11.5, pages 702–714)

`HashSet<T>` keeps its elements in a hash table: no duplicates, no fixed order, very fast existence checks. `Add()` returns `false` if the element was already there. Set operations such as `UnionWith`, `IntersectWith`, `ExceptWith` and `IsSubsetOf` modify the set or query relationships. Custom element types need matching `Equals()` and `GetHashCode()` methods; otherwise two equal points count as different (11.5.2.1, page 704, and 11.5.2.3, page 708). `SortedSet<T>` stores its elements in a balanced binary tree, is always sorted in ascending order and offers `Min`, `Max` and `GetViewBetween()` (11.5.3, page 711).

## Dictionaries (11.6, page 714)

`Dictionary<TKey,TValue>` maps each key to a value. The indexer sets or reads; reading a missing key throws an exception, so you ask with `TryGetValue()` or `ContainsKey()`. A `foreach` yields `KeyValuePair` objects, and there are also `Keys` and `Values`. Do not rely on the order of enumeration. To collect several values per key, use `Dictionary<K, List<V>>`.

## Read-only and Immutable (11.7, page 716)

`AsReadOnly()` hands out only a **view** (`ReadOnlyCollection<T>`): the recipient cannot change anything but sees later changes made by the owner. If you hand out the list itself as an `IReadOnlyList<T>`, not even that is safe: a cast back to `List<T>` is enough to change it. `ImmutableList<T>` from `System.Collections.Immutable`, on the other hand, is truly immutable; `Add()` returns a new list and leaves the old one unchanged. That saves synchronization when several threads work with the same data (11.7, page 716).

## Choosing the Right Collection

Ask what is required: order and index access (`List<T>`), waiting in line (`Queue<T>`), undo history (`Stack<T>`), existence checks and set operations (`HashSet<T>`), sorted without duplicates (`SortedSet<T>`), access by key (`Dictionary<K,V>`). `Contains()` costs O(n) in a list and O(1) in a `HashSet<T>` (11.5.3, page 713); with large amounts of data, that is the difference between seconds and milliseconds (the book's measurement: 11.5.2.3, page 710). The exercises at the end of the chapter (11.8, page 723) test exactly this knowledge.
