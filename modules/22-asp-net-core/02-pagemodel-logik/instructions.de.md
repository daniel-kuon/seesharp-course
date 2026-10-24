# PageModel-Logik per Unit-Test

Lies im Buch **22.5 PageModel-Klassen** (Seite 1563), vor allem **22.5.3
Behandlung von HTTP-Anforderungen** (Seite 1566) mit der POST-Behandlung in
22.5.3.4 (Seite 1567 bis 1570), und den Dienst-Container in **22.3**
(Seite 1554).

Das Projekt `Umfrage` ist eine Razor-Webanwendung (`Microsoft.NET.Sdk.Web`)
mit einer In-Memory-Umfrage: `IUmfrageDienst` liefert die Stimmen und nimmt
neue entgegen, `SpeicherDienst` speichert sie im Arbeitsspeicher. Öffne
`Pages/UmfrageModel.cs` und vervollständige die Klasse `UmfrageModel`:

1. Der Dienst kommt per **Konstruktorinjektion**; speichere ihn in einem Feld.
2. `Eingabe` wird per **Modellbindung** aus dem Formular gefüllt
   (`[BindProperty]`).
3. `OnGet()` füllt `Ergebnisse`: je Partei die Anzahl der Stimmen, die
   meisten zuerst, bei Gleichstand alphabetisch nach Partei.
4. `OnPost()` prüft `ModelState.IsValid`. Ungültig: `Ergebnisse` füllen und
   `Page()` zurückgeben, nichts speichern. Gültig: genau einmal speichern und
   mit `RedirectToPage("Danke", new { partei = ... })` weiterleiten.

Die Tests brauchen keinen Webserver: Sie erzeugen das Modell mit einem
Fake-Dienst und einem leeren `PageContext`, rufen `OnGet`/`OnPost` wie
normale Methoden auf und prüfen den Ergebnistyp (`PageResult` oder
`RedirectToPageResult`). Eine ungültige Eingabe simulieren sie mit
`ModelState.AddModelError`. Die Seiten (`.cshtml`) schreibst du erst in
Aufgabe 4.

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
