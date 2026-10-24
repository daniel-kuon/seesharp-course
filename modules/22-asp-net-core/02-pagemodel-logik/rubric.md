# Rubrik — PageModel-Logik (nur für die Betreuung)

- Kernidee: Ein PageModel ist eine normale Klasse. `OnGet`/`OnPost` sind
  gewöhnliche Methoden, deren Rückgabe (`PageResult`, `RedirectToPageResult`)
  man prüfen kann; HTTP, Routing und Razor sind dafür nicht nötig. Der
  Dienst kommt über den Konstruktor, deshalb lässt er sich durch ein Fake
  ersetzen.
- Warum braucht der Test einen `PageContext`? `ModelState` liegt im Kontext;
  ohne ihn gibt es eine NullReferenceException. Die Validierung selbst läuft
  im Test nicht (keine Modellbindung), daher `AddModelError`.
- Nachfrage: Warum füllt `OnPost` bei ungültiger Eingabe `Ergebnisse` noch
  einmal? (Die Seite wird neu gerendert, das PageModel-Objekt ist
  anforderungsbezogen; vgl. 22.5.4 Zustandslosigkeit.)
- Typische Fehler: `RedirectToPage("./Danke")` ohne Routenwert; `Page()`
  auch im Erfolgsfall; Dienst im Feld nicht gespeichert; `GroupBy` ohne
  `ThenBy` (instabile Reihenfolge bei Gleichstand).
- Das Redirect-Ziel `Danke` existiert erst in Aufgabe 4; hier wird nur der
  Seitenname geprüft.

Modellantwort: `solution/`; Vorlagen in `samples/ASP.NET Core/Razor/PartPref/Fertig` (Datenbank durch den Speicherdienst ersetzt).
