# Rubrik — Validierung (nur für die Betreuung)

- Kernidee: Regeln pro Eigenschaft als Attribute (`Required`, `StringLength`,
  `Range`, `EmailAddress`, jeweils mit `ErrorMessage`), Regeln über mehrere
  Eigenschaften in `IValidatableObject.Validate` mit `yield return new
  ValidationResult(meldung, [nameof(Ende)])`. Der Test ruft denselben
  `Validator` auf wie ASP.NET Core; ohne Webserver.
- Nachfrage: Warum meldet `Validate` bei leerem Namen und Ende vor Beginn nur
  den Namensfehler? (Der Validator führt Klassenregeln erst aus, wenn alle
  Eigenschaftsregeln erfüllt sind.) Folge: Der Benutzer sieht den zweiten
  Fehler erst im nächsten Versuch.
- Nachfrage: Wo liegt der Unterschied zwischen Validierung auf dem Klienten
  und auf dem Server (22.9.3/22.9.4)? Warum ist die Serverprüfung nicht
  verzichtbar? Der Test ist die Serverseite.
- Im Test über `Validator` gibt es kein implizites Required für
  null-unzulässige Referenztypen; das ergänzt erst die MVC-Modellvalidierung
  (22.9.6). Deshalb steht `[Required]` bei `Name` ausdrücklich im Modell.
- Typische Fehler: `Range` mit falschen Grenzen; `StringLength` ohne
  `MinimumLength`; `Validate` ohne Eigenschaftsnamen (dann landet die Meldung
  nicht am Feld); `<` gegen `<=` vertauscht.

Modellantwort: `solution/`; Vorlagen in `samples/ASP.NET Core/Razor/AllowEmptyStrings` und `Fehlende Werte`.
