# PageModel Logic via Unit Testing

Read Chapter **22.5**, **“PageModel Classes”** (page 1563), especially **Section 22.5.3, “Handling HTTP Requests”** (page 1566), which covers POST handling in Subsection 22.5.3.4 (pages 1567–1570), and the service container in **22.3** (page 1554).

The `Umfrage` project is a Razor web application (`Microsoft.NET.Sdk.Web`) with an in-memory poll: `IUmfrageDienst` returns the votes and accepts new ones, while `SpeicherDienst` stores them in memory. Open `Pages/UmfrageModel.cs` and complete the `UmfrageModel` class:

1. The service is provided via **constructor injection**; store it in an array.
2. `Eingabe` is filled from the form via **model binding** (`[BindProperty]`).
3. `OnGet()` populates `Ergebnisse` with the number of votes for each party, listing the highest totals first; in the event of a tie, the parties are listed alphabetically.
4. `OnPost()` checks `ModelState.IsValid`. Invalid: Populate the `Ergebnisse` and return `Page()`; do not save anything. Valid: Save exactly once and redirect using `RedirectToPage("Danke", new { partei = ... })`.

The tests do not require a web server: They create the model using a mock service and an empty `PageContext`, call `OnGet` and `OnPost` as if they were regular methods, and check the result type (`PageResult` or `RedirectToPageResult`). They simulate invalid input using `ModelState.AddModelError`. You will write the pages (`.cshtml`) in Task 4.

Tests:

- `Eingabe_ist_ein_BindProperty`
- `Eingabe_ist_nach_dem_Erzeugen_nicht_null`
- `OnGet_zaehlt_Stimmen_je_Partei_und_sortiert_absteigend`
- `OnGet_sortiert_bei_Gleichstand_nach_Partei`
- `OnGet_ohne_Stimmen_liefert_leere_Ergebnisse`
- `OnPost_gueltig_speichert_genau_eine_Stimme`
- `OnPost_gueltig_leitet_zur_Danke_Seite_weiter`
- `OnPost_ungueltig_gibt_die_Seite_zurueck_und_speichert_nichts`
- `OnPost_ungueltig_fuellt_trotzdem_die_Ergebnisse`
- `Das_Modell_nutzt_den_injizierten_Dienst`
