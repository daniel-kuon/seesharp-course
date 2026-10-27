# Rubrik — Delegaten-Quiz (nur für die Betreuung)

- `ereignis-versus-feld` und die beiden Szenariofragen sind der Kern:
  Entwurfsentscheidungen in eigenen Worten begründen lassen (Interface
  `IComparer<T>` oder `Comparison<T>`? `event` oder öffentliches Feld?).
- Die Klassifikationsfragen sind Lesetraining für fremden Code; die anonyme
  Methode kommt in neuem Code kaum vor, in älterem aber oft.
- Varianz: Aus der Regel herleiten lassen (`in` = nur Eingabe, `out` = nur
  Ausgabe, Level 9). Das Gegenbeispiel für die verbotene Richtung vorführen
  (`ao = as_` wäre unsicher: `ao(42)` würde der `Action<string>` ein `int`
  übergeben).
- Frage `e4-versiegeln`: `sealed override event` zeigen lassen.

Modellantwort: `samples/Delegaten und Ereignisse/Delegaten/Kovarianz`, `Kontravarianz`.
