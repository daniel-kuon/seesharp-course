# ObservableCollection and Validation

See section **12.10.2**, "**Binding the ItemsControl to a Collection**" (page 789), **12.10.4.2 INotifyCollectionChanged** (page 795), and **12.10.5 Data Validation** with **12.10.5.2 INotifyDataErrorInfo** (pages 796–801). Here, we’ll create the ViewModel for a small to-do list, again in a standard class library without WPF.

The `ViewModelBase`, `RelayCommand`, and `Aufgabe` (Titel, `Erledigt`) classes are already included; you can also use your own from the previous exercises. Open `AufgabenViewModel.cs`:

1. The constructor sets everything up (see the `TODO` notes) and checks the initial state: An empty title is invalid, so `HasErrors` is `true` at the beginning.
2. `NeuerTitel` is validated: if it is empty or contains only whitespace, the error message is `"Titel darf nicht leer sein"`; if it contains more than 50 characters, the error message is `"Titel zu lang"`. If the error message changes, `ErrorsChanged` is triggered exactly once, and `HasErrors` and `HinzufuegenCommand` report the change.
3. `HasErrors`, `GetErrors(propertyName)`, and `ErrorsChanged` implement `INotifyDataErrorInfo`. `GetErrors("NeuerTitel")` returns the message; for unknown names, it returns an empty list; `null` or `""` return all messages.
4. `Aufgaben` is an `ObservableCollection<Aufgabe>`. The ViewModel subscribes to its `CollectionChanged` and the `PropertyChanged` **of each** task it contains (and unsubscribes when a task is removed).
5. `OffeneAnzahl` is calculated (tasks excluding those marked as `Erledigt`) and updates when tasks are added, removed, or checked off.
6. `HinzufuegenCommand` (only if there are no errors) adds a task with a trimmed title and clears `NeuerTitel`. `ErledigteEntfernenCommand` (only if there are completed tasks) removes all completed tasks.

The following tests must be passed:

- `AufgabenTests.Das_ViewModel_implementiert_INotifyDataErrorInfo`
- `AufgabenTests.Im_Startzustand_ist_der_leere_Titel_ein_Fehler`
- `AufgabenTests.Gueltiger_Titel_entfernt_den_Fehler_und_meldet_das_genau_einmal`
- `AufgabenTests.ErrorsChanged_kommt_nur_bei_geaenderter_Meldung`
- `AufgabenTests.Zu_langer_Titel_ist_ein_Fehler_50_Zeichen_sind_erlaubt`
- `AufgabenTests.Nur_Leerraum_gilt_als_leer`
- `AufgabenTests.GetErrors_fuer_unbekannte_Eigenschaften_ist_leer_und_fuer_null_liefert_alles`
- `AufgabenTests.Gleicher_Titel_loest_nichts_aus`
- `AufgabenTests.Hinzufuegen_ist_nur_ohne_Fehler_ausfuehrbar_und_meldet_CanExecuteChanged`
- `AufgabenTests.Hinzufuegen_fuegt_die_Aufgabe_ein_trimmt_den_Titel_und_leert_das_Eingabefeld`
- `AufgabenTests.Aufgaben_ist_eine_ObservableCollection`
- `AufgabenTests.OffeneAnzahl_aendert_sich_bei_Hinzufuegen_Abhaken_und_Entfernen`
- `AufgabenTests.Entfernte_Aufgaben_beeinflussen_OffeneAnzahl_nicht_mehr`
- `AufgabenTests.Eine_Aufgabe_meldet_nur_Erledigt_nicht_andere_Namen_weiter`
- `AufgabenTests.ErledigteEntfernen_ist_nur_ausfuehrbar_wenn_etwas_erledigt_ist`
- `AufgabenTests.ErledigteEntfernen_entfernt_nur_erledigte_Aufgaben_einzeln`
