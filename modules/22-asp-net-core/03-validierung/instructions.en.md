# Validation Using Attributes and IValidatableObject

Read section **22.9**, "**Validation**" (page 1608), especially **22.9.1**, **"Declaration of Validation Rules in Model Classes**" (page 1609), **22.9.2 “Required” versus “BindRequired”** (page 1612), and **22.9.6 “Implicit Required Attribute”** (page 1618).

Open `Anmeldung/Anmeldung.cs`. The `Anmeldung` class is the input model for a registration form. Declare the rules using attributes from `System.ComponentModel.DataAnnotations`; the messages are included in the TODO comments and are thoroughly checked by the tests:

1. `Name`: Required field; 2 to 50 characters.
2. `Alter`: 18 to 120.
3. `Email`: optional; if provided, it must be a valid address.
4. `Validate`: The rule *"End not before Start"* applies to two properties, so no single attribute can express it. Implement `IValidatableObject.Validate` and specify the property `Ende` as the error location.

The tests use `Validator.TryValidateObject(..., validateAllProperties: true)`—the same approach ASP.NET Core uses for model binding—and check the boundary values (name lengths of 1, 2, 50, and 51 characters; ages of 17, 18, 120, and 121). Note: `Validate` runs only if all property rules are satisfied.

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

Next, answer two questions about `[Required]`, `[BindRequired]`, and the implicit `Required`.
