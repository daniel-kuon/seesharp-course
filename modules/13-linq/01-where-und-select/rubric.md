# Rubrik — Where und Select (nur für die Betreuung)

- Kernidee: Jede LINQ-Methode nimmt eine Sequenz und liefert eine Sequenz;
  man baut Abfragen aus kleinen Bausteinen. `Where` filtert (gleicher
  Elementtyp), `Select` formt um (neuer Elementtyp).
- `ToList`, `ToArray`, `ToDictionary` **materialisieren** das Ergebnis; ohne sie
  bleibt es eine nicht ausgeführte Abfrage (Vertiefung in 13/03).
- `ToDictionary` wirft bei doppeltem Schlüssel `ArgumentException`; die
  Testdaten haben eindeutige Namen. Nachfrage: Was wäre bei zwei Produkten
  gleichen Namens zu tun? (`GroupBy`, 13/04; Bonus (Deep Dive): `ToLookup`.)
- Tupel statt anonymer Typ für `Etiketten`, weil der Rückgabetyp benannt
  werden muss; das ist der Zusammenhang zur Quizfrage.
- Typischer Fehler: `Where(p => p.Lager > 0 && ...)` ist ebenso richtig wie zwei
  `Where`; beides akzeptieren, den Unterschied (Lesbarkeit) besprechen.

Modellantwort: `solution/` bzw. `samples/LINQ-to-Objects/Einstieg`.
