# Rubrik: Zusatz: Überweisungen mit Protokoll (nur für die Betreuung)

- **Kernidee:** Alles, was fachlich zusammengehört (Buchung *und* Protokoll), muss
  in **einer** Transaktion stehen; sonst kann es zu Buchungen ohne Protokoll oder
  umgekehrt kommen. `Rollback` und `throw;` stellen den Ausgangszustand her und melden
  den Fehler trotzdem.
- Der Test `Scheitert_das_Protokollieren_...` benutzt eine `CHECK`-Regel der
  Protokolltabelle (Betrag höchstens 1000), um einen Fehler *nach* den beiden
  `UPDATE`s zu erzeugen. Wer die Protokollzeile vor der Transaktion oder in einem
  eigenen Befehl ohne `Transaction` schreibt, besteht ihn nicht (im zweiten Fall wirft
  `Microsoft.Data.Sqlite` sogar, weil der Befehl ohne die laufende Transaktion läuft).
- Typische Fehler: Befehl ohne `befehl.Transaction`; `Rollback` ohne `throw;`
  (Fehler verschluckt, der Test erwartet die Ausnahme); Protokollzeile erst nach
  `Commit` (dann gibt es Buchungen ohne Protokoll, wenn das Protokollieren scheitert).
- Modellantwort: `solution/`; keine Vorlage im `samples`-Ordner.
