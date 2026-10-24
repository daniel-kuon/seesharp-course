# Extra: Contact Form with Validation

Review **Section 22.9**, **"Validation**" (page 1608), especially **22.9.1** (page 1609), and the POST handling in **Section 22.5.3.4** (page 1567).

Open `Kontakt/Pages/KontaktModel.cs`. The `Anfrage` class represents the input for a contact form, and `KontaktModel` represents the corresponding page:

1. `Anfrage`: Define the rules using attributes. Name, email, and message are required; the email must be a valid address; the message must be at least 10 characters long. The messages are listed in the TODO comments.
2. `KontaktModel.Eingabe` is populated from the form via model binding.
3. `OnPost()`: If invalid, returns `Page()`; if valid, redirects to the `Danke` page.

The tests replace model binding: They validate `Eingabe` with the `Validator`, enter the errors into `ModelState`, and call `OnPost()`.

Tests:

- `Eingabe_ist_ein_BindProperty`
- `Gueltige_Eingabe_leitet_zur_Danke_Seite_weiter`
- `Fehlender_Name_gibt_die_Seite_mit_Meldung_zurueck`
- `Fehlende_Email_wird_gemeldet`
- `Ungueltige_Email_wird_gemeldet`
- `Nachricht_braucht_mindestens_10_Zeichen`
- `Mehrere_Fehler_werden_gemeinsam_gemeldet`
