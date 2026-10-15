# Rubrik — default und Nullable (nur für die Betreuung)

- `default(T)` vs. `default`-Literal: beides gut; das Literal braucht einen
  Zieltyp.
- `def == null` bei unbeschränktem `T` ist erlaubt und für Werttypen immer
  `false`; kurz erklären, warum das kein Boxing-Problem ist (der Compiler
  behandelt es pro Konkretisierung).
- `int?`-Variante mit `?? 0` in einer Summe (`summe += w ?? 0`) ist elegant
  und erlaubt.
- Nullable-Referenztypen (`string?`) sind etwas anderes als `Nullable<T>`;
  Level 14 klärt das. Hier nur anmerken, wenn Verwirrung entsteht.

Modellantwort: `solution/` bzw. `samples/Typgenerisches Programmieren/default`.
