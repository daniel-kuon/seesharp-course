# Zusatz: Zahlen einlesen

Lies noch einmal **13.3.1.2 Ausnahmebehandlung per catch-Block** (Seite 891).

Öffne `Einleser.cs`. Die Klasse `LeseErgebnis` mit den Listen `Werte` und
`Fehler` ist vorgegeben.

1. `LiesZahlen(text)` zerlegt einen Text wie `"10;abc;99999999999;20"` an
   Semikolons (leere Teile werden übersprungen) und wandelt jeden Teil mit
   `int.Parse` um. Gültige Zahlen kommen in `Werte`. Für jeden Teil, der
   scheitert, steht ein Eintrag in `Fehler`:
   - `FormatException`: `"abc: keine Zahl"`
   - `OverflowException`: `"99999999999: zu groß"`

   Ein fehlerhafter Teil stoppt die anderen nicht: Das `try` gehört in die
   Schleife.
2. `Mittelwert(ergebnis)` liefert den Mittelwert der gültigen Zahlen oder
   `double.NaN`, wenn es keine gibt.

Tests: `LiesZahlen_meldet_Teile_die_keine_Zahl_sind`,
`LiesZahlen_meldet_zu_grosse_Zahlen`, `LiesZahlen_mit_gemischter_Eingabe` und
`Mittelwert_ohne_gueltige_Zahl_ist_NaN`.
