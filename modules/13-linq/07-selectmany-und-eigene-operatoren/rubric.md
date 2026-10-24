# Rubrik — SelectMany, Unterabfragen, eigene Operatoren (nur für die Betreuung)

- Kernidee: `SelectMany` flacht eine Sequenz von Sequenzen ab; die zweite
  `from`-Klausel ist dasselbe. Eigene Operatoren sind Erweiterungsmethoden auf
  `IEnumerable<T>` mit `yield return` und damit automatisch zurückgestellt (lazy).
- Unterabfrage in `where`: wird für jedes Element neu ausgeführt (n + 1
  Aufzählungen). Der Test `UeberDemSchnitt_zaehlt_die_Quelle_hoechstens_zweimal`
  deckt das auf; Lösung: Durchschnitt vorher berechnen oder die Quelle einmal
  mit `ToList()` materialisieren.
- `TakeEvery` mit Argumentprüfung: In einem Iterator läuft sie erst bei der
  Aufzählung; das ist ein bekannter Stolperstein (Prüfung in einer äußeren
  Methode wäre der Fix). Der Test akzeptiert deshalb die Ausnahme bei der Aufzählung.
- `Paarweise`: erstes Element merken, Sonderfall weniger als zwei Elemente.
- `OfType<int>` liefert nur Objekte, die genau `int` (geboxt) sind; `long` und
  `null` fehlen. Nachfrage: Unterschied zu `Cast<int>()` (wirft bei falschem Typ).

Modellantwort: `solution/` bzw. `samples/LINQ-to-Objects/OfType`, `Unterabfrage`.
