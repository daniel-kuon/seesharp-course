# Parallel and PLINQ

Read **17.5.11 The Parallel Class** (page 1152), which covers **Parallel.Invoke()** (page 1153), **Parallel.For()** (page 1155), and **Parallel.ForEach()** (page 1157), as well as **18.5 PLINQ** (page 1245) with **ForAll()** (page 1250) and **18.5.5 Ordered Parallel Queries** (page 1252).

`Parallel.For` and `Parallel.ForEach` automatically distribute the iterations of a loop across multiple threads. PLINQ (`AsParallel()`) does the same for LINQ queries. This is convenient, but the iterations run concurrently: Anything they share must be protected (using `Interlocked` or `lock`), otherwise a race condition will occur. And the order is no longer guaranteed.

**The tests are deterministic:** they do not measure time. They compare the parallel result with the sequential one, using many elements, so that any lack of protection becomes apparent.

Add the following to `ParallelRechner.cs`:

1. `SummeQuadrate(int[] a)`: `Parallel.For` loop through the indices; each iteration adds the square of its element to a shared `long` sum using `Interlocked.Add`.
2. `SammleGerade(int[] a)`: `Parallel.ForEach`, collects even elements into a shared `List<int>`. A `List<T>` cannot handle concurrent `Add` operations: Protect it with `lock`. `SammleGeradeUnsicher` is provided and demonstrates the error (it is not tested): Try it out in the program with a large array.
3. `Gleichzeitig(a, b, c)`: `Parallel.Invoke`.
4. `WiederholeParallel(anzahl, maxGrad, koerper)`: `Parallel.For` with `ParallelOptions { MaxDegreeOfParallelism = maxGrad }`. When `maxGrad = 1`, the iterations run sequentially.
5. `Primzahlen(bis)`: PLINQ using `Enumerable.Range(2, bis - 1).AsParallel().AsOrdered().Where(IstPrim).ToList()`. `AsOrdered()` preserves the order of the sequential result. For `bis < 2`, the list is empty.

The following tests must be passed:

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
