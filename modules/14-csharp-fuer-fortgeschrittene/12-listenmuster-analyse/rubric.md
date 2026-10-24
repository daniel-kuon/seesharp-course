# Rubrik — Zusatz: Muster in Messreihen (nur für die Betreuung)

- Kern: Listenmuster mit Elementmustern (`[var a, var b, var c]`), Bereichsmuster
  `..` (mit oder ohne `var`) und Relationsmustern im Element (`> 100`),
  kombiniert mit einer `when`-Bedingung. Die Reihenfolge der Arme ist Teil der
  Aufgabe: `[1, 50, 101]` ist `"steigend"`, nicht `"Ausreißer am Ende"`.
- `[.., > 100]` passt auf jede Reihe mit mindestens einem Element, deren letztes
  Element über 100 liegt; die leere und einelementige Reihe sind vorher
  abgefangen, ein einzelner Wert 500 bleibt `"einzeln"`.
- Listenmuster funktionieren auf Arrays und auf Typen, die `Count`/`Length`
  und einen `int`-Indexer haben (auch `List<T>`); das `.. var rest` liefert
  dann einen Ausschnitt bzw. eine Teilliste.
- Der Tupelelementname `Rest` ist im Compiler reserviert (CS8126), deshalb
  heißt das zweite Element `Uebrige`.

Modellantwort: `solution/`.
