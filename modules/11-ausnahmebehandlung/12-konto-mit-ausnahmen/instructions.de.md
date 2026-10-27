# Zusatz: Konto mit Ausnahmen

Lies noch einmal **13.5 Ausnahmeklassen in der BCL** (Seite 911) und
**13.7 Ausnahmen definieren** (Seite 916). Ein Konto kennst du aus Level 4.

Die Klasse `Konto` in `Konto.cs` prüft bisher nichts: Man kann negative Beträge
einzahlen und mehr abheben, als da ist. Melde jeden Fehler mit der passenden
Ausnahme:

1. `Einzahlen(betrag)` und `Abheben(betrag)` werfen bei `betrag <= 0` eine
   `ArgumentOutOfRangeException` (Parametername `"betrag"`).
2. Reicht das Guthaben bei `Abheben` nicht aus, wirft die Methode die
   **eigene** Ausnahme `GuthabenZuNiedrigException` mit dem Fehlbetrag
   (`betrag - Kontostand`). Sie steht in `GuthabenZuNiedrigException.cs` und soll
   von `InvalidOperationException` erben: Das Argument ist nicht falsch, das
   Konto hat nur im Moment nicht genug. Die Meldung gibst du an den
   Basiskonstruktor weiter.
3. `Ueberweisen(ziel, betrag)` wirft bei `ziel == null` eine
   `ArgumentNullException` (Parametername `"ziel"`). Scheitert die Abhebung,
   darf sich **kein** Konto ändern.
4. Der Konstruktor lehnt ein negatives Startguthaben mit
   `ArgumentOutOfRangeException` (Parametername `"startguthaben"`) ab.

Die Tests prüfen Ausnahmetyp, Eigenschaften und dass ein fehlgeschlagener
Aufruf die Kontostände nicht verändert: `Abheben_ueber_das_Guthaben_wirft_GuthabenZuNiedrigException_mit_Fehlbetrag`,
`GuthabenZuNiedrig_ist_eine_InvalidOperationException_mit_Fehlbetrag`,
`Ueberweisen_an_null_wirft_ArgumentNullException_und_aendert_nichts` und
`Ueberweisen_ohne_Deckung_laesst_beide_Konten_unveraendert`.
