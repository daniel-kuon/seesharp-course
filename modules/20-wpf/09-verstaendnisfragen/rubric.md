# Rubrik: Verständnisfragen WPF und MVVM (nur für die Betreuung)

Die Multiple-Choice-Fragen `mc-inpc-eigenschaft` (richtig: Option 4), `mc-kollektion` (Option 3) und
`mc-befehl` (Option 1) wertet das Programm selbst aus. Die Code-Listings sind reines C# (ohne WPF) und wurden in einer
`net10.0`-Konsolenanwendung ausgeführt; die Ausgaben unten sind echt. Aussagen zur Oberfläche (XAML, Bindung) folgen dem Buch
(Kapitel 12) und lassen sich ohne Fenster nicht ausführen.

## wpf-aufbau-xaml

Wesentlich:
- XAML ist XML, das einen **Objektgraphen** beschreibt: Ein Element erzeugt ein Objekt, ein Attribut setzt eine Eigenschaft, ein
  Eigenschaftselement (`<Button.Content>`) setzt einen komplexen Wert, eine Markuperweiterung (`{Binding}`, `{StaticResource}`) wertet beim
  Laden einen Ausdruck aus.
- Zu jeder `.xaml`-Datei gehört eine **partielle Klasse** in der Code-Behind-Datei (`MainWindow.xaml.cs`); der Build erzeugt aus dem XAML
  BAML und C#-Code mit dem Rest der Klasse, dessen `InitializeComponent()` das XAML lädt und die Objekte aufbaut (benannte Elemente werden Felder).
- Alle Oberflächenobjekte gehören dem einen UI-Thread; man darf sie nur aus diesem Thread ändern, langes Rechnen gehört nicht
  hinein (sonst friert das Fenster ein).

Typische Fehlvorstellungen: XAML werde zur Laufzeit wie HTML „interpretiert" und habe keine Verbindung zu C#-Klassen; `InitializeComponent`
sei ein Konstruktor oder gehöre dem Programmierer; jeder Thread dürfe Steuerelemente ändern.

## routingereignisse

Wesentlich:
- **Tunnelereignisse** (Namen mit `Preview…`, etwa `PreviewMouseDown`) laufen von der Wurzel zum Auslöser nach unten; **Blasenereignisse**
  (`MouseDown`, `Click`) laufen vom Auslöser nach oben; **Direktereignisse** bleiben beim Auslöser (z. B. `MouseEnter`).
- Reihenfolge beim Klick: zuerst Preview von `Window`, `Grid`, `StackPanel` bis `Button`, dann die Blasenereignisse von `Button`, `StackPanel`, `Grid` bis `Window`.
- `e.Handled = true` hält die Weiterleitung für gewöhnliche Handler an: Spätere Elemente der Route bekommen das Ereignis nicht mehr.
- Nutzen: Ein Handler weiter oben (z. B. am `StackPanel`) kann Ereignisse vieler Kinder abfangen, ohne jedes Kind zu abonnieren; Preview erlaubt Eingaben vorab zu prüfen oder zu verwerfen.

Typische Fehlvorstellungen: Blasen- und Tunnelereignis vertauscht; Ereignis erreiche nur das angeklickte Element; `Handled` lösche das Ereignis (es
stoppt nur das Weiterreichen).

## code-inpc

Ausgabe: `Betrag,Dollar,Betrag,Dollar`.

Wesentlich:
- Der erste Setzer (10) ändert den Wert: `PropertyChanged` kommt für `Betrag` (Name durch `[CallerMemberName]`) und für `Dollar`.
- Der zweite Setzer (wieder 10) tut wegen `if (_betrag == value) return;` nichts: keine Meldung. Der dritte (20) meldet wieder beide.
- `Dollar` ist eine berechnete Eigenschaft (hängt von `Betrag` ab, ohne eigenes Feld); die Oberfläche kann nicht wissen, dass sich der
  Wert mit `Betrag` ändert. Deshalb meldet das ViewModel ihn bei jeder Änderung von `Betrag` mit.

Typische Fehlvorstellungen: Ausgabe `Betrag,Dollar,Betrag,Dollar,Betrag,Dollar` (die Gleichheitsprüfung übersehen); `Dollar` werde von selbst
gemeldet, weil er den Betrag benutzt (das passiert nie automatisch).

## abhaengigkeitseigenschaften

Wesentlich:
- Der Wert einer Abhängigkeitseigenschaft liegt nicht in einem Feld, sondern in einer Wertetabelle (Wörterbuch) des Objekts; die Eigenschaft
  wird einmal registriert (`DependencyProperty.Register`), und der C#-Zugriffsteil ruft `GetValue`/`SetValue` auf.
- Vorteile (mindestens zwei): Wertevorrang (Animation, Trigger, Stil, Standardwert), Vererbung im Elementbaum (z. B. Schriftart) und vor allem Datenbindung.
- Die Datenbindung braucht als Ziel eine Abhängigkeitseigenschaft, weil nur sie Änderungsmeldung und Wertevorrang mitbringt (die Quelle kann eine gewöhnliche
  Eigenschaft sein, mit `INotifyPropertyChanged`).

Typische Fehlvorstellungen: Es sei nur „eine Eigenschaft mit anderer Schreibweise"; eine Abhängigkeitseigenschaft sei dasselbe wie eine
Eigenschaft mit `INotifyPropertyChanged`; die Quelle einer Bindung müsse auch eine Abhängigkeitseigenschaft sein.

## code-relaycommand

Ausgabe: `1 1`.

Wesentlich:
- Beim ersten Versuch ist `erlaubt` falsch, `CanExecute` liefert `false`, `Execute` wird nicht aufgerufen. Beim zweiten Versuch ist `erlaubt` wahr: `Execute` läuft, `zaehler` wird 1.
- `meldungen` zählt nur die **ausdrückliche** Meldung `RaiseCanExecuteChanged()` (einmal, am Ende). Das Ändern der Variablen `erlaubt` löst nichts aus: Der
  Befehl fragt die Bedingung erst bei `CanExecute` ab und meldet von selbst keine Änderung.
- Folgerung für ein ViewModel: Ändert sich die Bedingung (z. B. `Auswahl`), muss der Code `RaiseCanExecuteChanged()` aufrufen; WPF fragt `CanExecute` nur nach diesem Ereignis neu ab, sonst bleibt die Schaltfläche im alten Zustand.

Typische Fehlvorstellungen: `2 2` oder `1 2` (der Befehl melde jede Änderung der Bedingung selbst); `0 1` (`Execute` laufe nie, weil die Bedingung am Anfang falsch war).

## datenbindung-modi

Wesentlich:
- Eine Bindung verbindet eine Eigenschaft des **Ziels** (Abhängigkeitseigenschaft eines Steuerelements, z. B. `TextBox.Text`) mit einer Eigenschaft der **Quelle** (z. B. des ViewModels).
- `OneWay`: Quelle → Ziel; `TwoWay`: in beide Richtungen; `OneWayToSource`: nur Ziel → Quelle.
- Bei `TextBox.Text` wird standardmäßig erst beim **Fokusverlust** zurückgeschrieben; `UpdateSourceTrigger=PropertyChanged` schreibt bei jedem Tastendruck zurück.
- Damit die Oberfläche Änderungen der Quelle mitbekommt, muss die Quelle `INotifyPropertyChanged` implementieren und `PropertyChanged` mit dem Eigenschaftsnamen auslösen
  (Kollektionen: `INotifyCollectionChanged`, praktisch `ObservableCollection<T>`).

Typische Fehlvorstellungen: `TwoWay` bedeute, dass die Quelle sich automatisch melde (nein, `INotifyPropertyChanged` ist nötig); die `TextBox` schreibe bei jedem
Tastendruck zurück (nur mit `UpdateSourceTrigger=PropertyChanged`); die Bindung auf eine gewöhnliche `List<T>` aktualisiere die Anzeige.

## code-observablecollection

Ausgabe: `Add,Replace,Remove,Reset`.

Wesentlich:
- `ObservableCollection<T>` löst `CollectionChanged` aus, mit dem Aktionstyp: `Add` (c hinzugefügt), `Replace` (`liste[0] = "x"`), `Remove` (b entfernt), `Reset` (`Clear`).
- Eine `ListBox`, die an die Sammlung gebunden ist, abonniert dieses Ereignis und aktualisiert sich selbst.
- Eine gewöhnliche `List<string>` hat kein `CollectionChanged` (sie implementiert `INotifyCollectionChanged` nicht): Der Code würde sich nicht kompilieren lassen, und eine gebundene `ListBox` würde Änderungen
  nach dem Laden nicht sehen.

Typische Fehlvorstellungen: Ausgabe `Add,Replace,Remove,Clear` (`Clear` meldet `Reset`); die Liste melde auch das Ändern eines **Elements** (nur Ändern der Sammlung, nicht der Eigenschaften der Elemente: dafür muss das Element selbst `INotifyPropertyChanged` implementieren).

## code-validierung

Ausgabe: `2 False`.

Wesentlich:
- Der Startzustand hat noch keine Fehlermeldung (`_fehler` ist `null`): Es wird erst bei einer Zuweisung geprüft.
- `""` → Meldung „Name fehlt", anders als zuvor: `ErrorsChanged` (1). `" "` → dieselbe Meldung: `neu == _fehler`, es kommt keine Meldung. `"Ida"` → keine Meldung mehr, anders als zuvor: `ErrorsChanged` (2) und `HasErrors` wird `false`. `"Max"` → weiterhin keine Meldung: nichts.
- `ErrorsChanged` kommt also nur, wenn sich die **Fehlermeldung ändert**, nicht bei jedem Setzen der Eigenschaft; die Oberfläche fragt dann `GetErrors` neu ab und zeigt den Fehler an.

Typische Fehlvorstellungen: Ausgabe `4 False` oder `3 False` (Ereignis bei jedem Setzen); `HasErrors` sei am Ende `true`; die Prüfung finde schon im Konstruktor statt.

## mvvm-rollen

Wesentlich:
- **Modell**: Daten und Geschäftslogik. **Ansicht** (XAML): zeigt an, kennt nur Bindungen (und Befehle), keine Logik. **ViewModel**: bereitet Daten für die Ansicht auf, hält ihren Zustand
  (Eigenschaften mit `INotifyPropertyChanged`, Sammlungen) und stellt Befehle bereit.
- Das ViewModel kennt keine Fensterklassen und keine Steuerelemente; deshalb lässt es sich ohne Oberfläche in einem normalen Komponententest ausprobieren (Eigenschaft setzen, Befehl ausführen, Meldungen zählen), genau wie in den Aufgaben.
- Klick: Die Schaltfläche ist per `Command="{Binding ...}"` an ein Objekt gebunden, das `ICommand` implementiert (`Execute`, `CanExecute`, `CanExecuteChanged`); `RelayCommand` nimmt
  zwei Delegaten entgegen und erspart eine Klasse je Befehl.

Typische Fehlvorstellungen: Das ViewModel dürfe `MessageBox` oder Steuerelemente ansprechen; MVVM bedeute, dass es keinen Code-Behind gibt (er ist erlaubt, enthält aber keine Logik); Modell und ViewModel seien dasselbe.
