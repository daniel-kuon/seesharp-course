# Rubrik: Listen verwalten (nur für die Betreuung)

- **Kernidee:** eine Schleife von hinten nach vorn. Bonus (Deep Dive):
  `RemoveAll(z => z % 2 == 0)` ist auch richtig, steht aber nicht im Buch und
  braucht einen Lambda-Ausdruck (Level 12). Wer `foreach` mit `Remove()` schreibt, bekommt zur Laufzeit eine
  Ausnahme; wer vorwärts mit `for` und `RemoveAt(i)` arbeitet, überspringt das
  Element, das nachrückt (Testdaten `2, 4, 6`). Lässt sich der Teilnehmer das
  Problem erklären?
- `Top3`: Erst kopieren (`new List<int>(zahlen)`), dann `Sort()` und vom Ende
  her höchstens drei Werte in eine neue Liste übernehmen. Häufiger Fehler: das
  Argument sortieren und damit verändern. Bonus (Deep Dive): `Reverse()` und
  `GetRange(0, Math.Min(3, Count))` (beide nicht im Buch), wie in `solution/`.
- `Rotate`: `k %= Count` nicht vergessen, aber erst nach der Prüfung auf ein
  leeres Array (sonst Division durch null). Alternative ohne Liste ist erlaubt, wenn die Tests grün
  sind; die Aufgabe will aber `RemoveAt`/`Add`/`ToArray` üben.
- `MoveToFront`: `IndexOf` liefert -1, wenn der Eintrag fehlt.
- Nachfragen: Warum ist `RemoveAt(0)` bei großen Listen teuer? (Alle
  Folgeelemente rücken nach.) Das führt zu `LinkedList<T>` in Aufgabe 3
  (und zum Deep Dive `Queue<T>`).
- Modellantwort: `solution/`. Kein Beispielprojekt aus `samples/`; die Aufgabe
  ist neu geschrieben.
