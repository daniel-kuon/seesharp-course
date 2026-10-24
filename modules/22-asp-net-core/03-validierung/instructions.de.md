# Validierung per Attribut und IValidatableObject

Lies im Buch **22.9 Validierung** (Seite 1608), vor allem **22.9.1
Deklaration von Validierungsregeln in Modellklassen** (Seite 1609), **22.9.2
Required versus BindRequired** (Seite 1612) und **22.9.6 Implizites
Required-Attribut** (Seite 1618).

Öffne `Anmeldung/Anmeldung.cs`. Die Klasse `Anmeldung` ist das Eingabemodell
eines Anmeldeformulars. Deklariere die Regeln mit Attributen aus
`System.ComponentModel.DataAnnotations`; die Meldungen stehen in den
TODO-Kommentaren und werden von den Tests genau geprüft:

1. `Name`: Pflichtfeld und 2 bis 50 Zeichen.
2. `Alter`: 18 bis 120.
3. `Email`: optional, wenn angegeben eine gültige Adresse.
4. `Validate`: Die Regel *Ende nicht vor Beginn* betrifft zwei Eigenschaften,
   daher kann kein Attribut sie ausdrücken. Implementiere
   `IValidatableObject.Validate` und nenne die Eigenschaft `Ende` als
   Fehlerort.

Die Tests prüfen mit `Validator.TryValidateObject(..., validateAllProperties:
true)`, also so wie ASP.NET Core bei der Modellbindung, und testen die
Grenzwerte (Name mit 1, 2, 50 und 51 Zeichen; Alter 17, 18, 120 und 121).
Beachte: `Validate` läuft nur, wenn alle Eigenschaftsregeln erfüllt sind.

Tests:

- `Gueltige_Anmeldung_hat_keine_Fehler`
- `Anmeldung_implementiert_IValidatableObject`
- `Name_fehlt`
- `Name_Laenge_hat_die_Grenzen_2_und_50`
- `Alter_hat_die_Grenzen_18_und_120`
- `Email_darf_fehlen`, `Email_gueltig_wird_akzeptiert`, `Email_ungueltig_wird_gemeldet`
- `Ende_vor_Beginn_wird_fuer_Ende_gemeldet`
- `Ende_gleich_Beginn_ist_erlaubt`
- `Mehrere_Eigenschaftsfehler_werden_alle_gemeldet`
- `Validate_laeuft_erst_wenn_alle_Eigenschaftsregeln_erfuellt_sind`

Danach beantwortest du zwei Fragen zu `[Required]`, `[BindRequired]` und dem
impliziten `Required`.
