# Rubrik: Listen verwalten (nur für die Betreuung)

- **Kernidee:** eine Schleife von hinten nach vorn (`RemoveAll(z => z % 2 == 0)`
  ist auch richtig, braucht aber einen Lambda-Ausdruck, der erst in Level 12
  kommt). Wer `foreach` mit `Remove()` schreibt, bekommt zur Laufzeit eine
  Ausnahme; wer vorwärts mit `for` und `RemoveAt(i)` arbeitet, überspringt das
  Element, das nachrückt (Testdaten `2, 4, 6`). Lässt sich der Teilnehmer das
  Problem erklären?
- `Top3`: Erst kopieren (`new List<int>(zahlen)`), dann `Sort()`, `Reverse()`
  und `GetRange(0, Math.Min(3, Count))`. Häufiger Fehler: das Argument
  sortieren und damit verändern.
- `Rotate`: `k %= Count` nicht vergessen, aber erst nach der Prüfung auf ein
  leeres Array (sonst Division durch null). Alternative ohne Liste ist erlaubt, wenn die Tests grün
  sind; die Aufgabe will aber `RemoveAt`/`Add`/`ToArray` üben.
- `MoveToFront`: `IndexOf` liefert -1, wenn der Eintrag fehlt.
- Nachfragen: Warum ist `RemoveAt(0)` bei großen Listen teuer? (Alle
  Folgeelemente rücken nach.) Das führt zu `Queue<T>` und `LinkedList<T>` in
  Aufgabe 3.
- Modellantwort: `solution/`. Kein Beispielprojekt aus `samples/`; die Aufgabe
  ist neu geschrieben.
