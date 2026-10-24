# Zusatz: Ressourcen sicher schließen

Lies noch einmal **13.3.1.3 Aufräumarbeiten im finally-Block** (Seite 895) und
in **13.6** (Seite 913) den Abschnitt zum Weiterreichen mit `throw;`.

Das Interface `IVerbindung` in `Sender.cs` beschreibt eine Verbindung, die
geöffnet (`Oeffnen`), benutzt (`Senden`) und wieder geschlossen (`Schliessen`)
werden muss. Es ist vorgegeben; die Tests liefern eine Testverbindung, die
mitzählt und auf Wunsch Fehler auslöst.

Implementiere `Sender.SendeAlle(verbindung, nachrichten)`:

1. Die Verbindung wird geöffnet, alle Nachrichten werden der Reihe nach gesendet.
2. `Schliessen()` wird in **jedem** Fall genau einmal aufgerufen: nach Erfolg, nach
   einem Fehler beim Öffnen und nach einem Fehler beim Senden. Das ist ein Fall für
   `finally`.
3. Scheitert `Oeffnen()`, wird die Ausnahme in eine `InvalidOperationException`
   mit der Meldung `"Verbindung konnte nicht geöffnet werden"` verpackt; die
   ursprüngliche Ausnahme ist deren `InnerException`.
4. Scheitert `Senden()`, erhöht die Methode `Fehlschlaege` um 1 und reicht
   **dieselbe** Ausnahme mit `throw;` weiter (nicht verpacken, nicht neu werfen).

Tests: `Erfolg_sendet_alles_und_schliesst_genau_einmal`,
`Sendefehler_wird_unveraendert_weitergereicht_und_die_Verbindung_geschlossen`,
`Fehler_beim_Oeffnen_wird_verpackt_und_die_Ursache_bleibt_InnerException` und
`Fehlschlaege_zaehlen_ueber_mehrere_Aufrufe`.
