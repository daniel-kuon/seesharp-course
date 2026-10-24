# Rubrik — Zusatz Dateien asynchron verarbeiten (nur für die Betreuung)

- Kern: Dieselbe Frage wie in der Hauptaufgabe, jetzt mit echter Ein- und
  Ausgabe: Wo wartet der Thread, und wo gibt er ihn frei? Der Test kann
  nicht unterscheiden, ob die Dateien nacheinander oder gleichzeitig gelesen
  werden (ohne Zeitmessung), deshalb im Code nachsehen: Eine Schleife mit
  `await` im Rumpf liest nacheinander; richtig ist erst starten
  (`Select(...).ToArray()`), dann `WhenAll`. Wichtig: `ToArray()` (oder
  `ToList()`) ist nötig, sonst startet die verzögert ausgewertete Abfrage erst
  beim Durchlaufen.
- Fehlerbehandlung: Der `try/catch` gehört um das `await` der EINZELNEN
  Datei. Ein einziger `try/catch` um das `WhenAll` würde beim ersten Fehler
  das ganze Ergebnis verlieren. Gesprächsanlass: Warum fängt man hier nicht
  einfach `IOException`? (Es würde auch gesperrte oder beschädigte Dateien als
  "fehlt" melden.)
- Doppelte Pfade: Wer ohne `Distinct` ein `Dictionary.Add` benutzt, bekommt
  eine `ArgumentException`; der Test fängt das ab.
- Plattformhinweis: Der Test legt die Dateien mit `File.WriteAllLines` an,
  die Zeilenumbrüche ergeben sich aus dem Betriebssystem; gezählt wird
  mit `ReadAllLinesAsync`, das beide Varianten versteht.

Modellantwort: `solution/`.
