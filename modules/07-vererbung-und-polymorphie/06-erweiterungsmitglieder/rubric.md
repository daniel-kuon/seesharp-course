# Rubrik — Erweiterungsmitglieder (nur für die Betreuung)

- Unterschied `extension(double arg)` (Instanz) und `extension(double)`
  (statisch) klar? Statische Mitglieder und der Operator `^` brauchen keinen
  Empfänger und stehen deshalb im Block ohne Empfängerparameter (erlaubt
  wären sie auch im Block mit `arg`).
- Erweiterungsmethoden haben keinen Zugriff auf private Mitglieder des
  erweiterten Typs (7.15.1); sie sind keine Vererbung. Die Quizfrage zur Priorität (echtes Mitglied gewinnt)
  im Gespräch vertiefen: Was passiert, wenn .NET eines Tages
  `double.High` einbaut?
- `null`-Empfänger bei `s.Empty()`: Gelegenheit, über Nullable-Annotationen
  (`string?`) zu sprechen, Level 14 vertieft das.
- Ausblick: generische Erweiterungsblöcke in Level 8.

Modellantwort: `solution/`; Vorlagen in
`samples/Vererbung und Polymorphie/Erweiterungsmitglieder/*` und `DoubleExtensions`.
