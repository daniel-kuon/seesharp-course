# Rubrik — Generischer Stapel (nur für die Betreuung)

- `T[]` als interner Speicher: Nachfragen, was `new T[5]` für `T = string`
  enthält (nulls) und für `T = int` (Nullen), Vorgriff auf `default(T)`.
- `data[size++]` und `data[--size]`: Prä-/Post-Inkrement aus Level 2
  bewusst einsetzen oder lesbarer in zwei Zeilen schreiben; beides gut.
- `SimpleStack<int>` und `SimpleStack<string>` sind verschiedene Typen
  (Test prüft das); zur Laufzeit existiert pro Konkretisierung ein Typ
  (8.4).
- Ausblick: `Stack<T>` aus der BCL (Level 10) macht genau das, dynamisch
  wachsend.

Modellantwort: `solution/` bzw. `samples/Typgenerisches Programmieren/SimpleStack`.
