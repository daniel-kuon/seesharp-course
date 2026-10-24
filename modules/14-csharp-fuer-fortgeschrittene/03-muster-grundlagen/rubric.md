# Rubrik — Muster: Konstante, Typ, Relation, logisch (nur für die Betreuung)

- Kern: Muster beschreiben die Form eines Werts; Relationsmuster und die
  Kombinatoren `and`, `or`, `not` ersetzen verschachtelte Vergleiche. Der
  `switch`-Ausdruck prüft die Arme von oben nach unten; `< 0 or > 150` muss
  vor `< 13` stehen, sonst gilt −1 als Kind. Der Compiler warnt bei
  unerreichbaren Armen (CS8510), das ist ein guter Gesprächsanlass.
- Die Tests prüfen alle Grenzen (0, 12, 13, 17, 18, 64, 65, 150, 151, −1).
  Fehler bei 64/65 oder 17/18 meist durch `<=`-statt-`<`-Verwechslung.
- `IstIdentifierZeichen('ä')` muss `false` liefern (`char.IsLetter` wäre hier
  falsch); `IstPositiv(null)` darf nicht werfen.
- Nachfragen: Unterschied Typmuster `int` und Deklarationsmuster `int i`?
  Warum braucht `Beschreibe` ein `_`? (Ein switch-Ausdruck muss erschöpfend
  sein, sonst Warnung CS8509 und zur Laufzeit `SwitchExpressionException`.)
- Rangfolge `not` vor `and` vor `or` (Quiz-Item) besprechen.

Modellantwort: `solution/` bzw. `samples/C# für Fortgeschrittene/Musterabgleich/{Typmuster,Relationsmuster,logisches Muster}`.
