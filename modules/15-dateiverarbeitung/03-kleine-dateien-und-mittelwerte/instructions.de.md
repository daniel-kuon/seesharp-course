# Kleine Dateien und Spaltenmittelwerte

Lies im Buch **16.4 Schreiben und Lesen von kleinen Dateien mit Bytes
oder Texten** (Seite 1041) und die Übungsaufgabe **16.7/1** (Seite 1060).

Öffne `Mittelwerte.cs`. Für Dateien, die ganz in den Speicher passen, braucht
man keinen Datenstrom: `File.ReadAllLines`, `ReadAllBytes` und
`WriteAllLines` öffnen, lesen oder schreiben und schließen in einem Aufruf.
`File.AppendAllText(pfad, text)` arbeitet genauso, hängt aber einen String an
(nicht im Buch, hier vorgegeben; das Buch zeigt `AppendAllLines`).

1. `Berechne(pfad)`: Die Datei enthält Zahlen, durch `;` getrennt, eine
   Tabellenzeile pro Textzeile. Liefere `(double[] mittel, List<string>
   warnungen)`: den Mittelwert jeder Spalte. Ein Feld, das keine Zahl ist,
   ergibt eine Warnung der Form `Zeile 6, Spalte 2: 'sieben' ist keine
   Zahl` (Nummern ab 1, Zeilennummer = Zeile in der Datei) und wird bei der
   Mittelwertbildung ausgelassen. Das Beispiel aus dem Buch steht in den
   Tests. Einzelheiten stehen als Kommentar im Code; wichtig:
   - Zahlen haben in der Datei **immer** den Punkt als Dezimaltrennzeichen,
     egal welche Sprache der Rechner hat. Ein Test stellt die Kultur auf
     `de-DE` um. Nicht im Buch, hier vorgegeben: Parse jedes Feld mit
     `double.TryParse(feld, NumberStyles.Float, CultureInfo.InvariantCulture, out double wert)`
     (dazu `using System.Globalization;`). Warum, steht im Deep Dive der
     Zusammenfassung.
   - Ein Komma wie in `4,5` ist keine Zahl und ergibt eine Warnung.
2. `Kopiere(quelle, ziel)`: Großbuchstaben (`ToUpper()` oder `ToUpperInvariant()`) mit
   `ReadAllLines` und `WriteAllLines`.
3. `Bytes(pfad)`: Dateigröße per `File.ReadAllBytes`. `Anhaengen(pfad, text)`:
   `File.AppendAllText`.

Diese Tests müssen bestehen:

- `MittelwerteTests.Berechne_das_Beispiel_aus_dem_Buch`
- `MittelwerteTests.Berechne_ohne_Fehler_hat_keine_Warnungen`
- `MittelwerteTests.Berechne_verwendet_Punkt_als_Dezimaltrennzeichen`
- `MittelwerteTests.Berechne_ist_unabhaengig_von_der_Spracheinstellung`
- `MittelwerteTests.Berechne_meldet_ein_Komma_als_Warnung`
- `MittelwerteTests.Berechne_ignoriert_Leerraum_um_die_Felder_und_leere_Zeilen`
- `MittelwerteTests.Berechne_meldet_mehrere_Warnungen_mit_Zeile_und_Spalte`
- `MittelwerteTests.Berechne_mit_ungleich_langen_Zeilen_und_Spalte_ohne_Werte`
- `MittelwerteTests.Kopiere_schreibt_Grossbuchstaben`
- `MittelwerteTests.Bytes_liefert_die_Dateigroesse`
- `MittelwerteTests.Anhaengen_haengt_Text_an`
