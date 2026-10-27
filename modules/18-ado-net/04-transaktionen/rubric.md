# Rubrik: Transaktionen: Commit und Rollback (nur für die Betreuung)

- **Kernidee:** Zusammengehörige Änderungen bilden eine Einheit (Atomarität): Nach
  einem Fehler an beliebiger Stelle ist der Zustand wie vor Beginn. Muster:
  `BeginTransaction`; `try { Befehle; Commit } catch { Rollback; throw; }`. Der
  Fehler wird nach dem Aufräumen nicht verschluckt, sondern mit `throw;` weitergereicht.
- Typische Fehler:
  - `befehl.Transaction` nicht gesetzt: `Microsoft.Data.Sqlite` verlangt das bei
    laufender Transaktion und wirft eine `InvalidOperationException`, die leicht mit
    der fachlichen Ausnahme verwechselt wird; die Tests zeigen dann Fehler an
    unerwarteter Stelle;
  - `catch { ...; throw ex; }`: Der Stack Trace beginnt neu, der Test
    `Ausnahme_in_der_Transaktion_...` erkennt das; im Gespräch den Unterschied
    zu `throw;` erklären lassen;
  - `catch (Exception) { Rollback(); }` ohne `throw;`: Der Fehler verschwindet,
    der Aufrufer meint, es sei gelungen (der Test erwartet die Ausnahme);
  - Prüfung des Guthabens per `SELECT` und anschließendem `UPDATE` funktioniert hier,
    ist aber bei parallelem Zugriff ein Wettlauf. Die Musterlösung prüft in der
    `WHERE`-Klausel des `UPDATE` und wertet die Zahl der betroffenen Zeilen aus;
  - `Mehrfach` ruft `Ueberweise` je Eintrag auf: Jede Überweisung hat dann ihre
    eigene Transaktion (oder die zweite scheitert an der offenen ersten), nicht
    „alle oder keine“. Test `Mehrfach_ist_alles_oder_nichts_...`;
  - `using` vergessen und `Rollback` nur im Fehlerfall: Die Verbindung bleibt
    mit offener Transaktion zurück, wenn eine Ausnahme vor `Commit` den Aufruf
    verlässt und nicht gefangen wird. Der Test `Nach_einem_Fehler_ist_die_Verbindung_wieder_frei...`
    prüft das.
- `using var transaktion` allein genügt technisch (Dispose ohne Commit macht Rollback);
  die Aufgabe verlangt das ausdrückliche `Rollback()` samt `throw;`, damit das Muster
  geübt wird. Frage: Was passiert bei `Dispose` ohne `Commit`?
- Quizfrage: `TransactionScope` rollt ohne `Complete()` implizit zurück; hier nur als
  Konzept.
- Modellantwort: `solution/`; Vorlage `samples/ADO.NET/Transaction`.
