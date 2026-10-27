# Files, Folders, and Paths

See the book, **Section 16.6 Managing Files and Directories** (page 1052), including **16.6.1 File Management**, **16.6.2 Folder Management** (page 1055), **16.6.3 Special Folders** (page 1056), and **16.6.4 The Path Class** (page 1057). `DriveInfo` and `FileSystemWatcher` (16.6.5, 16.6.6) are not part of the assignment.

Open `Dateien.cs`. Paths are constructed using `Path` and split using it; never use `+` or `\`. The tests are running again in a temp folder with spaces, commas, and umlauts in the name.

1. `Sichere(datei, zielOrdner)`: Creates the destination folder if it does not exist and copies the file there as `<name>_backup<endung>` (`bericht.txt` becomes `bericht_backup.txt`). An existing backup will be overwritten. The function returns the new path.
2. `ListeRekursiv(ordner, muster)`: All files within the folder (including those in subfolders) that match the pattern, listed as paths **relative** to the folder and sorted ordinally.
3. `Verschiebe(von, nach)`: moves a file and creates the destination folder if necessary; an existing destination file is overwritten (`File.Move` with `overwrite: true`; without it, `Move` throws an `IOException`, page 1054). If the source is missing, returns `false`.
4. `LoescheLeereOrdner(wurzel)`: Deletes empty folders from the bottom up (a folder that becomes empty only after its empty subfolders are deleted is included); the root folder remains. Return value: Number of folders deleted.
5. `ErsetzeEndung(pfad, neu)`: `Path.ChangeExtension`.
6. `NeuerArbeitsordner()` creates a unique folder within the Temp folder (`Path.GetTempPath`, `Path.GetRandomFileName`).
7. `AppOrdner(appName)`: Subfolder `appName` in the user's local application data folder (`Environment.SpecialFolder.LocalApplicationData`); it is not created.

Two quiz questions explain `Path.Combine` and the calls for the special folders.

The following tests must be passed:

- `DateienTests.Sichere_legt_den_Zielordner_an_und_kopiert_mit_neuem_Namen`
- `DateienTests.Sichere_funktioniert_auch_ohne_Endung_und_ueberschreibt_ein_altes_Backup`
- `DateienTests.ListeRekursiv_liefert_relative_sortierte_Pfade_zum_Muster`
- `DateienTests.Verschiebe_verschiebt_und_legt_den_Zielordner_an`
- `DateienTests.Verschiebe_liefert_false_wenn_die_Quelle_fehlt_und_ueberschreibt_das_Ziel`
- `DateienTests.LoescheLeereOrdner_loescht_von_unten_nach_oben`
- `DateienTests.LoescheLeereOrdner_ohne_leere_Ordner_loescht_nichts`
- `DateienTests.ErsetzeEndung_tauscht_nur_die_letzte_Endung`
- `DateienTests.ErsetzeEndung_laesst_Ordner_mit_Punkt_und_Umlaut_in_Ruhe`
- `DateienTests.NeuerArbeitsordner_liegt_im_Temp_Ordner_und_ist_eindeutig`
- `DateienTests.AppOrdner_liegt_im_lokalen_Anwendungsdatenordner`
