# Zusatz: Bibliotheksauskunft

Lies im Buch **18.2.10 Verknüpfen von zwei Sequenzen** (Seite 1224) und
wiederhole `Join` und `GroupJoin` aus Aufgabe 13/05.

Die Records `Autor(Id, Name)`, `Buch(Id, Titel, AutorId)` und
`Ausleihe(BuchId, Leser)` sind vorgegeben. `Auskunft` bekommt die drei
Folgen im Konstruktor; schreibe in `Auskunft.cs`:

1. `BuecherMitAutor()`: `(Titel, Autor)` für jedes Buch, dessen Autor bekannt
   ist, nach Titel sortiert (`Join`, `Select`, `StringComparer.Ordinal`).
2. `Ausleihen(leser)`: Titel der Bücher, die der Leser ausgeliehen hat, nach
   Titel sortiert (`Join` von Ausleihen und Büchern, `Where`).
3. `NieAusgeliehen()`: Titel der Bücher ohne jede Ausleihe, nach Titel
   sortiert (`GroupJoin`; die Gruppe der Ausleihen ist leer).

Tests: `BuecherMitAutor_laesst_Buecher_ohne_bekannten_Autor_weg`,
`Ausleihen_eines_Lesers`, `NieAusgeliehen_findet_Buecher_ohne_Ausleihe`,
`Ohne_Ausleihen_sind_alle_Buecher_nie_ausgeliehen`.
