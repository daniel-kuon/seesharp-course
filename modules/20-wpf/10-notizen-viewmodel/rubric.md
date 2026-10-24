# Rubrik — Zusatz Notizen-ViewModel (nur für die Betreuung)

- Kern: Das Zusammenspiel von Zustand (`Text`, `Ausgewaehlt`), Befehlen und
  Sammlung, jetzt ohne Hilfe durch Vorgaben. Typische Fehler: `Hinzufuegen`
  neu bewerten vergessen, wenn sich `Text` ändert (Schaltfläche bleibt
  grau); `Ausgewaehlt` nach dem Löschen nicht zurücksetzen (Schaltfläche
  bleibt aktiv, `Remove` mit nicht mehr vorhandenem Wert).
- `ObservableCollection<string>.Remove` entfernt das erste gleiche Element;
  bei doppelten Notizen verschwindet also nicht unbedingt die markierte
  Zeile. Gesprächsanlass: Wie ließe sich das mit einer Notiz-Klasse
  oder `RemoveAt` über den Index lösen? (Der Test fordert nur, dass ein
  Eintrag verschwindet.)
- In der Oberfläche wäre `Ausgewaehlt` an `ListBox.SelectedItem` mit
  `Mode=TwoWay` gebunden.

Modellantwort: `solution/`.
