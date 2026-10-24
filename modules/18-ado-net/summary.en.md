# SQL and ADO.NET (with SQLite)

Programs usually store their data in a **relational database**. Chapter 19 of the book (page 1257) introduces databases and **ADO.NET**, the .NET library for database access. The book uses SQL Server (`Northwind.mdf`); the exercises here use in-memory **SQLite** with the `Microsoft.Data.Sqlite` namespace. No server is required, and each test gets its own fresh database. The chapters on SSMS and Azure Data Studio (19.3 through 19.5) have been omitted.

## Relational Databases and SQL (19.2, page 1264; 19.6, page 1296)

Data is stored in **tables** consisting of rows and columns. A **primary key** uniquely identifies a row; a **foreign key** references the primary key of another table, thereby ensuring that relationships remain consistent. Additional constraints (`NOT NULL`, `UNIQUE`, `CHECK`) are defined in the schema so that the database automatically rejects invalid data.

**SQL** consists of three parts: data definition (`CREATE TABLE`), data manipulation (`INSERT`, `UPDATE`, `DELETE`), and queries using `SELECT`. Queries are filtered using `WHERE`, sorted using `ORDER BY`, join tables using `JOIN ... ON`, and evaluated using aggregate functions (`COUNT`, `SUM`, `AVG`) and `GROUP BY`; `HAVING` filters the groups (19.6.4, page 1302). Dialects differ: SQLite uses `LIMIT 3` instead of `TOP 3` and uses `INTEGER PRIMARY KEY` without `IDENTITY`.

## ADO.NET and the Provider Model (19.7.1 and 19.7.2, page 1307)

ADO.NET consists of a few basic building blocks: **connection** (`DbConnection`), **command** (`DbCommand`), **reader** (`DbDataReader`), and **adapter** for `DataSet` objects. Each database system has a **provider** with its own derived classes (`SqlConnection` for SQL Server, `SqliteConnection` for SQLite). The base classes are in `System.Data.Common`.

## Connections and Commands (19.7.4 and 19.7.5, pages 1319 and 1323)

A connection is opened using a **connection string** (`Open()`) and, like any other command, must be included in a `using` statement so that it is released. Commands are executed depending on the result:

- `ExecuteNonQuery` for changes; returns the number of rows affected,
- `ExecuteScalar` for a single value (e.g., `COUNT(*)`),
- `ExecuteReader` for result rows.

Values should be included in the command as **parameters** (`@name`), never via string concatenation in the SQL text: Otherwise, a user could inject their own SQL code with an input such as `'; DROP TABLE ...` (**SQL injection**). A missing value is `NULL` in the database and `DBNull.Value` in ADO.NET: When writing, `null` is converted to `DBNull.Value`; when reading, you check for it using `IsDBNull` or `is DBNull` and convert it back to `null`.

## DbDataReader and Objects (July 19, 2015, page 1363)

A `DbDataReader` returns rows sequentially: `Read()` moves forward, `GetOrdinal` returns the column number, and `GetInt32`, `GetString`, and `GetDecimal` read values by type. An object is created from each row (mapping). The reader is immediately released.

## Transactions (19.7.7 and 19.7.8, pages 1332–1343)

A `DbTransaction` groups multiple commands together: `Commit()` commits them all at once, and `Rollback()` rolls them all back at once (ACID). The standard pattern is `BeginTransaction`, `try { ...; Commit }`, `catch { Rollback; throw; }`. All commands must be associated with the transaction. `TransactionScope` is the implicit variant, which rolls back without `Complete()`; it is discussed here only as a concept.

## Provider-Independent Code and DataTable (July 19, 2003, July 19, 2009, July 19, 2017)

If you program using `DbConnection`, `DbCommand`, and `DbProviderFactory` (19.7.3, page 1314), you can swap out the database system in a single place. The factory creates a `DbConnectionStringBuilder`, which safely constructs connection strings. A `DataTable` (19.7.9, page 1343) holds a result in memory; you populate it using `Load(leser)`; **LINQ-to-DataSet** (19.7.17, page 1365) queries it using `AsEnumerable()` and `Field<T>("Spalte")`.

## Exercises

1. SQL Basics with SQLite: Schema, Data, and Queries as SQL Statements.
2. Connection, Commands, and Parameters: A Reference Guide to `ExecuteNonQuery`, `ExecuteScalar`, Parameters, and `DBNull`.
3. DataReader and Object Mapping.
4. Transactions: Transfers with commit and rollback.
5. Vendor-neutral code, `DataTable`, and LINQ to DataSet.
