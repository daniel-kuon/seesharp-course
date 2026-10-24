# Zusatz: Notizen-ViewModel

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**12.13.2 Beispiel** (Seite 862) und **12.13.3 Kommandobindung**
(Seite 865).

Eine kleine Notizen-App besteht aus einem Eingabefeld, einer Schaltfläche
**Hinzufügen**, einer Liste und einer Schaltfläche **Löschen**. `ViewModelBase`
und `RelayCommand` liegen fertig bei. Öffne `NotizenViewModel.cs`:

1. `Notizen` ist eine `ObservableCollection<string>`. `Text` ist das Eingabefeld,
   `Ausgewaehlt` die in der Liste markierte Notiz (`null`: keine).
2. `Hinzufuegen` ist nur ausführbar, wenn `Text` nicht leer und nicht nur
   Leerraum ist. Beim Ausführen kommt der getrimmte Text ans Ende der Liste,
   `Text` wird geleert.
3. `Loeschen` ist nur ausführbar, wenn etwas ausgewählt ist. Beim Ausführen
   verschwindet die ausgewählte Notiz, danach ist nichts mehr ausgewählt.
4. Ändert sich `Text` oder `Ausgewaehlt`, meldet das ViewModel
   `PropertyChanged`, und der betroffene Befehl meldet `CanExecuteChanged`.
   Ein gleicher Wert löst nichts aus.

Diese Tests müssen bestehen:

- `NotizenTests.Startzustand_ist_leer_und_beide_Befehle_sind_gesperrt`
- `NotizenTests.Hinzufuegen_ist_nur_mit_Text_ausfuehrbar`
- `NotizenTests.Text_meldet_PropertyChanged_nur_bei_Aenderung`
- `NotizenTests.Hinzufuegen_fuegt_die_getrimmte_Notiz_ein_und_leert_den_Text`
- `NotizenTests.Notizen_bleiben_in_der_Eingabereihenfolge`
- `NotizenTests.Loeschen_ist_nur_mit_Auswahl_ausfuehrbar`
- `NotizenTests.Ausgewaehlt_meldet_PropertyChanged_nur_bei_Aenderung`
- `NotizenTests.Loeschen_entfernt_die_ausgewaehlte_Notiz_und_hebt_die_Auswahl_auf`
- `NotizenTests.Gleiche_Notiz_zweimal_loescht_nur_einen_Eintrag`
