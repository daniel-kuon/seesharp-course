# Zusatz: Parallele Summe

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**17.5.11 Die Klasse Parallel** (Seite 1152), **Parallel.For()** (Seite 1155),
**17.2.4.2.3 Atomare Operationen** (Seite 1084) und **17.5.1.3.2 `Run()`**
(Seite 1124).

Drei klassische Statistikfunktionen, parallel berechnet und mit dem
sequenziellen Ergebnis vergleichbar. Das Testarray hat 100.000
Zufallszahlen zwischen 0 und 99, erzeugt mit fester Saat: jeder Lauf
prüft dieselben Daten.

1. `Statistik.Summe(int[])` mit `Parallel.For`; jede Iteration addiert mit
   `Interlocked.Add` zu einer gemeinsamen `long`-Summe.
2. `Statistik.Maximum(int[])`: Teile das Array in vier Abschnitte, jeder
   Abschnitt wird in einer eigenen `Task.Run`-Aufgabe zu seinem Maximum
   verarbeitet, dann zählt das größte Teilergebnis. Bei kurzen Arrays
   können Abschnitte leer sein. Ein leeres Array ist ein Fehler
   (`InvalidOperationException`).
3. `Statistik.Histogramm(int[] daten, int klassen)`: wie viele Zahlen fallen in
   jede von `klassen` gleich breiten Klassen? Die Klasse von `w` ist
   `w * klassen / 100`. `Parallel.For`, jede Iteration erhöht ihren
   Zähler mit `Interlocked.Increment(ref ergebnis[klasse])`. `klassen < 1` ist
   eine `ArgumentOutOfRangeException`.

Diese Tests müssen bestehen:

- `ParalleleSummeTests.Summe_entspricht_der_sequenziellen_Summe`
- `ParalleleSummeTests.Summe_kleiner_und_leerer_Arrays_und_langer_Zahlen`
- `ParalleleSummeTests.Maximum_entspricht_dem_sequenziellen_Maximum`
- `ParalleleSummeTests.Maximum_findet_den_Wert_in_jedem_Abschnitt_auch_bei_kurzen_Arrays`
- `ParalleleSummeTests.Maximum_negativer_Zahlen`
- `ParalleleSummeTests.Maximum_eines_leeren_Arrays_ist_ein_Fehler`
- `ParalleleSummeTests.Histogramm_entspricht_dem_sequenziellen_Ergebnis`
- `ParalleleSummeTests.Histogramm_kleines_Beispiel`
- `ParalleleSummeTests.Histogramm_verlangt_mindestens_eine_Klasse`
