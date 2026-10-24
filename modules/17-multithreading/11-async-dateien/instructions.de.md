# Zusatz: Dateien asynchron verarbeiten

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**17.6.5 await-Ausdruck** (Seite 1173), **17.6.7 Ausnahmebehandlung**
(Seite 1178) und **17.6.10.1 I/O-gebundene Operationen** (Seite 1191).

Dateizugriffe sind der klassische Fall für `async`: Der Thread muss nicht
warten, bis die Platte liefert. Noch besser wird es, wenn man mehrere
Dateien **gleichzeitig** liest.

`Dateien.ZaehleZeilenAsync(IEnumerable<string> pfade)` liefert ein
`Dictionary<string, int>` mit der Zeilenzahl jeder Datei:

- Starte zuerst alle Lesevorgänge (`File.ReadAllLinesAsync`) und warte dann
  gemeinsam mit `Task.WhenAll`. Wer jede Datei einzeln mit `await` liest,
  liest nacheinander.
- Eine Datei, die es nicht gibt (`FileNotFoundException` oder
  `DirectoryNotFoundException`), bekommt den Wert `-1`. Fang den Fehler um das
  `await` der einzelnen Datei; die anderen Dateien werden trotzdem gezählt.
  Tipp: Eine kleine `async`-Hilfsmethode für eine Datei macht den
  `try/catch` übersichtlich.
- Ein mehrfach genannter Pfad steht nur einmal im Ergebnis; eine leere Folge
  liefert ein leeres Wörterbuch.

Die Tests legen ihre Dateien in einem eigenen, einmaligen Temp-Ordner an und
räumen auf.

Diese Tests müssen bestehen:

- `AsyncDateienTests.Zaehlt_die_Zeilen_jeder_Datei`
- `AsyncDateienTests.Fehlende_Dateien_werden_mit_minus_eins_gemeldet_ohne_zu_werfen`
- `AsyncDateienTests.Mehrfach_genannte_Pfade_stehen_nur_einmal_im_Ergebnis`
- `AsyncDateienTests.Eine_leere_Folge_liefert_ein_leeres_Woerterbuch`
- `AsyncDateienTests.Viele_Dateien_auf_einmal`
