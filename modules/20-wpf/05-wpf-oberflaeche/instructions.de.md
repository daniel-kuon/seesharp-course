# Die Oberfläche: Layout, Bindung und Steuerelemente

Diese Aufgabe wird von der Betreuung geprüft; es gibt keine Tests. Sie
braucht Windows und Rider mit der .NET-Desktop-Unterstützung, weil WPF nur
unter Windows läuft (Zieltyp `net10.0-windows`). Wer keinen Windows-Rechner
hat, bespricht die Aufgabe mit der Betreuung.

Lies im Buch **12.11 Layoutcontainer** (Seite 804) mit **12.11.1 Grid**
(Seite 807), **12.11.2 DockPanel** (Seite 812), **12.11.3 StackPanel**
(Seite 814) und **12.11.4 WrapPanel** (Seite 815), außerdem **12.12
Steuerelemente** (Seite 819) und **12.10 Datenbindung** (Seite 787). Als
Vorlage dienen im Sample-Ordner des Buchs `WPF/Eurokonverter`,
`WPF/MVVM/RelayCommand` und `WPF/Layoutcontainer`.

Vorgehen:

1. Lege die Lösung an: eine **Klassenbibliothek** (`net10.0`) mit den
   ViewModel-Klassen aus den Aufgaben 2 bis 4, die du hier **kopierst oder
   neu anlegst**, und eine **WPF-Anwendung** (`net10.0-windows`), die per
   Projektverweis auf die Bibliothek zugreift. Die Bibliothek bekommt keinen
   WPF-Verweis, damit sie testbar bleibt.
2. Wähle **eines** der drei ViewModels und baue das Fenster dazu.
   - Setze den `DataContext` in `App.xaml.cs` oder im Fenster.
   - Ordne die Elemente mit `Grid` (Zeilen und Spalten mit `Auto` und `*`)
     und, wo es passt, `DockPanel` oder `StackPanel` an.
   - `TextBox`: `Text="{Binding ..., Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"`.
   - Schaltflächen: `Command="{Binding ...}"`, bei Bedarf mit `CommandParameter`.
   - Sammlung: `ListBox` oder `ItemsControl` mit `ItemsSource`.
   - Validierung: Fehler müssen sichtbar sein (Meldungstext, Rahmen).
3. Beantworte die offene Frage und mache einen Screenshot. SeeSharp nimmt die
   Quelldateien in das Prüfpaket auf; lege den Screenshot dazu.

Die Betreuung prüft: keine Logik im Code-Behind außer `InitializeComponent()`,
Bindungen statt Ereignisbehandlungsmethoden, ein Fenster, das sich beim
Verändern der Größe vernünftig verhält (kein `Canvas`, keine festen
Koordinaten), und lesbare Namen und Texte.
