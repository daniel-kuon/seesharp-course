# Kollektionen: Listen, Mengen, Wörterbücher

Arrays haben eine feste Größe: Wer ein Element einfügen oder entfernen will,
muss selbst ein neues Array anlegen und umkopieren. Die Kollektionsklassen
im Namensraum `System.Collections.Generic` nehmen einem diese Arbeit ab, wachsen
mit und bieten fertige Methoden zum Suchen, Einfügen und Entfernen (Kapitel 11,
Seite 691; 11.1 Arrays versus Kollektionen). Alle generischen Kollektionen
implementieren `IEnumerable<T>`, die meisten auch `ICollection<T>` (11.2,
Seite 693; `Queue<T>` und `Stack<T>` nicht). Wer Parameter mit
diesen Interfaces deklariert statt mit `List<T>`, schreibt Code, der für Listen,
Mengen und Arrays gleichermaßen funktioniert.

## Initialisierer und Kollektionsausdrücke (11.3, Seite 695)

Ein Kollektionsinitialisierer füllt eine Kollektion bei der Erzeugung
(`new List<string> { "a", "b" }`); dahinter steckt für jedes Element ein
`Add()`-Aufruf. In Objektinitialisierern darf eine Kollektionseigenschaft mit
`Artikel = { "A", "B" }` befüllt werden. Der Kollektionsausdruck `[1, 2, 3]`
braucht einen Zieltyp (`int[]`, `List<int>`, `IReadOnlyList<int>`); mit dem
Spread-Element `..` (im Buch: Bereichsoperator) fügt man eine ganze Folge ein: `[rand, ..mitte, rand]`.
`var x = [];` geht nicht, denn es fehlt der Zieltyp.

## Listen, Warteschlangen, Stapel, verkettete Listen (11.4, Seite 697 bis 702)

`List<T>` ruht auf einem Array, das bei Bedarf vergrößert wird. Sie bietet
`Add`, `Insert`, `Remove`, `RemoveAt`, `Contains`, `IndexOf`,
`Sort`, `Reverse`, `GetRange` und `ToArray`; der Indexer greift schnell
zu. Wichtig: Während eines `foreach` darf man die Liste nicht verändern, das
löst zur Laufzeit eine `InvalidOperationException` aus (4.7.3.2, Seite 275).
Sicher geht es mit einer `for`-Schleife, die rückwärts läuft (`RemoveAll()`
braucht einen Lambda-Ausdruck, der erst in Level 12 kommt). `Queue<T>`
(Warteschlange, FIFO: `Enqueue`, `Dequeue`, `Peek`) und `Stack<T>` (Stapel,
LIFO: `Push`, `Pop`, `Peek`) sind Spezialisierungen für genau diese
Reihenfolge; das Buch nennt sie in 11.4 (Seite 697) nur kurz. `LinkedList<T>`
verbindet Knoten (`LinkedListNode<T>`) in beide Richtungen; Einfügen und
Entfernen an bekannter Stelle kostet kaum etwas (11.4.2, Seite 700).

## Mengen (11.5, Seite 702 bis 714)

`HashSet<T>` verwaltet Elemente in einer Hashtabelle: kein Duplikat,
keine feste Reihenfolge, sehr schnelle Existenzprüfung. `Add()` liefert
`false`, wenn das Element schon da war. Mengenoperationen wie `UnionWith`,
`IntersectWith`, `ExceptWith` und `IsSubsetOf` verändern die Menge oder
fragen Beziehungen ab. Eigene Elementtypen brauchen passende `Equals()`- und
`GetHashCode()`-Methoden, sonst gelten zwei gleiche Punkte als verschieden
(11.5.2.1, Seite 704, und 11.5.2.3, Seite 708). `SortedSet<T>` speichert in einem balancierten
Binärbaum, ist immer aufsteigend sortiert und kennt `Min`, `Max` und
`GetViewBetween()` (11.5.3, Seite 711).

## Wörterbücher (11.6, Seite 714)

`Dictionary<TKey,TValue>` ordnet jedem Schlüssel einen Wert zu. Der Indexer
setzt oder liest; ein fehlender Schlüssel beim Lesen löst eine Ausnahme aus,
darum fragt man mit `TryGetValue()` oder `ContainsKey()`. Ein `foreach` liefert
`KeyValuePair`-Objekte, außerdem gibt es `Keys` und `Values`. Auf die
Reihenfolge der Aufzählung darf man sich nicht verlassen. Um mehrere Werte
pro Schlüssel zu sammeln, nimmt man `Dictionary<K, List<V>>`.

## Schreibgeschützt und unveränderlich (11.7, Seite 716)

`AsReadOnly()` gibt nur eine **Sicht** heraus (`ReadOnlyCollection<T>`): Der
Empfänger kann nichts ändern, sieht aber spätere Änderungen des Besitzers.
Gibt man die Liste selbst als `IReadOnlyList<T>` heraus, ist nicht einmal das
sicher: Ein Cast zurück auf `List<T>` genügt zum Ändern.
`ImmutableList<T>` aus `System.Collections.Immutable` dagegen ist wirklich
unveränderlich; `Add()` liefert eine neue Liste und lässt die alte unverändert.
Das erspart Synchronisierung, wenn mehrere Threads mit denselben Daten
arbeiten (11.7, Seite 716).

## Die richtige Kollektion wählen

Frage nach der Anforderung: Reihenfolge und Indexzugriff (`List<T>`), Warten
in der Reihe (`Queue<T>`), Rückgängig-Verlauf (`Stack<T>`), Existenzprüfung
und Mengenlehre (`HashSet<T>`), sortiert ohne Duplikate (`SortedSet<T>`),
Zugriff über Schlüssel (`Dictionary<K,V>`). `Contains()` kostet in einer Liste
O(n), in einem `HashSet<T>` O(1) (11.5.3, Seite 713); bei großen Datenmengen ist das der
Unterschied zwischen Sekunden und Millisekunden (Messung im Buch: 11.5.2.3,
Seite 710). Die Übungsaufgaben am
Kapitelende (11.8, Seite 723) prüfen genau dieses Wissen.
