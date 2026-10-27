# Entity Framework Core (with SQLite)

With ADO.NET, you write SQL statements and read rows manually. **Entity Framework Core** (EF Core, Chapter 20, page 1399), on the other hand, maps classes to tables: You work with objects and LINQ, and EF Core generates the SQL. Here, we’re using the `Microsoft.EntityFrameworkCore.Sqlite` package with an in-memory SQLite database instead of SQL Server. Knowledge from the ADO.NET elective module is not required.

## Entities and Context (20.1, page 1399; 20.2, page 1402; 20.4, page 1414)

An **entity class** describes a row: properties become columns, and by convention, the `Id` (or `<Klasse>Id`) is the primary key. The **`DbContext`** serves as the bridge to the database. It has one `DbSet<T>` per table and receives its configuration (provider, connection) as `DbContextOptions`. A context is a short-lived unit of work: create it, use it, and release it with `using`. `Database.EnsureCreated()` creates the schema (it is not in the book, which uses migrations for this, 20.3; for tests it is the shorter way), `Add` marks entities for insertion, and `SaveChanges()` commits all changes.

## Mapping and Configuration (20.5, pages 1420–1435)

The schema follows from conventions and can be changed in two ways: **annotations** on the classes (`[Required]`, `[MaxLength]`, `[Key]`) and the **Fluent API** in `OnModelCreating` (relationships, indexes, delete behavior, **value converters** such as `HasConversion<string>()` for enumerations). Which rules are enforced is determined by the database system: SQLite enforces `NOT NULL`, but not text lengths. A **1:n relationship** consists of a foreign key (`BlogId`) and navigation properties (20.5.11, page 1429).

## Queries with LINQ to Entities (20.9, pages 1451–1465)

EF Core translates LINQ expressions on a `DbSet` into SQL (`Where`, `OrderBy`, `Take`, `Select`, `Count`, `Sum`, `Average`). The query runs only at `ToList()`, `First...`, and similar calls; `ToQueryString()` shows the generated SQL. `AsEnumerable()` ends the server-side evaluation: Everything after that runs in C# (20.9.6). Aggregates and projections belong on the server whenever possible. EF Core does not load associated entities by itself: **`Include`** (eager loading) fetches them along (20.9.7).

## Modify, Delete, Track (20.10 and 20.11, pages 1466–1478)

The context **tracks** loaded entities and knows their `EntityState` (`Added`, `Unchanged`, `Modified`, `Deleted`, `Detached`). So all you need to do is make changes: set the property, then call `SaveChanges()`. Entities loaded with `AsNoTracking()` are not tracked (faster, but changes are not saved). `Remove` deletes; the **deletion behavior** of a relationship (`Cascade`, `SetNull`, `Restrict`) is specified in the schema. `ExecuteUpdate` and `ExecuteDelete` (20.15.2, page 1492) update or delete multiple rows with a single command without loading them.

## Conflicts and Transactions (20.13 and 20.14, pages 1482–1490)

EF Core operates **in an optimistic mode**: Two users can load the same row. A **concurrency token** (`[ConcurrencyCheck]` on a version column) causes `SaveChanges` to throw a `DbUpdateConcurrencyException` if the row has been modified in the meantime; the program decides whether to reload and retry. `SaveChanges` is atomic on its own; `Database.BeginTransaction()` groups multiple steps together with `Commit` and `Rollback`.

## Migrations (20.3, page 1404)

As the model grows, **migrations** (`dotnet ef migrations add`) update the schema incrementally and are versioned. `EnsureCreated` and migrations are mutually exclusive on the same database. Migrations are not automatically testable and are practiced in a review task.

## Exercises

1. The First `DbContext`: Entity, Context, `EnsureCreated`, `Add`, `SaveChanges`.
2. Queries using LINQ to Entities, on the server and on the client.
3. Modify, Delete, and Change Tracking; `ExecuteUpdate`/`ExecuteDelete`.
4. Relationships: `Include`, cascade, and Fluent API.
5. Value Converter, Concurrency Token, Transaction; Review: First Migration.
