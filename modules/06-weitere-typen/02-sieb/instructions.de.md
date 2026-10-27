# Sieb des Eratosthenes

Lies im Buch Abschnitt **6.2 Arrays** (Seite 455) bis 6.2.3 (Seite 459) und
die Aufgabe 3 in **6.10** (Seite 539), die das Verfahren Schritt für Schritt
erklärt.

In Level 3 hast du einzelne Zahlen auf Primalität geprüft. Das Sieb findet
**alle** Primzahlen bis zu einer Grenze in einem Durchgang: Ein `bool`-Array
merkt sich für jede Zahl, ob sie noch Kandidat ist; beginnend mit der Basis 2
werden alle echten Vielfachen gestrichen, dann die nächste nicht gestrichene
Zahl als Basis genommen, bis die Basis größer als die Wurzel der Grenze ist.

Öffne `Primzahlen.cs` und implementiere:

1. `BisZu(int grenze)`: Array `bool[grenze + 1]` anlegen (Index = Zahl),
   Einträge ab 2 auf `true` setzen, sieben, danach die verbliebenen Zahlen
   aufsteigend in ein `int[]` passender Länge kopieren. Für `grenze < 2`
   ein leeres Array liefern.
2. `Anzahl(int grenze)`: wie viele Primzahlen es bis `grenze` gibt (bis
   1000 sind es 168).

Tipp: Die Vielfachen einer Basis `b` kannst du ab `b * b` streichen, kleinere
Vielfache sind schon weg. Basen brauchst du nur bis zur Wurzel der Grenze. Die Tests prüfen
auch die Grenze 1 000 000; ohne diese Abkürzungen dauert das spürbar länger.
