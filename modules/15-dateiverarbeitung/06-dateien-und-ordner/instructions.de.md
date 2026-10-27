# Dateien, Ordner und Pfade

Lies im Buch **16.6 Verwaltung von Dateien und Verzeichnissen**
(Seite 1052) mit **16.6.1 Dateiverwaltung**, **16.6.2 Ordnerverwaltung**
(Seite 1055), **16.6.3 Spezielle Ordner** (Seite 1056) und **16.6.4 Klasse
Path** (Seite 1057). `DriveInfo` und `FileSystemWatcher` (16.6.5, 16.6.6) sind
nicht Teil der Aufgabe.

Öffne `Dateien.cs`. Pfade setzt man mit `Path` zusammen und zerlegt sie
damit, nie mit `+` und `\`. Die Tests arbeiten wieder in einem Temp-Ordner mit
Leerzeichen, Komma und Umlaut im Namen.

Nicht im Buch, hier vorgegeben (die Kommentare im Code nennen sie an der
passenden Stelle):

- `Path.GetFileNameWithoutExtension(pfad)`: Dateiname ohne Ordner und Endung.
- `Path.GetDirectoryName(pfad)`: der Ordner eines Pfads.
- `Directory.EnumerateFiles(ordner, muster, SearchOption.AllDirectories)`: alle
  passenden Dateien, auch in Unterordnern.
- `Path.GetRelativePath(ordner, pfad)`: `pfad` relativ zu `ordner`.
- `File.Move(von, nach, overwrite: true)`: verschiebt und überschreibt ein
  vorhandenes Ziel.
- `Path.ChangeExtension(pfad, neu)`: tauscht die letzte Endung.
- `Path.GetTempPath()` und `Path.GetRandomFileName()`: der Temp-Ordner und ein
  zufälliger Name.

1. `Sichere(datei, zielOrdner)`: legt den Zielordner an, falls er fehlt, und
   kopiert die Datei dorthin als `<name>_backup<endung>` (`bericht.txt` wird zu
   `bericht_backup.txt`). Ein vorhandenes Backup wird überschrieben. Rückgabe ist
   der neue Pfad.
2. `ListeRekursiv(ordner, muster)`: alle Dateien unterhalb des Ordners
   (auch in Unterordnern), die zum Muster passen, als Pfade **relativ** zum
   Ordner, ordinal sortiert.
3. `Verschiebe(von, nach)`: verschiebt eine Datei und legt den Zielordner bei
   Bedarf an; eine vorhandene Zieldatei wird überschrieben (`File.Move` mit
   `overwrite: true`; ohne wirft `Move` eine `IOException`, Seite 1054). Fehlt
   die Quelle, kommt `false` zurück.
4. `LoescheLeereOrdner(wurzel)`: löscht leere Ordner von unten nach oben (ein
   Ordner, der erst durch das Löschen seiner leeren Unterordner leer wird,
   zählt mit); die Wurzel bleibt. Rückgabe: Zahl der gelöschten Ordner.
5. `ErsetzeEndung(pfad, neu)`: `Path.ChangeExtension`.
6. `NeuerArbeitsordner()`: legt einen eindeutigen Ordner unterhalb des
   Temp-Ordners an (`Path.GetTempPath`, `Path.GetRandomFileName`).
7. `AppOrdner(appName)`: Unterordner `appName` im lokalen
   Anwendungsdatenordner des Benutzers (`Environment.SpecialFolder.LocalApplicationData`);
   er wird nicht angelegt.

Zwei Quizfragen klären `Path.Combine` und die Aufrufe für die speziellen Ordner.

Diese Tests müssen bestehen:

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
