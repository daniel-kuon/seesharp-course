# Extra: Grade Statistics

Read **18.2.11 Additional LINQ Operators** (page 1228) in the book and review `GroupBy` from 18.2.9 (page 1222). `OrderBy`/`ThenBy` with `StringComparer.Ordinal` as a second argument is known from Exercise 13/04 (not in the book).

The record `Pruefung(Fach, Student, Note)` holds a grade (1.0 is the best, 5.0 is the worst). `Notenstatistik` receives all exams in its constructor; write the following in `Notenstatistik.cs`:

1. `Durchschnitt(fach)`: the average grade in the subject (`Where`, `Average`); if there is no exam in the subject, `null`.
2. `Bestenliste(n)`: the `n` best exams, best first; for equal grades by student, then by subject (`StringComparer.Ordinal`).
3. `DurchschnittProFach()`: `(Fach, Durchschnitt)` per subject, sorted by subject (ordinal) (`GroupBy`).
4. `Durchgefallene()`: All exams with a grade above 4.0, in their original order.

Tests: `Durchschnitt_pro_Fach`, `Durchschnitt_ohne_Pruefung_ist_null`, `Bestenliste_ordnet_nach_Note_Student_und_Fach`, `DurchschnittProFach_ist_nach_Fach_sortiert`, `Durchgefallene_haben_eine_Note_ueber_4`, `Leere_Statistik`.
