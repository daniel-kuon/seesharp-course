# Relationships: Include, Cascade, and Fluent API

See the book, section **20.5.11 "Master Details - Relationship**" (page 1429), sections **20.5.13 through 20.5.14** on the Fluent API and `IEntityTypeConfiguration`, **section 20.9.7** on loading associated entities, and section **20.11.4** on deleting entities. A 1:n relationship has a **foreign key** (`BlogId`) on the n side and **navigation properties** on both sides (`Blog.Beitraege`, `Beitrag.Blog`).

The data model (`Blog`, `Beitrag`, `Autor`) is defined in `Datenmodell.cs`; the methods for creating entries are provided in `BlogDienst.cs`.

1. **`OnModelCreating`** (Fluent API) in `BlogContext`:
   - A blog has many posts, and each post belongs to a blog: `HasMany(...).WithOne(...).HasForeignKey(...).OnDelete(DeleteBehavior.Cascade)`).
   - The blog name is unique (`HasIndex(...).IsUnique()`); a duplicate name triggers a `DbUpdateException`.
   - A post may optionally have an author (`AutorId` is `int?`). If the author is deleted, the post remains with `AutorId == null`: `DeleteBehavior.SetNull`.
2. **`BlogMitBeitraegen(id)`**: returns the blog along with its posts using `Include` (eager loading), or `null`. Lazy loading is not configured; the test initializes the context and then reads the `Beitraege`.
3. **`LoescheBlog(id)`**: `Find`, `Remove`, `SaveChanges`. The blog's posts disappear as part of the cascade; posts from other blogs remain.
4. **`LoescheAutor(id)`**: the same applies to an author; their posts remain.

Then answer the quiz question.

Tests: `BlogMitBeitraegen_laedt_die_Beitraege_mit_Include`, `BlogMitBeitraegen_liefert_null_fuer_unbekannte_Id_und_leere_Liste_ohne_Beitraege`, `LoescheBlog_loescht_auch_die_Beitraege_aber_nur_seine_eigenen`, `LoescheAutor_laesst_die_Beitraege_mit_AutorId_null_zurueck`, `Doppelte_Blognamen_loesen_DbUpdateException_aus`, `Das_Modell_enthaelt_die_konfigurierten_Regeln`.
