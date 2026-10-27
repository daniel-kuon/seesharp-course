# Zusatz: Bücherverwaltung

Lies noch einmal **20.11 Entitäten erstellen, modifizieren und löschen** (Seite 1472).
`Buch` (`Id`, `Titel`, `Autor`, `Jahr`, `Ausgeliehen`) und `BuchContext` sind vorgegeben.
In `Buecherei.cs` verwaltest du die Bücher; **jeder Aufruf verwendet einen frischen Kontext**
in einer `using`-Anweisung.

1. `Aufnehmen(titel, autor, jahr)`: Schema bei Bedarf mit `kontext.Database.EnsureCreated();`
   (nicht im Buch, wie in Aufgabe 1 vorgegeben), `Add`, `SaveChanges`;
   liefert die neue `Id`.
2. `Ausleihen(id)`: setzt `Ausgeliehen = true`. `false`, wenn es das Buch nicht gibt oder es
   schon ausgeliehen ist.
3. `Entfernen(id)`: löscht das Buch; `true`, wenn es eines gab.
4. `Suche(teil)`: Bücher, deren Titel `teil` enthält, nach Titel sortiert.

Tests: `Aufnehmen_speichert_das_Buch_und_liefert_die_Id`, `Aufnehmen_legt_das_Schema_bei_Bedarf_an`,
`Ausleihen_markiert_das_Buch_als_ausgeliehen`,
`Ausleihen_scheitert_bei_schon_ausgeliehenem_oder_unbekanntem_Buch`,
`Entfernen_loescht_genau_das_Buch`, `Suche_findet_Teiltext_und_sortiert_nach_Titel`,
`Suche_mit_leerem_Text_liefert_alle_sortiert`.
