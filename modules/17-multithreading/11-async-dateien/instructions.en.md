# Extra: Processing Files Asynchronously

Extra exercise: optional; it unlocks nothing. For further reading: **17.6.5 `await` expression** (page 1173), **17.6.7 Exception Handling** (page 1178), and **17.6.10.1 I/O-Bound Operations** (page 1191).

File accesses are a classic use case for `async`: The thread doesn't have to wait for the disk to respond. It gets even better when you read multiple files **at the same time**.

`Dateien.ZaehleZeilenAsync(IEnumerable<string> pfade)` returns a `Dictionary<string, int>` containing the number of lines in each file:

- First, start all read operations (`File.ReadAllLinesAsync`) and then wait using `Task.WhenAll`. If you read each file individually using `await`, they will be read one after the other.
- A file that doesn't exist (`FileNotFoundException` or `DirectoryNotFoundException`) is assigned the value `-1`. Catch the exception around the `await` for each individual file; the other files will still be counted. Tip: A small `async` helper method for a file makes the `try/catch` block easier to read.
- A path that is mentioned multiple times appears only once in the result; an empty sequence returns an empty dictionary.

The tests store their files in their own unique temporary folder and clean up afterward.

The following tests must be passed:

- `AsyncDateienTests.Zaehlt_die_Zeilen_jeder_Datei`
- `AsyncDateienTests.Fehlende_Dateien_werden_mit_minus_eins_gemeldet_ohne_zu_werfen`
- `AsyncDateienTests.Mehrfach_genannte_Pfade_stehen_nur_einmal_im_Ergebnis`
- `AsyncDateienTests.Eine_leere_Folge_liefert_ein_leeres_Woerterbuch`
- `AsyncDateienTests.Viele_Dateien_auf_einmal`
