# Rubrik — default und Nullable (nur für die Betreuung)

- `default(T)` vs. `default`-Literal: beides gut; das Literal braucht einen
  Zieltyp.
- `def == null` bei unbeschränktem `T` ist erlaubt und für nicht null-fähige
  Werttypen immer `false` (für `int?` dagegen `true`); kurz erklären, warum das
  kein Boxing-Problem ist (die CLR erzeugt pro Werttyp-Konkretisierung eigenen
  Code, 8.4).
- `T? ErstesOderDefault<T>` im Starter: Bei unbeschränktem `T` ist `T?` nur eine
  Nullable-Annotation (Level 14), für `T = int` bleibt der Rückgabetyp `int`,
  nicht `int?`. Nur ansprechen, wenn der Trainee fragt.
- `int?`-Variante mit `?? 0` in einer Summe (`summe += w ?? 0`) ist elegant
  und erlaubt.
- Nullable-Referenztypen (`string?`) sind etwas anderes als `Nullable<T>`;
  Level 14 klärt das. Hier nur anmerken, wenn Verwirrung entsteht.

Modellantwort: `solution/` bzw. `samples/Typgenerisches Programmieren/default`.
