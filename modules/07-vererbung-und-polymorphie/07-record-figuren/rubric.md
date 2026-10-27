# Rubrik — Record-Figuren (nur für die Betreuung)

- Die Lösung ist `: Figur(X, Y)`. Wer stattdessen in `Kreis` eigene
  Eigenschaften `X`/`Y` deklariert, hat die Tests vielleicht grün, aber die
  Validierung verdoppelt; nachfragen.
- Warnung CS8907 als Werkzeug: Warnungen lesen lohnt sich. Vergleich mit
  Level 0 (Compilerfehler lesen).
- `EqualityContract`: mit dem Decompiler zeigen, warum `Figur == Kreis`
  trotz gleicher Position `false` ist.
- `with` auf einen Kreis über eine `Figur`-Referenz liefert einen Kreis
  (virtuelle Klon-Methode, die den Kopierkonstruktor aufruft) — kleiner Bonus zum Ausprobieren.

Modellantwort: `solution/` bzw. `samples/Vererbung und Polymorphie/Record-Figuren`.
