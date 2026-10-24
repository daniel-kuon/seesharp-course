# Rubrik — Gästebuch (nur für die Betreuung)

- Kernidee: wie Aufgabe 2, aber ohne Vorlage: Konstruktorinjektion,
  `[BindProperty]`, `ModelState.IsValid`, Post-Redirect-Get. Hier leitet die
  Seite auf sich selbst um, deshalb `RedirectToPage()` ohne Namen; nach dem
  Redirect lädt der Browser die Seite per GET und zeigt den neuen Eintrag.
- Nachfrage: Was passiert bei F5 nach dem Speichern mit und ohne Redirect?
- Typische Fehler: `Eintraege` bei ungültiger Eingabe nicht gefüllt; Reihenfolge nicht umgedreht; `RedirectToPage("Gaestebuch")` funktioniert auch, die Tests
  erwarten aber den namenlosen Aufruf.

Modellantwort: `solution/`.
