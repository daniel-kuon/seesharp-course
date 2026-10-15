# Rubrik — Lotto (nur für die Betreuung)

- `rnd.Next(i + 1)` statt `rnd.Next(i)`: Das Buch-Beispiel nutzt `Next(i)`,
  das ist Sattolos Variante (erzeugt nur zyklische Permutationen). Der Test
  mit festem Seed verlangt die korrekte Fisher-Yates-Form; wer den Buchcode
  abtippt, fällt durch und lernt dabei, Verfahren genau zu lesen.
- Referenzsemantik von Arrays: `Mische` hat keinen Rückgabewert und wirkt
  trotzdem. Nachfragen, warum das bei einem `int`-Parameter nicht ginge.
- `Array.Copy` vs. Bereich `vektor[..6]` (6.2.8): beides richtig.
- Nachfrage: Warum ist `Random` mit Seed in Tests nützlich und in der
  Produktion gefährlich?

Modellantwort: `solution/` bzw. `samples/Weitere .NETte Typen/Arrays/Lotto`.
