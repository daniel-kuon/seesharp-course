# LINQ to Objects

**LINQ** (Language Integrated Query) is a collection of extension methods on `IEnumerable<T>` (`System.Linq.Enumerable` class) that expect lambda expressions as embedded functionality (Chapter 18, page 1209). Because each method returns a sequence, the calls can be chained together to form a **fluent API**: `produkte.Where(...).OrderBy(...).Select(...)` (18.2.1 through 18.2.3, pages 1211 through 1213). Prerequisites include lambdas and `Func<>` from Level 12, as well as `IEnumerable<T>` and extension methods from earlier levels.

## Deferred and Immediate Execution (18.2.4, page 1215)

`Where`, `Select`, `OrderBy`, and most other operators simply build a **query** (a recipe) and do not read the source until someone iterates over it (`foreach`) or an **immediate** operator retrieves it: `ToList()`, `ToArray()`, `ToDictionary()`, `Count()`, `Sum()`, `First()`. Each iteration re-executes the query; changes to the source between building and iterating are visible. If you need a result multiple times, materialize it once using `ToList()`.

## Filtering, Sorting, Projecting (18.2.6 through 18.2.8, pages 1217 through 1222)

`Where` filters; `OfType<T>()` filters by runtime type; `Select` converts to a new element type, including tuples and anonymous types. `OrderBy`, `ThenBy`, and the `...Descending` variants sort (18.2.7, page 1218), and they do so **stably**: elements with equal keys keep their source order (the book does not mention this; .NET guarantees it). `SelectMany` flattens a sequence of sequences (18.2.8.2, page 1220).

## Grouping and Linking (18.2.9 and 18.2.10, pages 1222–1228)

`GroupBy` returns groups (`IGrouping<TKey, T>`) that are themselves sequences and have their key stored in `Key`. `Join` is an inner join; `GroupJoin` appends the group of its partners (which may be empty) to each element of the outer sequence (the book calls this a left outer join, page 1228; since .NET 10 there is also `LeftJoin` for it). `Zip` pairs two sequences element by element (18.2.8.3, page 1221).

## Additional Operators (18.2.11, page 1228)

Quantifiers (`Any`, `All`, `Contains`), element operators (`First`, `FirstOrDefault`, `Single`, `Last`, `ElementAt`), set operators (`Distinct`, `Union`, `Intersect`, `Except`), aggregates (`Count`, `Sum`, `Average`, `Min`, `Max`; on an empty sequence of numbers `Average`, `Min` and `Max` throw, while `Sum` and `Count` return 0) and subsequences (`Take`, `Skip`, `TakeWhile`, `Chunk`, page 1234). The book is based on .NET 8: `CountBy`, `AggregateBy`, and `Index` (available starting with .NET 9) are not included. `CountBy(f)` counts per key in a single pass and replaces `GroupBy(f).Select(g => (g.Key, g.Count()))`; `AggregateBy` aggregates by key to any value.

## Query Syntax and Subqueries (18.3 and 18.4, pages 1235–1244)

`from x in quelle where ... orderby ... select ...` is another way of writing the same method calls; the compiler translates them. This includes `group ... by`, `join ... on ... equals ...` (with `into` for the `GroupJoin`), `let` for intermediate values, and `into` for continuation queries. Two `from` clauses become `SelectMany`. Anything without a keyword (`Take`, `Count`, `Distinct`) is appended as a method call to the parenthesized expression. A **subquery** sits inside another query but is evaluated again for every element: compute expensive parts once beforehand.

## Custom Operators

An extension method on `IEnumerable<T>` that uses `yield return` behaves like the built-in operators: it is deferred and can also be used on infinite sources. PLINQ (18.5) belongs to the optional Multithreading module.

Further study in the book: Chapter 18 (pages 1209–1256); the exercises in 18.6 (page 1255) provide the quiz questions and the duplicate search for this level.
