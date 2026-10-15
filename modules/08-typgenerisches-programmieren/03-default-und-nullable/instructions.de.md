# default(T) und Nullable<T>

Lies im Buch **8.7 default-Operator** (Seite 605), **8.5 Generische
Methoden** (Seite 602) und **8.3 Nullable<T> als Beispiel für generische
Strukturen** (Seite 598) mit 8.3.2 zu den Koaleszenzoperatoren (Seite 600).

Eine generische Methode hat ihren eigenen Typformalparameter:
`BeschreibeDefault<T>()` wird mit `Werte.BeschreibeDefault<int>()`
aufgerufen. Öffne `Werte.cs`:

1. `BeschreibeDefault<T>()`: `default(T)` liefert den Standardwert des
   Typs, 0 für Zahlen, `false` für `bool`, `null` für Referenztypen und für
   `Nullable<T>`. Gib `"null"` zurück, wenn der Wert null ist, sonst
   `ToString()` des Werts.
2. `ErstesOderDefault<T>(T[] arr)`: das erste Element oder `default`, wenn
   das Array leer ist. Hier reicht das Literal `default`, der Compiler
   kennt `T`.
3. `Summe(int?[] werte)`: `int?` ist `Nullable<int>`, eine Struktur mit
   `HasValue` und `Value`. Summiere nur vorhandene Werte.
4. `OderErsatz(int? wert, int ersatz)`: der null-Koaleszenzoperator `??`
   erledigt das in einer Zeile.

Beim Aufruf von `ErstesOderDefault([5, 6])` musst du `<int>` nicht
hinschreiben: Der Compiler leitet `T` aus dem Argument ab (Typinferenz).
