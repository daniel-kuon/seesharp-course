# Rubrik — IComparable/ICloneable (nur für die Betreuung)

- Das Buch-Beispiel rechnet `long z1hn = Zaehler * b.Nenner;` ohne Cast,
  also in `int`, und läuft bei großen Werten über. Der Test
  `CompareTo_ueberlaeuft_nicht_bei_grossen_Werten` fängt das; wer abgetippt
  hat, lernt den Unterschied zwischen Deklaration und Rechentyp.
- `MemberwiseClone()` vs. `new Bruch(...)`: beides richtig; flach vs. tief
  kurz einordnen.
- Nachfrage: Warum ist `CompareTo` mit `Bruch?` deklariert? (Das Interface
  erlaubt null; Nullable-Annotation.)
- `Array.Sort` ohne `IComparable<T>` wirft `InvalidOperationException`;
  einmal zeigen, indem man die Interface-Angabe entfernt.

Modellantwort: `solution/` bzw. `samples/Klassen und Objekte/Bruch/b10 IComparable, IClonable`.
