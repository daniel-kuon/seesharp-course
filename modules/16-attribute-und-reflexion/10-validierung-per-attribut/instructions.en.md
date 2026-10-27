# Extra: Validation by Attribute

Extra exercise: optional; it unlocks nothing. For further reading: **14.6 Defining Attributes** (page 940) and **14.2 Evaluating Attributes via Reflection** (page 924).

Instead of writing separate `if` chains in each class, you define the rules declaratively on the properties and check them in a single location using reflection. This is the pattern behind the validation attributes in many frameworks. In this project, there are `[Pflicht]` and `[Bereich(min, max)]`; the `Person` class is already equipped with them:

1. `PflichtAttribute.cs` and `BereichAttribute.cs`: Both attributes should only be allowed on properties and should not be applied multiple times to the same property (`[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]`).
> **Deep Dive (optional):** `PropertyInfo.GetValue(o)` reads the value of a property; `o.GetType().GetProperties()` returns the properties. Neither is in the book (see Exercise 16/04, Deep Dive).

2. `Validierer.Pruefe(object o)` returns the error messages for all public properties in the order they are declared (an empty list means everything is OK):
   - `[Pflicht]`, and the value is `null`, or the text is empty or consists only of spaces: `"Name: ist ein Pflichtfeld"`.
   - `[Bereich(min, max)]` and the value is outside the range (the limits themselves are inside): `"Alter: muss zwischen 0 und 120 liegen"`. A `null` value is not checked against the range; `[Pflicht]` is used for that purpose.
   - If a property has both attributes, the required message comes first.
   - Properties without attributes are ignored.

The following tests must be passed:

- `ValidierungTests.Attribute_gelten_nur_fuer_Eigenschaften_und_nicht_mehrfach`
- `ValidierungTests.Gueltige_Person_ergibt_keine_Fehler`
- `ValidierungTests.Fehlender_Name_wird_gemeldet`
- `ValidierungTests.Alter_ausserhalb_des_Bereichs_wird_gemeldet`
- `ValidierungTests.Die_Grenzen_des_Bereichs_gehoeren_dazu`
- `ValidierungTests.Mehrere_Fehler_kommen_in_der_Reihenfolge_der_Eigenschaften`
- `ValidierungTests.Eigenschaften_ohne_Attribut_werden_nicht_geprueft`
- `ValidierungTests.Fehlender_Wert_meldet_nur_die_Pflicht`
- `ValidierungTests.Wert_ausserhalb_meldet_nur_den_Bereich`
