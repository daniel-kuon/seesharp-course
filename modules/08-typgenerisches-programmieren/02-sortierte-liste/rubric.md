# Rubrik — Sortierte Liste (nur für die Betreuung)

- Die Schleife `for (i = size - 1; i >= 0 && element.CompareTo(data[i]) < 0; i--)`
  ist die Kernstelle; bedingte Auswertung (`&&`) schützt vor `data[-1]`.
  Nachfragen, warum `<` und nicht `<=` (Stabilität bei gleichen Werten).
- `IComparable<T>` ist ein Interface; Level 9 implementiert es selbst. Hier
  reicht: "Typen, die sich vergleichen lassen".
- Was passiert bei `SimpleSortedList<object>`? (Compilerfehler, object
  implementiert IComparable<object> nicht.)

Modellantwort: `solution/` bzw. `samples/Typgenerisches Programmieren/SimpleSortedList`.
