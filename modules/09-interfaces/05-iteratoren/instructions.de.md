# Iteratoren mit yield: RangeItUpDown

Lies im Buch **9.5.2 Algorithmus-Enumeratoren** (Seite 651) und **9.5.3
Benannte Kollektions-Enumeratoren** (Seite 652) sowie Aufgabe 4 in **9.6**
(Seite 655).

In der vorigen Übung hast du einen Enumerator von Hand geschrieben. Mit
`yield return` übernimmt das der Compiler: Eine Methode, die
`IEnumerator<T>` oder `IEnumerable<T>` liefert und `yield` enthält, wird zu
einer Zustandsmaschine, die bei jedem `MoveNext()` bis zum nächsten `yield`
läuft. Öffne `SimpleSortedList.cs`:

1. `GetEnumerator()`: Schleife über `data[0 .. size - 1]` mit `yield return`.
2. `RangeIt(first, last)`: liefert die Elemente von `first` bis `last`
   einschließlich; liegt der Bereich außerhalb (`first < 0` oder
   `last >= size`), beendet `yield break` den Iterator, ohne etwas zu
   liefern.
3. `DownIt`: ein Iterator als **Eigenschaft**, alle Elemente absteigend.
4. `RangeItUpDown(first, last)` (Buchaufgabe): wie `RangeIt`, aber bei
   `first > last` wird abwärts gezählt. Prüfe den Bereich mit `int.Min` und
   `int.Max`, bevor du die Richtung wählst.

Beachte, dass Iteratoren **faul** sind: `si.RangeIt(1, 99)` wirft nichts und
prüft nichts, solange niemand darüber iteriert. Der Test
`Iteratoren_sind_faul` zeigt das.
