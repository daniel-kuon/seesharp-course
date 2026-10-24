# BCL-Attribute: Obsolete, Caller-Info, Flags und nameof

Lies im Buch **14.1 Attribute vergeben** (Seite 922), **14.4 nameof-Operator**
(Seite 933), **14.5.1 Aufruferinformations-Attribute** (Seite 934) und
**14.5.4 Bitfelder per FlagsAttribute** (Seite 937). Ein Attribut ist
Metadatum in eckigen Klammern vor dem Programmelement; der Compiler oder
die Laufzeit werten es aus. In diesem Projekt fehlen vier solcher Angaben.

1. `Protokoll.cs`: `Log(text)` soll `"<Methode>:<Zeile>: <text>"` liefern,
   wobei Methodenname und Zeilennummer **der Aufrufstelle** stammen. Der
   Aufrufer übergibt sie nicht selbst: Setze `[CallerMemberName]` und
   `[CallerLineNumber]` auf die beiden optionalen Parameter. Wer sie
   ausdrücklich angibt, überstimmt den Compiler.
2. `Berechnung.cs`: Markiere `Alt` mit `[Obsolete("Bitte Neu(...) verwenden")]`.
   Aufrufer sollen eine Warnung sehen, der Code muss weiter übersetzbar bleiben.
3. `Rechte.cs`: Mach `Rechte` mit `[Flags]` zum Bitfeld, damit
   `Rechte.Lesen | Rechte.Schreiben` als `Lesen, Schreiben` ausgegeben wird.
   Implementiere dann `Hat` (sind alle gesuchten Bits gesetzt?) und `Entziehe`
   (die genannten Bits löschen) mit den Bitoperatoren `&`, `|` und `~`.
4. `Pruefung.cs`: `Pruefe` wirft `ArgumentException` mit der Meldung
   `Parameter 'name' fehlt`, wenn der Name `null`, leer oder nur Leerraum
   ist. Schreib den Parameternamen nicht als Text, sondern mit
   `nameof(name)`: Benennt jemand den Parameter um, zieht die Meldung mit.

Diese Tests müssen bestehen:

- `BclAttributeTests.Log_beginnt_mit_dem_Namen_der_aufrufenden_Methode`
- `BclAttributeTests.Log_liefert_die_Zeilennummer_der_Aufrufstelle`
- `BclAttributeTests.Log_nimmt_explizite_Angaben_unveraendert_entgegen`
- `BclAttributeTests.Alt_ist_als_Obsolete_markiert`
- `BclAttributeTests.Neu_ist_nicht_veraltet`
- `BclAttributeTests.Alt_rechnet_weiter_wie_Neu`
- `BclAttributeTests.Rechte_ist_ein_Bitfeld`
- `BclAttributeTests.Kombinierte_Rechte_werden_lesbar_ausgegeben`
- `BclAttributeTests.Hat_prueft_ob_alle_gesuchten_Rechte_vorhanden_sind`
- `BclAttributeTests.Entziehe_entfernt_nur_die_genannten_Bits`
- `BclAttributeTests.Pruefe_akzeptiert_einen_Namen`
- `BclAttributeTests.Pruefe_wirft_bei_fehlendem_Namen`
