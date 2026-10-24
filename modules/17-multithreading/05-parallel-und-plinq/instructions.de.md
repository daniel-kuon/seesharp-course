# Parallel und PLINQ

Lies im Buch **17.5.11 Die Klasse Parallel** (Seite 1152) mit
**Parallel.Invoke()** (Seite 1153), **Parallel.For()** (Seite 1155) und
**Parallel.ForEach()** (Seite 1157) sowie **18.5 PLINQ** (Seite 1245) mit
**ForAll()** (Seite 1250) und **18.5.5 Geordnete parallele Abfragen**
(Seite 1252).

`Parallel.For` und `Parallel.ForEach` verteilen die Iterationen einer
Schleife selbständig auf mehrere Threads. PLINQ (`AsParallel()`) macht
dasselbe für LINQ-Abfragen. Das ist bequem, aber die Iterationen laufen
gleichzeitig: Alles, was sie gemeinsam benutzen, braucht Schutz (`Interlocked`
oder `lock`), sonst entsteht eine Race Condition. Und die Reihenfolge ist
nicht mehr vorgegeben.

**Die Tests sind deterministisch:** Sie messen keine Zeit. Sie vergleichen
das parallele Ergebnis mit dem sequenziellen, bei vielen Elementen, damit
fehlender Schutz auffällt.

Ergänze in `ParallelRechner.cs`:

1. `SummeQuadrate(int[] a)`: `Parallel.For` über die Indizes, jede Iteration
   addiert ihr Quadrat mit `Interlocked.Add` zu einer gemeinsamen `long`-Summe.
2. `SammleGerade(int[] a)`: `Parallel.ForEach`, gerade Elemente in eine
   gemeinsame `List<int>`. Eine `List<T>` verträgt kein gleichzeitiges `Add`:
   Schütze es mit `lock`. `SammleGeradeUnsicher` ist vorgegeben und zeigt
   den Fehler (sie wird nicht getestet): Probiere sie im Programm mit einem
   großen Array aus.
3. `Gleichzeitig(a, b, c)`: `Parallel.Invoke`.
4. `WiederholeParallel(anzahl, maxGrad, koerper)`: `Parallel.For` mit
   `ParallelOptions { MaxDegreeOfParallelism = maxGrad }`. Mit `maxGrad = 1`
   laufen die Iterationen nacheinander.
5. `Primzahlen(bis)`: PLINQ mit `Enumerable.Range(2, bis - 1).AsParallel()
   .AsOrdered().Where(IstPrim).ToList()`. `AsOrdered()` hält die Reihenfolge des
   sequenziellen Ergebnisses ein. Für `bis < 2` ist die Liste leer.

Diese Tests müssen bestehen:

- `ParallelPlinqTests.SummeQuadrate_kleine_Beispiele`
- `ParallelPlinqTests.SummeQuadrate_verliert_bei_vielen_Elementen_nichts`
- `ParallelPlinqTests.SummeQuadrate_rechnet_mit_long`
- `ParallelPlinqTests.SammleGerade_liefert_alle_geraden_Elemente`
- `ParallelPlinqTests.SammleGerade_verliert_bei_vielen_Elementen_nichts_und_verdoppelt_nichts`
- `ParallelPlinqTests.SammleGerade_ohne_gerade_Elemente_ist_leer`
- `ParallelPlinqTests.Gleichzeitig_fuehrt_jede_Aktion_genau_einmal_aus_und_kehrt_erst_danach_zurueck`
- `ParallelPlinqTests.WiederholeParallel_fuehrt_den_Koerper_genau_anzahl_Mal_aus`
- `ParallelPlinqTests.WiederholeParallel_mit_Grad_1_laeuft_nacheinander`
- `ParallelPlinqTests.WiederholeParallel_haelt_den_Parallelitaetsgrad_ein`
- `ParallelPlinqTests.Primzahlen_entsprechen_dem_sequenziellen_Ergebnis_in_derselben_Reihenfolge`
- `ParallelPlinqTests.Primzahlen_beginnen_mit_2_3_5_7`
- `ParallelPlinqTests.Primzahlen_unterhalb_von_2_gibt_es_keine`
