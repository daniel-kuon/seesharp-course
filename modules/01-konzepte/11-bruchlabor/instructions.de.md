# Zusatz: Bruchlabor

Zusatzaufgabe: freiwillig, sie blockiert nichts. Du benutzt die Klasse
`Bruch` aus Kapitel 1, ohne sie zu verändern, und beobachtest, wie Objekte
auf Nachrichten reagieren.

Lies im Buch **1.3 Objektorientierte Programmierung** (Seite 9)
und **1.5 Startklasse und Main()-Methode** (Seite 12).

`Bruch.cs` ist fertig, **ändere es nicht**. Ein Bruch-Objekt hat die
Eigenschaften `Zaehler` und `Nenner` sowie die Methoden `Kuerze()`,
`Addiere(Bruch b)` und `Text()` (liefert zum Beispiel `1/2`). Ein neues
Objekt entsteht mit `Bruch b = new Bruch();`, eine Eigenschaft setzt du mit
`b.Zaehler = 4;`.

Öffne `Bruchlabor.cs` und vervollständige die drei statischen Methoden. Jede
erzeugt ihre Brüche selbst und liefert am Ende `Text()` zurück:

1. `KuerzeVierAchtel()`: Bruch 4/8 anlegen, `Kuerze()` schicken. Ergebnis `1/2`.
2. `NennerNull()`: Bruch anlegen, Zähler auf 3 und **Nenner auf 0** setzen.
   Was passiert? Ergebnis `3/1`. Sieh dir in `Bruch.cs` an, warum.
3. `EinHalbPlusEinDrittel()`: zwei Brüche 1/2 und 1/3 anlegen, dem ersten die
   Nachricht `Addiere(...)` mit dem zweiten schicken. Ergebnis `5/6`.

Diese Tests müssen bestehen:

- `BruchlaborTests.Vier_Achtel_gekuerzt_ist_ein_Halb`
- `BruchlaborTests.Nenner_null_wird_abgelehnt`
- `BruchlaborTests.Ein_Halb_plus_ein_Drittel_ist_fuenf_Sechstel`
