# Rubrik — Max mit Serienparameter (nur für die Betreuung)

- `params T[]`: ein Array oder einzelne Werte; `Serie.Max<int>()` ohne
  Argumente ist ein leeres Array, keine fehlende Überladung.
- `where T : struct, IComparable<T>`: Reihenfolge und Wirkung auf `T?`
  erklären; ohne `struct` wäre `T?` nur eine Nullable-Annotation ohne
  `Nullable<T>`-Struktur. Das ist der eigentliche Lerninhalt zu
  Einschränkungsarten.
- `MaxOderNull` darf `Max` wiederverwenden.
- Ausblick: `params ReadOnlySpan<T>` (Level 14) spart das Array.

Modellantwort: `solution/`; im Buch gibt es dazu kein Beispielprojekt.
