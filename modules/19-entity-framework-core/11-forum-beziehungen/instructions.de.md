# Zusatz: Forum mit Themen und Antworten

Lies noch einmal **20.5.11 Master-Details - Beziehung** (Seite 1429). Ein `Thema` hat viele
`Antwort`en (1:n). Die Klassen und der `ForumContext` stehen in `Datenmodell.cs`,
`ThemaAnlegen` und `Antworten` in `ForumDienst.cs` sind vorgegeben.

1. In `OnModelCreating` (Fluent API): Thema hat viele Antworten, jede Antwort gehört zu einem
   Thema (`ThemaId`); beim Löschen eines Themas werden die Antworten mitgelöscht
   (`DeleteBehavior.Cascade`).
2. `ThemaMitAntworten(id)`: das Thema samt Antworten mit `Include`, oder `null`.
3. `LoescheThema(id)`: löscht das Thema; die Antworten verschwinden durch die Kaskade mit,
   die anderer Themen bleiben.
4. `AntwortenProThema()`: ein `Dictionary<string, int>` mit der Zahl der Antworten je
   Themen-Titel, auch `0` für Themen ohne Antworten. Lass die Datenbank zählen
   (`Select(t => new { t.Titel, Anzahl = t.Antworten.Count })`).

Tests: `ThemaMitAntworten_laedt_die_Antworten_mit_Include`,
`ThemaMitAntworten_liefert_null_oder_leere_Liste`, `LoescheThema_entfernt_auch_die_Antworten`,
`LoescheThema_ohne_Antworten_und_unbekanntes_Thema`, `AntwortenProThema_zaehlt_je_Titel_auch_Nullen`,
`Das_Modell_loescht_Antworten_per_Kaskade`.
