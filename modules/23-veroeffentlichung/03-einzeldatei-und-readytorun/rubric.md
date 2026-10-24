# Rubrik — Einzeldatei und ReadyToRun (nur für die Betreuung)

- Größenordnungen (auf dem Rechner des Trainees prüfen, die Zahlen schwanken
  mit der SDK-Version): frameworkabhängig wenige Dateien, unter 1 MB;
  eigenständig als Einzeldatei grob 60 bis 70 MB (Buch 23.2.1: etwa 68 MB;
  mit Trimmen etwa 11 MB); mit ReadyToRun größer als ohne, dafür schnellerer
  Start, weil weniger JIT-Arbeit anfällt. Die Dateizahl der
  nicht zusammengefassten eigenständigen Variante lag im Buch bei 191 Dateien
  mit 71,2 MB (23.1.6, Seite 1646).
- Erwartete Erklärung: Einzeldatei = bequeme Auslieferung (eine Datei, nichts
  geht verloren); eigenständig = keine Laufzeit am Zielrechner nötig, aber groß
  und an Betriebssystem und CPU gebunden; R2R = Vorübersetzung für genau eine
  Zielruntime, nicht portabel (23.2.2, Seite 1652).
- Nachfrage: Läuft die win-x64-Datei auf Linux? Nein; für Linux muss mit
  `-r linux-x64` neu veröffentlicht werden. Warum geht das mit demselben
  Quelltext? (Der IL-Code ist portabel, die mitgelieferte Laufzeit nicht.)
- Nachfrage: Warum kann man WPF nicht trimmen? (Fehler NETSDK1168, 23.1.6,
  Seite 1648.)
- Startzeit nicht per Stoppuhr "beweisen" lassen, nur beschreiben; die
  Aufgabe verlangt keine Messung.
