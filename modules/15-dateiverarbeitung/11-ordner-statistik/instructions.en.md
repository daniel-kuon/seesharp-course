# Extra: Folder Statistics

Extra exercise: optional; it unlocks nothing. For further reading: **16.6.1 File Management** (page 1052), **16.6.2 Folder Management** (page 1055), and **16.6.4 The Path Class** (page 1057).

The `Ordnerstatistik` class in `Ordnerstatistik.cs` analyzes a folder tree. The tests create a small tree in a temporary folder with spaces and umlauts in the names, including `Büro Ordner` and `Übersicht.TXT`.

1. `AnzahlDateien(ordner)`: all files, including those in subfolders.
2. `GroessteDatei(ordner)`: Path to the largest file **relative** to the folder (`Path.GetRelativePath`, `FileInfo.Length`); in case of a tie, the path with the smaller ordinal number wins; `null` if no file exists.
3. `ProEndung(ordner)`: A dictionary containing the number of files for each file extension; the key is the extension in lowercase followed by a period (`".txt"`), and files without an extension are counted under `"(keine)"`.
4. `KopiereAlleTxt(quelle, ziel)`: Copies all `.txt` files (including `.TXT` files) along with their subfolder structure to `ziel`, creates any missing folders, and returns the number of copies.

The following tests must be passed:

- `OrdnerstatistikTests.AnzahlDateien_zaehlt_rekursiv`
- `OrdnerstatistikTests.GroessteDatei_liefert_den_relativen_Pfad`
- `OrdnerstatistikTests.GroessteDatei_ohne_Dateien_ist_null`
- `OrdnerstatistikTests.GroessteDatei_bei_Gleichstand_gewinnt_der_ordinal_kleinere_Pfad`
- `OrdnerstatistikTests.ProEndung_zaehlt_klein_geschrieben_und_mit_Punkt`
- `OrdnerstatistikTests.KopiereAlleTxt_behaelt_die_Ordnerstruktur`
