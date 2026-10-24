# Beziehungen: Include, Kaskade und Fluent API

Lies im Buch **20.5.11 Master-Details - Beziehung** (Seite 1429), **20.5.13 bis 20.5.14**
zur Fluent API und zu `IEntityTypeConfiguration`, **20.9.7** zum Laden assoziierter Entitäten
und **20.11.4** zum Löschen. Eine 1:n-Beziehung hat einen **Fremdschlüssel** (`BlogId`) auf der
n-Seite und **Navigationseigenschaften** auf beiden Seiten (`Blog.Beitraege`, `Beitrag.Blog`).

Das Datenmodell (`Blog`, `Beitrag`, `Autor`) steht in `Datenmodell.cs`; die Methoden zum
Anlegen in `BlogDienst.cs` sind vorgegeben.

1. **`OnModelCreating`** (Fluent API) in `BlogContext`:
   - Ein Blog hat viele Beiträge, jeder Beitrag gehört zu einem Blog:
     `HasMany(...).WithOne(...).HasForeignKey(...).OnDelete(DeleteBehavior.Cascade)`.
   - Der Blogname ist eindeutig (`HasIndex(...).IsUnique()`); ein doppelter Name löst eine
     `DbUpdateException` aus.
   - Ein Beitrag hat optional einen Autor (`AutorId` ist `int?`). Wird der Autor gelöscht,
     bleibt der Beitrag mit `AutorId == null` erhalten: `DeleteBehavior.SetNull`.
2. **`BlogMitBeitraegen(id)`**: liefert den Blog samt Beiträgen mit `Include` (Eager Loading),
   oder `null`. Lazy Loading ist nicht eingerichtet; der Test gibt den Kontext frei und
   liest danach `Beitraege`.
3. **`LoescheBlog(id)`**: `Find`, `Remove`, `SaveChanges`. Die Beiträge des Blogs verschwinden durch
   die Kaskade mit; die Beiträge anderer Blogs bleiben.
4. **`LoescheAutor(id)`**: dasselbe für einen Autor; seine Beiträge bleiben stehen.

Beantworte danach die Quizfrage.

Tests: `BlogMitBeitraegen_laedt_die_Beitraege_mit_Include`,
`BlogMitBeitraegen_liefert_null_fuer_unbekannte_Id_und_leere_Liste_ohne_Beitraege`,
`LoescheBlog_loescht_auch_die_Beitraege_aber_nur_seine_eigenen`,
`LoescheAutor_laesst_die_Beitraege_mit_AutorId_null_zurueck`,
`Doppelte_Blognamen_loesen_DbUpdateException_aus`, `Das_Modell_enthaelt_die_konfigurierten_Regeln`.
