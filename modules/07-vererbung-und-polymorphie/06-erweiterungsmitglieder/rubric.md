# Rubrik — Erweiterungsmitglieder (nur für die Betreuung)

- Unterschied `extension(double arg)` (Instanz) und `extension(double)`
  (statisch) klar? Der Operator `^` muss in den statischen Block.
- Erweiterungsmethoden sehen nur die öffentliche Schnittstelle; sie sind
  keine Vererbung. Die Quizfrage zur Priorität (echtes Mitglied gewinnt)
  im Gespräch vertiefen: Was passiert, wenn .NET eines Tages
  `double.High` einbaut?
- `null`-Empfänger bei `s.Empty()`: Gelegenheit, über Nullable-Annotationen
  (`string?`) zu sprechen, Level 14 vertieft das.
- Ausblick: generische Erweiterungsblöcke in Level 8.

Modellantwort: `solution/`; Vorlagen in
`samples/Vererbung und Polymorphie/Erweiterungsmitglieder/*` und `DoubleExtensions`.
