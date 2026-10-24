# Rubrik — Umfrage-Oberfläche (nur für die Betreuung)

Review-Aufgabe ohne Tests; die Modellantwort liegt in `solution/`
(vollständiges Layout, partielle Ansicht, Stylesheet, Skripte aus einem CDN
statt `wwwroot/lib`).

Checkliste:

- Formular nutzt Tag-Helfer (`asp-for`, `asp-items`, `asp-validation-for`,
  `asp-validation-summary`), nicht von Hand geschriebene `name`/`id`/`value`.
  Im HTML-Quelltext (Browser, Ansicht des Quelltexts) zeigen lassen, was der
  Tag-Helfer erzeugt: `data-val-*`-Attribute, Antiforgery-Token.
- Skripte für die Klienten-Validierung eingebunden (jQuery, jquery.validate,
  unobtrusive), vorzugsweise in einer Section `Scripts` des Layouts. Ohne sie
  kommt jede Meldung erst vom Server; mit ihnen verhindert der Browser das
  Absenden (22.9.3). Nachfrage: Warum genügt die Klientenprüfung nie? (22.5.3.4,
  Seite 1567.)
- Beschriftungen und Texte an einer Stelle (22.11.1): Anzeigenamen per
  `[Display]` am Modell oder gemeinsam im Markup, nicht in jeder Seite
  verstreut. Im Beispiel reichen die Standardlabels.
- Formularwerte gehen nach einem Fehler nicht verloren (22.11.2): Das liegt
  an `asp-for`, der den gebundenen Wert wieder in `value`/`selected`
  schreibt, und daran, dass `OnPost` `Page()` zurückgibt statt umzuleiten.
- Keine Geschäftslogik in `.cshtml`: Schleifen und `@if` zur Darstellung sind
  in Ordnung, Auswertung, Sortierung und Dienstaufrufe gehören ins PageModel
  (`ParteiAuswahl`, `Ergebnisse`).
- Layout: Navigation mit `asp-page`, `@RenderBody()`, `ViewData["Title"]`;
  `_ViewStart.cshtml` setzt `Layout`. `UseStaticFiles()` steht in
  `Program.cs`; ohne die Middleware bleibt das Stylesheet 404.
- Screenshots: leeres Formular, Formular mit Fehlern, Ergebnisseite. Der
  Fehlerfall zeigt die Serverprüfung nur, wenn die Klientenprüfung
  ausgeschaltet oder umgangen wurde (Skripte entfernen).
- Hinweis zur Modellantwort: Die CDN-Skripte brauchen Internet; im Kurs
  kann alternativ LibMan oder `wwwroot/lib` genutzt werden (22.10.7).
