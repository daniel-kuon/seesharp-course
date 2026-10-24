# The First DbContext

Read sections **20.1, "First Impressions and Overview**" (page 1399), and **20.2** (page 1402) regarding NuGet packages, as well as section **20.4** (page 1414) regarding context. Entity Framework Core (EF Core) maps classes to tables, allowing you to store and read data using objects instead of SQL. Instead of SQL Server, we use the `Microsoft.EntityFrameworkCore.Sqlite` package with an in-memory SQLite database.

You need three things: an **entity class** (`Blog`), a **context** (`BlogContext : DbContext` with a `DbSet<Blog>`), and code that uses the context (`BlogRepository`).

1. `Blog.cs`: The name is required and must be no more than 100 characters long. Add the `[Required]` and `[MaxLength(100)]` annotations (`System.ComponentModel.DataAnnotations`).
2. `BlogContext.cs`: The constructor accepts `DbContextOptions<BlogContext>` and passes it to the base class. The options specify which database is used; the tests pass an open SQLite connection. Convert `Blogs` to a true `DbSet<Blog>` (property with `get` and `set`).
3. `BlogRepository.cs`:
   - `Anlegen(name)` creates a new context (`using var`), creates the schema using `Database.EnsureCreated()`, adds the blog using `Add`, saves it using `SaveChanges()`, and returns the new `Id` (which is greater than 0 after saving). A `null` value for the name violates the NOT NULL constraint: the `DbUpdateException` remains unhandled.
   - `Alle()` reads using a **new context for each call**. A context is a short unit of work; one that were persistently stored would display outdated data.

Then answer the quiz question.

Tests: `Blog_hat_die_Annotationen_Required_und_MaxLength`, `Kontext_kennt_die_Annotationen_im_Modell`, `Kontext_hat_ein_DbSet_fuer_Blogs`, `Anlegen_liefert_nach_SaveChanges_eine_Id_groesser_0`, `Alle_liefert_die_gespeicherten_Blogs`, `Alle_auf_leerer_Datenbank_liefert_leere_Liste`, `Anlegen_ohne_Namen_loest_DbUpdateException_aus`, `Daten_sind_fuer_einen_anderen_Kontext_erst_nach_SaveChanges_sichtbar`, `Alle_verwendet_bei_jedem_Aufruf_einen_frischen_Kontext`, `Bei_Anlegen_wird_das_Schema_bei_Bedarf_erzeugt_und_mehrfach_verwendet`.
