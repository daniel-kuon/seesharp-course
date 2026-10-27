# Max<T>() mit generischem Serienparameter

Lies im Buch **8.5 Generische Methoden** (Seite 602) und Aufgabe 3 in
**8.8** (Seite 607). Zu Serienparametern (`params`) siehe **5.3.1.3.3** (Seite 321);
die Einschränkungsarten stehen in **8.2.2** (Seite 593).

Das Buch zeigt in 8.5 eine Methode `Max<T>(T x, T y)` für zwei Werte. Die
Übung verlangt eine Fassung für beliebig viele. Öffne `Serie.cs`:

1. `Max<T>(params T[] werte)` und `Min<T>(params T[] werte)`: Aufruf mit
   `Serie.Max(3, 9, 4)` oder mit einem Array. Durchlaufe die Serie mit
   `CompareTo`; bei leerer Serie wirf `ArgumentException`.
2. `MaxOderNull<T>(params T[] werte)` liefert `null` statt einer Ausnahme.
   Damit `T?` ein `Nullable<T>` ist, muss `T` ein Werttyp sein: Ergänze die
   Einschränkung zu `where T : struct, IComparable<T>` (die Reihenfolge ist
   vorgeschrieben: `struct` zuerst). Der Test prüft die Einschränkung per
   Reflection.
3. `Klemme<T>(wert, min, max)` begrenzt einen Wert auf einen Bereich.

Probiere in `Program.cs`, was `Serie.MaxOderNull("a", "b")` tut: Der
Compiler lehnt den Aufruf ab, weil `string` kein Werttyp ist.
