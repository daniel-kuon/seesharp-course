# Extra: Transfers with a log

Read section **19.7.7**, **“DbTransaction”** (page 1332), again. In `Bank.cs`, there is a `Ueberweise` method that debits and credits an account, but **without a transaction**: if the credit fails, the debited money is lost. In addition, every successful transfer should leave a row in the `Protokoll(Id, Von, Nach, Betrag)` table.

Expand `Ueberweise`:

1. Start a transaction and attach it to **all** commands (`befehl.Transaction`).
2. After the credit entry, insert the log line (parameter, in the same transaction).
3. `Commit()`—on every exception, call `Rollback()` and propagate it with `throw;`.

It is important that the log be part of the transaction: If a transfer fails (due to insufficient funds, a missing destination account, or even a failure to log the transaction itself), neither a posting nor a log entry remains. The `Protokoll()` method is provided for reading the log.

Tests: `Erfolgreiche_Ueberweisung_wird_gebucht_und_protokolliert`, `Mehrere_Ueberweisungen_werden_in_Reihenfolge_protokolliert`, `Ueberweisung_ohne_Guthaben_hinterlaesst_keine_Protokollzeile`, `Ueberweisung_an_fehlendes_Konto_stellt_die_Abbuchung_wieder_her`, `Scheitert_das_Protokollieren_wird_auch_die_Buchung_zurueckgenommen`, `Nach_einem_Fehler_funktionieren_weitere_Ueberweisungen`.
