# Wertkonverter, Konflikte, Transaktionen, Migrationen

Lies im Buch **20.13 Konflikte durch parallele Zugriffe** (Seite 1482), **20.14**
(Transaktionen), **20.5.6** (Wertkonverter) und **20.3** (Migrationen, Seite 1404).

`Konto` (`Id`, `Inhaber`, `Saldo`, `Status`, `Version`) und `KontoContext` stehen in
`Datenmodell.cs`; `Kontodienst.Anlegen` ist vorgegeben.

1. **Wertkonverter** in `OnModelCreating`: Der Aufzählungstyp `Status` wird als **Text**
   gespeichert (`"Neu"`, `"Aktiv"`, `"Gesperrt"`), nicht als Zahl:
   `Property(k => k.Status).HasConversion<string>()`. Der Test liest die Rohspalte mit
   einem einfachen SQL-Befehl.
2. **Concurrency Token**: Die Eigenschaft `Version` bekommt `[ConcurrencyCheck]`. SQLite hat
   keinen `rowversion`-Typ, daher zählt der Code die Version bei jeder Änderung von Hand hoch.
   EF Core ergänzt dann jedes `UPDATE` um `WHERE Version = <geladener Wert>`; hat ein anderer
   Kontext die Zeile inzwischen geändert, trifft das keine Zeile und `SaveChanges` wirft eine
   `DbUpdateConcurrencyException`.
3. **`Konfliktloeser.Speichere(kontext, konto, aenderung)`**: wendet `aenderung` an, zählt die
   Version hoch und speichert. Bei einer `DbUpdateConcurrencyException` (20.13.2):
   `kontext.Entry(konto).Reload();` lädt den aktuellen Stand aus der Datenbank (nicht im Buch,
   hier vorgegeben),
   die Änderung auf den frischen Stand **erneut** anwenden, Version hochzählen und **ein Mal**
   wiederholen. Scheitert auch das, geht die Ausnahme an den Aufrufer. Rückgabe: die Zahl der
   Versuche (1 oder 2).
4. **`Kontodienst.Ueberweisung(von, nach, betrag)`**: mit
   `kontext.Database.BeginTransaction()`. Erst abbuchen und speichern, dann gutschreiben und
   speichern, dann `Commit()`. Fehlt ein Konto oder reicht der Saldo nicht:
   `InvalidOperationException`. Bei jeder Ausnahme `Rollback()` und `throw;`, damit nichts
   Halbes zurückbleibt.
5. **Review-Aufgabe (Migrationen)**: nicht automatisch prüfbar. Die Beschreibung steht beim
   Quizpunkt `migration` im Aufgabenblatt: Ein kleines Scratch-Projekt mit `dotnet ef migrations add Anfang`;
   die Betreuung sieht sich den Ordner `Migrations` an.

Beantworte außerdem die Quizfrage zum Concurrency Token.

Tests: `Status_wird_als_Text_gespeichert`, `Status_wird_beim_Lesen_wieder_zum_Enum`,
`Zwei_Kontexte_aendern_dieselbe_Zeile_der_zweite_SaveChanges_scheitert`,
`Konfliktloeser_ohne_Konflikt_speichert_beim_ersten_Versuch`,
`Konfliktloeser_laedt_bei_Konflikt_neu_und_wiederholt_einmal`,
`Konfliktloeser_gibt_nach_dem_zweiten_Konflikt_auf`,
`Ueberweisung_bucht_um_und_zaehlt_die_Versionen_hoch`, `Ueberweisung_ohne_Guthaben_aendert_nichts`,
`Ueberweisung_auf_fehlendes_Konto_nimmt_die_Abbuchung_zurueck`,
`Ueberweisung_von_fehlendem_Konto_wirft`.
