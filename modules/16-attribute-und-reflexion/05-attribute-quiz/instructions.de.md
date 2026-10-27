# Attribute: Quiz

Lies im Buch **14.3 Attribute für Assemblies** (Seite 929), **14.5.2 Bedingte
Methodenausführung per ConditionalAttribute** (Seite 935), **14.5.3
Debugger-Stopps verhindern** und **14.5.5 Unions per StructLayoutAttribute**
(Seite 937 bis 940). Die Beispiele `ConditionalAttribute` und
`DebuggerStepThrough` liegen im Sample-Ordner des Buchs unter `Attribute`.

Warum ohne Programmieraufgabe? `[Conditional("DEBUG")]` hängt davon ab,
mit welchen Symbolen der Compiler läuft; das legt der Build fest, nicht der
Test. Probiere es trotzdem im Beispielprojekt `ConditionalAttribute` aus: Es
verwendet das Symbol `Kontrollausgaben`. Kommentiere die Zeile
`#define Kontrollausgaben` am Dateianfang aus und vergleiche die Ausgabe.
(Das Symbol `DEBUG` setzt dagegen der Debug-Build von selbst, der
Release-Build nicht.)

Die offene Frage am Ende wird nicht automatisch bewertet; schreib ein, zwei
Sätze auf und besprich sie mit der Betreuung.
