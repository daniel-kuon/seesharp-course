# Rubrik — Zusatz Mini-Chat-Protokoll (nur für die Betreuung)

- Kern: Aufgabe 4 ohne Hilfen, mit einem Protokoll, das **Zustand** hat (der
  Name gilt für die folgenden Zeilen): Ein Zustand der Verbindung lebt in
  einer lokalen Variablen der Bedienschleife, nicht in einem statischen Feld
  (sonst teilen sich später mehrere Klienten den Namen).
- Typische Fehler: nach dem ersten Leerzeichen zu früh trennen
  (`Split(' ')[1]` verliert den Rest), Zeile mit `ReadToEnd` lesen (blockiert),
  fehlendes `AutoFlush`, `SAGE` ohne Text nicht abfangen, `null` von
  `ReadLine` nicht behandeln.
- Gesprächsanlass: Ein Protokoll legt fest, wer wann was sendet und wie
  Fehler gemeldet werden. Was fehlt diesem Chat für mehrere Teilnehmer
  (Verteilung an alle, Annahmeschleife: Aufgabe 5)?

Modellantwort: `solution/`.
