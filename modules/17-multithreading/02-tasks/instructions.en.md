# Tasks: Task.Run, WhenAll, WhenAny, ContinueWith

Read **17.5.1 Creating Tasks With or Without a Return Value** (page 1120, especially 17.5.1.3.2 `Run()` on page 1124), **17.5.5.2 Waiting for Multiple Tasks** (page 1129), **17.5.8 Continuation Tasks** (page 1138), **17.5.9 Meta-Tasks** with `WhenAll` and `WhenAny` (page 1142), and **17.7.3 Wrapping Arbitrary Asynchronous Operations in Tasks** using `TaskCompletionSource` (page 1205).

A `Task` is a promise of a future result. `Task.Run` starts work in the thread pool, `ContinueWith` appends follow-up work, `WhenAll` and `WhenAny` combine tasks, and `TaskCompletionSource<T>` turns anything that is an event into a task that you complete yourself.

**The tests are deterministic:** they do not measure time and never go to sleep. Tasks that are completed "at some point" are represented in the tests as `TaskCompletionSource` objects, which the test itself completes. The wait times in the test are purely safety limits to prevent the test from hanging.

Add the following to `Berechnungen.cs`:

1. `SummeParallel(int[] a)`: Four tasks using `Task.Run`, each of which sums a section into a `long` value. The final result is the sum of the four `Result` values. The `Sensor` in `Sensor.cs` is predefined.
2. `AlleFertig(aufgaben)`: a task that does not complete until **all** of them have finished, and then returns the sorted results. The method does not block: `Task.WhenAll(...)`, then `ContinueWith`.
3. `ErsterFertiger(a, b)`: the result of the task that finishes first (`WhenAny`). The other task may never finish in the test; waiting for it would be an error.
4. `Verdopple(t)`: a continuation that returns twice `t.Result` after `t` completes. `Verdopple` does not block.
5. `WartenAufMesswert(sensor)`: a `Task<double>` that comes from the `TaskCompletionSource<double>` and completes when the first `Messwert` event occurs. After that, the method unsubscribes from the event; subsequent measurement values have no effect.

The following tests must be passed:

- `AufgabenTests.SummeParallel_summiert_Arrays_jeder_Groesse`
- `AufgabenTests.SummeParallel_rechnet_mit_long_und_ueberlaeuft_nicht`
- `AufgabenTests.SummeParallel_summiert_viele_Elemente`
- `AufgabenTests.AlleFertig_wird_erst_fertig_wenn_alle_fertig_sind_und_sortiert`
- `AufgabenTests.AlleFertig_mit_leerer_Folge_liefert_ein_leeres_Array`
- `AufgabenTests.ErsterFertiger_nimmt_die_fertige_Aufgabe_auch_wenn_die_andere_nie_fertig_wird`
- `AufgabenTests.Verdopple_wartet_nicht_und_setzt_nach_dem_Ende_fort`
- `AufgabenTests.Verdopple_funktioniert_auch_fuer_eine_schon_fertige_Aufgabe`
- `AufgabenTests.WartenAufMesswert_ist_erst_nach_dem_Ereignis_fertig`
- `AufgabenTests.WartenAufMesswert_nimmt_nur_den_ersten_Wert_und_meldet_sich_ab`
- `AufgabenTests.WartenAufMesswert_kann_mehrfach_hintereinander_benutzt_werden`
