# Euro Converter as a ViewModel

Read section **12.10.4, "Change Notifications**" (page 792), along with **12.10.4.1, "INotifyPropertyChanged**" (page 793), and **12.13.1, "Distribution of Responsibilities"** (page 857). The task takes up book exercise **12.14/2** (page 884), the bidirectional euro/DM converter. Instead of choosing the direction with radio buttons and filling an output-only field as in the book, you can type into both fields here. You’ll build the user interface in Exercise 5; here, you’re only creating the ViewModel in a standard class library (without a WPF reference). That’s why the tests run everywhere.

Open `ViewModelBase.cs`:

1. `OnPropertyChanged(name)` triggers `PropertyChanged` (with `this` as the sender). If there are no subscribers, nothing happens.
2. `SetProperty(ref feld, wert, name)` sets the field and notifies of the change, but only if the value actually changes. The return value indicates whether the field was set. `[CallerMemberName]` assigns the name of the calling property to `name`.

Open `UmrechnerViewModel.cs` (exchange rate: 1 euro = 1.95583 DM, numbers with commas):

3. `EuroText` and `DmText` are the texts of the two input fields. If the user changes one of them, the other field displays the converted amount rounded to two decimal places (commercial rounding, `"F2"`).
4. **No ping-pong:** If the user sets `EuroText = "10"`, the ViewModel must not overwrite `EuroText` via `DmText` (`"10"` would become `"10,00"`). Therefore, set the partner field using `SetProperty`. Each affected property reports its change exactly once.
5. Invalid text sets `Fehlermeldung` and leaves the partner field unchanged. Empty text clears the partner field without generating an error. Valid text clears the error message.
6. `HatFehler` is **calculated** (`Fehlermeldung` is not empty) and is reported together with `Fehlermeldung` whenever the latter changes.

The following tests must be passed:

- `UmrechnerTests.ViewModelBase_implementiert_INotifyPropertyChanged`
- `UmrechnerTests.OnPropertyChanged_meldet_den_Namen_mit_this_als_Sender`
- `UmrechnerTests.OnPropertyChanged_ohne_Abonnenten_wirft_nicht`
- `UmrechnerTests.SetProperty_setzt_den_Wert_und_meldet_den_Eigenschaftsnamen_genau_einmal`
- `UmrechnerTests.SetProperty_mit_gleichem_Wert_meldet_nichts_und_liefert_false`
- `UmrechnerTests.SetProperty_liefert_true_und_nimmt_einen_ausdruecklichen_Namen`
- `UmrechnerTests.Der_Umrechner_ist_ein_ViewModelBase`
- `UmrechnerTests.Startzustand_ist_leer_und_ohne_Fehler`
- `UmrechnerTests.Euro_eingeben_berechnet_DM_mit_zwei_Nachkommastellen`
- `UmrechnerTests.DM_eingeben_berechnet_Euro`
- `UmrechnerTests.Kein_Ping_Pong_die_Eingabe_des_Benutzers_bleibt_unveraendert`
- `UmrechnerTests.Jede_Aenderung_meldet_jede_Eigenschaft_genau_einmal`
- `UmrechnerTests.Gleicher_Text_loest_nichts_aus`
- `UmrechnerTests.Ungueltige_Eingabe_setzt_Fehlermeldung_und_laesst_den_Partner_unveraendert`
- `UmrechnerTests.Punkt_als_Dezimaltrenner_ist_ungueltig`
- `UmrechnerTests.Gueltige_Eingabe_loescht_den_Fehler_und_meldet_ihn`
- `UmrechnerTests.Zweite_ungueltige_Eingabe_mit_gleicher_Meldung_meldet_den_Fehler_nicht_erneut`
- `UmrechnerTests.Leere_Eingabe_leert_den_Partner_ohne_Fehler`
- `UmrechnerTests.HatFehler_ist_eine_berechnete_Eigenschaft_ohne_eigenes_Feld`
- `UmrechnerTests.Der_Kurs_ist_1_95583`

You'll also answer the questions about the responsibilities of the Model, View, and ViewModel in the quiz section of this assignment.
