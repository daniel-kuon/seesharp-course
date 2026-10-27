# Validation Using Attributes

Read section **22.9**, "**Validation**" (page 1608), especially **22.9.1**, **"Declaration of Validation Rules in Model Classes**" (page 1609), **22.9.2 “Required” versus “BindRequired”** (page 1612), and **22.9.6 “Implicit Required Attribute”** (page 1618).

Open `Anmeldung/Anmeldung.cs`. The `Anmeldung` class is the input model for a registration form. Declare the rules using attributes from `System.ComponentModel.DataAnnotations`; the messages are included in the TODO comments and are thoroughly checked by the tests:

1. `Name`: Required field; 2 to 50 characters.
2. `Alter`: 18 to 120.
3. `Email`: optional; if provided, it must be a valid address. The attribute for this is not in the book and is given here: `[EmailAddress(ErrorMessage = "E-Mail-Adresse ungültig")]`.

The tests use `Validator.TryValidateObject(..., validateAllProperties: true)`—the same approach ASP.NET Core uses for model binding (not in the book; you do not call it yourself)—and check the boundary values (name lengths of 1, 2, 50, and 51 characters; ages of 17, 18, 120, and 121).

Tests:

- `Gueltige_Anmeldung_hat_keine_Fehler`
- `Name_fehlt`
- `Name_Laenge_hat_die_Grenzen_2_und_50`
- `Alter_hat_die_Grenzen_18_und_120`
- `Email_darf_fehlen`, `Email_gueltig_wird_akzeptiert`, `Email_ungueltig_wird_gemeldet`
- `Mehrere_Eigenschaftsfehler_werden_alle_gemeldet`

> **Deep Dive (optional):** Not in the book. The rule *"End not before Start"* applies to two properties, so no attribute can express it. The interface `IValidatableObject` exists for this: its method `Validate` returns the errors as `ValidationResult`s, here `yield return new ValidationResult("Ende liegt vor dem Beginn", [nameof(Ende)]);` when `Ende < Beginn`. The property name says at which field the message appears. `Validate` runs only once all property rules are satisfied. The extra tests for this are `Anmeldung_implementiert_IValidatableObject`, `Ende_vor_Beginn_wird_fuer_Ende_gemeldet`, `Ende_gleich_Beginn_ist_erlaubt` and `Validate_laeuft_erst_wenn_alle_Eigenschaftsregeln_erfuellt_sind`; they are not required. An example of what to look into next.

Next, answer two questions about `[Required]`, `[BindRequired]`, and the implicit `Required`.
