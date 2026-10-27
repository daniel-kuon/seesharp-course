# Zusatz: Wortanalyse

Lies im Buch **18.2.9 GroupBy()** (Seite 1222) und **18.2.8.2 SelectMany()**
(Seite 1220).

Schreibe in `Wortanalyse.cs` (die Trennzeichen `Trenner` sind vorgegeben);
Wörter werden mit `ToLowerInvariant()` klein geschrieben (nicht im Buch, hier
vorgegeben: wie `ToLower()`, aber unabhängig von der Spracheinstellung):

1. `Woerter(text)`: alle Wörter des Textes in Reihenfolge, auch
   Wiederholungen. Der Text hat mehrere Zeilen: Zerlege ihn zuerst an
   `'\n'` und flache dann mit `SelectMany` ab.
2. `Haeufigste(text, n)`: die `n` häufigsten Wörter als `(Wort, Anzahl)`,
   häufigste zuerst, bei gleicher Anzahl alphabetisch (`StringComparer.Ordinal`)
   (`GroupBy`, `OrderByDescending`, `ThenBy`).
3. `ProAnfangsbuchstabe(text)`: `Dictionary<char, List<string>>`: je
   Anfangsbuchstabe die **verschiedenen** Wörter, alphabetisch sortiert
   (`GroupBy`).
4. `LaengsteWoerter(text)`: alle verschiedenen Wörter mit der größten Länge,
   alphabetisch sortiert; leerer Text: leere Liste.

> **Deep Dive (optional):** `CountBy` (ab .NET 9) steht nicht im Buch: Es
> liefert zu jedem Schlüssel die Anzahl (`Key`, `Value`) und ersetzt in
> `Haeufigste` das `GroupBy`. Probiere beide Varianten aus.

Tests: `Woerter_flacht_alle_Zeilen_ab`,
`Haeufigste_ordnet_nach_Anzahl_und_Alphabet`,
`ProAnfangsbuchstabe_gruppiert_verschiedene_Woerter`,
`LaengsteWoerter_liefert_alle_mit_der_groessten_Laenge`.
