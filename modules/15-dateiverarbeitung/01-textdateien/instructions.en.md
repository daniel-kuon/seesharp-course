# Text Files with StreamWriter and StreamReader

Read sections **16.3.2 "Writing and Reading in Text Format**" (page 1036) and **16.3.3 "Reading Text Files Encoded in Windows-1252**" (page 1040) in the book. The examples in **Section 16.1, “Data Streams of Bytes”** (page 1013), illustrate the basic principle.

All tests run in their own temp folder, whose name contains a space, a comma, and an umlaut (`Schere, Stein, Prüfung`): Your code must not rely on any specific path format. You won't learn the `using` statement until Exercise 4: Close files here using `Close()` in a `finally` block. Open `Textdatei.cs`:

1. `Schreibe(pfad, zeilen)`: Writes each line to the file using `WriteLine` (overwriting it). If the source of the lines throws an exception while writing, the file must still be closed.
2. `LiesZeilen(pfad)`: reads using `ReadLine()` until `null` and returns a `List<string>`. `LiesOderLeer(pfad)` catches `FileNotFoundException` and `DirectoryNotFoundException` and then returns an empty list; other exceptions are ignored.
3. `Anhaengen(pfad, zeile)`: `new StreamWriter(pfad, append: true)`.
4. `LiesAnsi(pfad)` and `SchreibeAnsi(pfad, text)`: Windows-1252 using `Encoding.GetEncoding(1252)` (the provider is already registered in the static constructor). The "ä" is represented by the byte `0xE4` there.
5. `SchreibeUtf8(pfad, text)`: UTF-8 **without** a byte order mark. The test checks the raw bytes.

The following tests must be passed:

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
