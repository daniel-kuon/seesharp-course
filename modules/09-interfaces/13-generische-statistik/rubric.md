# Rubrik — Zusatz generische Statistik (nur für die Betreuung)

- `T.Zero` statt `default(T)`: Für alle eingebauten Zahltypen ist beides 0,
  aber `T.Zero` sagt, was gemeint ist, und funktioniert auch für eigene
  Zahltypen, deren "Null" nicht der Standardwert ist (ein `Bruch` mit
  Nenner 0 wäre keiner).
- `checked(summe + w)`: Im Buch (9.6 Aufgabe 3) war es umgekehrt, dort
  wurde der checked-Operator für `Bruch` *implementiert*; hier wird er
  *benutzt*. Nachfragen, warum `SummeGeprueft<double>` nie wirft
  (`double` läuft nach `Infinity` über, nicht um).
- `T.CreateChecked(werte.Length)`: Warum nicht `(T)werte.Length`? (Für ein
  offenes `T` gibt es keinen Cast von `int`.) `CreateChecked` würde bei
  `byte` und mehr als 255 Werten werfen; das Gegenstück `CreateSaturating`
  kurz erwähnen.
- `Mittelwert(1, 2)` liefert für `int` 1: Typ bestimmt die Division. Gute
  Gelegenheit, Level 2 (Ganzzahldivision) zu wiederholen.

Modellantwort: `solution/`.
