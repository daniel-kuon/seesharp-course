# Zusatz: Produktdetailseite mit Routenparameter

Wiederhole **22.7 Routing** (Seite 1577), vor allem **22.7.2
Routenparameter** (Seite 1578) mit den Restriktionen in 22.7.2.4 (Seite 1581),
und die Razor-Syntax in **22.4.3** (Seite 1561).

Das Projekt `Shop` zeigt Produkte aus einem festen Katalog
(`IProduktkatalog`). `Program.cs` und die Liste der Produkte im PageModel
sind fertig. Du schreibst:

1. `Pages/Produkte/Index.cshtml`: Liste aller Produkte; jeder Name ist ein
   Link auf `/Produkte/Detail/<Id>` (Tag-Helfer `asp-page` mit
   `asp-route-id`).
2. `Pages/Produkte/Detail.cshtml`: Route mit `int`-Parameter `id`, Name und
   Beschreibung anzeigen.
3. `Pages/Produkte/Detail.cshtml.cs`: `OnGet(int id)` sucht das Produkt;
   gibt es keins, ist die Antwort `NotFound()`.

Die Tests starten die Anwendung mit `WebApplicationFactory<Program>` (NuGet-Paket
`Microsoft.AspNetCore.Mvc.Testing`) und prüfen HTML und Statuscodes. Ein Test
ersetzt den Katalog durch ein Fake, um zu beweisen, dass die Seiten den
registrierten Dienst benutzen. Beim ersten Lauf braucht das Paket Netzzugang.

Tests:

- `Liste_zeigt_alle_Produktnamen`
- `Liste_verlinkt_jedes_Produkt_auf_seine_Detailseite`
- `Detailseite_zeigt_Name_und_Beschreibung`
- `Unbekanntes_Produkt_gibt_404` (Ids 99, -1, `abc` und fehlende Id)
- `Die_Seiten_benutzen_den_registrierten_Katalog`
