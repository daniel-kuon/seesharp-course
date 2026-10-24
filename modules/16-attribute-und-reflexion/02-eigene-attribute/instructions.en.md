# Define Your Own Attributes

Read section **14.6**, **“Defining Attributes”** (page 940), **14.7 Generic Attributes** (page 942), specifically 14.7.1 (the old solution using the `typeof` parameter, page 942) and 14.7.2 (the generic version, page 944). An System.Attribute class derives from `System.Attribute` and is usually named with `Attribute` as a suffix; it is applied without this suffix (`[Autor(...)]`). `[AttributeUsage]` specifies where it may be placed. Positional parameters come from the constructor; **named** parameters come from public, writable properties (`Version = 2`).

The three attribute classes and the `Rechner` and `Person` classes have been created but are not yet complete (`// TODO` notes in the files):

1. `AutorAttribute`: an attribute with a positional `Name` and a named `Version` (Standard 1). It may only be applied to classes and methods and may be applied multiple times to the same target (`AllowMultiple = true`).
2. `SpalteAttribute(name)`: Applies only to properties.
3. `ImplementierungAttribute<T>`: generic, applies only to classes, with the type constraint `where T : IRechnung`. `Typ` returns `typeof(T)`. This eliminates the runtime check that the book performs in the constructor using `IsAssignableFrom`: the compiler rejects invalid types.
4. Apply the attributes: The `Rechner` receives `[Autor("Anna", Version = 2)]`, `[Autor("Ben")]`, and `[Implementierung<StandardRechnung>]`; The `Addiere` method takes `[Autor("Ben", Version = 3)]`. In `Person`, the `Name` and `Alter` are stored in `[Spalte("name")]` and `[Spalte("alter")]`, `Passwort`: none.

The compiler determines whether an attribute is allowed at a given location; therefore, the tests read `AttributeUsageAttribute.ValidOn` and `AllowMultiple` via reflection, rather than triggering a compilation error.

The following tests must be passed:

- `EigeneAttributeTests.Autor_ist_ein_Attribut`
- `EigeneAttributeTests.Autor_darf_nur_an_Klassen_und_Methoden_stehen`
- `EigeneAttributeTests.Autor_darf_mehrfach_am_selben_Ziel_stehen`
- `EigeneAttributeTests.Autor_hat_positionalen_Namen_und_benannte_Version_mit_Standard_1`
- `EigeneAttributeTests.Spalte_ist_ein_Attribut_nur_fuer_Eigenschaften`
- `EigeneAttributeTests.Implementierung_ist_ein_generisches_Attribut_fuer_Klassen`
- `EigeneAttributeTests.Implementierung_verlangt_per_Typeinschraenkung_eine_IRechnung`
- `EigeneAttributeTests.Implementierung_liefert_den_Typ_des_Typarguments`
- `EigeneAttributeTests.Rechner_hat_zwei_Autoren`
- `EigeneAttributeTests.Addiere_hat_den_Autor_Ben_in_Version_3_und_Teile_keinen`
- `EigeneAttributeTests.Person_markiert_Name_und_Alter_als_Spalten_aber_nicht_das_Passwort`
- `EigeneAttributeTests.Rechner_ist_mit_Implementierung_StandardRechnung_markiert`
