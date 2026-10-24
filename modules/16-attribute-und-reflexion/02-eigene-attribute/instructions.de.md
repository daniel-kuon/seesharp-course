# Eigene Attribute definieren

Lies im Buch **14.6 Attribute definieren** (Seite 940), **14.7 Generische
Attribute** (Seite 942) mit 14.7.1 (die alte Lösung per `typeof`-Parameter,
Seite 942) und 14.7.2 (die generische Fassung, Seite 944). Eine
Attributklasse leitet von `System.Attribute` ab und heißt üblicherweise auf
`Attribute` endend; sie wird ohne dieses Suffix angewendet (`[Autor(...)]`).
`[AttributeUsage]` legt fest, wo sie stehen darf. Positionale Parameter
stammen aus dem Konstruktor, **benannte** aus öffentlichen, schreibbaren
Eigenschaften (`Version = 2`).

Die drei Attributklassen und die Klassen `Rechner` und `Person` sind
angelegt, aber noch nicht fertig (Hinweise `// TODO` in den Dateien):

1. `AutorAttribute`: ein Attribut mit positionalem `Name` und benanntem
   `Version` (Standard 1). Es darf nur an Klassen und Methoden stehen und
   mehrfach am selben Ziel (`AllowMultiple = true`).
2. `SpalteAttribute(name)`: nur an Eigenschaften.
3. `ImplementierungAttribute<T>`: generisch, nur an Klassen, mit der
   Typeinschränkung `where T : IRechnung`. `Typ` liefert `typeof(T)`. So
   entfällt die Laufzeitprüfung, die das Buch im Konstruktor mit
   `IsAssignableFrom` macht: Der Compiler lehnt falsche Typen ab.
4. Wende die Attribute an: `Rechner` bekommt `[Autor("Anna", Version = 2)]`,
   `[Autor("Ben")]` und `[Implementierung<StandardRechnung>]`; die Methode
   `Addiere` bekommt `[Autor("Ben", Version = 3)]`. In `Person` tragen `Name`
   und `Alter` `[Spalte("name")]` bzw. `[Spalte("alter")]`, `Passwort` keines.

Ob ein Attribut an einer Stelle erlaubt ist, entscheidet der Compiler; die
Tests lesen deshalb `AttributeUsageAttribute.ValidOn` und `AllowMultiple`
per Reflexion, statt einen Übersetzungsfehler zu provozieren.

Diese Tests müssen bestehen:

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
