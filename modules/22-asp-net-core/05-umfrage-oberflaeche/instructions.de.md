# Die Umfrage-Oberfläche mit Layout und Tag-Helfern

Lies im Buch **22.6 Tag-Helfer** (Seite 1572, mit 22.6.2 Formular-Tag-Helfern
und 22.6.2.4 Validierung), **22.9.3 Klienten-seitige Validierung** und
**22.9.7 asp-validation-summary** (Seite 1613 und 1619), **22.10
Layout-Technik** (Seite 1620) mit den partiellen Ansichten in 22.10.5 und
dem Ordner `wwwroot` in 22.10.7, sowie **22.11 Verbesserungen im
Umfragenbeispiel** (Seite 1632).

Das Projekt `Umfrage` ist die funktionierende Umfrage aus Aufgabe 4. Es hat
noch keine Gestaltung. Starte es lokal
(`dotnet run`, Rider: grüner Pfeil) und baue die Oberfläche aus:

1. **Formular** in `Pages/Umfrage.cshtml`: `<select>` für die Partei, Label,
   Fehlermeldung am Feld und Zusammenfassung der Fehler, alles mit
   Tag-Helfern (`asp-for`, `asp-items`, `asp-validation-for`,
   `asp-validation-summary`) und mit den Skripten für die Klienten-Validierung.
2. **Layout:** `Pages/Shared/_Layout.cshtml` mit Navigation und `@RenderBody()`,
   `Pages/_ViewStart.cshtml`; die Ergebnistabelle als partielle Ansicht
   `_Ergebnisse.cshtml`.
3. **Stylesheet** in `wwwroot/css/site.css`. Damit der Server die Datei
   ausliefert, brauchst du in `Program.cs` die Middleware `UseStaticFiles()` vor
   `UseRouting()`.

Es gibt keine automatischen Tests. Lege drei Screenshots (leeres Formular,
Formular mit Fehlermeldungen, Ergebnisseite) in den Ordner
`Umfrage/screenshots` und besprich sie mit der Betreuung. Beantworte am
Ende die offene Frage zu Texten und Geschäftslogik.
