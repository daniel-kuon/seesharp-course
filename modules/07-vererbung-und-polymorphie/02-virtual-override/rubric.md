# Rubrik — virtual/override (nur für die Betreuung)

- Die Umstellung `new` → `override` ist mechanisch; der Lernwert ist das
  Warum. Fragen: Was ändert sich für `Kreis k = new Kreis(); k.Wo()`?
  (Nichts.) Für `Figur f = k; f.Wo()`? (Alles.)
- `base.Wo()`: Wiederverwendung der Basisimplementierung statt Kopie.
- `sealed override`: Reflection-Test prüft `IsFinal`. Nachfragen, wann man
  versiegelt (Invarianten schützen, 7.10).
- `Beschreibe()` nicht-virtuell mit virtuellen Aufrufen darin: Template
  Method im Kleinen; kurz benennen.

Modellantwort: `solution/`; Vorlagen in
`samples/Vererbung und Polymorphie/Polymorphie` und `abstract`.
