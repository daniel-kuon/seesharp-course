# Rubrik — Mehrfachdelegaten (nur für die Betreuung)

- Kernidee: `+=` und `-=` erzeugen jeweils ein neues Delegatenobjekt
  (Delegaten sind unveränderlich); `ziele?.Invoke(text)` schützt vor dem
  leeren Delegaten (`null`).
- Typische Fehler: `Sende` ohne null-Prüfung (NullReferenceException),
  `AnzahlZiele` ohne den Fall `null` (keine Ziele).
- `Kette`: Jeder Schritt bekommt das Argument des Aufrufs, nicht das Ergebnis
  des Vorgängers (das wäre Komposition, kommt in 12/04).
- Bonus (Deep Dive): Wie kommt man an alle Zwischenergebnisse?
  (`GetInvocationList()` durchlaufen; nicht im Buch.)
- Doppelt angemeldete Methoden stehen doppelt in der Liste; `-=` entfernt
  das letzte Vorkommen.

Modellantwort: `solution/` bzw. `samples/Delegaten und Ereignisse/Delegaten/OpChain`.
