# Zusatz: Gästebuch-Seite

Wiederhole **22.5 PageModel-Klassen** (Seite 1563), vor allem **22.5.2
Beispiel** (Seite 1564) und die POST-Behandlung in **22.5.3.4** (Seite 1567).

Öffne `Gaestebuch/Pages/GaestebuchModel.cs` und vervollständige das
PageModel eines Gästebuchs. Der Dienst `IGaestebuch` (mit einer
Speicher-Implementierung) und die Klasse `Eintrag` mit ihren
Validierungsregeln sind fertig:

1. Der Dienst kommt per Konstruktorinjektion.
2. `Neu` wird per `[BindProperty]` aus dem Formular gefüllt.
3. `OnGet()` füllt `Eintraege`, der neueste Eintrag zuerst (`Alle()` liefert
   die ältesten zuerst).
4. `OnPost()`: Bei ungültiger Eingabe `Eintraege` füllen und `Page()`
   zurückgeben, nichts speichern. Sonst `Neu` speichern und auf dieselbe Seite
   umleiten (`RedirectToPage()` ohne Seitenname).

Die Tests sind normale Unit-Tests mit einem Fake-Dienst; einen Webserver
gibt es nicht.

Tests:

- `Neu_ist_ein_BindProperty`
- `OnGet_zeigt_die_neuesten_Eintraege_zuerst`
- `OnPost_gueltig_speichert_den_gebundenen_Eintrag`
- `OnPost_gueltig_leitet_auf_dieselbe_Seite_um`
- `OnPost_ungueltig_gibt_die_Seite_zurueck_und_speichert_nichts`
- `OnPost_ungueltig_zeigt_trotzdem_die_Eintraege`
