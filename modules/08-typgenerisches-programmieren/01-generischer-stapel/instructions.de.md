# Ein generischer Stapel

Lies im Buch **8.1 Motive für generische Typen** (Seite 589) und **8.2.1
Generische Klassen: Definition** (Seite 591).

`SimpleStack<T>` ist ein Stapel (zuletzt hinein, zuerst heraus) mit fester
Kapazität. Der Typformalparameter `T` steht für den Elementtyp; erst beim
Verwenden wird er konkretisiert: `new SimpleStack<double>(10)`. Öffne
`SimpleStack.cs` und vervollständige:

1. Beide Konstruktoren legen das Array `data` vom Typ `T[]` an; `max` wird
   nur übernommen, wenn es größer als 0 ist, sonst bleibt die Kapazität 5.
2. `Count` liefert die Anzahl der Elemente.
3. `Push(T element)` legt ein Element oben ab; ist der Stapel voll, wirft
   die Methode `InvalidOperationException`.
4. `Pop()` entfernt das oberste Element und liefert es; `Peek()` liefert es,
   ohne es zu entfernen. Beide werfen bei leerem Stapel
   `InvalidOperationException`.

`Program.cs` benutzt den Stapel mit `double` und mit `string`; beides ist
dieselbe Klasse. Mit Ausnahmen beschäftigt sich Level 11; hier reicht
`throw new InvalidOperationException("…")`.
