# Extra: Diary

Extra exercise: optional; it unlocks nothing. For further reading: **16.3.2 Writing and Reading in Text Format** (page 1036) and **16.4 Writing and Reading Small Files** (page 1041).

A diary is a text file with one line per entry, in the format `yyyy-MM-dd;text`, for example `2025-06-04;Sonne`. Open `Tagebuch.cs` (the file path is provided by the constructor):

1. `Schreibe(tag, text)`: Appends an entry to the end of the file (`StreamWriter` with `append: true`, `Close` in the `finally` block). The text must not contain any line breaks; otherwise, the line would be corrupted: Throw an `ArgumentException` before anything is written.
2. `Eintraege(tag)`: all texts from a single day in the order they were written (without dates or semicolons) using a `StreamReader`. If the file does not yet exist, an empty list is returned. The text itself may contain semicolons.
3. `AnzahlEintraege()` returns the number of lines read using `File.ReadAllLines`; returns 0 if no file is present.

The `Datum` helper method writes the date regardless of the language setting.

The following tests must be passed:

- `TagebuchTests.Schreibe_haengt_Zeilen_im_vereinbarten_Format_an`
- `TagebuchTests.Schreibe_ueberschreibt_nichts`
- `TagebuchTests.Schreibe_lehnt_Zeilenumbrueche_ab_ohne_zu_schreiben`
- `TagebuchTests.Eintraege_liefert_alle_Texte_des_Tages_in_Schreibreihenfolge`
- `TagebuchTests.Datum_ist_unabhaengig_von_der_Spracheinstellung`
- `TagebuchTests.Ohne_Datei_ist_alles_leer`
- `TagebuchTests.AnzahlEintraege_zaehlt_alle_Zeilen`
