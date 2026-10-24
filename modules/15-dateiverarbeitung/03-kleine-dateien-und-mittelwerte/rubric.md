# Rubrik — Kleine Dateien und Spaltenmittelwerte (nur für die Betreuung)

- Kern: `File.ReadAll…`/`WriteAll…` für kleine Dateien (ein Aufruf statt
  Öffnen, Lesen, Schließen), dazu das Zerlegen von Zeilen mit `Split`
  und fehlerhafte Felder melden, nicht abstürzen. Der Trainee soll `TryParse`
  statt `Parse` mit `try/catch` bevorzugen und begründen können (kein
  Ausnahmefall, sondern ein erwarteter Datenfehler).
- Die Falle des Levels ist die Kultur: `double.Parse("1.5")` ergibt unter
  `de-DE` 15 (Punkt = Tausendertrennzeichen), unter `en-US` 1,5. Der Test
  `Berechne_ist_unabhaengig_von_der_Spracheinstellung` stellt die Kultur um und
  entlarvt Lösungen ohne `InvariantCulture`. Wer nur `InvariantCulture` ohne
  `NumberStyles.Float` angibt, wird bei `4,5` erwischt: Die Standardstile von
  `TryParse` erlauben Tausendertrennzeichen, `4,5` ergäbe 45 statt einer Warnung
  (`Berechne_meldet_ein_Komma_als_Warnung`). Beides gemeinsam besprechen.
  Läuft der Test in einer Umgebung ohne Kulturdaten (invariante Globalisierung),
  ist die Kultur-Falle nicht nachstellbar; der Test besteht dann trotzdem.
- Die Rückgabe `(double[] mittel, List<string> warnungen)` ist ein benanntes
  Tupel (Level 6). Eine Spalte ohne gültigen Wert liefert `NaN`, nicht 0
  und nicht `DivideByZeroException` (bei `double` gibt es die ohnehin nicht).
- Die Zeilennummer muss die Zeile **in der Datei** sein (leere Zeilen
  mitzählen), nicht die Nummer der gültigen Zeile.
- `ReadAllLines` lädt die ganze Datei; Nachfrage: Wann wäre ein
  `StreamReader` besser? (Sehr große Dateien, die nicht in den Speicher passen.)

Modellantwort: `solution/` bzw. `samples/Ein- und Ausgabe über Datenströme/Mittelwerte` und `…/Schreiben und Lesen von kleinen Dateien/`.
