# Binary Files: FileStream and BinaryWriter

Read section **16.1.3**, **“Important Methods and Properties of the Base Class Stream”** (page 1015), **16.1.4 “FileStream** with **FileMode**, **FileAccess,** and **FileShare”** (page 1018), and **16.3.1 “Writing and Reading in Binary Format**” (page 1032).

Open `Binaerdaten.cs`. As in Exercise 1, close each file using `Close()` within a `finally` block; the tests create all files in a separate temp folder.

1. `Kopiere(quelle, ziel)`: Copies byte by byte using a 4096-byte buffer with `Read` and `Write`. The source is opened for reading only (`FileMode.Open`, `FileAccess.Read`, `FileShare.Read`); the destination is opened with `FileMode.Create`. Write exactly as many bytes as `Read` returned. The function returns the number of bytes copied.
2. `SchreibeMesswerte(pfad, werte)`: A `BinaryWriter` writes the number as an `int`, followed by each `double`. The file is then `4 + 8 * n` bytes in size. `LiesMesswerte(pfad)` reads the same format using a `BinaryReader`.
3. `HaengeAn(pfad, daten)`: `FileMode.Append` creates the file if necessary and writes to the end of it.
4. `LiesAb(pfad, offset, anzahl)`: Jump to the position using `Seek` and read up to `anzahl` bytes. Fewer bytes are returned at the end of the file; an empty array is returned after the end.
5. `Erzeuge(pfad)`: Creates a new, empty file (`FileMode.CreateNew`). If the file already exists, it returns `false` without throwing an exception (check beforehand using `File.Exists`).

The following tests must be passed:

- `BinaerdatenTests.Kopiere_kopiert_100000_Bytes_unveraendert`
- `BinaerdatenTests.Kopiere_ueberschreibt_ein_laengeres_Ziel_vollstaendig`
- `BinaerdatenTests.Kopiere_kopiert_eine_leere_Datei`
- `BinaerdatenTests.Kopiere_oeffnet_die_Quelle_nur_lesend`
- `BinaerdatenTests.Kopiere_fehlende_Quelle_wirft`
- `BinaerdatenTests.Messwerte_haben_die_Dateigroesse_4_plus_8_mal_n`
- `BinaerdatenTests.Messwerte_Rundreise`
- `BinaerdatenTests.Messwerte_Rundreise_ohne_Werte`
- `BinaerdatenTests.Messwerte_speichern_die_Anzahl_zuerst_als_int`
- `BinaerdatenTests.HaengeAn_haengt_hinten_an_und_legt_bei_Bedarf_an`
- `BinaerdatenTests.LiesAb_springt_an_die_Position`
- `BinaerdatenTests.LiesAb_am_Dateiende_liefert_weniger`
- `BinaerdatenTests.Erzeuge_legt_neu_an_und_verweigert_Vorhandenes_ohne_Ausnahme`
