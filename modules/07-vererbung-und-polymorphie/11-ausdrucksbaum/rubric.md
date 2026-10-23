# Rubrik — Zusatz Ausdrucksbaum (nur für die Betreuung)

- Kernidee: Kein `switch` über den Knotentyp. Jede Klasse kennt ihre eigene
  Rechnung; `BinaererAusdruck.Auswerten()` ist eine Schablonenmethode, die
  `Verknuepfe` aufruft. Wer in `Auswerten` mit `is Plus` verzweigt, hat das
  Ziel verfehlt, auch wenn Tests grün sind.
- `sealed override` auf `Auswerten`/`Knoten`: Warum ist das hier sinnvoll?
  (Die Reihenfolge links → rechts → verknüpfen ist eine Invariante; die
  Operatoren sollen nur `Verknuepfe` liefern.)
- `Mal.Vereinfache()` mit `base.Vereinfache()`: Erweiterung statt Kopie.
  Gute Nachfrage: Warum vereinfacht `(2 + 3) * 4` nicht vollständig zu 20?
  (Die Kinder werden nicht zuerst vereinfacht; das wäre eine Erweiterung
  für Fortgeschrittene.)
- `ToString()` von `Zahl` mit Nachkommastellen hängt von der Kultur ab
  (`2,5` bzw. `2.5`); die Tests verwenden deshalb nur ganze Zahlen.

Modellantwort: `solution/`.
