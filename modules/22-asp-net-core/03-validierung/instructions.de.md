# Validierung per Attribut

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
3. `Email`: optional, wenn angegeben eine gültige Adresse. Das Attribut dafür
   steht nicht im Buch und ist hier vorgegeben:
   `[EmailAddress(ErrorMessage = "E-Mail-Adresse ungültig")]`.

Die Tests prüfen mit `Validator.TryValidateObject(..., validateAllProperties:
true)`, also so wie ASP.NET Core bei der Modellbindung (nicht im Buch, du rufst
es nicht selbst auf), und testen die Grenzwerte (Name mit 1, 2, 50 und 51
Zeichen; Alter 17, 18, 120 und 121).

Tests:

- `Gueltige_Anmeldung_hat_keine_Fehler`
- `Name_fehlt`
- `Name_Laenge_hat_die_Grenzen_2_und_50`
- `Alter_hat_die_Grenzen_18_und_120`
- `Email_darf_fehlen`, `Email_gueltig_wird_akzeptiert`, `Email_ungueltig_wird_gemeldet`
- `Mehrere_Eigenschaftsfehler_werden_alle_gemeldet`

> **Deep Dive (optional):** Nicht im Buch. Die Regel *Ende nicht vor Beginn*
> betrifft zwei Eigenschaften, daher kann kein Attribut sie ausdrücken. Dafür
> gibt es die Schnittstelle `IValidatableObject`: Ihre Methode `Validate`
> liefert die Fehler als `ValidationResult`s, hier mit
> `yield return new ValidationResult("Ende liegt vor dem Beginn", [nameof(Ende)]);`,
> wenn `Ende < Beginn`. Der Eigenschaftsname sagt, an welchem Feld die Meldung
> erscheint. `Validate` läuft erst, wenn alle Eigenschaftsregeln erfüllt sind.
> Die Zusatztests dazu sind `Anmeldung_implementiert_IValidatableObject`,
> `Ende_vor_Beginn_wird_fuer_Ende_gemeldet`, `Ende_gleich_Beginn_ist_erlaubt` und
> `Validate_laeuft_erst_wenn_alle_Eigenschaftsregeln_erfuellt_sind`; sie sind
> nicht verlangt. Ein Beispiel dafür, was du dir als Nächstes ansehen kannst.

Danach beantwortest du zwei Fragen zu `[Required]`, `[BindRequired]` und dem
impliziten `Required`.
