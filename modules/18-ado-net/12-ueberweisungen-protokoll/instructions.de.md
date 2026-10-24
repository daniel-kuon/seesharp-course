# Zusatz: Überweisungen mit Protokoll

Lies noch einmal **19.7.7 DbTransaction** (Seite 1332). In `Bank.cs` gibt es eine
`Ueberweise`-Methode, die abbucht und gutschreibt, aber **ohne Transaktion**: Scheitert
das Gutschreiben, ist das abgebuchte Geld verloren. Außerdem soll jede erfolgreiche
Überweisung eine Zeile in der Tabelle `Protokoll(Id, Von, Nach, Betrag)` hinterlassen.

Erweitere `Ueberweise`:

1. Eine Transaktion beginnen und an **alle** Befehle hängen (`befehl.Transaction`).
2. Nach dem Gutschreiben die Protokollzeile einfügen (Parameter, in derselben
   Transaktion).
3. `Commit()`; bei jeder Ausnahme `Rollback()` und mit `throw;` weiterreichen.

Wichtig ist, dass das Protokoll zur Transaktion gehört: Scheitert eine Überweisung
(zu wenig Guthaben, Zielkonto fehlt oder sogar das Protokollieren selbst), bleibt weder
eine Buchung noch eine Protokollzeile zurück. Die Methode `Protokoll()` zum Auslesen ist
vorgegeben.

Tests: `Erfolgreiche_Ueberweisung_wird_gebucht_und_protokolliert`,
`Mehrere_Ueberweisungen_werden_in_Reihenfolge_protokolliert`,
`Ueberweisung_ohne_Guthaben_hinterlaesst_keine_Protokollzeile`,
`Ueberweisung_an_fehlendes_Konto_stellt_die_Abbuchung_wieder_her`,
`Scheitert_das_Protokollieren_wird_auch_die_Buchung_zurueckgenommen`,
`Nach_einem_Fehler_funktionieren_weitere_Ueberweisungen`.
