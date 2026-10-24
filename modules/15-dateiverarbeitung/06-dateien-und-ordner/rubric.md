# Rubrik — Dateien, Ordner und Pfade (nur für die Betreuung)

- Kern: `File`, `Directory` und `Path` sind statische Hilfsklassen für das
  Dateisystem. Pfade sind Zeichenfolgen mit Regeln; `Path.Combine`,
  `GetFileNameWithoutExtension`, `GetExtension`, `GetRelativePath`,
  `ChangeExtension` kennen sie. Wer `ordner + "\\" + name` schreibt, scheitert
  auf Linux und bei doppelten Trennzeichen.
- `ErsetzeEndung_laesst_Ordner_mit_Punkt_und_Umlaut_in_Ruhe` fängt Lösungen
  mit `pfad.Replace(".txt", …)` oder `Substring(IndexOf('.'))`: Im Ordner
  `Büro, v1.2` steht ein Punkt. `archiv.tar.gz` zeigt, dass nur die letzte Endung
  zählt.
- Die Liste der leeren Ordner ist ein kleiner Rekursionsfall: erst die Kinder
  löschen, dann prüfen, ob der Ordner jetzt leer ist. Wer nur eine Ebene
  prüft, löscht `a` nicht (der Test zählt 5, nicht 3).
- `GetRelativePath` und Sortierung: Der Test erwartet die Pfade mit dem
  Trennzeichen des Systems und ordinal sortiert. Ein kulturabhängiger
  Vergleich würde Bindestriche und Punkte anders einordnen.
- Zwei Quiz-Items: `Path.Combine("a", "/b")` ergibt `"/b"` (absoluter
  Teil verwirft den Anfang); die drei Aufrufe für Temp, Dokumente und
  Anwendungsdaten. Diese Anwendungsfrage (wohin gehören die Dateien eines
  Programms?) mit dem Trainee besprechen: nicht ins Programmverzeichnis, nicht ins
  aktuelle Verzeichnis.
- `FileSystemWatcher`, `DriveInfo` und `Directory.Move` sind Vorführstoff im
  Buch und nicht bewertet.

Modellantwort: `solution/` bzw. `samples/Ein- und Ausgabe über Datenströme/{Dateiverwaltung,Ordnerverwaltung,Path}`.
