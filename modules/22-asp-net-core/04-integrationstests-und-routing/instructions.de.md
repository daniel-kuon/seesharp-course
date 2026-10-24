# Seiten, Routing und Integrationstests

Lies im Buch **22.2 Konfiguration der Request Pipeline und Anwendungsstart
per Program.cs** (Seite 1552), **22.3 Service-Container** (Seite 1554),
**22.4 Markup-Dateien** mit der Razor-Syntax in 22.4.3 (Seite 1561)
und **22.7 Routing** mit den Routenparametern in 22.7.2 (Seite 1578).

Das Projekt `Umfrage` ist jetzt eine vollständige Webanwendung bis auf vier
Stellen, die du schreibst. Die Seiten `Umfrage` (Formular) sowie alle
`PageModel`-Klassen sind fertig; das Formular mit seinen Tag-Helfern
behandelt Aufgabe 5.

1. `Program.cs`: Razor Pages registrieren, `IUmfrageDienst` als Singleton
   mit `SpeicherDienst` registrieren und `MapRazorPages()` aufrufen. Ohne
   `AddRazorPages()` meldet die Anwendung schon beim Start, dass ein
   Autorisierungsdienst fehlt: Das ist die Folge der fehlenden Registrierung,
   nicht ein eigener Fehler.
2. `Pages/Index.cshtml`: Parteiliste mit `@foreach`, jeder Name ist ein Link auf
   die Detailseite.
3. `Pages/Detail.cshtml`: Route mit einem `int`-Parameter `id`
   (`@page "{id:int}"`), Name und Stimmenzahl der Partei anzeigen.
4. `Pages/Danke.cshtml`: Dankestext mit dem Namen der Partei.

Die Tests starten die echte Anwendung im Speicher mit
`WebApplicationFactory<Program>` (NuGet-Paket `Microsoft.AspNetCore.Mvc.Testing`),
schicken HTTP-Anforderungen und prüfen Statuscodes und HTML. Beim POST holt der
Test zuerst das Formular, liest das Antiforgery-Token aus dem HTML und schickt
es mit; das Cookie dazu verwaltet der Test-Klient. Ein Test ersetzt den Dienst
durch ein Fake und beweist damit, dass die Seiten wirklich den registrierten
Dienst benutzen. Das Projekt braucht `public partial class Program { }`, damit
das Testprojekt die Startklasse sieht; die Zeile steht schon da.

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

Der Test braucht beim ersten Lauf das NuGet-Paket und damit Netzzugang.
