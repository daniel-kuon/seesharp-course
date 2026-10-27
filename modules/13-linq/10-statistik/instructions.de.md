# Zusatz: Notenstatistik

Lies im Buch **18.2.11 Weitere LINQ-Operatoren** (Seite 1228) und
wiederhole `GroupBy` aus 18.2.9 (Seite 1222). `OrderBy`/`ThenBy` mit
`StringComparer.Ordinal` als zweitem Argument kennst du aus Aufgabe 13/04
(nicht im Buch).

Der Record `Pruefung(Fach, Student, Note)` hält eine Note (1,0 ist die
beste, 5,0 die schlechteste). `Notenstatistik` bekommt alle Prüfungen im
Konstruktor; schreibe in `Notenstatistik.cs`:

1. `Durchschnitt(fach)`: der Notendurchschnitt im Fach (`Where`,
   `Average`); gibt es keine Prüfung im Fach, `null`.
2. `Bestenliste(n)`: die `n` besten Prüfungen, beste zuerst; bei gleicher Note
   nach Student, dann nach Fach (`StringComparer.Ordinal`).
3. `DurchschnittProFach()`: `(Fach, Durchschnitt)` je Fach, nach Fach
   (Ordinal) sortiert (`GroupBy`).
4. `Durchgefallene()`: alle Prüfungen mit Note über 4,0 in der ursprünglichen
   Reihenfolge.

Tests: `Durchschnitt_pro_Fach`, `Durchschnitt_ohne_Pruefung_ist_null`,
`Bestenliste_ordnet_nach_Note_Student_und_Fach`,
`DurchschnittProFach_ist_nach_Fach_sortiert`,
`Durchgefallene_haben_eine_Note_ueber_4`, `Leere_Statistik`.
