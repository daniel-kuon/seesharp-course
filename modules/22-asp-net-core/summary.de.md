# ASP.NET Core Razor Pages

Eine Razor-Webanwendung ist ein Programm, das HTTP-Anforderungen entgegennimmt
und HTML-Seiten zurückschickt. Das Buch entwickelt in Kapitel 22 (Seite 1537)
eine Online-Umfrage zur Parteienpräferenz: Formular, Entitätsklasse,
Probelauf (22.1, Seite 1538). Im Kurs läuft sie ohne Datenbank; ein Dienst im
Arbeitsspeicher übernimmt die Speicherung.

## Programmstart und Dienste (22.2 und 22.3, Seite 1552 bis 1555)

`Program.cs` besteht aus Anweisungen auf oberster Ebene. Der
`WebApplicationBuilder` sammelt in `builder.Services` die **Dienste** der
Anwendung (`AddRazorPages()`); `Build()` liefert die `WebApplication`. Danach
folgt die **Request-Pipeline**: eine Kette von Middleware-Komponenten, die jede
Anforderung in der Reihenfolge ihrer Vereinbarung durchläuft
(`UseHttpsRedirection`, `UseStaticFiles`, `UseRouting`, `UseAuthorization`,
`MapRazorPages`). Die Reihenfolge ist Teil des Programms. Der
**Service-Container** erzeugt und entsorgt die Dienstobjekte; eine Klasse
fordert ihre Abhängigkeiten im Konstruktor an (Konstruktorinjektion) und
kennt dabei nur eine Schnittstelle. Registriert man den Typ mit `AddSingleton`,
`AddScoped` oder `AddTransient`, legt man seine Lebensdauer fest.

## Seiten und PageModel (22.4 und 22.5, Seite 1556 bis 1572)

Eine Seite besteht aus einer Markup-Datei (`.cshtml`, Razor-Syntax: `@model`,
`@foreach`, `@if`, `@Model.Eigenschaft`) und einer `PageModel`-Klasse. Die
Behandlungsmethoden heißen `OnGet` und `OnPost` und liefern ein
`IActionResult`: `Page()` zeigt die Seite, `RedirectToPage(...)` leitet um,
`NotFound()` antwortet mit 404. Nach einem erfolgreichen POST leitet man um
(Post-Redirect-Get), damit ein Neuladen das Formular nicht erneut abschickt.
HTTP ist zustandslos: Seite und PageModel leben nur eine Anforderung lang,
Zustand über Anforderungen hinweg braucht Datenbank, Cookie oder einen Dienst
(22.5.4, Seite 1571). Weil ein PageModel eine normale Klasse ist, lässt sich
seine Logik ohne Webserver testen.

## Formulare, Routing, Bindung (22.6 bis 22.8, Seite 1572 bis 1607)

**Tag-Helfer** (`asp-for`, `asp-page`, `asp-validation-for`) erzeugen aus
Markup das passende HTML samt Antiforgery-Token. Das **Routing** bildet
Seitenpfade auf Seiten ab; ein Routenparameter mit Einschränkung
(`@page "{id:int}"`) lässt nur passende URLs durch, alle anderen enden mit 404.
Die **Modellbindung** schreibt Formularwerte in PageModel-Eigenschaften, die
mit `[BindProperty]` markiert sind; fehlende oder nicht umwandelbare Werte
landen als Fehler im `ModelState`. Weil sie jede bindbare Eigenschaft
beschreibt, die in der Anforderung vorkommt, ist **Overposting** möglich
(22.8.7, Seite 1606): Gegenmittel sind eine Positivliste (`[Bind]`) oder
besser eine eigene Eingabemodellklasse.

## Validierung (22.9, Seite 1608 bis 1619)

Regeln stehen als Attribute am Modell (`[Required]`, `[Range]`,
`[StringLength]`, `[EmailAddress]`); Regeln über mehrere Eigenschaften
implementieren `IValidatableObject`. Der Server prüft immer, die
Klienten-seitige Validierung ist nur Komfort. `OnPost` fragt
`ModelState.IsValid` ab. Ein null-unzulässiger Referenztyp gilt implizit als
`[Required]` (22.9.6); `[BindRequired]` fordert dagegen, dass der Wert in der
Anforderung überhaupt vorkommt (22.9.2).

## Layout (22.10 und 22.11, Seite 1620 bis 1640)

`_Layout.cshtml` enthält das gemeinsame Gerüst mit `@RenderBody()`,
`_ViewStart.cshtml` wählt es aus, `_ViewImports.cshtml` registriert Tag-Helfer
und `@using`-Anweisungen, partielle Ansichten (`<partial>`) kapseln
Wiederkehrendes, und Dateien aus `wwwroot` liefert `UseStaticFiles` aus.

## Testen

Im Kurs prüfen Tests zweierlei: Die PageModel-Logik wird als normale Klasse
ohne Host getestet (Fake-Dienst, `PageContext`, Ergebnistyp prüfen). Ganze
Seiten testet `WebApplicationFactory<Program>` mit HTTP-Anforderungen im
Speicher. Die Gestaltung der Oberfläche prüft die Betreuung.
