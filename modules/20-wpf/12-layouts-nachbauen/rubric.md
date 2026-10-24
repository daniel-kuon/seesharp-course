# Rubrik — Zusatz Layouts nachbauen (nur für die Betreuung)

Reine Sichtprüfung am laufenden Fenster (Windows); es gibt keine Tests.

- Beide Fenster in kleiner und großer Fassung ansehen: Eingabefelder bzw.
  Lesebereich wachsen, nichts wird abgeschnitten, die Schnellfilter
  umbrechen.
- Befund, wenn `Canvas` oder feste `Margin`-Positionen für das Gesamtlayout
  benutzt werden; `Width`/`Height` nur bei kleinen Elementen wie
  Schaltflächen sind in Ordnung.
- Die Wahl der Container begründen lassen: `Grid` für Tabellen und
  mehrspaltige Aufteilung (`Auto`, `*`), `DockPanel` für Kopf- und Fußbereiche,
  `StackPanel` für Reihen von Schaltflächen, `WrapPanel` für umbrechende
  Reihen.
- `GridSplitter` ist nicht im Buch behandelt; die Funktion ist ein
  Zusatz. Wer Spalten ohne Trenner baut, hat die Kernaufgabe gelöst.
- Die Skizzen liegen als Text in der Aufgabenstellung (kein Bildmaterial);
  auf Wunsch kann die Betreuung eigene Screenshots dazugeben.
