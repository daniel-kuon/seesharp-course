# Rubrik — Zusatz Validierung per Attribut (nur für die Betreuung)

- Kern: Regeln als Metadaten an den Daten, eine Prüfroutine für alle Typen.
  Die Attribute tragen nur Werte (`Min`, `Max`); das Verhalten steckt im
  `Validierer`. Gesprächsanlass: Warum gehört die Prüflogik nicht in das
  Attribut? (Attribute sind passive Metadaten; der Prüfer kann sich ändern,
  ohne dass Attribute neu übersetzt werden müssen.)
- Der Test mit `Wertung` (`int? Punkte` mit beiden Attributen) deckt die
  Reihenfolge Pflicht, dann Bereich und das Überspringen bei `null` ab.
  Typischer Fehler: `Convert.ToInt32(null)` liefert 0 und löst eine falsche
  Bereichsmeldung aus.
- Die Meldung nutzt `p.Name`: Hier wäre `nameof` nicht möglich, weil der
  Name erst zur Laufzeit feststeht. Nachfragen, warum.
- Reflexion ist langsamer als direkter Zugriff. Für Validierung von
  Formulardaten egal; bei Millionen Objekten würde man Ergebnisse
  zwischenspeichern.

Modellantwort: `solution/`.
