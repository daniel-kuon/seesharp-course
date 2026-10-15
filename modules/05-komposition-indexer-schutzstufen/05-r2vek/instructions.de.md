# Vektoren in der Ebene (R²)

Lies im Buch **5.15 Übungsaufgaben zum Kapitel 5**, Aufgabe 4 (Seite 425).
Nachschlagen: **4.5.2 Methodenaufruf** (Klasse `Math`, Seite 220).

Die Klasse `R2Vek` beschreibt einen Vektor mit den Koordinaten `X` und `Y`.
Öffne `R2Vek.cs` und vervollständige:

1. `Laenge`: berechnete Nur-Lese-Eigenschaft, Wurzel aus `X² + Y²`. Es gibt
   kein Feld dafür; der Wert wird bei jedem Lesen neu berechnet.
2. `Normiere()`: teilt beide Koordinaten durch die Länge, sodass der Vektor
   die Länge 1 bekommt. Ist die Länge kleiner als `1e-14`, passiert nichts
   und die Methode liefert `false`, sonst `true`.
3. `Addiere(R2Vek)` verändert **diesen** Vektor; `Plus(R2Vek)` lässt beide
   Vektoren in Ruhe und liefert einen **neuen** Vektor mit der Summe.
4. `SP(R2Vek)`: Skalarprodukt `X·X' + Y·Y'`.
5. `Winkel(R2Vek)`: Winkel zwischen beiden Vektoren in **Grad**. Der Kosinus
   des Winkels ist das Skalarprodukt geteilt durch das Produkt der Längen;
   `Math.Acos` liefert Bogenmaß, `double.RadiansToDegrees` rechnet um.
6. `Drehe(double deg)`: dreht den Vektor um `deg` Grad gegen den
   Uhrzeigersinn: `x' = cos·x − sin·y`, `y' = sin·x + cos·y`. Merke dir den
   alten `X`-Wert, bevor du ihn überschreibst, denn `Y` braucht ihn noch.

Die Tests vergleichen Gleitkommawerte mit einer Toleranz, exakte Gleichheit
ist bei `double` nicht zu erwarten (siehe Level 2).
