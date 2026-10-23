# Rubrik — Zusatz Cache (nur für die Betreuung)

- Einschränkung `where TKey : IComparable<TKey>`: Ohne sie kennt der
  Compiler `CompareTo` nicht. Eigentlich braucht ein Cache nur Gleichheit,
  nicht Ordnung; `IEquatable<T>` und `Dictionary<TKey, TValue>` (Level 10)
  wären die richtige Wahl. Hier bleibt es bei dem, was Level 8 kennt.
- `NachHinten` als gemeinsamer Baustein für `Setze` und `HoleOderDefault`:
  Wer die Verschiebeschleife zweimal schreibt, besteht auch; auf
  Wiederverwendung ansprechen.
- Laufzeit: Jede Operation ist O(n) wegen linearer Suche und Verschieben.
  Für eine Handvoll Einträge egal; echte LRU-Caches kombinieren ein
  Dictionary mit einer verketteten Liste (Level 10).
- `HoleOderDefault` liefert `TValue?`, bei `int` also 0 und nicht `null`.
  Kann der Aufrufer dann zwischen "nicht da" und "Wert 0" unterscheiden?
  (Nein, deshalb gibt es `Enthaelt`, und in der BCL `TryGetValue`.)

Modellantwort: `solution/`.
