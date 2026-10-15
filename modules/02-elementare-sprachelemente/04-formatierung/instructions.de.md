# Zeichenketten und Formatierung

Lies im Buch Abschnitt **4.2.2 Ausgabe einer (zusammengesetzten)
Zeichenfolge** (Seite 176) und **4.2.3 Formatierte Ausgabe** (Seite 176),
besonders 4.2.3.2 zur Zeichenfolgeninterpolation (Seite 178). Zu
Escape-Sequenzen siehe **4.3.10.5** (Seite 208).

Öffne `Formatierung.cs`:

1. `SummeText()` soll `3 + 2 = 5` liefern. Die vorhandene Fassung liefert
   `3 + 2 = 32`. Erkläre dir, warum, und behebe es mit einem Klammerpaar.
2. `Bruchzeile(int zaehler, int nenner)` liefert per Interpolation den Text
   `zaehler/nenner`, also `Bruchzeile(3, 4)` gibt `3/4`.
3. `Ausgerichtet(int i, int j, int k, int m)` liefert **eine** Zeichenkette
   mit Zeilenumbrüchen (`\n`) und Tabulatoren (`\t`) in genau diesem Aufbau
   (die Zahlen rechtsbündig in Breite 4, dann linksbündig in Breite 4):

   ```
   Rechtsbündig:
   	i = 4711
   	j =  471
   	k =   47
   	m =    4

   Linksbündig:
   	4711 (i)
   	471  (j)
   	47   (k)
   	4    (m)
   ```

   Jede Zeile außer der ersten beginnt mit einem Tabulator; nach der letzten
   Zeile folgt kein Zeilenumbruch. Zwischen den Blöcken steht eine Leerzeile.

Diese Tests müssen bestehen:

- `FormatierungTests.SummeText_rechnet_in_Klammern`
- `FormatierungTests.Bruchzeile_interpoliert`
- `FormatierungTests.Ausgerichtet_rechts_und_linksbuendig`
