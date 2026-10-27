# Small Files and Column Averages

Read Section **16.4, "Reading and Writing Small Files Containing Bytes or Text**" (page 1041), and Exercise **16.7/1** (page 1060).

Open `Mittelwerte.cs`. For files that fit entirely into memory, you don't need a data stream: `File.ReadAllLines`, `ReadAllBytes`, and `WriteAllLines` open, read or write, and close the file in a single call. `File.AppendAllText(pfad, text)` works the same way but appends a string (not in the book, given here; the book shows `AppendAllLines`).

1. `Berechne(pfad)`: The file contains numbers separated by `;`, with one table row per text line. Return `(double[] mittel, List<string> warnungen)`: the mean of each column. A field that is not a number results in a warning of the form `Zeile 6, Spalte 2: 'sieben' ist keine Zahl` (numbers start at 1; row number = row in the file) and is omitted when calculating the mean. The example from the book is included in the tests. Details are provided as comments in the code; important:
   - Numbers in the file **always** use a period as the decimal separator, regardless of the computer's language settings. A test switches the culture to `de-DE`. Not in the book, given here: parse every field with `double.TryParse(feld, NumberStyles.Float, CultureInfo.InvariantCulture, out double wert)` (plus `using System.Globalization;`). The summary's Deep Dive explains why.
   - A comma, such as in `4,5`, is not a number and triggers a warning.
2. `Kopiere(quelle, ziel)`: Capitalize (`ToUpper()` or `ToUpperInvariant()`) using `ReadAllLines` and `WriteAllLines`.
3. `Bytes(pfad)`: File size using `File.ReadAllBytes`. `Anhaengen(pfad, text)`: `File.AppendAllText`.

The following tests must be passed:

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
