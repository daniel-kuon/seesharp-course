# Strukturen, Wertsemantik und Boxing

Lies im Buch Abschnitt **6.1 Strukturen** (Seite 431), besonders 6.1.1
(Wertsemantik, Seite 434), 6.1.2 (Erzeugen und Initialisieren, Seite 438) und
6.1.6 (Boxing, Seite 450). Die Quizfrage zu `o1 == o2` ist Aufgabe 1 aus
6.10 (Seite 537).

Öffne `Punkt.cs`. `Punkt` ist im Starter noch eine **Klasse**; die Tests
erwarten eine **Struktur**:

1. Ersetze `class` durch `struct`. Alles andere (Primärkonstruktor,
   Eigenschaften, der verkettete parameterlose Konstruktor `: this(0, 0)`)
   darf bleiben.
2. Implementiere `Verschoben(Punkt p, double hor, double vert)`: Bei einer
   Struktur ist `p` bereits eine Kopie des Arguments. Verschiebe sie und gib
   sie zurück; der Punkt des Aufrufers bleibt unverändert.

Probiere in `PunktDemo.cs` aus, was `var p3 = p1; p1.Bewegen(1, 0);` bei
einer Klasse und bei einer Struktur mit `p3` macht. Der Test
`Geboxte_Kopien_sind_unabhaengig` zeigt dasselbe mit `object`: Die Zuweisung
an `object` boxt und kopiert.
