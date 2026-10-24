# Zusatz: Validierung per Attribut

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**14.6 Attribute definieren** (Seite 940) und **14.2 Attribute per
Reflexion auswerten** (Seite 924).

Statt in jeder Klasse eigene `if`-Ketten zu schreiben, beschreibt man die
Regeln deklarativ an den Eigenschaften und prüft sie an einer einzigen
Stelle per Reflexion. Das ist das Muster hinter den Validierungsattributen
vieler Frameworks. In diesem Projekt gibt es `[Pflicht]` und
`[Bereich(min, max)]`, die Klasse `Person` ist damit schon ausgestattet:

1. `PflichtAttribute.cs` und `BereichAttribute.cs`: Beide Attribute sollen
   nur an Eigenschaften stehen dürfen und nicht mehrfach an derselben
   (`[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]`).
2. `Validierer.Pruefe(object o)` liefert die Fehlermeldungen aller
   öffentlichen Eigenschaften in Deklarationsreihenfolge (leere Liste =
   alles in Ordnung):
   - `[Pflicht]` und der Wert ist `null` oder ein leerer bzw. nur aus
     Leerraum bestehender Text: `"Name: ist ein Pflichtfeld"`.
   - `[Bereich(min, max)]` und der Wert liegt außerhalb (Grenzen zählen mit):
     `"Alter: muss zwischen 0 und 120 liegen"`. Ein `null`-Wert wird nicht
     auf den Bereich geprüft; dafür gibt es `[Pflicht]`.
   - Trägt eine Eigenschaft beide Attribute, steht die Pflicht-Meldung zuerst.
   - Eigenschaften ohne Attribut bleiben unbeachtet.

Diese Tests müssen bestehen:

- `ValidierungTests.Attribute_gelten_nur_fuer_Eigenschaften_und_nicht_mehrfach`
- `ValidierungTests.Gueltige_Person_ergibt_keine_Fehler`
- `ValidierungTests.Fehlender_Name_wird_gemeldet`
- `ValidierungTests.Alter_ausserhalb_des_Bereichs_wird_gemeldet`
- `ValidierungTests.Die_Grenzen_des_Bereichs_gehoeren_dazu`
- `ValidierungTests.Mehrere_Fehler_kommen_in_der_Reihenfolge_der_Eigenschaften`
- `ValidierungTests.Eigenschaften_ohne_Attribut_werden_nicht_geprueft`
- `ValidierungTests.Fehlender_Wert_meldet_nur_die_Pflicht`
- `ValidierungTests.Wert_ausserhalb_meldet_nur_den_Bereich`
