# Der erste DbContext

Lies im Buch **20.1 Erster Eindruck und Überblick** (Seite 1399) sowie **20.2**
(Seite 1402) zu den NuGet-Paketen und **20.4** (Seite 1414) zum Kontext. Entity
Framework Core (EF Core) bildet Klassen auf Tabellen ab, sodass du Daten mit Objekten
statt mit SQL speicherst und liest. Statt des SQL Servers verwenden wir das Paket
`Microsoft.EntityFrameworkCore.Sqlite` mit einer SQLite-Datenbank im Speicher.

Du brauchst drei Dinge: eine **Entitätsklasse** (`Blog`), einen **Kontext**
(`BlogContext : DbContext` mit einem `DbSet<Blog>`) und Code, der den Kontext benutzt
(`BlogRepository`).

1. `Blog.cs`: Der Name ist Pflicht und höchstens 100 Zeichen lang. Setze die Annotationen
   `[Required]` und `[MaxLength(100)]` (`System.ComponentModel.DataAnnotations`).
2. `BlogContext.cs`: Der Konstruktor übernimmt `DbContextOptions<BlogContext>` und reicht sie
   an die Basisklasse weiter. Die Optionen enthalten, welche Datenbank benutzt wird; die
   Tests übergeben eine offene SQLite-Verbindung. Mache aus `Blogs` ein echtes `DbSet<Blog>`
   (Eigenschaft mit `get` und `set`).
3. `BlogRepository.cs`:
   - `Anlegen(name)` erzeugt einen frischen Kontext (`using var`), legt das Schema mit
     `Database.EnsureCreated()` an, fügt den Blog mit `Add` hinzu, speichert mit
     `SaveChanges()` und liefert die neue `Id` (nach dem Speichern größer als 0).
     Ein Name `null` verletzt die NOT-NULL-Spalte: Die `DbUpdateException` bleibt unbehandelt.
   - `Alle()` liest mit einem **frischen Kontext pro Aufruf**. Ein Kontext ist eine kurze
     Arbeitseinheit; ein dauerhaft aufbewahrter würde veraltete Daten zeigen.

Beantworte danach die Quizfrage.

Tests: `Blog_hat_die_Annotationen_Required_und_MaxLength`, `Kontext_kennt_die_Annotationen_im_Modell`,
`Kontext_hat_ein_DbSet_fuer_Blogs`, `Anlegen_liefert_nach_SaveChanges_eine_Id_groesser_0`,
`Alle_liefert_die_gespeicherten_Blogs`, `Alle_auf_leerer_Datenbank_liefert_leere_Liste`,
`Anlegen_ohne_Namen_loest_DbUpdateException_aus`,
`Daten_sind_fuer_einen_anderen_Kontext_erst_nach_SaveChanges_sichtbar`,
`Alle_verwendet_bei_jedem_Aufruf_einen_frischen_Kontext`,
`Bei_Anlegen_wird_das_Schema_bei_Bedarf_erzeugt_und_mehrfach_verwendet`.
