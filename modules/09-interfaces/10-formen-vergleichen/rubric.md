# Rubrik — Zusatz Formen vergleichen (nur für die Betreuung)

- Kern: ein Interface erweitert ein anderes (`IForm : IComparable<IForm>`)
  und liefert die Implementierung als konkretes Mitglied gleich mit. Der
  Test `CompareTo_steckt_im_Interface` prüft per `GetInterfaceMap`, dass
  `Kreis` die Methode aus `IForm` benutzt; wer `CompareTo` in jede Klasse
  kopiert, fällt dort durch. Gesprächsanlass: Wann ist eine abstrakte
  Basisklasse `Form` die bessere Wahl? (Wenn auch Zustand geteilt werden
  soll; Interfaces haben keine Felder.)
- Die Syntax `int IComparable<IForm>.CompareTo(...)` im Interface sieht aus
  wie eine explizite Implementierung (Übung 2) und ist auch eine. Ein
  `public int CompareTo(...)` ohne Präfix würde das geerbte Mitglied nur
  verdecken (Warnung CS0108) und nichts implementieren.
- `Array.Sort` auf `IForm[]` funktioniert ohne `IComparer`, weil der
  Elementtyp `IComparable<IForm>` ist. Diskussionsfrage zur Kontravarianz
  (Übung 7): Lässt sich auch ein `Kreis[]` sortieren? (Ja: Wegen
  `IComparable<in T>` gilt ein `IComparable<IForm>` auch als
  `IComparable<Kreis>`.)
- Heron: Die Prüfung der Dreiecksungleichung gehört in den Konstruktor,
  nicht in `Flaeche` (sonst liefert `Math.Sqrt` stillschweigend `NaN`).

Modellantwort: `solution/`.
