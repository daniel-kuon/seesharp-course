# Extra: Product detail page with route parameters

Review **Section 22.7**, **“Routing”** (page 1577), particularly Section **22.7.2, “Route Parameters**” (page 1578), along with the restrictions in Section 22.7.2.4 (page 1581), and the Razor syntax in **22.4.3** (page 1561).

The `Shop` project displays products from a fixed catalog (`IProduktkatalog`). `Program.cs` and the list of products in the PageModel are complete. You write:

1. `Pages/Produkte/Index.cshtml`: List of all products; each name is a link to `/Produkte/Detail/<Id>` (`asp-page` tag helper with `asp-route-id`; the markup is in the starter, not in the book, given here).
2. `Pages/Produkte/Detail.cshtml`: Route with an `int` parameter `id`; display name and description.
3. `Pages/Produkte/Detail.cshtml.cs`: `OnGet(int id)` searches for the product; if none is found, the response is `NotFound()`.

> **Deep Dive (optional):** Not in the book, and you do not write these tests yourself; an example of what to look into next. The tests launch the application using `WebApplicationFactory<Program>` (from the NuGet package `Microsoft.AspNetCore.Mvc.Testing`) and verify the HTML and status codes. One test replaces the catalog with a mock to verify that the pages use the registered service.

The test package requires network access on the first run.

Tests:

- `Liste_zeigt_alle_Produktnamen`
- `Liste_verlinkt_jedes_Produkt_auf_seine_Detailseite`
- `Detailseite_zeigt_Name_und_Beschreibung`
- `Unbekanntes_Produkt_gibt_404` (IDs 99, -1, `abc`, and missing ID)
- `Die_Seiten_benutzen_den_registrierten_Katalog`
