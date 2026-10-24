# Transactions: Commit and Rollback

Read sections **19.7.7 "DbTransaction"** (page 1332) and **19.7.8** on `TransactionScope` in the book. A transaction groups together multiple statements: Either they are all confirmed with `Commit()`, or `Rollback()` reverts them all (ACID, 19.7.7.1).

Open `Bank.cs`. A bank transfer consists of two `UPDATE` commands on the `Konto(Id, Inhaber, Saldo)` table: debit and credit. Nothing should happen in between that would leave only one of them.

1. `Ueberweise(c, von, nach, betrag, nachAbbuchung)`:
   - `c.BeginTransaction()`; both commands take parameters; set `befehl.Transaction = transaktion` for each one; and call `Commit()` at the end.
   - If the balance is insufficient or an account is missing (an `UPDATE` updates 0 rows), throw an `InvalidOperationException`; everything will be rolled back.
   - If any other exception occurs (the tests trigger it via the `nachAbbuchung` parameter in the middle of the transaction), call `Rollback()` and pass it on unchanged using `throw;`.
2. `Mehrfach(c, ueberweisungen)`: all transfers in **a single** transaction: all or none. SQLite does not support nested transactions; therefore, break down the work so that both methods use the same private helper methods with a passed-in transaction.

Then answer the quiz question about `TransactionScope`.

Tests: `Ueberweise_bucht_ab_und_schreibt_gut`, `Ueberweise_erlaubt_genau_das_Guthaben`, `Ueberweise_ohne_Guthaben_nimmt_alles_zurueck`, `Ueberweise_auf_fehlendes_Zielkonto_stellt_die_Abbuchung_wieder_her`, `Ueberweise_von_fehlendem_Quellkonto_aendert_nichts`, `Ausnahme_in_der_Transaktion_fuehrt_zum_Rollback_und_wird_mit_throw_weitergereicht`, `Nach_einem_Fehler_ist_die_Verbindung_wieder_frei_fuer_neue_Transaktionen`, `Mehrfach_bucht_alle_Ueberweisungen`, `Mehrfach_ist_alles_oder_nichts_bei_zu_wenig_Guthaben`, `Mehrfach_ist_alles_oder_nichts_bei_fehlendem_Konto`, `Mehrfach_ohne_Ueberweisungen_aendert_nichts`.
