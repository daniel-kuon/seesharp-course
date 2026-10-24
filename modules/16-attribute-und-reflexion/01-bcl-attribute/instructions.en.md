# BCL Attributes: Obsolete, Caller Info, Flags, and nameof

See the book: **14.1 Assigning Attributes** (page 922), **14.4 The nameof Operator** (page 933), **14.5.1 Caller Information Attributes** (page 934), and **14.5.4 Bit Fields Using FlagsAttribute** (page 937). An attribute is metadata enclosed in square brackets before the program element; the compiler or the runtime evaluates it. Four such specifications are missing in this project.

1. `Protokoll.cs`: `Log(text)` should return `"<Methode>:<Zeile>: <text>"`, where the method name and line number come from **the calling location**. The caller does not pass them in explicitly: Set `[CallerMemberName]` and `[CallerLineNumber]` to the two optional parameters. If you specify them explicitly, you override the compiler.
2. `Berechnung.cs`: Mark `Alt` with `[Obsolete("Bitte Neu(...) verwenden")]`. Callers should see a warning, but the code must remain compilable.
3. `Rechte.cs`: Convert `Rechte` with `[Flags]` to a bit field so that `Rechte.Lesen | Rechte.Schreiben` is output as `Lesen, Schreiben`. Then implement `Hat` (are all the bits being searched for set?) and `Entziehe` (clear the specified bits) using the bitwise operators `&`, `|`, and `~`.
4. `Pruefung.cs`: `Pruefe` throws a `ArgumentException` with the message `Parameter 'name' fehlt` if the name is `null`, empty, or consists only of whitespace. Do not write the parameter name as text; instead, use `nameof(name)`: If someone renames the parameter, the message will update accordingly.

The following tests must be passed:

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
