# Extra: Calculator ViewModel

Extra exercise: optional; it unlocks nothing. For further reading: **12.13.3 Command Binding** (page 865) and **12.13.3.2 ... with CommandParameter Passing** (page 867).

A calculator has many buttons, but only a few commands: All the number buttons use the **same** command, `ZifferCommand`, which uses `CommandParameter="7"` to determine which button was pressed. The same applies to `OperatorCommand` (`"+"`, `"-"`, `"*"`, `"/"`). `ViewModelBase` and `RelayCommand` are already included. Open `RechnerViewModel.cs`: The `TODO` notes describe each method in detail.

- `Anzeige` is a **calculated** property (without its own field): It is derived from the computer's state (the number entered, the current result, and any error conditions). Every key that has an effect triggers `PropertyChanged("Anzeige")` exactly once; keys with no effect do not trigger anything.
- Calculations are performed from left to right (`2 + 3 * 4 =` gives 20), with a decimal comma. After the equals sign `=`, you can continue the calculation with an operator; a digit starts a new calculation.
- Division by 0 shows `Fehler`. In this error state, only `C` has an effect.
- Commands check their parameters in `CanExecute`: The parameter must be a `string` (as it comes from XAML); anything else is not executable.

The following tests must be passed:

- `RechnerTests.Startanzeige_ist_0`
- `RechnerTests.Ziffern_werden_angehaengt`
- `RechnerTests.Fuehrende_Null_wird_ersetzt`
- `RechnerTests.Komma_wird_einmal_angehaengt_und_ergibt_bei_leerer_Eingabe_0_Komma`
- `RechnerTests.Addition`
- `RechnerTests.Grundrechenarten`
- `RechnerTests.Es_wird_von_links_nach_rechts_gerechnet`
- `RechnerTests.Ein_zweiter_Operator_zeigt_das_Zwischenergebnis`
- `RechnerTests.Ein_zweiter_Operator_ersetzt_den_ersten`
- `RechnerTests.Nach_dem_Operator_zeigt_die_Anzeige_noch_den_linken_Operand`
- `RechnerTests.Nach_Gleich_kann_mit_dem_Ergebnis_weitergerechnet_werden`
- `RechnerTests.Nach_Gleich_beginnt_eine_Ziffer_eine_neue_Rechnung`
- `RechnerTests.Division_durch_0_zeigt_Fehler`
- `RechnerTests.Im_Fehlerzustand_wirkt_nur_C`
- `RechnerTests.C_setzt_alles_zurueck`
- `RechnerTests.Jede_wirksame_Taste_meldet_Anzeige_genau_einmal`
- `RechnerTests.Wirkungslose_Tasten_melden_nichts`
- `RechnerTests.Anzeige_ist_eine_berechnete_Eigenschaft`
- `RechnerTests.Die_Eingabe_ist_auf_15_Zeichen_begrenzt`
- `RechnerTests.ZifferCommand_lehnt_ungueltige_Parameter_ab`
- `RechnerTests.OperatorCommand_lehnt_ungueltige_Parameter_ab`
- `RechnerTests.Gueltige_Parameter_sind_ausfuehrbar`
