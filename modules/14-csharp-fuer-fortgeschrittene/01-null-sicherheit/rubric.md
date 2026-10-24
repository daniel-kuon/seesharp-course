# Rubrik — Nullable-Kontext und Nullzustandsanalyse (nur für die Betreuung)

- Kern: Warnungen werden durch Code-Änderung behoben, nicht unterdrückt. Die
  Tests prüfen die Annotationen über Reflexion (`NullabilityInfoContext`,
  `NotNullIfNotNull`, `NotNullWhen`), denn eine Warnung selbst kann ein Test
  nicht feststellen; `WarningsAsErrors` sorgt dafür, dass sie im Starter den
  Build bricht.
- `!` darf höchstens einmal vorkommen (`ErstesVorhandenes`), und der Kommentar
  davor muss den Beweis liefern (`Any` hat ein Element != null gefunden).
  Mehrere `!` oder ein `!` im Konstruktor von `Kunde` ablehnen. Wer eine
  Schleife schreibt, braucht gar kein `!` und hat ebenfalls richtig gelöst.
- Nachfragen: Warum ist `string?` zur Laufzeit dasselbe wie `string`? Was
  passiert ohne `[NotNullIfNotNull]` bei `string r = Reverse("abc");`? (Warnung
  CS8600, der Aufrufer müsste prüfen oder `!` schreiben.) Wieso gibt
  `TryFinde` den `out`-Wert als `string?` an und nicht als `string`?
- Das csproj-Element `WarningsAsErrors` gehört zur Aufgabe und bleibt
  unverändert; wer es entfernt, hat das Problem versteckt statt gelöst.

Modellantwort: `solution/` bzw. `samples/C# für Fortgeschrittene/Nullable-Kontext für Referenztypen`.
