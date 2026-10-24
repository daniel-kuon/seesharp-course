# Rubrik — Binärdateien: FileStream und BinaryWriter (nur für die Betreuung)

- Kern: Ein `FileStream` kennt nur Bytes und eine Position. `FileMode` sagt,
  was mit der Datei geschieht (neu, überschreiben, anhängen), `FileAccess`,
  was **dieses** Objekt darf, `FileShare`, was **andere** dürfen. Der Test
  `Kopiere_oeffnet_die_Quelle_nur_lesend` hält die Quelle mit
  `FileShare.Read` offen: Eine Quelle, die der Trainee mit Schreibzugriff
  öffnet, scheitert mit `IOException` (Sharing Violation).
- Klassischer Fehler: im Kopierpuffer immer `puffer.Length` schreiben statt
  der von `Read` gelieferten Zahl. Bei 100 000 Bytes (kein Vielfaches von
  4096) fällt das durch Müll am Dateiende auf. Ebenso: `Read` mit einem
  einzigen Aufruf in `LiesAb` zu verwenden, ohne den Rückgabewert zu prüfen.
- `BinaryWriter` schreibt `int` als 4 Bytes (Little Endian) und `double` als
  8 Bytes. Der Test liest die Rohbytes mit `BitConverter` nach. Eine
  textuelle Darstellung oder ein `string` davor würde die Größe `4 + 8 * n`
  verfehlen.
- `Erzeuge`: Die Aufgabe vermeidet absichtlich eine Ausnahme als Kontrollfluss;
  `FileMode.CreateNew` allein würde bei vorhandener Datei werfen. Ein
  `try/catch` wäre aus Level 11 bekannt, ist aber nicht das Ziel. Die Prüfung
  mit `File.Exists` hat selbst eine Lücke (ein anderer Prozess kann dazwischen
  die Datei anlegen); das lohnt eine Nachfrage.
- Nachfrage: Warum ist `FileMode.Append` nur mit `FileAccess.Write` erlaubt?

Modellantwort: `solution/` bzw. `samples/Ein- und Ausgabe über Datenströme/{BinWrtRd,Einstieg}`.
