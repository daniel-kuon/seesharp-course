# Rubrik — Die Oberfläche (nur für die Betreuung)

Es gibt nichts Automatisches zu prüfen; die Aufgabe ist reine Betreuungsarbeit
und braucht Windows.

Checkliste:

- Projektstruktur: Bibliothek `net10.0` ohne WPF, WPF-Projekt
  `net10.0-windows` mit `ProjectReference`; `UseWPF` nur im WPF-Projekt.
  Nachfrage: Wozu die Trennung? (Testbarkeit, auch unter Linux; ein
  ViewModel kennt keine Fensterklassen.)
- Code-Behind: außer `InitializeComponent()` (und gegebenenfalls dem Setzen
  des `DataContext`) nichts. Ereignisbehandlungsmethoden wie `Button_Click`
  sind ein Befund, außer die Betreuung hat eine begründete Ausnahme vereinbart.
- Bindungen: `TwoWay` mit `UpdateSourceTrigger=PropertyChanged` für die
  Eingabefelder, `Command` und gegebenenfalls `CommandParameter` für
  Schaltflächen, `ItemsSource` für die Sammlung. Prüfen, dass Schaltflächen
  sich bei geänderter Ausführbarkeit deaktivieren (liefert der
  `RelayCommand` aus Aufgabe 3 `CanExecuteChanged`?).
- Validierung: Fehler sichtbar (z. B. `TextBlock` mit `Fehlermeldung` oder
  `Validation.ErrorTemplate`); beim Aufgaben-ViewModel muss die Bindung
  `NotifyOnValidationError` bzw. `ValidatesOnNotifyDataErrors` verwenden
  (Standard bei `INotifyDataErrorInfo`).
- Layout: Fenster verkleinern und vergrößern lassen; `Grid`-Zeilen und
  -Spalten mit `Auto` und `*`, kein `Canvas`, keine festen Positionen.
  Texte der Oberfläche dürfen für ein Trainee-Projekt auf Deutsch fest
  im XAML stehen.
- Offene Frage: Gesucht sind Testbarkeit, lose Kopplung und das Beispiel
  einer ersetzten Click-Methode (Befehl statt Click, Bindung statt `TextChanged`).
- Hinweis zum Prüfpaket: Das Prüfpaket enthält die Quelldateien; den
  Screenshot legt die Trainee/der Trainee zusätzlich bei.

Modellantwort: `samples/WPF/Eurokonverter`, `samples/WPF/MVVM/RelayCommand`,
`samples/WPF/Layoutcontainer/*`, `samples/WPF/Steuerelemente/*`.
