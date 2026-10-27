# Rubrik — IComparable/ICloneable (nur für die Betreuung)

- Die Beispiellösung zum Buch (`samples/`) rechnet `long z1hn = Zaehler * b.Nenner;` ohne Cast,
  also in `int`, und läuft bei großen Werten über. Der Test
  `CompareTo_ueberlaeuft_nicht_bei_grossen_Werten` fängt das; wer abgetippt
  hat, lernt den Unterschied zwischen Deklaration und Rechentyp.
- `MemberwiseClone()` vs. `new Bruch(...)`: beides richtig; flach vs. tief
  kurz einordnen.
- Nachfrage: Warum ist `CompareTo` mit `Bruch?` deklariert? (Das Interface
  erlaubt null; Nullable-Annotation.)
- Negative Nenner (`1/-2`): Die Kreuzmultiplikation allein kehrt den Vergleich
  um, wenn genau ein Nenner negativ ist. Der Test
  `CompareTo_beachtet_negative_Nenner` prüft das. Alternative, die ebenfalls
  besteht: beide Brüche vorher auf positiven Nenner bringen (Vorzeichen in den
  Zähler). Nachfrage: Warum dreht ein negatives Produkt das Ergebnis?
- `Array.Sort` ohne `IComparable<T>` wirft `InvalidOperationException`;
  einmal zeigen, indem man die Interface-Angabe entfernt.

Modellantwort: `solution/` bzw. `samples/Klassen und Objekte/Bruch/b10 IComparable, IClonable`.
