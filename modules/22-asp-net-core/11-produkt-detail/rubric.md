# Rubrik — Produktdetailseite (nur für die Betreuung)

- Kernidee: Ordner und Dateiname bestimmen die Route (`Pages/Produkte/Index.cshtml`
  = `/Produkte`, `Pages/Produkte/Detail.cshtml` = `/Produkte/Detail`);
  `@page "{id:int}"` hängt den Parameter an und beschränkt ihn auf Zahlen.
- Zwei Wege zum 404 unterscheiden: `/Produkte/Detail/abc` und
  `/Produkte/Detail` scheitern am Routing (`OnGet` läuft nicht),
  `/Produkte/Detail/99` und `/-1` kommen bis `OnGet` und erhalten dort
  `NotFound()`.
- `asp-page="/Produkte/Detail"` mit führendem Schrägstrich ist ein absoluter
  Seitenpfad; ohne ihn sucht der Tag-Helfer relativ zur aktuellen Seite.
- Typische Fehler: `@page` ohne `{id:int}` (Detailseite unter `/Produkte/Detail/2`
  nicht erreichbar); `@Model.Produkt.Name` ohne `?` gibt eine Warnung;
  `Page()` auch bei fehlendem Produkt (leere Seite mit Status 200).

Modellantwort: `solution/`.
