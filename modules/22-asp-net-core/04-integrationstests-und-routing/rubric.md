# Rubrik — Seiten, Routing und Integrationstests (nur für die Betreuung)

- Kernidee: `Program.cs` baut Container (`AddRazorPages`, `AddSingleton`) und
  Pipeline (`UseRouting`, `UseAuthorization`, `MapRazorPages`); die Reihenfolge
  der `Use...`-Aufrufe ist die Reihenfolge der Middleware. Die
  `AddSingleton`-Zeile ist in der Aufgabe vorgegeben (nicht im Buch).
- Bonus (Deep Dive): Ein Integrationstest fährt die echte Pipeline im Speicher
  hoch (`WebApplicationFactory<Program>`, nicht im Buch), ohne Port und ohne
  Browser.
- Antiforgery: Das `<form method="post">` mit Tag-Helfern erzeugt ein
  verstecktes Token-Feld und ein Cookie; ein POST ohne beides wird mit 400
  abgelehnt. Der Test liest das Token aus dem HTML. Nachfragen: Wovor schützt
  das? (CSRF, 22.5.4, Seite 1571.)
- Erwartet: Das PageModel ist pro Anforderung neu (22.5.4); deshalb liegen die
  Stimmen im Dienst. Bonus (Deep Dive): Der Singleton-Test scheitert bei
  `AddTransient` und `AddScoped`, weil dann jede Anforderung einen neuen
  Speicherdienst bekommt (Lebensdauern stehen nicht im Buch).
- Bonus (Deep Dive): Das Fake ersetzt die Registrierung erst im Test
  (`ConfigureTestServices`); die Seiten wissen davon nichts. Das ist der
  Vorteil der Schnittstelle `IUmfrageDienst`.
- `@page "{id:int}"`: `/Detail/abc` gibt 404, bevor `OnGet` läuft;
  `/Detail/99` gibt 404 aus `NotFound()`. Beide Wege unterscheiden können.
- Typische Fehler: `@page` ohne Routenvorlage (dann 404 auf `/Detail/2`);
  `@Model.Partei` statt `@Model.Partei.Name` (Ausgabe `Partei`);
  `MapRazorPages` vergessen (alle Seiten 404); `AddRazorPages` vergessen
  (Startfehler "AddAuthorization").
- Technischer Hinweis: Die Testanwendung findet das Inhaltsverzeichnis des
  Webprojekts über die von `Microsoft.AspNetCore.Mvc.Testing` erzeugte
  Manifestdatei; das funktioniert auch im temporären Ordner des Graders ohne
  weitere Einstellung. Die Aufgabe braucht beim ersten Lauf NuGet-Zugang.

Modellantwort: `solution/`; Vorlagen in `samples/ASP.NET Core/Razor/PartPref/Gerüst` und `Fertig`, `ArrayBindSimple`.
