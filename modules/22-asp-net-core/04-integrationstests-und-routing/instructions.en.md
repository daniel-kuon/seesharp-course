# Pages, Routing, and Integration Tests

Read sections **22.2**, **“Configuring the Request Pipeline and Starting the Application via Program.cs”** (page 1552), and **22.3**, **“Service Container”** (page 1554), **22.4 “Markup Files** with Razor Syntax” in 22.4.3 (page 1561), and **22.7 “Routing** with Route Parameters” in 22.7.2 (page 1578).

The `Umfrage` project is now a complete web application, except for four parts that you will write. The `Umfrage` (form) page and all `PageModel` classes are complete; the form and its tag helpers are covered in Exercise 5.

1. `Program.cs`: Register Razor Pages, register `IUmfrageDienst` as a singleton with `SpeicherDienst`, and call `MapRazorPages()`. Without `AddRazorPages()`, the application reports a missing authorization service as soon as it starts: This is a result of the missing registration, not an error of its own.
2. `Pages/Index.cshtml`: Party list using `@foreach`; each name is a link to the details page.
3. `Pages/Detail.cshtml`: Route with an `int` parameter `id` `@page "{id:int}"`, display the party's name and number of votes.
4. `Pages/Danke.cshtml`: Thank-you message with the party's name.

The tests launch the actual application in memory using `WebApplicationFactory<Program>` (NuGet package `Microsoft.AspNetCore.Mvc.Testing`), send HTTP requests, and check status codes and HTML. For a POST request, the test first retrieves the form, reads the anti-forgery token from the HTML, and sends it along; the test client manages the corresponding cookie. A test replaces the service with a mock, thereby verifying that the pages are indeed using the registered service. The project requires `public partial class Program { }` so that the test project can see the entry point class; this line is already present.

Tests:

- `Startseite_zeigt_alle_Parteien`
- `Detailseite_zeigt_die_gewaehlte_Partei`
- `Detailseite_mit_Text_statt_Zahl_gibt_404`
- `Detailseite_mit_unbekannter_Id_gibt_404`
- `Gueltige_Abstimmung_leitet_zur_Danke_Seite_weiter`
- `Danke_Seite_nennt_die_Partei`
- `Ungueltige_Abstimmung_zeigt_die_Fehlermeldung_wieder_an`
- `Die_Seiten_benutzen_den_registrierten_Dienst`
- `Der_Dienst_ist_ein_Singleton_und_behaelt_Stimmen_zwischen_Anforderungen`

The first time the test runs, it requires the NuGet package and, therefore, internet access.
