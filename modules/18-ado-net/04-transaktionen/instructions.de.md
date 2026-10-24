# Transaktionen: Commit und Rollback

Lies im Buch **19.7.7 DbTransaction** (Seite 1332) und **19.7.8** zu
`TransactionScope`. Eine Transaktion fasst mehrere Befehle zusammen: Entweder
werden alle mit `Commit()` bestätigt, oder `Rollback()` nimmt alle zurück (ACID,
19.7.7.1).

Öffne `Bank.cs`. Eine Überweisung sind zwei `UPDATE`-Befehle auf der Tabelle
`Konto(Id, Inhaber, Saldo)`: abbuchen, gutschreiben. Dazwischen darf nichts
passieren, was nur eine Hälfte übrig lässt.

1. `Ueberweise(c, von, nach, betrag, nachAbbuchung)`:
   - `c.BeginTransaction()`, beide Befehle mit Parametern, jeweils
     `befehl.Transaction = transaktion` setzen, am Ende `Commit()`.
   - Reicht das Guthaben nicht oder fehlt ein Konto (ein `UPDATE` ändert 0 Zeilen),
     wirf eine `InvalidOperationException`; alles wird zurückgenommen.
   - Tritt irgendeine andere Ausnahme auf (die Tests lösen sie über den Parameter
     `nachAbbuchung` mitten in der Transaktion aus), mache `Rollback()` und reiche
     sie mit `throw;` unverändert weiter.
2. `Mehrfach(c, ueberweisungen)`: alle Überweisungen in **einer** Transaktion:
   alle oder keine. SQLite kennt keine verschachtelten Transaktionen; zerlege daher
   die Arbeit so, dass beide Methoden dieselben privaten Hilfsmethoden mit einer
   übergebenen Transaktion benutzen.

Beantworte danach die Quizfrage zu `TransactionScope`.

Tests: `Ueberweise_bucht_ab_und_schreibt_gut`, `Ueberweise_erlaubt_genau_das_Guthaben`,
`Ueberweise_ohne_Guthaben_nimmt_alles_zurueck`,
`Ueberweise_auf_fehlendes_Zielkonto_stellt_die_Abbuchung_wieder_her`,
`Ueberweise_von_fehlendem_Quellkonto_aendert_nichts`,
`Ausnahme_in_der_Transaktion_fuehrt_zum_Rollback_und_wird_mit_throw_weitergereicht`,
`Nach_einem_Fehler_ist_die_Verbindung_wieder_frei_fuer_neue_Transaktionen`,
`Mehrfach_bucht_alle_Ueberweisungen`, `Mehrfach_ist_alles_oder_nichts_bei_zu_wenig_Guthaben`,
`Mehrfach_ist_alles_oder_nichts_bei_fehlendem_Konto`, `Mehrfach_ohne_Ueberweisungen_aendert_nichts`.
