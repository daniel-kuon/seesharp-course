# LINQ to Objects

**LINQ** (Language Integrated Query) is a collection of extension methods on `IEnumerable<T>` (`System.Linq.Enumerable` class) that expect lambda expressions as embedded functionality (Chapter 18, page 1209). Because each method returns a sequence, the calls can be chained together to form a **fluent API**: `produkte.Where(...).OrderBy(...).Select(...)` (18.2.1 through 18.2.3, pages 1211 through 1213). Prerequisites include lambdas and `Func<>` from Level 12, as well as `IEnumerable<T>` and extension methods from earlier levels.

## Deferred and Immediate Execution (18.2.4, page 1215)

`Where`, `Select`, `OrderBy`, and most other operators simply build a **query** (a recipe) and do not read the source until someone iterates over it (`foreach`) or an **immediate** operator retrieves it: `ToList()`, `ToArray()`, `ToDictionary()`, `Count()`, `Sum()`, `First()`. Each iteration re-executes the query; changes to the source between building and iterating are visible. If you need a result multiple times, materialize it once using `ToList()`.

## Filtering, Sorting, Projecting (18.2.6 through 18.2.8, pages 1217 through 1222)

`Where` filters; `OfType<T>()` filters by runtime type; `Select` converts to a new element type, including tuples and anonymous types. `OrderBy`, `ThenBy`, and the `...Descending` variants sort **in a stable manner** (18.2.7, page 1218). `SelectMany` flattens a sequence of sequences (18.2.8.2, page 1220).

## Grouping and Linking (18.2.9 and 18.2.10, pages 1222–1228)

`GroupBy` returns groups (`IGrouping<TKey, T>`) that are themselves sequences and have their key stored in `Key`. `Join` is an inner join; `GroupJoin` appends the group of its partners (which may be empty) to each element of the outer sequence; `Zip` pairs two sequences element by element.

## Additional Operators (February 18, 2011, page 1228)

Quantifiers (`Any`, `All`, `Contains`), Element operators (`First`, `FirstOrDefault`, `Single`, `Last`, `ElementAt`), Set Operators (`Distinct`, `Union`, `Intersect`, `Except`), Aggregates (`Count`, `Sum`, `Average`, `Min`, `Max`; (`Average` and `Min` on an empty sequence) and subsequences (`Take`, `Skip`, `TakeWhile`, `Chunk`, page 1234). The book is based on .NET 8: `CountBy`, `AggregateBy`, and `Index` (available starting with .NET 9) are not included. `CountBy(f)` counts the number of keys in a single pass and replaces `GroupBy(f).Select(g => (g.Key, g.Count()))`; `AggregateBy` aggregates by key to any value.

## Query Syntax and Subqueries (18.3 and 18.4, pages 1235–1244)

`from x in quelle where ... orderby ... select ...` is another way of writing the same method calls; the compiler translates them. This includes `group ... by`, `join ... on ... equals ...` (with `into` for the `GroupJoin`), `let` for intermediate values, and `into` for subqueries. Two `from` clauses become `SelectMany`. Anything that isn’t a keyword (`Take`, `Count`, `Distinct`) is appended as a method to the expression in parentheses. A **subquery** is nested within another query but is re-evaluated for each element: computationally expensive parts are calculated once in advance.

## Custom Operators

An extension method on `IEnumerable<T>` that uses `yield return` behaves like the built-in operators: it is deferred and can also be used on infinite sources. PLINQ (18.5) is part of the Multithreading optional module.

Further study in the book: Chapter 18 (pages 1209–1256); the exercises in 18.6 (page 1255) provide the quiz questions and the duplicate search for this level.
