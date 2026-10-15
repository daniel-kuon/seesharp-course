# Rubrik — Aggregation (nur für die Betreuung)

- Kernfrage: Wer rechnet? `Aufgabe` soll delegieren (`lsg.Addiere(b2)`), nicht
  selbst mit Zähler und Nenner hantieren. Wer die Bruchrechnung in `Init()`
  nachbaut, hat Aggregation noch nicht verstanden.
- `NeueWerte` darf keine neuen Objekte anlegen; der Test über `Bruch.Anzahl`
  fängt das. Gelegenheit, `readonly`-Felder zu erklären: die Referenz ist
  fest, das Objekt dahinter veränderbar.
- `Pruefe` mit einem temporären Bruch lösen (kürzen, dann vergleichen); eine
  Kreuzmultiplikation ist auch in Ordnung.
- Bonus: Warum ist `Loesung` eine Eigenschaft, die die Referenz herausgibt,
  und was kann ein Aufrufer damit anstellen?

Modellantwort: `solution/` bzw. `samples/Klassen und Objekte/Bruch/b8 Aggregation`
im Tool-Repository.
