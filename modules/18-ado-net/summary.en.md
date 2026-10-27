# SQL and ADO.NET (with SQLite)

Programs usually store their data in a **relational database**. Chapter 19 of the book (page 1257) introduces databases and **ADO.NET**, the .NET library for database access. The book uses SQL Server (`Northwind.mdf`); the exercises here use in-memory **SQLite** with the `Microsoft.Data.Sqlite` package. No server is required, and each test gets its own fresh database. The sections on Visual Studio, SSMS and Azure Data Studio (19.3 through 19.5) are left out.

## Relational Databases and SQL (19.2, page 1264; 19.6, page 1296)

Data is stored in **tables** consisting of rows and columns. A **primary key** uniquely identifies a row; a **foreign key** references the primary key of another table, thereby ensuring that relationships remain consistent. Additional constraints (`NOT NULL`, `CHECK`) are defined in the schema so that the database automatically rejects invalid data.

**SQL** consists of three parts: data definition (`CREATE TABLE`), data manipulation (`INSERT`, `UPDATE`, `DELETE`), and queries using `SELECT`. Queries are filtered with `WHERE` and sorted with `ORDER BY`; `JOIN ... ON` combines tables, and aggregate functions (`COUNT`, `SUM`, `AVG`) with `GROUP BY` evaluate them (19.6.4, page 1302). Every database system speaks its own SQL dialect; the book shows SQL Server's T-SQL. The few SQLite differences the exercises need are given in the exercises (see Deep Dive).

## ADO.NET and the Provider Model (19.7.1 and 19.7.2, page 1307)

ADO.NET consists of a few basic building blocks: **connection** (`DbConnection`), **command** (`DbCommand`), **reader** (`DbDataReader`), and **adapter** for `DataSet` objects. Each database system has a **provider** with its own derived classes (`SqlConnection` for SQL Server, `SqliteConnection` for SQLite). The base classes are in `System.Data.Common`.

## Connections and Commands (19.7.4 and 19.7.5, pages 1319 and 1323)

A connection is opened using a **connection string** (`Open()`) and, like every command, belongs in a `using` statement so that it is released. Commands are executed depending on the result:

- `ExecuteNonQuery` for changes; returns the number of rows affected,
- `ExecuteScalar` for a single value (e.g., `COUNT(*)`),
- `ExecuteReader` for result rows.

Values should be included in the command as **parameters** (`@name`), never via string concatenation in the SQL text: Otherwise, a user could inject their own SQL code with an input such as `'; DROP TABLE ...` (**SQL injection**). A missing value is `NULL` in the database and `DBNull.Value` in ADO.NET: When writing, `null` is converted to `DBNull.Value`; when reading, you check for it using `is DBNull` and convert it back to `null`.

## DbDataReader and Objects (19.7.15, page 1363)

A `DbDataReader` returns rows sequentially: `Read()` moves forward and returns `false` when no row is left; the indexer (`leser["Name"]` or `leser[0]`) returns the value as an `object`, a NULL as `DBNull.Value`. An object is created from each row (mapping). The reader is released immediately. Typed read methods (`GetOrdinal`, `GetString`, `IsDBNull` ...) are not in the book; exercise 3 gives them.

## Transactions (19.7.7 and 19.7.8, pages 1332–1343)

A `DbTransaction` groups multiple commands together: `Commit()` commits them all at once, and `Rollback()` rolls them all back at once (ACID). The standard pattern is `BeginTransaction`, `try { ...; Commit }`, `catch { Rollback; throw; }`. All commands must be associated with the transaction. `TransactionScope` is the implicit variant, which rolls back without `Complete()`; it is discussed here only as a concept.

## Provider-Independent Code and DataTable (19.7.3, 19.7.9, 19.7.17)

If you program against `DbConnection`, `DbCommand`, and `DbProviderFactory` (19.7.3, page 1314), you can swap out the database system in a single place. A `DbConnectionStringBuilder` (19.7.4.2) safely constructs connection strings; provider-independently, the factory supplies it (given in exercise 5). A `DataTable` (19.7.9, page 1343) holds a result in memory; you populate it using `Load(leser)`; **LINQ-to-DataSet** (19.7.17, page 1365) queries it using `AsEnumerable()` and `Field<T>("Spalte")`.

## Exercises

1. SQL Basics with SQLite: Schema, Data, and Queries as SQL Statements.
2. Connection, commands and parameters: an address book with `ExecuteNonQuery`, `ExecuteScalar`, Parameters, and `DBNull`.
3. DataReader and Object Mapping.
4. Transactions: Transfers with commit and rollback.
5. Provider-independent code, `DataTable`, and LINQ to DataSet.

## Deep Dive (optional)

> Not in the book. These topics are optional – examples of what to look into next.

- **More SQL:** `UNIQUE` forbids duplicate values in a column. `HAVING` follows `GROUP BY` and filters the groups (the condition may contain aggregate functions). A **subquery** is a `SELECT` in parentheses inside another command; `NOT EXISTS (SELECT ...)` is true when it returns no row. A `LEFT JOIN` keeps every row of the left table; where nothing matches on the right, there are NULL values. Exercise 1 and extra exercise 10 have optional parts on this.
- **SQLite dialect:** `INTEGER PRIMARY KEY` counts up without `IDENTITY`, `LIMIT 3` at the end replaces `TOP 3`, `SELECT last_insert_rowid()` returns the last assigned Id, and SQLite is loosely typed (`TEXT`, `REAL`, `INTEGER`).
- **Typed read methods** of `DbDataReader`: `GetOrdinal`, `GetInt32`, `GetString`, `GetDecimal`, `IsDBNull`. They save casts but cannot handle NULL.
