# Rubrik: Lotto mit SortedSet<T> (nur für die Betreuung)

- **Kernidee:** `SortedSet<T>` verbindet zwei Eigenschaften, die das
  Lottoprogramm braucht: keine Duplikate (ein zweites `Add` derselben Zahl
  ändert nichts) und immer aufsteigend sortiert, ohne dass man selbst
  sortiert. Die Schleife `while (Count < 6) Add(...)` ersetzt die Prüfarbeit
  der Array-Lösung aus Level 6.
- Der Test mit festem Startwert hängt von `rnd.Next(1, 50)` und der
  Schleife ab. Wer `Next(49) + 1` verwendet (wie das Beispielprojekt), erhält
  dieselben Zahlen; wer zuerst 6 Zahlen zieht und dann prüft, nicht.
- `Treffer`: Häufiger Fehler ist `tipp.IntersectWith(ziehung)` direkt auf dem
  Argument. Der Test `Treffer_veraendert_keine_der_Mengen` fängt das.
  Alternative ohne Kopie: `tipp.Count(ziehung.Contains)` (LINQ, kommt erst in
  Level 13); eine Schleife mit `Contains` ist ebenfalls richtig.
- `NaechsteZahl`: Erwartet ist ein `foreach` über die aufsteigend sortierte
  Menge, das bei der ersten Zahl größer als `x` aufhört.
  Bonus (Deep Dive): `GetViewBetween` (nicht im Buch); es wirft bei
  `unten > oben` eine Ausnahme, und `x + 1` läuft bei `int.MaxValue` über,
  beides prüfen die Tests. Die Sicht ist keine Kopie, sie liest denselben Baum.
- Nachfragen: Wann nimmt man `SortedSet<T>`, wann `HashSet<T>`? (Sortiert
  und Bereichsabfragen gegen schnellste Existenzprüfung.)
- Modellantwort: `solution/`; Vorlage `samples/Kollektionen/Mengenlotto`.
