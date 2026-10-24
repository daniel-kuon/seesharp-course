# Rubrik — WPF-Grundlagen-Quiz (nur für die Betreuung)

- Die fünf Aussagen der Buchaufgabe sind schnell geprüft. Zum Nachfragen
  taugt Aussage 3: Warum bevorzugt man trotzdem XAML (deklarativ,
  Designer-Werkzeuge, Trennung von Layout und Logik)?
- Kern ist `bindungsmodus` mit `inpc-noetig`: Wer verstanden hat, dass
  `TextBox.Text` erst bei Fokusverlust zurückschreibt und dass die Quelle
  `INotifyPropertyChanged` braucht, kommt in den Aufgaben 02 bis 04 ohne
  Umwege voran.
- `tunneln-blubbern` und `handled` lassen sich am besten am Beispielprojekt
  `WPF/Routingereignisse` vorführen (Windows).
- Die Frage zur Abhängigkeitseigenschaft nicht auswendig lernen lassen:
  Gesucht ist die Idee, dass der Wert aus mehreren Quellen mit Vorrang
  stammen kann und dass nur sie Bindungsziel sein darf.

Modellantwort: `samples/WPF/Routingereignisse`, `samples/WPF/Abhängigkeitseigenschaften`.
