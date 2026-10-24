# Euro-Konverter als ViewModel

Lies im Buch **12.10.4 Änderungsbenachrichtigungen** (Seite 792) mit
**12.10.4.1 INotifyPropertyChanged** (Seite 793) sowie **12.13.1 Verteilung
von Zuständigkeiten** (Seite 857). Die Aufgabe ist die Logik der Buchaufgabe
**12.14/2** (Seite 884): ein Euro/DM-Umrechner, bei dem man in beide Felder
tippen kann. Die Oberfläche baust du erst in Aufgabe 5; hier entsteht nur das
ViewModel in einer normalen Klassenbibliothek (ohne WPF-Verweis). Deshalb
laufen die Tests überall.

Öffne `ViewModelBase.cs`:

1. `OnPropertyChanged(name)` löst `PropertyChanged` aus (mit `this` als
   Sender). Ohne Abonnenten passiert nichts.
2. `SetProperty(ref feld, wert, name)` setzt das Feld und meldet die Änderung,
   aber nur, wenn sich der Wert wirklich ändert. Der Rückgabewert sagt, ob
   gesetzt wurde. `[CallerMemberName]` füllt `name` mit dem Namen der
   aufrufenden Eigenschaft.

Öffne `UmrechnerViewModel.cs` (Kurs 1 Euro = 1,95583 DM, Zahlen mit Komma):

3. `EuroText` und `DmText` sind die Texte der beiden Eingabefelder. Ändert
   der Benutzer einen davon, bekommt das andere Feld den umgerechneten Betrag
   mit zwei Nachkommastellen (kaufmännisch gerundet, `"F2"`).
4. **Kein Ping-Pong:** Setzt der Benutzer `EuroText = "10"`, darf das ViewModel
   dabei nicht über `DmText` wieder `EuroText` überschreiben (aus `"10"` würde
   `"10,00"`). Setze das Partnerfeld deshalb über `SetProperty` auf dem
   Feld. Jede betroffene Eigenschaft meldet sich genau einmal.
5. Ungültiger Text setzt `Fehlermeldung` und lässt das Partnerfeld
   unverändert. Leerer Text leert das Partnerfeld, ohne Fehler. Ein gültiger
   Text löscht die Fehlermeldung.
6. `HatFehler` ist **berechnet** (`Fehlermeldung` nicht leer) und meldet sich
   zusammen mit `Fehlermeldung`, wenn diese sich ändert.

Diese Tests müssen bestehen:

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

Die Fragen zu den Zuständigkeiten von Modell, Ansicht und ViewModel
beantwortest du zusätzlich im Quiz-Teil dieser Aufgabe.
