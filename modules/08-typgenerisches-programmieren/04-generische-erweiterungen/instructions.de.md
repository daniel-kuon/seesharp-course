# Generische Erweiterungsmitglieder

Lies im Buch **8.6 Generische Erweiterungsmitglieder** (Seite 604) und
noch einmal **7.15.2 Erweiterungsblöcke** (Seite 583).

Der Erweiterungsblock `extension<T>(T[] arr) where T : IComparable<T>`
rüstet **alle** Arrays vergleichbarer Elemente nach. Öffne `ArrayExt.cs`:

1. `MinFirst` (Eigenschaft im Block): `null` für ein leeres Array, sonst
   `true`, wenn kein Element kleiner als `arr[0]` ist.
2. `Groesstes()` (Methode im Block): das größte Element per `CompareTo`;
   leeres Array wirft `InvalidOperationException`. Nicht sortieren.
3. `LeadingMin<T>(this T[] arr)`: dieselbe Logik wie `MinFirst` in der
   klassischen Form einer generischen Erweiterungsmethode; die
   Einschränkung steht hier hinter der Parameterliste.
4. `Umgekehrt<T>(this T[] arr)`: neues Array in umgekehrter Reihenfolge.
   Hier wird nichts verglichen, also keine Einschränkung.

Beim Aufruf schreibst du nie `<int>` hin: `zahlen.MinFirst`,
`zahlen.LeadingMin()`, `woerter.Umgekehrt()`; der Compiler leitet `T` aus
dem Empfänger ab.
