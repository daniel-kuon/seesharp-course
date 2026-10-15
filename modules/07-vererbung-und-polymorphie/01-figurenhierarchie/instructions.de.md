# Eine Figurenhierarchie

Lies im Buch die Abschnitte **7.3 Definition einer abgeleiteten Klasse**
(Seite 547), **7.4 Konstruktoren und Vererbung** (Seite 549), **7.5
Zugriffsmodifikator protected** (Seite 554), **7.7 Verwaltung von Objekten
über Basisklassenreferenzen** (Seite 561) und **7.8 Typtest-Operatoren**
(Seite 563).

`Figur` ist fertig: Position `xpos`/`ypos` (als `protected`), ein
validierender Konstruktor, die Eigenschaft `Wo`. `Kreis` und `Rechteck`
sollen davon erben:

1. Beide Klassen sind bereits mit `: Figur` von `Figur` abgeleitet; sieh
   dir an, wie wenig dafür nötig ist, und was sie damit alles erben.
2. Reiche im Konstruktor `x` und `y` mit `: base(x, y)` an den
   Basiskonstruktor weiter; den Radius bzw. Breite und Höhe übernimmst du
   nur, wenn sie nicht negativ sind (sonst bleiben die Vorgaben 75 bzw.
   50 × 50).
3. `UntenRechts` berechnet die untere rechte Ecke aus den geerbten
   `protected`-Feldern: Kreis `(xpos + 2·radius, ypos + 2·radius)`,
   Rechteck `(xpos + breite, ypos + hoehe)`.
4. `Figur.SummeRadien(Figur[] figuren)` läuft über ein Array von
   Basisklassenreferenzen und addiert die Radien aller Kreise. Der Typtest
   mit Musterdeklaration `if (f is Kreis k)` liefert die passende Referenz.

`Program.cs` legt ein `Figur[]` mit gemischten Figuren an und zeigt, dass
jede Figur ihren Laufzeittyp kennt (`GetType().Name`).
