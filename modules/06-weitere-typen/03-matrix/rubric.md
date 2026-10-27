# Rubrik — float-Matrix (nur für die Betreuung)

- Häufiger Fehler beim quadratischen Fall: alle Paare tauschen (`j < Zeilen`
  statt `j < i`), dann ist die Matrix am Ende wieder die alte. Der Test
  `Transponieren_einer_quadratischen_Matrix_in_place` fängt das.
- Beim nicht quadratischen Fall müssen `Zeilen` und `Spalten` vor dem
  Anlegen des neuen Arrays getauscht werden (oder man benutzt die alten
  Werte sauber). Tupelzuweisung als eleganteste Form zeigen.
- `float[,]` gegen `float[][]` (6.2.10) abgrenzen: rechteckig vs. "ausgesägt" (jagged).
- `Anzeigen()` liefert einen String statt zu drucken; kurz begründen
  (Testbarkeit).

Modellantwort: `solution/` bzw. `samples/Weitere .NETte Typen/Arrays/FloatMatrix`.
