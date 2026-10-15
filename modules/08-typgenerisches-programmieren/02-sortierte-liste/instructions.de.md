# Sortierte Liste mit where T : IComparable<T>

Lies im Buch **8.2.2 Restringierte Typformalparameter** (Seite 593).

`SimpleSortedList<T>` hält ihre Elemente beim Einfügen sortiert. Dazu muss
sie Elemente vergleichen können; das kann nicht jeder Typ. Öffne
`SimpleSortedList.cs`:

1. Schränke `T` mit `where T : IComparable<T>` ein. Danach kennt der
   Compiler `element.CompareTo(other)` (negativ: kleiner, 0: gleich,
   positiv: größer). Ohne die Einschränkung kompiliert `Add` nicht.
2. `Add(T element)`: Ist die Liste voll, wirf `InvalidOperationException`.
   Sonst gehe von hinten (`size - 1`) nach vorn und schiebe jedes Element,
   das größer als `element` ist, um eine Position nach rechts; setze
   `element` in die entstandene Lücke und erhöhe `size`. Das ist ein
   Einfügeschritt wie beim Insertion Sort.
3. Der Indexer liefert `data[index]` und wirft `ArgumentOutOfRangeException`
   für Indizes außerhalb `0 .. Count - 1`.

Die Tests verwenden die Liste mit `int` und mit `string`; beide Typen
implementieren `IComparable<T>`. Ein Reflection-Test prüft, dass die
Einschränkung wirklich in der Klasse steht.
