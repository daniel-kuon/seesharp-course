# Ein Interface implementieren

Lies im Buch die Einleitung zu Kapitel **9 Interfaces** (Seite 609), **9.1
Interfaces definieren** (Seite 614, nur 9.1.1.1), **9.2 Interfaces
implementieren** (Seite 640) und **9.3 Interfaces als Referenzdatentypen**
(Seite 644) mit dem Boxing-Fall in 9.3.2 (Seite 645).

`IForm` verlangt von einer Form einen Namen, einen Flächeninhalt, einen
Umfang und eine Skalierung. Öffne `IForm.cs`:

1. Implementiere die vier Mitglieder in `Kreis` (eine Klasse; Fläche
   `π·r²`, Umfang `2·π·r`, Skalieren multipliziert den Radius).
2. Implementiere sie in `Quadrat` (eine Struktur; Fläche `s²`, Umfang `4·s`,
   Skalieren multipliziert die Seite). Strukturen dürfen Interfaces
   implementieren, aber nicht von einer Basisklasse erben.
3. `Formen.Gesamt(IForm[])` summiert die Inhalte; `Formen.Groesste(IForm[])`
   liefert den Namen der Form mit dem größten Inhalt (leeres Array: `""`).
   Beide Methoden kennen nur das Interface, nicht die konkreten Typen.

Sieh dir in `Program.cs` den Boxing-Fall an: `IForm geboxt = q;` kopiert
die Struktur auf den Heap. `q.Skaliere(3)` ändert `q`, nicht die Kopie in
`geboxt`.
Der letzte Test prüft genau das.
