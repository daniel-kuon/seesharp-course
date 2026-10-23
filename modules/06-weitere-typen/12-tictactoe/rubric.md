# Rubrik — Zusatzaufgabe Tic-Tac-Toe (nur für die Betreuung)

- `Feld.Leer` steht absichtlich zuerst: Der Standardwert eines Enums ist der
  Wert 0, also ist `new Feld[3, 3]` automatisch leer. Nachfragen, was
  passiert wäre, wenn `X` zuerst stünde.
- `AmZug` ohne eigenes Feld: Der Zustand steckt nur im Array, deshalb kann
  er nicht auseinanderlaufen. Gleiche Idee wie die Uhrzeit-Zusatzaufgabe in
  Level 4.
- `Gewinner`: Die Prüfung `!= Feld.Leer` wird gern vergessen; dann
  "gewinnt" die erste leere Zeile mit `Feld.Leer`, und eine spätere
  Gewinnreihe wird übersehen (Tests mit Sieg in der unteren Zeile oder in
  einer Spalte schlagen fehl). Elegante Variante: Schleife über die acht
  Reihen als Tupel-Array.
- `Setze` muss nach dem Sieg ablehnen (letzter Test). Wer `Spielstand()` in
  `Setze` aufruft, verwendet die eigene Methode wieder.
- `foreach` über `Feld[,]` läuft alle neun Elemente zeilenweise ab;
  `GetLength(0)`/`GetLength(1)` statt fester 3 ist ein Pluspunkt.

Modellantwort: `solution/TicTacToe/Spielfeld.cs`.
