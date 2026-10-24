# RelayCommand und CanExecute

Lies im Buch **12.13.3 Kommandobindung** (Seite 865) mit **12.13.3.1 ICommand**
(Seite 866), **12.13.3.2 Separate ICommand-Implementation mit
CommandParameter-Übergabe** (Seite 867) und **12.13.3.4 RelayCommand**
(Seite 872). Eine Schaltfläche löst in MVVM keine Click-Methode im Code-Behind
aus, sondern führt einen **Befehl** aus, an den sie per `Command="{Binding ...}"`
gebunden ist. Der Befehl ist ein Objekt, das `System.Windows.Input.ICommand`
implementiert; die Schnittstelle liegt in `System.ObjectModel` und braucht kein
WPF, deshalb bleibt alles testbar.

`ViewModelBase` aus der letzten Aufgabe liegt fertig bei. Öffne
`RelayCommand.cs`:

1. Der Konstruktor merkt sich die beiden Delegaten
   (`Action<object?> ausfuehren`, optional `Func<object?, bool>? kannAusfuehren`).
   Ohne `ausfuehren` wirft er `ArgumentNullException`.
2. `CanExecute(parameter)` liefert `true`, wenn keine Bedingung angegeben
   wurde, sonst das Ergebnis der Bedingung.
3. `Execute(parameter)` ruft die Aktion mit dem Parameter auf.
4. `RaiseCanExecuteChanged()` löst `CanExecuteChanged` aus. WPF fragt
   `CanExecute` nur nach diesem Ereignis neu ab.

Öffne `ZaehlerViewModel.cs`:

5. Im Konstruktor entstehen die Befehle `Erhoehen`, `Verringern` (ausführbar
   nur, solange `Wert > 0`) und `SetzeAuf` mit einem `CommandParameter`.
   `SetzeAuf` akzeptiert einen `int` (aus dem Code) und einen `string`
   (aus XAML, wo `CommandParameter="10"` Text ist); ungültige Parameter
   (`null`, kein Zahlentext, negative Zahl) machen den Befehl nicht ausführbar.
   Die Hilfsmethode `LiesZahl` ist fertig.
6. Ändert sich `Wert`, meldet das ViewModel `PropertyChanged` und
   `Verringern` meldet `CanExecuteChanged`.

Diese Tests müssen bestehen:

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
