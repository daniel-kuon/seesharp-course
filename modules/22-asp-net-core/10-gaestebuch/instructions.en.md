# Extra: Guestbook Page

Review **the 22.5 PageModel classes** (page 1563), especially **22.5.2 Example** (page 1564) and the POST handling in **22.5.3.4** (page 1567).

Open `Gaestebuch/Pages/GaestebuchModel.cs` and complete the PageModel for a guestbook. The `IGaestebuch` service (with a storage implementation) and the `Eintrag` class with its validation rules are complete:

1. The service is provided via constructor injection.
2. `Neu` is now populated from the form using `[BindProperty]`.
3. `OnGet()` populates `Eintraege` with the most recent entry first (`Alle()` returns the oldest entries first).
4. `OnPost()`: If the input is invalid, populate the `Eintraege` and return `Page()`; do not save anything. Otherwise, save `Neu` and redirect to the same page (`RedirectToPage()` without a page name).

The tests are standard unit tests using a mock service; there is no web server.

Tests:

- `Neu_ist_ein_BindProperty`
- `OnGet_zeigt_die_neuesten_Eintraege_zuerst`
- `OnPost_gueltig_speichert_den_gebundenen_Eintrag`
- `OnPost_gueltig_leitet_auf_dieselbe_Seite_um`
- `OnPost_ungueltig_gibt_die_Seite_zurueck_und_speichert_nichts`
- `OnPost_ungueltig_zeigt_trotzdem_die_Eintraege`
