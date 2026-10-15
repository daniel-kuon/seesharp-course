# Rubrik — Felder, Eigenschaften, Validierung (nur für die Betreuung)

- Greift der Setter von `Nenner` auf das Feld (`nenner = value`) oder auf die
  Eigenschaft (`Nenner = value`) zu? Letzteres ist der rekursive Fehler aus
  5.15 Aufgabe 3; im Starter absichtlich nicht eingebaut, weil er den Testlauf
  zum Absturz bringt. Im Review in Rider provozieren und die Stack-overflow-
  Ausgabe ansehen.
- `Kuerze()`: Übernahme aus Level 3 mit `Math.Abs`; ohne `Abs` scheitert
  `Kuerze_mit_negativem_Zaehler`, weil `%` das Vorzeichen des Dividenden
  behält und `rest > 0` dann sofort falsch wird.
- `Addiere`: darf auf die privaten Felder von `b` zugreifen (gleiche Klasse) —
  gute Gelegenheit, Kapselung auf Klassenebene zu erklären.

Modellantwort: `samples/Klassen und Objekte/Bruch/b0` im Tool-Repository.
