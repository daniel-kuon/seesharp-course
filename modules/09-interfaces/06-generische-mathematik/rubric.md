# Rubrik — Generische Mathematik (nur für die Betreuung)

- `checked(...)` um jeden Teilausdruck oder ein `checked { }`-Block im
  Operator: beides korrekt. Wer nur `new Bruch(checked(z), n)` schreibt und
  den Nenner vergisst, fällt bei anderen Werten durch; nachfragen.
- `where TSelf : IKombinierbar<TSelf>` (CRTP-Muster) kurz erklären: Das
  Interface spricht über den implementierenden Typ selbst.
- `Rechner.Summe` mit `+=`: Der Compiler übersetzt `summe = summe + r` über
  den statischen abstrakten Operator; es gibt keinen virtuellen Aufruf.
- Bonus (Deep Dive): `operator checked +=` (nicht im Buch). Nachfragen,
  warum ohne ihn auch im `checked`-Block das normale `+=` läuft.
- Stretch (nicht verlangt): `INumber<T>` und `T.Zero` wie im Beispiel
  `Generische Mathematik/Anwendung`.

Modellantwort: `solution/` bzw. `samples/Klassen und Objekte/Bruch/b11 IAdditionOperators`
und `samples/Interfaces/Statische Mitglieder/Generische Mathematik/Operatorüberladung`.
