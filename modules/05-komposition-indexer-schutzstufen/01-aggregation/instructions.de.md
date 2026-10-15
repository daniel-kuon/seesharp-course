# Aggregation: eine Aufgabe besitzt ihre Brüche

Lies im Buch Abschnitt **5.10 Aggregation bzw. Komposition** (Seite 388).

Bisher stand `Bruch` allein. Jetzt kommt eine zweite Klasse `Aufgabe` dazu, die
drei `Bruch`-Objekte als Felder besitzt: die beiden Argumente `b1` und `b2`
und die Lösung `lsg`. Eine Aufgabe rechnet nicht selbst, sondern bittet ihre
Brüche darum.

Öffne `Bruch.cs` und `Aufgabe.cs` und vervollständige:

1. `Bruch.Multipliziere(Bruch b)`: Zähler mal Zähler, Nenner mal Nenner,
   danach kürzen (Gegenstück zu `Addiere`).
2. Der Konstruktor von `Aufgabe` erzeugt `b1` und `b2` mit den Etiketten
   `"1. Argument:"` und `"2. Argument:"`, legt `lsg` mit den Werten von
   `b1` und dem Etikett `"Resultat"` an und ruft `Init()` auf.
3. `Init()` verrechnet `lsg` mit `b2`: bei `Op == '+'` per `Addiere`, bei
   `'*'` per `Multipliziere`.
4. `Pruefe(zaehler, nenner)` baut aus der Antwort einen Bruch, kürzt ihn und
   vergleicht Zähler und Nenner mit `lsg`. `2/4` ist also eine richtige
   Antwort auf `1/2`.
5. `NeueWerte(...)` ändert nur die Werte der vorhandenen Brüche (kein `new`!)
   und ruft erneut `Init()` auf. Der Test prüft `Bruch.Anzahl` vorher und
   nachher.

`Bruchrechnung.cs` enthält ein kleines Konsolenprogramm zum Ausprobieren.
