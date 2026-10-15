# Eine float-Matrix mit Transponieren

Lies im Buch Abschnitt **6.2.9 Mehrdimensionale Arrays** (Seite 467) und
Aufgabe 4 in **6.10** (Seite 541). Für den zweidimensionalen Indexer siehe
**5.12.3** (Seite 397), für die Tupelzuweisung **6.6** (Seite 486).

`FloatMatrix` kapselt ein rechteckiges Array `float[,]`. Öffne
`FloatMatrix.cs` und vervollständige:

1. Der Konstruktor legt das Array nur bei sinnvollen Maßen an (`z > 0`,
   `s > 0`, höchstens `maxSize` Elemente) und setzt `Zeilen` und `Spalten`;
   sonst bleibt die Matrix leer (0 × 0).
2. Der Indexer `this[int z, int s]` liest und schreibt `data[z, s]`.
3. `Transponieren()` spiegelt die Matrix an der Hauptdiagonale: Aus
   `m[i, j]` wird `m[j, i]`.
   - Quadratisch: in place, indem du jedes Element unterhalb der Diagonale
     mit seinem Gegenstück oberhalb tauschst. Eine Tupelzuweisung
     `(a, b) = (b, a)` spart die Hilfsvariable.
   - Sonst: neues Array mit vertauschten Maßen füllen, `Zeilen` und
     `Spalten` tauschen, Array ersetzen.

`FloatMatrixDemo.cs` zeigt eine 3 × 5-Matrix vor und nach dem Transponieren.
