# using, Dispose, and AutoFlush

Read section **16.2, “Releasing External Resources”** (page 1026), including **16.2.1 “Dispose() or Close()**,” **16.2.3 “using Statement”** (page 1027), **16.2.4 using Declaration,** and **16.2.5 Handling Exceptions** (page 1030). For information on `AutoFlush`, see **16.3.2.1.3 Buffering Characters** (page 1038) and Exercise **16.7/2** (page 1060).

The file `Freigabe.cs` contains five methods that work in the normal case but forget streams or only close them on the success path. So that the release can be observed, they receive a factory (`Func<Stream>`) instead of a path: The tests supply a stream that counts every `Dispose`. Rewrite them so that **exactly one** `Dispose` is called per stream, even when an exception passes through:

1. `SchreibeText`: a `using` statement.
2. `Kopiere`: two nested `using` statements. First, the stream (destination) that will be opened later is released, then the source. Even if `ziel()` throws an exception, the source must still be released.
3. `ZaehleBytes`: the **using declaration** (`using var s = quelle();`); the stream is released at the end of the method, even on `return`.
4. `Verarbeite`: Releases the stream even if the passed-in action throws an exception.
5. `SchreibeSicher(pfad, zeilen)`: `using` **within** `try`, `catch (IOException)` returns `false` (for example, because the folder does not exist). Even if an error occurs in the middle of writing, the file is closed; other exceptions continue to run.

`Logger.cs` is all about `AutoFlush`. The `Logger` writes to a stream; so far, `Log` has been calling `Flush()` manually after every line:

6. Set `AutoFlush = true` in the constructor and remove the manual `Flush()`. Each line will then be immediately visible in the stream, even to a second reader.
7. `SchreibeViele(n)` (Book 16.7/2) writes `Eintrag 1` through `Eintrag n`. Flushing after each line is unreasonably slow: Disable `AutoFlush` for the loop, then call `Flush()` **once**, and set `AutoFlush` back to `true` in the `finally` block.

The following tests must be passed:

- `FreigabeTests.SchreibeText_schreibt_und_gibt_einmal_frei`
- `FreigabeTests.SchreibeText_gibt_auch_bei_einer_Ausnahme_frei`
- `FreigabeTests.Kopiere_kopiert_und_gibt_zuerst_das_Ziel_dann_die_Quelle_frei`
- `FreigabeTests.Kopiere_gibt_beide_Stroeme_frei_wenn_das_Kopieren_scheitert`
- `FreigabeTests.Kopiere_gibt_die_Quelle_frei_wenn_das_Ziel_nicht_geoeffnet_werden_kann`
- `FreigabeTests.ZaehleBytes_zaehlt_und_gibt_einmal_frei`
- `FreigabeTests.ZaehleBytes_gibt_auch_bei_einer_Ausnahme_frei`
- `FreigabeTests.Verarbeite_ruft_die_Aktion_auf_und_gibt_einmal_frei`
- `FreigabeTests.Verarbeite_gibt_frei_wenn_die_Aktion_wirft`
- `FreigabeTests.SchreibeSicher_schreibt_und_liefert_true`
- `FreigabeTests.SchreibeSicher_liefert_false_wenn_der_Ordner_fehlt`
- `FreigabeTests.SchreibeSicher_schliesst_die_Datei_nach_einem_IO_Fehler_beim_Schreiben`
- `FreigabeTests.SchreibeSicher_laesst_andere_Ausnahmen_durch_und_schliesst_trotzdem`
- `FreigabeTests.Logger_schaltet_AutoFlush_ein`
- `FreigabeTests.Logger_Zeile_ist_sofort_im_Strom_sichtbar`
- `FreigabeTests.Logger_SchreibeViele_schreibt_alle_Zeilen_mit_hoechstens_wenigen_Flushes`
- `FreigabeTests.Logger_hat_nach_SchreibeViele_wieder_AutoFlush`
