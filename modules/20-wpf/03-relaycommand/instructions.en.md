# RelayCommand and CanExecute

Read section **12.13.3 Command Binding** (page 865), including **12.13.3.1 ICommand** (page 866), **12.13.3.2 “Separate ICommand Implementation with CommandParameter Passing”** (page 867), and **12.13.3.4 “RelayCommand”** (page 872). In MVVM, a button does not trigger a Click method in the code-behind; instead, it executes a **command** to which it is bound via `Command="{Binding ...}"`. The command is an object that implements `System.Windows.Input.ICommand`; the interface is located in `System.ObjectModel` and does not require WPF, so everything remains testable.

The `ViewModelBase` from the last exercise is ready. Open `RelayCommand.cs`:

1. The constructor stores the two delegates (`Action<object?> ausfuehren`, and optionally `Func<object?, bool>? kannAusfuehren`). If `ausfuehren` is omitted, it throws an `ArgumentNullException`.
2. `CanExecute(parameter)` returns `true` if no condition is specified; otherwise, it returns the result of the condition.
3. `Execute(parameter)` calls the action with the parameter.
4. `RaiseCanExecuteChanged()` triggers `CanExecuteChanged`. WPF only re-checks `CanExecute` after this event.

Open `ZaehlerViewModel.cs`:

5. The constructor creates the commands `Erhoehen`, `Verringern` (executable only as long as `Wert > 0`), and `SetzeAuf`, each with a `CommandParameter`. `SetzeAuf` accepts an `int` (from the code) and a `string` (from XAML, where `CommandParameter="10"` is the text); invalid parameters (`null`, non-numeric text, negative number) prevent the command from executing. The helper method `LiesZahl` is complete.
6. If the `Wert` property changes, the ViewModel raises a `PropertyChanged` event, and `Verringern` raises a `CanExecuteChanged` event.

The following tests must be passed:

- `BefehleTests.RelayCommand_ist_ein_ICommand`
- `BefehleTests.Ohne_Bedingung_ist_der_Befehl_immer_ausfuehrbar`
- `BefehleTests.CanExecute_ruft_die_Bedingung_mit_dem_Parameter_auf`
- `BefehleTests.Execute_ruft_die_Aktion_mit_dem_Parameter_auf`
- `BefehleTests.RaiseCanExecuteChanged_loest_das_Ereignis_mit_dem_Befehl_als_Sender_aus`
- `BefehleTests.RaiseCanExecuteChanged_ohne_Abonnenten_wirft_nicht`
- `BefehleTests.Konstruktor_ohne_Aktion_wirft_ArgumentNullException`
- `BefehleTests.Der_Zaehler_ist_ein_ViewModelBase_und_startet_bei_0`
- `BefehleTests.Erhoehen_und_Verringern_aendern_den_Wert`
- `BefehleTests.Verringern_ist_nur_ausfuehrbar_solange_der_Wert_groesser_0_ist`
- `BefehleTests.Verringern_meldet_CanExecuteChanged_bei_jeder_Wertaenderung`
- `BefehleTests.Wert_meldet_PropertyChanged_genau_einmal_pro_Aenderung`
- `BefehleTests.SetzeAuf_nimmt_einen_int_als_Parameter`
- `BefehleTests.SetzeAuf_nimmt_auch_eine_Zeichenkette_wie_aus_XAML`
- `BefehleTests.SetzeAuf_ist_bei_ungueltigem_Parameter_nicht_ausfuehrbar`
- `BefehleTests.SetzeAuf_auf_0_schaltet_Verringern_wieder_ab`
