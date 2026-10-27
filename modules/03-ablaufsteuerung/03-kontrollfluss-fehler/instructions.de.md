# Fehlersuche in Verzweigungen

Lies im Buch Abschnitt **4.7.2 Bedingte Anweisung und Fallunterscheidung**
(Seite 253), vor allem 4.7.2.1 und 4.7.2.2 zur `if`- und `if-else`-Anweisung
und zum dangling else (Seite 254 bis 258). Die Aufgaben 1, 2 und 4 in **4.7.4** (Seite 281) sind die
Vorlage.

Öffne `Fehlersuche.cs`. Beide Methoden kompilieren, liefern aber falsche
Ergebnisse. Finde die Ursache, bevor du änderst:

1. `Gewinn(int losNr)`: Eine Lotterie zahlt 100 Euro für Losnummern, die durch
   13 teilbar sind, und 1 Euro für Losnummern, die nicht durch 13, aber durch
   7 teilbar sind; sonst nichts. Die vorhandene Fassung ordnet das `else`
   falsch zu. Schreibe sie als `else if`-Kette um.
2. `Beschreibe(bool b)`: soll `"b ist False"` oder `"b ist True"` liefern,
   behauptet aber für `false` das Gegenteil. Sieh dir die Bedingung genau an.

Beantworte danach die beiden Fragen.

Diese Tests müssen bestehen:

- `FehlersucheTests.Durch_13_teilbar_gewinnt_100`
- `FehlersucheTests.Nur_durch_7_teilbar_gewinnt_1`
- `FehlersucheTests.Durch_7_und_13_teilbar_gewinnt_100`
- `FehlersucheTests.Sonst_gewinnt_nichts`
- `FehlersucheTests.Beschreibe_false`
- `FehlersucheTests.Beschreibe_true`
