# Zusatz: Tagebuch

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**16.3.2 Schreiben und Lesen im Textformat** (Seite 1036) und
**16.4 Schreiben und Lesen von kleinen Dateien** (Seite 1041).

Ein Tagebuch ist eine Textdatei mit einer Zeile pro Eintrag, im Format
`yyyy-MM-dd;text`, zum Beispiel `2025-06-04;Sonne`. Öffne `Tagebuch.cs`
(der Dateipfad kommt über den Konstruktor):

1. `Schreibe(tag, text)`: hängt einen Eintrag an das Dateiende an
   (`StreamWriter` mit `append: true`, `Close` im `finally`). Der Text darf
   keinen Zeilenumbruch enthalten, sonst wäre die Zeile kaputt: Wirf eine
   `ArgumentException`, bevor etwas geschrieben wird.
2. `Eintraege(tag)`: alle Texte eines Tages in der Reihenfolge des Schreibens
   (ohne Datum und Semikolon) mit einem `StreamReader`. Gibt es die Datei
   noch nicht, kommt eine leere Liste. Der Text darf selbst Semikolons
   enthalten.
3. `AnzahlEintraege()`: Zahl der Zeilen mit `File.ReadAllLines`; ohne Datei 0.

Das Datum schreibt die Hilfsmethode `Datum` unabhängig von der Spracheinstellung.

Diese Tests müssen bestehen:

- `TagebuchTests.Schreibe_haengt_Zeilen_im_vereinbarten_Format_an`
- `TagebuchTests.Schreibe_ueberschreibt_nichts`
- `TagebuchTests.Schreibe_lehnt_Zeilenumbrueche_ab_ohne_zu_schreiben`
- `TagebuchTests.Eintraege_liefert_alle_Texte_des_Tages_in_Schreibreihenfolge`
- `TagebuchTests.Datum_ist_unabhaengig_von_der_Spracheinstellung`
- `TagebuchTests.Ohne_Datei_ist_alles_leer`
- `TagebuchTests.AnzahlEintraege_zaehlt_alle_Zeilen`
