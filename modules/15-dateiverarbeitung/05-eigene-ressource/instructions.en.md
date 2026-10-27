# A Custom IDisposable Class

Read **sections 5.4.5 "Clearing Unneeded Objects**" (page 355), **16.2.1 "Dispose() or Close()**," and **16.2.2 "Garbage Collector**" (pages 1026–1027) in the book.

If you hold a file or another external resource in a field, you must let your users release it: through `IDisposable`. Then the `using` statement and the `using` declaration also work for your class. Open `Logbuch.cs`. The Logbook opens a file in the constructor and writes lines to it using `Eintrag(text)`:

1. `Dispose()` closes the `StreamWriter` (and thus the file).
2. `Dispose()` is **idempotent**: A second or third call has no effect.
3. After `Dispose()`, `Eintrag(…)` throws an `ObjectDisposedException` (Tip, not in the book, given here: `ObjectDisposedException.ThrowIf(bedingung, this)` throws it if the condition is true; it is derived from `InvalidOperationException`).
4. The static property `Offene` counts logbooks that have been created but not yet released: It is incremented in the constructor after the file has been successfully opened (if the constructor fails, there is nothing to release) and decremented exactly once in `Dispose()`.

You don't need a finalizer (`~Logbuch`): The class holds only one managed object, which handles the file on its own (16.2.2).

The following tests must be passed:

- `LogbuchTests.Logbuch_implementiert_IDisposable`
- `LogbuchTests.Eintraege_stehen_nach_dem_Dispose_in_der_Datei`
- `LogbuchTests.Dispose_gibt_die_Datei_frei`
- `LogbuchTests.Offene_zaehlt_erzeugte_und_noch_nicht_freigegebene_Logbuecher`
- `LogbuchTests.Zweites_Dispose_tut_nichts`
- `LogbuchTests.Eintrag_nach_Dispose_wirft_ObjectDisposedException`
- `LogbuchTests.Using_gibt_auch_frei_wenn_eine_Ausnahme_durchlaeuft`
- `LogbuchTests.Scheitert_der_Konstruktor_wird_nichts_gezaehlt`
- `LogbuchTests.Ohne_Dispose_bleibt_die_Datei_gesperrt`
