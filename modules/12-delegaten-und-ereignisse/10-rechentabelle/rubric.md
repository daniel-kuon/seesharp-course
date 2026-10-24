# Rubrik — Rechentabelle (Zusatzaufgabe, nur für die Betreuung)

- Kernidee: Delegaten sind Werte; man kann sie in einem Dictionary ablegen
  und per Name wieder herausholen (Dispatch-Tabelle statt `switch`).
- Typische Fehler: Indexzugriff `_operationen[name]` ohne `TryGetValue`
  (KeyNotFoundException), Zeilen/Spalten vertauscht, Obergrenze `bis` vergessen.
- Nachfrage: Wie würde man `Tabelle` ohne zweite Berechnungsmethode
  schreiben? (Doppelschleife mit `Berechne` ist ausreichend.)

Modellantwort: `solution/`.
