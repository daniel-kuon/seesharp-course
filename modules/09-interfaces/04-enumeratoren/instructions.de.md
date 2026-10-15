# IEnumerable<T> und ein handgeschriebener IEnumerator<T>

Lies im Buch **9.5 IEnumerable<T> und IEnumerator<T>** (Seite 647) mit
**9.5.1 Kollektions-Enumeratoren** (Seite 648) sowie **9.1.4.1** zu den
Schnittstellen `IEnumerable<T>` und `IEnumerable` (Seite 631).

`foreach` funktioniert mit jedem Typ, der `IEnumerable<T>` implementiert:
Es holt sich mit `GetEnumerator()` einen Enumerator und ruft so lange
`MoveNext()` auf, wie der `true` liefert; `Current` ist jeweils das aktuelle
Element. Das Buch lässt diese Arbeit in 9.5 den Compiler machen (`yield`,
nächste Übung); hier schreibst du den Enumerator einmal von Hand, um zu
sehen, was dahinter steckt. Öffne `SimpleSortedList.cs`:

1. Die geschachtelte Klasse `Enumerator` merkt sich die Liste und eine
   Position, die vor dem ersten Element (`-1`) beginnt. `MoveNext()` rückt
   die Position weiter und liefert `true`, solange sie auf ein Element
   zeigt; am Ende bleibt sie stehen und liefert `false`. `Current` liefert
   `liste.data[position]` (die geschachtelte Klasse darf auf das private
   Array zugreifen) und wirft `InvalidOperationException`, wenn es kein
   aktuelles Element gibt. `Reset()` springt zurück vor das erste Element.
2. `GetEnumerator()` liefert bei jedem Aufruf einen **neuen** Enumerator;
   zwei verschachtelte `foreach`-Schleifen über dieselbe Liste müssen
   unabhängig laufen.
3. Das nicht-generische `IEnumerable.GetEnumerator()` ist explizit
   implementiert und delegiert einfach an die generische Fassung.

Der Kollektionsinitialisierer `new SimpleSortedList<int> { 11, 2 }` in
`Program.cs` funktioniert, weil die Klasse `IEnumerable` und `Add` hat.
