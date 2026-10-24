# using, Dispose und AutoFlush

Lies im Buch **16.2 Freigabe von externen Ressourcen** (Seite 1026) mit
**16.2.1 Dispose() oder Close()**, **16.2.3 using-Anweisung** (Seite 1027),
**16.2.4 using-Deklaration** und **16.2.5 Ausnahmen behandeln**
(Seite 1030). Zu `AutoFlush` siehe **16.3.2.1.3 Pufferung von Zeichen**
(Seite 1038) und die Übung **16.7/2** (Seite 1060).

In `Freigabe.cs` stehen fünf Methoden, die im Normalfall arbeiten, aber Ströme
vergessen oder nur auf dem Erfolgsweg schließen. Damit man das Freigeben
beobachten kann, bekommen sie eine Fabrik (`Func<Stream>`) statt eines Pfads:
Die Tests liefern einen Strom, der jedes `Dispose` mitzählt.
Schreibe sie so um, dass **genau ein** `Dispose` pro Strom aufgerufen wird,
auch wenn eine Ausnahme durchläuft:

1. `SchreibeText`: eine `using`-Anweisung.
2. `Kopiere`: zwei geschachtelte `using`-Anweisungen. Zuerst wird der
   später geöffnete Strom (Ziel) freigegeben, dann die Quelle. Wirft schon
   `ziel()`, muss die Quelle trotzdem freigegeben werden.
3. `ZaehleBytes`: die **using-Deklaration** (`using var s = quelle();`);
   freigegeben wird am Ende der Methode, auch bei `return`.
4. `Verarbeite`: gibt den Strom auch frei, wenn die übergebene Aktion wirft.
5. `SchreibeSicher(pfad, zeilen)`: `using` **innerhalb** von `try`,
   `catch (IOException)` liefert `false` (zum Beispiel weil der Ordner
   fehlt). Auch nach einem Fehler mitten im Schreiben ist die Datei
   geschlossen; andere Ausnahmen laufen weiter.

In `Logger.cs` geht es um `AutoFlush`. Der `Logger` schreibt in einen Strom;
bisher ruft `Log` nach jeder Zeile von Hand `Flush()`:

6. Setze im Konstruktor `AutoFlush = true` und lösche das manuelle `Flush()`.
   Jede Zeile ist dann sofort im Strom sichtbar, auch für einen zweiten Leser.
7. `SchreibeViele(n)` (Buch 16.7/2) schreibt `Eintrag 1` bis `Eintrag n`.
   Ein Flush pro Zeile ist dafür unsinnig langsam: Schalte AutoFlush für die
   Schleife aus, rufe danach **einmal** `Flush()` und stelle AutoFlush im
   `finally` wieder auf `true`.

Diese Tests müssen bestehen:

- `FreigabeTests.SchreibeText_schreibt_und_gibt_einmal_frei`
- `FreigabeTests.SchreibeText_gibt_auch_bei_einer_Ausnahme_frei`
- `FreigabeTests.Kopiere_kopiert_und_gibt_zuerst_das_Ziel_dann_die_Quelle_frei`
- `FreigabeTests.Kopiere_gibt_beide_Stroeme_frei_wenn_das_Kopieren_scheitert`
- `FreigabeTests.Kopiere_gibt_die_Quelle_frei_wenn_das_Ziel_nicht_geoeffnet_werden_kann`
- `FreigabeTests.ZaehleBytes_zaehlt_und_gibt_einmal_frei`
- `FreigabeTests.ZaehleBytes_gibt_auch_bei_einer_Ausnahme_frei`
- `FreigabeTests.Verarbeite_ruft_die_Aktion_auf_und_gibt_einmal_frei`
- `FreigabeTests.Verarbeite_gibt_frei_wenn_die_Aktion_wirft`
- `FreigabeTests.SchreibeSicher_schreibt_und_liefert_true`
- `FreigabeTests.SchreibeSicher_liefert_false_wenn_der_Ordner_fehlt`
- `FreigabeTests.SchreibeSicher_schliesst_die_Datei_nach_einem_IO_Fehler_beim_Schreiben`
- `FreigabeTests.SchreibeSicher_laesst_andere_Ausnahmen_durch_und_schliesst_trotzdem`
- `FreigabeTests.Logger_schaltet_AutoFlush_ein`
- `FreigabeTests.Logger_Zeile_ist_sofort_im_Strom_sichtbar`
- `FreigabeTests.Logger_SchreibeViele_schreibt_alle_Zeilen_mit_hoechstens_wenigen_Flushes`
- `FreigabeTests.Logger_hat_nach_SchreibeViele_wieder_AutoFlush`
