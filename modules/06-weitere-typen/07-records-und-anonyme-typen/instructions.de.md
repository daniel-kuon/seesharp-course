# Records, anonyme Klassen, using-Alias

Lies im Buch Abschnitt **6.7 Record-Datentypen** (Seite 495) mit 6.7.1
(Definition), 6.7.2 (vom Compiler erstellte Methoden, Seite 498) und 6.7.3
(Kopierkonstruktoren und `with`, Seite 499). Für das Quiz außerdem **6.5
Anonyme Klassen** (Seite 483) und **6.8 using-Aliasdirektive** (Seite 504).

Öffne `Artikel.cs`. `Artikel` ist im Starter eine gewöhnliche Klasse mit
`init`-Eigenschaften, Konstruktor und einer handgeschriebenen `Deconstruct`.
Ein positionaler Record bekommt das alles geschenkt:

1. Ersetze den Klassenkopf durch `public record Artikel(string Name, int Menge)`
   und behalte den Rumpf mit `MitMenge` und `Plus`. Lösche Konstruktor,
   Eigenschaften und `Deconstruct`; der Compiler
   erzeugt sie, dazu `Equals`, `GetHashCode`, `==`, `!=` und ein
   `ToString()` der Form `Artikel { Name = Apfel, Menge = 3 }`.
2. `MitMenge(int menge)` und `Plus(int zusatz)` liefern Kopien mit
   geänderter Menge: `this with { Menge = … }`. Das Original bleibt
   unverändert, Records sind hier wie Strukturen wertorientiert.

Probiere in `Program.cs`, was `a == b` vor und nach dem Umbau liefert.
