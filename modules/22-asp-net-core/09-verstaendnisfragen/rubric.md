# Rubrik: Verständnisfragen ASP.NET Core Razor Pages (nur für die Betreuung)

Die Multiple-Choice-Fragen `mc-program-cs` (richtig: Option 2), `mc-redirect` (Option 3) und `mc-overposting` (Option 1) wertet
das Programm selbst aus. Geprüft wurde so: Die Code-Listings `code-onpost`, `code-lebensdauer` und `code-validierung` liefen in
einer `net10.0`-Webprojekt-Konsole; `code-routing` und die Option „ohne `MapRazorPages()`" in der echten Anwendung aus Aufgabe 4
mit `WebApplicationFactory<Program>`; der Fehler bei Dienstregistrierung nach `Build()` ebenfalls. Die Ausgaben unten sind echt.

## pipeline-und-program

Wesentlich:
- Vor `Build()` sammelt `builder.Services` die **Dienste** der Anwendung (`AddRazorPages()`, eigene Dienste); `Build()` erzeugt daraus die `WebApplication`
  (der Container ist danach schreibgeschützt). Danach vereinbart man mit `app.Use…` die **Request-Pipeline**.
- Die Pipeline ist eine Kette von Middleware-Komponenten; jede Anforderung durchläuft sie in der Reihenfolge der Vereinbarung (z. B. `UseStaticFiles`, `UseRouting`, `UseAuthorization`).
  Die Reihenfolge ist Teil des Programms, weil spätere Komponenten nur sehen, was frühere durchlassen (eine Datei, die `UseStaticFiles` ausliefert, erreicht die Seiten nie).
- `MapRazorPages()` ordnet die Razor Pages den Adressen zu; ohne diesen Aufruf antwortet die Anwendung auf jede Seite mit 404.

Typische Fehlvorstellungen: Reihenfolge sei egal; Dienste könne man auch nach `Build()` noch registrieren; Middleware und Dienste seien dasselbe.

## code-onpost

Ausgabe: `PageResult / RedirectToPageResult / 1`.

Wesentlich:
- `a`: `Name` ist nur Leerraum, also wird ein Modellfehler eingetragen, `ModelState.IsValid` ist `false`: `Page()` (`PageResult`), nichts wird gespeichert.
- `b`: gültig: Der Dienst speichert einmal, `RedirectToPage("Danke")` gibt ein `RedirectToPageResult` zurück (Post-Redirect-Get).
- Insgesamt wird genau ein Name gespeichert: 1.
- Zusatz: Weil das PageModel eine normale Klasse ist, braucht der Test keinen Webserver.

Typische Fehlvorstellungen: Beide Aufrufe liefern `RedirectToPageResult` (die Prüfung wird übersehen); `a` speichere trotzdem (die Liste hätte 2 Einträge).

## di-lebensdauer

Wesentlich:
- Konstruktorinjektion: Die Klasse fordert ihre Abhängigkeiten als Konstruktorparameter an; der Service-Container erzeugt sie und reicht sie hinein (die Klasse erzeugt sie nicht selbst mit `new`).
- Als Schnittstelle: Die Klasse kennt nur den Vertrag, nicht die Implementierung; sie lässt sich austauschen (Speicher, Datenbank) und im Test durch einen **Fake** ersetzen, ohne die Seite zu ändern.
- Lebensdauer: `AddSingleton`: eine Instanz für die ganze Anwendung; `AddScoped`: eine Instanz je Anforderung; `AddTransient`: eine neue Instanz bei jeder Anforderung des Dienstes.
  Der Speicher, der die Stimmen aller Besucher hält, muss `Singleton` sein, sonst beginnt jede Anforderung mit einem leeren Speicher.

Typische Fehlvorstellungen: Scoped sei „ein Objekt je Benutzer"; Transient sei „der Standard und passe für den Speicher"; Konstruktorinjektion sei ein Entwurfsmuster nur für Tests.

## code-lebensdauer

Ausgabe: `True True False False`.

Wesentlich:
- `a` (Singleton, zwei Scopes): dieselbe Instanz: `True`.
- `b` (Scoped, derselbe Scope): dieselbe Instanz: `True`.
- `c` (Scoped, zwei Scopes, also zwei Anforderungen): verschiedene Instanzen: `False`.
- `d` (Transient, derselbe Scope): bei jeder Anforderung eine neue Instanz: `False`.

Typische Fehlvorstellungen: `True True True False` (Scoped wie Singleton gedacht); `True False False False` (Scoped wie Transient gedacht); `==` vergleiche den Inhalt (bei Klassen ohne eigenen Operator vergleicht es die Referenz).

## pagemodel-und-zustand

Wesentlich:
- `OnGet` behandelt GET (Seite anzeigen), `OnPost` behandelt POST (Formular verarbeiten); beide liefern ein `IActionResult`: `Page()` zeigt die Seite, `RedirectToPage(...)` leitet um, `NotFound()` antwortet mit 404.
- Post-Redirect-Get: Nach einem erfolgreichen POST wird umgeleitet; der Browser lädt die Zielseite per GET. Ein Neuladen wiederholt nur das GET und schickt das Formular nicht noch einmal ab (keine doppelte Speicherung).
- HTTP ist zustandslos: Für jede Anforderung entsteht ein neues PageModel, das nur eine Anforderung lang lebt; Felder sind bei der nächsten Anforderung weg.
  Zustand über Anforderungen hinweg gehört in eine Datenbank, ein Cookie/eine Sitzung oder einen Dienst (Singleton).

Typische Fehlvorstellungen: Das PageModel bleibe zwischen Aufrufen bestehen; ein Neuladen nach `Page()` sei harmlos; `RedirectToPage` sei nur eine Alternative zu `Page()` ohne Unterschied.

## code-validierung

Ausgabe:

```
False 2
Name|Alter
```

Wesentlich:
- `Name = "Al"` ist zu kurz (`StringLength` mit `MinimumLength = 3`), `Alter = 17` liegt außerhalb von 18 bis 99 (`Range`): zwei Fehler, jeder nennt seine Eigenschaft in `MemberNames`.
- `Required` ist erfüllt (`"Al"` ist nicht leer).
- In einer Razor Page prüft das Framework dieselben Attribute bei der Modellbindung: Die Fehler stehen im `ModelState`, `ModelState.IsValid` ist `false`, `asp-validation-for` zeigt sie an.

Typische Fehlvorstellungen: Ausgabe `False 1` (nur ein Fehler gezählt) oder `True 0`; `Required` sei verletzt; die Prüfung geschehe erst beim Speichern.

## validierung-und-bindung

Wesentlich:
- Modellbindung schreibt Formularwerte in PageModel-Eigenschaften, die mit `[BindProperty]` markiert sind; fehlende oder nicht umwandelbare Werte (z. B. Text statt Zahl) landen als Fehler im `ModelState`.
- Regeln stehen als Attribute am Modell (`[Required]`, `[Range]`, `[StringLength]`, `[EmailAddress]`); `IValidatableObject` für Regeln über mehrere Eigenschaften (z. B. Ende nach Beginn).
  `OnPost` fragt `ModelState.IsValid` ab.
- Der Server prüft immer: Die Prüfung im Browser ist nur Komfort und lässt sich umgehen (z. B. mit einem selbst gebauten POST).
- Overposting: Die Modellbindung füllt jede bindbare Eigenschaft, die in der Anforderung vorkommt, auch solche, die das Formular gar nicht anbietet (z. B. `IstAdmin`, `Gezaehlt`).
  Gegenmittel: eine Positivliste (`[Bind]`) oder besser eine eigene Eingabemodellklasse, die nur die erwünschten Felder enthält.

Typische Fehlvorstellungen: Die Prüfung im Browser genüge; nur sichtbare Formularfelder könnten gebunden werden; `[Required]` verhindere Overposting.

## code-routing

Ausgabe (Statuscodes): `/Detail/2` → 200, `/Detail/abc` → 404, `/Detail/99` → 404, `/Detail` → 404.

Wesentlich:
- `/Detail/2`: Die Route passt (`int`), `OnGet(2)` findet die Partei: `Page()`, 200.
- `/Detail/abc`: Das **Routing** entscheidet: Die Einschränkung `:int` lässt den Text nicht durch, keine Seite passt, 404; `OnGet` läuft gar nicht.
- `/Detail/99`: Die Route passt, `OnGet(99)` läuft, findet keine Partei und liefert `NotFound()`: 404 durch den Code.
- `/Detail`: Der Routenparameter `id` ist Pflicht (`{id:int}`), ohne ihn passt die Route nicht: 404 durch das Routing.

Typische Fehlvorstellungen: `/Detail/abc` liefere 400 oder 500 oder rufe `OnGet` mit 0 auf; `/Detail` zeige die Seite mit `id = 0`; alle 404 hätten dieselbe Ursache.
