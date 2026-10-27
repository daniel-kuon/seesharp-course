# Rubrik — Generische Erweiterungen (nur für die Betreuung)

- Zwei Schreibweisen für dasselbe (Block vs. `this`-Methode): Der Trainee
  soll beide lesen und schreiben können, der Block ist die neue Form.
- `bool?` als Rückgabetyp verbindet Nullable mit Generics; nachfragen, warum
  `null` hier besser ist als `false`.
- Wer `arr.Min()` (LINQ) verwendet, hat einen Vorgriff gemacht; erlaubt, aber
  `CompareTo` von Hand soll vorkommen (Groesstes).
- Nachfrage: Warum geht `extension<T>(T[] arr)`, aber nicht
  `extension(object[] arr)` für `int[]`? (Array-Kovarianz gilt nur für
  Referenztyp-Elemente: `string[]` passt auf `object[]`, `int[]` nicht;
  8.2.3, Seite 597.)

Modellantwort: `solution/` bzw. `samples/Typgenerisches Programmieren/Generische Erweiterungsmethoden`.
