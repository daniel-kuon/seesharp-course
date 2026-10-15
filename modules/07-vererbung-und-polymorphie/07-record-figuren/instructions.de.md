# Record-Hierarchie: verlorene Positionswerte

Lies im Buch **6.7.4 Vererbung** bei Records (Seite 502) und Aufgabe 4 in
**7.16** (Seite 587).

`Figur` ist ein positionaler Record, der seine Parameter `X` und `Y`
ausdrücklich als Eigenschaften deklariert, um sie mit `CheckGE0` zu
validieren. `Kreis` leitet davon ab und ergänzt `Radius`. Das Programm
`Program.cs` gibt aber `dx=0, dy=0, dr=30` aus: Die Position kommt nicht an.

1. Baue das Projekt und lies die Warnung des Compilers zu `Kreis.cs` (CS8907:
   Parameter wird nicht gelesen). Sie zeigt die Ursache: Die
   Basisklassenangabe `: Figur` ruft den **parameterlosen** Konstruktor von
   `Figur` auf, die positionalen Parameter `X` und `Y` des Kreises werden
   nie weitergegeben.
2. Behebe das mit der kleinstmöglichen Änderung in `Kreis.cs`: Reiche die
   Parameter an den primären Konstruktor der Basis weiter.

Danach greift auch die Validierung der Basis für Kreise (`new Kreis(-1, 0,
1)` wirft), und zwei Kreise mit gleichen Werten sind gleich.
