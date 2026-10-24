# WPF und das MVVM-Muster

Dieses Wahlmodul ist optional und braucht für die Programmieraufgaben kein
WPF: Getestet werden nur ViewModel-Klassen in einer normalen
`net10.0`-Klassenbibliothek. Die Oberfläche selbst baust du in Rider (Windows)
und zeigst sie der Betreuung (Kapitel 12, Seite 725).

## Einordnung und Grundlagen (12.1 bis 12.3, Seite 727 bis 745)

WPF ist die seit 2006 verfügbare GUI-Technik für Windows-Desktopanwendungen,
technisch der älteren Windows Forms überlegen, aber wie diese auf Windows
beschränkt (Zieltyp `net10.0-windows`). Microsoft favorisiert für Neues das
Windows App SDK mit WinUI 3; MAUI, Avalonia und Uno decken weitere Plattformen
ab (12.1.1). Eine WPF-Anwendung besteht aus genau einem `Application`-Objekt,
das den Start steuert, und mindestens einem `Window`. Alle Oberflächenobjekte
gehören dem einen UI-Thread (12.2.2).

## XAML und Code-Behind (12.4 bis 12.6, Seite 746 bis 764)

XAML ist XML, das einen Objektgraphen beschreibt: Ein Element erzeugt ein
Objekt, ein Attribut setzt eine Eigenschaft, ein Eigenschaftselement
(`<Button.Content>`) setzt komplexe Werte, und Markuperweiterungen wie
`{Binding}` oder `{StaticResource}` werten beim Laden einen Ausdruck aus. Zu
jeder `.xaml`-Datei gehört eine partielle Klasse in der Code-Behind-Datei;
beim Build entstehen daraus BAML und generierter C#-Code, der
`InitializeComponent()` füllt.

## Routingereignisse und Abhängigkeitseigenschaften (12.8 und 12.9, Seite 766 bis 786)

Routingereignisse wandern durch die Elementhierarchie: Tunnelereignisse
(`PreviewMouseDown`) laufen von oben nach unten, Blasenereignisse
(`MouseDown`, `Click`) von der Quelle nach oben, Direktereignisse bleiben bei
der Quelle. `Handled = true` hält die Weiterleitung für gewöhnliche Handler
an. Abhängigkeitseigenschaften speichern ihren Wert nicht im Feld, sondern in
einem Wörterbuch des Objekts; das erlaubt Wertevorrang (Animation, Trigger,
Stil, Standardwert), Vererbung im Elementbaum und vor allem Datenbindung.

## Datenbindung (12.10, Seite 787 bis 803)

Ein `Binding` verbindet eine Zielobjekt-Eigenschaft (Abhängigkeitseigenschaft)
mit einer Quelleigenschaft. Der Modus (`OneWay`, `TwoWay`, `OneWayToSource`)
legt die Richtung fest; `UpdateSourceTrigger` bestimmt, wann eine Eingabe
zurückgeschrieben wird. Bei `TextBox.Text` ist das standardmäßig erst beim
Fokusverlust, mit `UpdateSourceTrigger=PropertyChanged` bei jedem Tastendruck.
Damit die Quelle die Oberfläche aktualisieren kann, muss sie
`INotifyPropertyChanged` implementieren (12.10.4.1); Kollektionen melden
Änderungen über `INotifyCollectionChanged`, praktisch also
`ObservableCollection<T>` (12.10.4.2). Validierung läuft über Ausnahmen oder
besser über `INotifyDataErrorInfo` (12.10.5.2).

## Layout und Steuerelemente (12.11 und 12.12, Seite 804 bis 855)

`Grid` (Zeilen und Spalten, Größen `Auto`, `*`, feste Werte), `StackPanel`,
`DockPanel` und `WrapPanel` ordnen Elemente relativ an, sodass das Fenster bei
veränderter Größe bedienbar bleibt; `Canvas` mit festen Koordinaten ist die
Ausnahme. Gängige Steuerelemente sind `TextBox`, `Button`, `ListBox` und
`ComboBox`.

## MVVM (12.13, Seite 856 bis 883)

Das Muster trennt drei Rollen: Das **Modell** hält Daten und Geschäftslogik,
die **Ansicht** (XAML) zeigt an und kennt nur Bindungen, das **ViewModel**
bereitet Daten für die Ansicht auf, hält ihren Zustand und stellt Befehle
bereit. Das ViewModel kennt keine Fensterklassen, deshalb lässt es sich ohne
Oberfläche testen, und genau das tun die Tests in diesem Modul. Befehle
implementieren `ICommand` (`Execute`, `CanExecute`, `CanExecuteChanged`;
12.13.3.1); `RelayCommand` nimmt zwei Delegaten entgegen und erspart eine
eigene Klasse je Befehl (12.13.3.4). Das MVVM Community Toolkit liefert fertige
Bausteine (`ObservableObject`, `ObservableValidator`, `RelayCommand`;
12.13.4); in den Aufgaben schreibst du sie einmal selbst, um sie zu verstehen.
