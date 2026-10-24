# Threads, lock, and Interlocked

Read sections **17.1 Introduction** (page 1062), **17.2.1 Creating Threads,** and **17.2.2 Starting Threads** (pages 1065–1068), **17.2.4.1.1 The `lock` Statement** (page 1073), and **17.2.4.2.3 Atomic Operations** (page 1084). Threads share the heap but each has its own stack. This is precisely what makes shared data dangerous: Two threads that modify the same variable can overwrite each other’s changes.

**All tests in this exercise are deterministic.** They do not measure time and never sleep. They use `Join()` to wait for the threads (the time limits are only there to prevent a deadlock) and use a `Barrier` to have the threads start simultaneously so that their work overlaps as much as possible.

1. `Parallelrechner.Berechne` (file `Parallelrechner.cs`) applies a function to each element of an array, distributed across threads. `Quadrate` is already using it. Split the array into contiguous blocks (at most `threads` in size; the last one may be shorter), start a separate `Thread` for each block that writes its results to a shared result array, and wait for all of them to finish using `Join()`. The threads write to different elements, so the array does not need a `lock`. Note the pitfall with the loop variable (closure) in the thread’s lambda: copy it to a local variable beforehand. If `threads < 1`, a `ArgumentOutOfRangeException` is thrown.
2. `UnsichererZaehler` is predefined and intentionally incorrect. Read the comment and run the program: The value is less than 400,000, and it's different every time you run it.
3. `SichererZaehler`: Increment **and** read the counter using `lock` on a private lock object.
4. `AtomarerZaehler`: Increment using `Interlocked.Increment`, without a `lock`.
5. Answer the quiz question about race conditions.

The following tests must be passed:

- `SynchronisationTests.SichererZaehler_verliert_keine_Updates`
- `SynchronisationTests.AtomarerZaehler_verliert_keine_Updates`
- `SynchronisationTests.Zaehler_beginnen_bei_null_und_zaehlen_einzeln`
- `SynchronisationTests.Quadrate_liefert_alle_Quadrate_in_der_richtigen_Reihenfolge`
- `SynchronisationTests.Quadrate_funktioniert_auch_fuer_leere_kleine_und_ungerade_Arrays`
- `SynchronisationTests.Quadrate_veraendert_die_Eingabe_nicht`
- `SynchronisationTests.Weniger_als_ein_Thread_ist_ein_Fehler`
- `SynchronisationTests.Die_Bloecke_laufen_wirklich_gleichzeitig_auf_eigenen_Threads`
