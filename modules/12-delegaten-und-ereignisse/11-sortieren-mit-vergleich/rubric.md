# Rubrik — Sortieren mit Vergleichslambda (Zusatzaufgabe, nur für die Betreuung)

- Kernidee: Das Lambda ist die Vergleichsfunktion; Gleichstand sauber über
  eine zweite Stufe auflösen (`CompareTo` verketten), weil `List<T>.Sort`
  nicht stabil ist.
- Der Test zu `NachAlter` prüft bei Gleichstand nur die Altersfolge, weil die
  Reihenfolge gleich alter Personen nicht festgelegt ist. Nachfrage: Warum?
- `Juengste`: Das Lambda verändert eine eingefangene lokale Variable
  (`Person? beste = null`); Nullprüfung beim ersten Element beachten.
- Typischer Fehler: `<=` statt `<` im Vergleich (dann gewinnt die letzte
  gleich alte Person).

Modellantwort: `solution/`.
