# Zusatz: Kontaktformular mit Validierung

Wiederhole **22.9 Validierung** (Seite 1608), vor allem **22.9.1** (Seite
1609), und die POST-Behandlung in **22.5.3.4** (Seite 1567).

Öffne `Kontakt/Pages/KontaktModel.cs`. Die Klasse `Anfrage` ist die Eingabe
eines Kontaktformulars, `KontaktModel` die zugehörige Seite:

1. `Anfrage`: Deklariere die Regeln mit Attributen. Name, E-Mail und Nachricht
   sind Pflicht; die E-Mail muss eine Adresse sein; die Nachricht braucht
   mindestens 10 Zeichen. Die Meldungen stehen in den TODO-Kommentaren.
2. `KontaktModel.Eingabe` wird per Modellbindung aus dem Formular gefüllt.
3. `OnPost()`: Ungültig gibt `Page()` zurück, gültig leitet auf die Seite
   `Danke` um.

Die Tests ersetzen die Modellbindung: Sie prüfen `Eingabe` mit dem
`Validator`, tragen die Fehler in `ModelState` ein und rufen `OnPost()` auf.

Tests:

- `Eingabe_ist_ein_BindProperty`
- `Gueltige_Eingabe_leitet_zur_Danke_Seite_weiter`
- `Fehlender_Name_gibt_die_Seite_mit_Meldung_zurueck`
- `Fehlende_Email_wird_gemeldet`
- `Ungueltige_Email_wird_gemeldet`
- `Nachricht_braucht_mindestens_10_Zeichen`
- `Mehrere_Fehler_werden_gemeinsam_gemeldet`
