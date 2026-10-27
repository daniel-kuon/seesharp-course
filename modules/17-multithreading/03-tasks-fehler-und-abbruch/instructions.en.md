# Exceptions and Cancellation in Tasks

Read **17.5.6 Unhandled Exceptions During Task Execution** (page 1129), including **17.5.6.1 Re-throwing at a Higher Level** (page 1130) and `Flatten()` in 17.5.6.1.2 (page 1132), as well as **17.5.10 Cancelling Tasks** (page 1145).

Two rules are new compared to standard code:

- An exception in a task is not thrown where it happens but is stored in the task. Anyone waiting on the task (`Wait`, `WaitAll`, `Result`) receives it as an `AggregateException`, which contains **all** errors. Multiple tasks, multiple errors. `Flatten()` resolves nested groups; the individual exceptions are contained in `InnerExceptions`.
- A task cannot be stopped from the outside. It is canceled **cooperatively**: The caller invokes `Cancel()` on a `CancellationTokenSource`, the task periodically checks the `CancellationToken` and ends itself. The usual way is `token.ThrowIfCancellationRequested()`. The resulting `OperationCanceledException` is not an error: if the task was started with the same token (`Task.Run(..., token)`), it ends in the "canceled" state (`IsCanceled`), not "failed" (`IsFaulted`).

**The tests are deterministic:** no timing, no `Thread.Sleep`. The cancellation test uses a `ManualResetEventSlim` to wait until the task is actually running, and only then cancels. Wait times are only used to prevent hangs.

Add:

1. `Fehler.Sammle(params Func<int>[] aufgaben)` (`Fehler.cs`): run each function with `Task.Run`, then `Task.WaitAll` in a `try/catch (AggregateException)` block. Return the sorted messages of all exceptions (using `Flatten()`); if successful, return an empty list.
2. `Fehler.ErsteMeldung(Task t)`: the message of the first exception thrown by a failed task; otherwise, `null`.
3. `Zaehler.ZaehleHoch` (`Zaehler.cs`): counts without end, sets the signal at 1,000, and checks with `ThrowIfCancellationRequested` on every iteration.
4. `Suche.ErstenTreffer` (`Suche.cs`): searches for the first matching element and checks before each element whether it has been cancelled. If the token is already cancelled when the method is called, the predicate must not run even once.

The following tests must be passed:

- `FehlerAbbruchTests.Sammle_liefert_die_Meldungen_aller_Fehler_sortiert`
- `FehlerAbbruchTests.Sammle_ohne_Fehler_oder_ohne_Aufgaben_ist_leer`
- `FehlerAbbruchTests.Sammle_loest_verschachtelte_AggregateExceptions_auf`
- `FehlerAbbruchTests.Sammle_wartet_auf_alle_Aufgaben_auch_wenn_eine_frueh_scheitert`
- `FehlerAbbruchTests.ErsteMeldung_liefert_die_Meldung_der_Ausnahme`
- `FehlerAbbruchTests.ErsteMeldung_ist_null_wenn_nichts_fehlgeschlagen_ist`
- `FehlerAbbruchTests.ZaehleHoch_meldet_1000_und_endet_beim_Abbruch_als_abgebrochen`
- `FehlerAbbruchTests.ZaehleHoch_zaehlt_nichts_wenn_das_Token_schon_abgebrochen_ist`
- `FehlerAbbruchTests.ErstenTreffer_findet_das_erste_passende_Element_oder_null`
- `FehlerAbbruchTests.ErstenTreffer_ruft_das_Praedikat_bei_abgebrochenem_Token_nie_auf`
- `FehlerAbbruchTests.ErstenTreffer_bemerkt_einen_Abbruch_mitten_in_der_Suche`
