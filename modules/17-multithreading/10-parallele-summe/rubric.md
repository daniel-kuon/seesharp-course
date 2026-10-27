# Rubrik — Zusatz Parallele Summe (nur für die Betreuung)

- Kern: Zwei Muster, wie parallele Teilergebnisse zusammenkommen: ein
  gemeinsamer Zähler mit `Interlocked` (Summe, Histogramm), und
  Teilergebnisse je Aufgabe, die zuletzt zusammengeführt werden (Maximum).
  Das letzte Muster braucht keine Sperre, weil jede Aufgabe nur ihre
  eigene lokale Variable ändert: das ist die skalierbarste Variante.
- Typische Fehler beim Maximum: Abschnittsgrenzen um eins daneben
  (Test: Das Maximum steht einmal an jeder Position in Arrays der
  Längen 1 bis 7); `Task.Run` in der Schleife ohne Kopie der Schleifenvariablen
  (Closure); `.Result` direkt hinter `Task.Run` in derselben Schleife, was
  sequenziell rechnet.
- Histogramm: Der Index `ergebnis[klasse]` ist pro Klasse ein eigenes
  Feld; `Interlocked.Increment(ref ergebnis[klasse])` funktioniert auch für
  Arrayelemente. Gesprächsanlass: Viele Iterationen schreiben in dieselben
  Zähler. Das ist korrekt, aber langsamer als Teilhistogramme je
  Partition. Messen würde es zeigen; die Tests messen bewusst keine Zeit.
- Die Aufgabe prüft nur Gleichheit mit dem sequenziellen Ergebnis. Ob parallel
  schneller wäre, ist eine offene Frage für das Gespräch (bei 100.000
  Elementen und trivialer Arbeit meist nicht).

Modellantwort: `solution/`.
