# Rubrik — Reparatur (nur für die Betreuung)

- Fehler 1 (CS7036/CS1729): Der implizite Standardkonstruktor verschwindet,
  sobald die Basisklasse einen expliziten Konstruktor hat. Nachfragen, ob
  der Trainee auch die Alternative kennt (parameterlosen Basiskonstruktor
  ergänzen) und warum sie hier schlechter ist (Ibas wäre dann 3 statt des
  gewünschten Werts).
- Fehler 2 (CS0122): "vererbt" ≠ "zugänglich". Wer `protected` gewählt hat,
  hat die Tests auch bestanden; im Gespräch die `base(x, y)`-Lösung zeigen
  (keine doppelte Validierung).
- Offene Frage: Beide Erklärungen sollen die Begriffe "impliziter
  Standardkonstruktor" und "private vs. protected" enthalten.

Modellantwort: `solution/`; verwandtes Beispiel
`samples/Vererbung und Polymorphie/protected`.
