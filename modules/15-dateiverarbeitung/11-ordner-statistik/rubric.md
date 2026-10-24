# Rubrik — Zusatz: Ordnerstatistik (nur für die Betreuung)

- Kern: `Directory.EnumerateFiles(…, SearchOption.AllDirectories)`, `FileInfo`,
  `Path.GetRelativePath/GetExtension/Combine/GetDirectoryName` und `File.Copy`.
  Der Trainee soll Pfade nie von Hand zerlegen; Ordner mit Leerzeichen und Umlaut
  zeigen, wo das schiefgeht.
- Beim Kopieren müssen die Zielordner vor `File.Copy` existieren
  (`Directory.CreateDirectory(Path.GetDirectoryName(zielDatei))`). Fehlt das,
  wirft `File.Copy` eine `DirectoryNotFoundException`.
- Die Endung zählt ohne Rücksicht auf Groß-/Kleinschreibung (`Übersicht.TXT`):
  `*.txt` als Suchmuster ist je nach Betriebssystem case-sensitiv oder nicht;
  deshalb wird die Endung in der Lösung verglichen. Das ist ein Gesprächsanlass
  über Windows- und Linux-Dateisysteme.
- `ProEndung` ist eine Wiederholung von Wörterbuch-Zählen (Level 10):
  `GetValueOrDefault` oder `TryGetValue`; beides ist in Ordnung.
- Die Reihenfolge der Dateien aus `EnumerateFiles` ist nicht festgelegt: Das
  Gleichstandsverhalten von `GroessteDatei` muss darum selbst ordnen.

Modellantwort: `solution/`.
