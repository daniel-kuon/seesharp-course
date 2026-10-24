# ObservableCollection und Validierung

Lies im Buch **12.10.2 ItemsControl-Steuerelement an eine Kollektion binden**
(Seite 789), **12.10.4.2 INotifyCollectionChanged** (Seite 795) und
**12.10.5 Datenvalidierung** mit **12.10.5.2 INotifyDataErrorInfo**
(Seite 796 bis 801). Hier entsteht das ViewModel einer kleinen Aufgabenliste,
wieder in einer normalen Klassenbibliothek ohne WPF.

Die Klassen `ViewModelBase`, `RelayCommand` und `Aufgabe` (Titel, `Erledigt`)
liegen fertig bei; du kannst auch deine eigenen aus den letzten Aufgaben
verwenden. Öffne `AufgabenViewModel.cs`:

1. Der Konstruktor verdrahtet alles (siehe die `TODO`-Hinweise) und prüft den
   Startzustand: Ein leerer Titel ist ungültig, `HasErrors` ist also am Anfang
   `true`.
2. `NeuerTitel` ist validiert: leer oder nur Leerraum ergibt
   `"Titel darf nicht leer sein"`, mehr als 50 Zeichen `"Titel zu lang"`.
   Ändert sich die Fehlermeldung, wird `ErrorsChanged` genau einmal
   ausgelöst, `HasErrors` und `HinzufuegenCommand` melden die Änderung.
3. `HasErrors`, `GetErrors(propertyName)` und `ErrorsChanged` bilden
   `INotifyDataErrorInfo`. `GetErrors("NeuerTitel")` liefert die Meldung,
   unbekannte Namen eine leere Liste, `null` oder `""` alle Meldungen.
4. `Aufgaben` ist eine `ObservableCollection<Aufgabe>`. Das ViewModel
   abonniert ihr `CollectionChanged` und das `PropertyChanged` **jeder**
   enthaltenen Aufgabe (und meldet sich beim Entfernen wieder ab).
5. `OffeneAnzahl` ist berechnet (Aufgaben ohne `Erledigt`) und meldet sich
   bei Hinzufügen, Entfernen und Abhaken.
6. `HinzufuegenCommand` (nur ohne Fehler) fügt eine Aufgabe mit getrimmtem
   Titel hinzu und leert `NeuerTitel`. `ErledigteEntfernenCommand` (nur wenn
   etwas erledigt ist) entfernt alle erledigten Aufgaben.

Diese Tests müssen bestehen:

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
