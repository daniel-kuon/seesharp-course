# Rubrik — Interface implementieren (nur für die Betreuung)

- Interface-Mitglieder müssen `public` implementiert werden; wer `Name`
  ohne `public` schreibt, bekommt CS0737. Nachfragen, warum das so ist.
- `IForm[]` mit Klasse und Struktur gemischt: Was passiert beim Einfügen des
  Quadrats ins Array? (Boxing.) Was liefert `formen[1].GetType()`?
- Vergleich mit Level 7: Warum hier Interface statt abstrakter Basisklasse?
  (Struktur kann nicht erben; eine Klasse kann mehrere Interfaces
  implementieren.) Level 9.7 vertieft das.

Modellantwort: `solution/`; Vorlagen in `samples/Interfaces/Interface-Datentypen` und `Fimplement`.
