# Rubrik — Sieb des Eratosthenes (nur für die Betreuung)

- Zwei Schleifen übereinander mit Array-Zugriff über berechnete Indizes:
  Hier lernt der Trainee, dass der Index eine Bedeutung tragen kann (Index =
  Zahl). Nachfragen, warum das Array `grenze + 1` lang ist.
- Ergebnis-Array mit passender Länge: Zwei Durchläufe (zählen, dann
  kopieren) sind die erwartete Lösung ohne `List<T>` (kommt in Level 10).
  Wer `List<int>` nimmt, hat nichts falsch gemacht, soll aber die
  Array-Variante erklären können.
- Laufzeit: Start der inneren Schleife bei `basis * basis` und Schrittweite
  `basis`. Der Test bis 1 000 000 fällt sonst nicht durch, dauert aber
  spürbar.

Modellantwort: `solution/`; die Konsolenfassung des Buchs liegt in
`samples/Weitere .NETte Typen/Arrays/Eratosthenes`.
