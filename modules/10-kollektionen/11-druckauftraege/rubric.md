# Rubrik: Deep Dive Druckaufträge und Rückgängig-Stapel (nur für die Betreuung)

- **Kernidee:** Rückgängig ist LIFO (der letzte Schritt wird zuerst
  zurückgenommen): `Stack<T>`. Ein Druckauftrag ist FIFO (wer zuerst kommt,
  druckt zuerst): `Queue<T>`. Die Wahl der Kollektion steckt die Reihenfolge
  fest, ohne Index und ohne Sortierung.
- Der Editor speichert ganze Textstände auf den Stapeln. Das ist bewusst
  einfach; ein Teilnehmer, der nur die getippten Stücke stapelt, ist
  genauso richtig, solange die Tests grün sind.
- Pflichtpunkt: Neues Tippen nach `Rueckgaengig` leert den Wiederholen-Stapel
  (wie in jedem Editor). Nachfragen, warum.
- `Auftrag(string name, int seiten)`: Der Parameter `seiten` verdeckt das
  Feld `seiten`; dafür gibt es den Hinweis `this.seiten`. Eine Umbenennung
  ist erlaubt, solange die öffentliche Signatur bleibt.
- Modellantwort: `solution/`.
