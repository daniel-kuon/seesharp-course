# Extra: Notes ViewModel

Extra exercise: optional; it unlocks nothing. For further reading: **12.13.2 Example** (page 862) and **12.13.3 Command Binding** (page 865).

A simple notes app consists of an input field, an **"Add"** button, a list, and a **"Delete"** button. `ViewModelBase` and `RelayCommand` are already included. Open `NotizenViewModel.cs`:

1. `Notizen` is an `ObservableCollection<string>`. `Text` is the input field, and `Ausgewaehlt` is the note selected in the list (`null` if none is selected).
2. `Hinzufuegen` can only be executed if `Text` is not empty and does not consist solely of whitespace. When executed, the trimmed text is appended to the end of the list, and `Text` is cleared.
3. `Loeschen` can only be executed if something is selected. When you execute it, the selected note disappears, and nothing is selected afterward.
4. If `Text` or `Ausgewaehlt` changes, the ViewModel raises a `PropertyChanged` event, and the affected command raises a `CanExecuteChanged` event. An identical value does not trigger anything.

The following tests must be passed:

- `NotizenTests.Startzustand_ist_leer_und_beide_Befehle_sind_gesperrt`
- `NotizenTests.Hinzufuegen_ist_nur_mit_Text_ausfuehrbar`
- `NotizenTests.Text_meldet_PropertyChanged_nur_bei_Aenderung`
- `NotizenTests.Hinzufuegen_fuegt_die_getrimmte_Notiz_ein_und_leert_den_Text`
- `NotizenTests.Notizen_bleiben_in_der_Eingabereihenfolge`
- `NotizenTests.Loeschen_ist_nur_mit_Auswahl_ausfuehrbar`
- `NotizenTests.Ausgewaehlt_meldet_PropertyChanged_nur_bei_Aenderung`
- `NotizenTests.Loeschen_entfernt_die_ausgewaehlte_Notiz_und_hebt_die_Auswahl_auf`
- `NotizenTests.Gleiche_Notiz_zweimal_loescht_nur_einen_Eintrag`
