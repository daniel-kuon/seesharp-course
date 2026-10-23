# Rubrik — Zusatzaufgabe Caesar (nur für die Betreuung)

- `char.IsLetter` ist hier eine Falle: Es liefert auch für `Ä` und `ß`
  `true`, die dann falsch verschoben werden. Der Test
  `Andere_Zeichen_bleiben_unveraendert` fängt das. Bereichsprüfung
  `c >= 'A' && c <= 'Z'` ist richtig.
- Normierung des negativen Schlüssels: gleiche Falle wie bei der
  Uhrzeit-Zusatzaufgabe in Level 4 (`%` mit negativem linken Operanden).
- `StringBuilder` mit Startkapazität `text.Length` ist ein Pluspunkt, aber
  nicht verlangt. `s += c` in der Schleife funktioniert, verfehlt aber das
  Lernziel; im Review ansprechen (Quizfrage aus der Pflichtübung).
- `Knacke` ist statistisch und versagt bei kurzen Texten. Nachfrage: Wie
  ließe sich das robuster machen? (Häufigkeitsprofil vergleichen; außerdem
  gibt es nur 26 Schlüssel, Ausprobieren genügt.)
- Ausblick: Die Klasse ist `static`, weil sie keinen Zustand hat.

Modellantwort: `solution/Caesar/Caesar.cs`.
