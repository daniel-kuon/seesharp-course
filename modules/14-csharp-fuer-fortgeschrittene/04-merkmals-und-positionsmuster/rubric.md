# Rubrik — Merkmals-, Positions- und var-Muster (nur für die Betreuung)

- Kern: Ein Merkmalsmuster `{ Eigenschaft: Muster }` fragt Eigenschaften ab und
  ist dabei null-sicher; das Positionsmuster nutzt `Deconstruct`; `var` fängt
  einen Teilwert ein, `when` hängt eine beliebige Bedingung an.
- In `Gebuehr` entscheidet die Reihenfolge. Häufiger Fehler: die `when`-Zeile
  hinter die allgemeine Deutschland-Zeile setzen; der Compiler meldet dann
  CS8510 (Muster bereits behandelt), weil der spätere Arm unerreichbar ist.
  Der Test mit Baujahr 2006/2005 (20 bzw. 21 Jahre) fängt auch `>=` statt `>` ab.
- `Halter` ist absichtlich nullable: `{ Halter.Land: "DE" }` darf bei `null`
  nicht werfen. Nachfrage: Was würde `f.Halter.Land == "DE"` tun?
- Nachfragen: Wann Positionsmuster, wann Merkmalsmuster? (Positionsmuster
  brauchen `Deconstruct` und hängen an der Reihenfolge der Komponenten;
  Merkmalsmuster nennen die Namen.)

Modellantwort: `solution/` bzw. `samples/C# für Fortgeschrittene/Musterabgleich/{Merkmalsmuster,Positionsmuster,var-Muster}`.
