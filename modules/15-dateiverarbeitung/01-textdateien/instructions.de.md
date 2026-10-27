# Textdateien mit StreamWriter und StreamReader

Lies im Buch **16.3.2 Schreiben und Lesen im Textformat** (Seite 1036)
und **16.3.3 Textdateien mit der Codierung Windows-1252 lesen**
(Seite 1040). Die Beispiele zu **16.1 Datenströme aus Bytes** (Seite 1013)
zeigen das Grundprinzip.

Alle Tests arbeiten in einem eigenen Temp-Ordner, dessen Name ein Leerzeichen,
ein Komma und einen Umlaut enthält (`Schere, Stein, Prüfung`): Dein Code darf
sich auf keine bestimmte Pfadform verlassen. Die `using`-Anweisung lernst du
erst in Aufgabe 4: Schließe Dateien hier mit `Close()` in einem
`finally`-Block. Öffne `Textdatei.cs`:

1. `Schreibe(pfad, zeilen)`: schreibt jede Zeile mit `WriteLine` in die
   Datei (überschreibt sie). Wirft die Quelle der Zeilen mitten im Schreiben
   eine Ausnahme, muss die Datei trotzdem geschlossen werden.
2. `LiesZeilen(pfad)`: liest mit `ReadLine()` bis `null` und liefert eine
   `List<string>`. `LiesOderLeer(pfad)` fängt `FileNotFoundException` und
   `DirectoryNotFoundException` und liefert dann eine leere Liste; andere
   Ausnahmen bleiben unberührt.
3. `Anhaengen(pfad, zeile)`: `new StreamWriter(pfad, append: true)`.
4. `LiesAnsi(pfad)` und `SchreibeAnsi(pfad, text)`: Windows-1252 mit
   `Encoding.GetEncoding(1252)` (der Provider ist im statischen Konstruktor
   schon registriert). Das ä ist dort das Byte `0xE4`.
5. `SchreibeUtf8(pfad, text)`: UTF-8 **ohne** Byte-Order-Mark. Der Test prüft
   die Rohbytes. Nicht im Buch, hier vorgegeben: Die Codierung dafür ist
   `new UTF8Encoding(false)` (`Encoding.UTF8` würde die drei Bytes `EF BB BF`
   an den Anfang schreiben).

Diese Tests müssen bestehen:

- `TextdateiTests.Schreibe_erzeugt_eine_Zeile_pro_Eintrag`
- `TextdateiTests.Schreibe_ueberschreibt_eine_vorhandene_Datei`
- `TextdateiTests.Schreibe_gibt_die_Datei_frei`
- `TextdateiTests.Schreibe_schliesst_die_Datei_auch_bei_einer_Ausnahme`
- `TextdateiTests.LiesZeilen_liest_bis_zum_Dateiende`
- `TextdateiTests.LiesZeilen_einer_leeren_Datei_ist_leer`
- `TextdateiTests.LiesZeilen_gibt_die_Datei_frei`
- `TextdateiTests.LiesZeilen_einer_fehlenden_Datei_wirft`
- `TextdateiTests.LiesOderLeer_faengt_fehlende_Datei_und_fehlenden_Ordner`
- `TextdateiTests.Anhaengen_haengt_an_und_legt_die_Datei_bei_Bedarf_an`
- `TextdateiTests.LiesAnsi_liest_Windows_1252`
- `TextdateiTests.SchreibeAnsi_schreibt_Einzelbytes_fuer_Umlaute`
- `TextdateiTests.SchreibeUtf8_schreibt_ohne_BOM`
