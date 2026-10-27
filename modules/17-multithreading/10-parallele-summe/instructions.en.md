# Extra: Parallel Sum

Extra exercise: optional; it unlocks nothing. For further reading: **17.5.11 The Parallel Class** (page 1152), **Parallel.For()** (page 1155), **17.2.4.2.3 Atomic Operations** (page 1084) and **17.5.1.3.2 `Run()`** (page 1124).

Three classic statistical functions, calculated in parallel and compared with the sequential result. The test array contains 100,000 random numbers between 0 and 99, generated using a fixed seed: each run tests the same data.

1. `Statistik.Summe(int[])` using `Parallel.For`; each iteration adds to a shared `long` sum using `Interlocked.Add`.
2. `Statistik.Maximum(int[])`: Divide the array into four sections; each section is processed in its own `Task.Run` task to find its maximum, then the largest partial result counts. For short arrays, some sections may be empty. An empty array results in an error (`InvalidOperationException`).
3. `Statistik.Histogramm(int[] daten, int klassen)`: How many numbers fall into each of the `klassen` equally spaced classes? The class for `w` is `w * klassen / 100`. `Parallel.For`; each iteration increments its counter using `Interlocked.Increment(ref ergebnis[klasse])`. `klassen < 1` is an `ArgumentOutOfRangeException`.

The following tests must be passed:

- `ParalleleSummeTests.Summe_entspricht_der_sequenziellen_Summe`
- `ParalleleSummeTests.Summe_kleiner_und_leerer_Arrays_und_langer_Zahlen`
- `ParalleleSummeTests.Maximum_entspricht_dem_sequenziellen_Maximum`
- `ParalleleSummeTests.Maximum_findet_den_Wert_in_jedem_Abschnitt_auch_bei_kurzen_Arrays`
- `ParalleleSummeTests.Maximum_negativer_Zahlen`
- `ParalleleSummeTests.Maximum_eines_leeren_Arrays_ist_ein_Fehler`
- `ParalleleSummeTests.Histogramm_entspricht_dem_sequenziellen_Ergebnis`
- `ParalleleSummeTests.Histogramm_kleines_Beispiel`
- `ParalleleSummeTests.Histogramm_verlangt_mindestens_eine_Klasse`
