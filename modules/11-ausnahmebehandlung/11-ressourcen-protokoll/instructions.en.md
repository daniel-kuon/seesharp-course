# Extra: Safely Close Resources

Reread **Section 13.3.1.3, “Cleanup in the finally Block**” (page 895), and the section on passing errors using `throw;` in **Section 13.6** (page 913).

The `IVerbindung` interface in `Sender.cs` describes a connection that must be opened (`Oeffnen`), used (`Senden`), and closed (`Schliessen`). It is predefined; the tests provide a test connection that keeps track of the count and triggers errors as needed.

Implement `Sender.SendeAlle(verbindung, nachrichten)`:

1. The connection is established, and all messages are sent in sequence.
2. `Schliessen()` is always called exactly once: after a successful operation, after an error occurs while opening, and after an error occurs while sending. This is a case for `finally`.
3. If `Oeffnen()` fails, the exception is wrapped in an `InvalidOperationException` with the message `"Verbindung konnte nicht geöffnet werden"`; the original exception is its `InnerException`.
4. If `Senden()` fails, the method increments `Fehlschlaege` by 1 and passes the **same** exception on using `throw;` (do not wrap it, do not rethrow it).

Tests: `Erfolg_sendet_alles_und_schliesst_genau_einmal`, `Sendefehler_wird_unveraendert_weitergereicht_und_die_Verbindung_geschlossen`, `Fehler_beim_Oeffnen_wird_verpackt_und_die_Ursache_bleibt_InnerException`, and `Fehlschlaege_zaehlen_ueber_mehrere_Aufrufe`.
