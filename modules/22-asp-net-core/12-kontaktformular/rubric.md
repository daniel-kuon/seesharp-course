# Rubrik — Kontaktformular (nur für die Betreuung)

- Kernidee: Die Modellbindung füllt `Eingabe` und führt die Validierung aus;
  `OnPost` liest nur noch `ModelState.IsValid`. Der Test spielt die
  Modellbindung nach (Validator, dann `AddModelError` mit Schlüssel
  `Eingabe.<Feld>`), damit die Attribute wirklich geprüft werden.
- Nachfrage: Warum meldet ein leeres Feld nur "fehlt" und nicht zusätzlich
  "ungültig"? (Der Validator prüft `Required` zuerst und bricht für dieses
  Feld ab.)
- Typische Fehler: `StringLength` ohne `MinimumLength` (Maximum allein
  prüft nicht die Mindestlänge); `Email` nur mit `EmailAddress`, aber ohne
  `Required` (leer wäre dann gültig); Redirect auf `./Danke` statt
  `Danke` (beides geht, der Test erwartet den Seitennamen `Danke`).

Modellantwort: `solution/`.
