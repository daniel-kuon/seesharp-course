# Rubrik — ObservableCollection und Validierung (nur für die Betreuung)

- Kern: Zwei Meldekanäle für zwei Arten von Änderungen. Die Sammlung meldet
  Hinzufügen und Entfernen (`CollectionChanged`), das Element meldet seine
  Eigenschaften (`PropertyChanged`); wer die berechnete Eigenschaft
  `OffeneAnzahl` richtig halten will, braucht beide. Typischer Fehler: nur
  `CollectionChanged` abonnieren, dann stimmt die Anzahl nach dem Abhaken nicht.
- Abmelden beim Entfernen (Test `Entfernte_Aufgaben_...`): Ohne `-=` hält die
  Aufgabe das ViewModel am Leben. Bekannte Lücke der Musterlösung:
  `Aufgaben.Clear()` meldet `Reset` ohne `OldItems`; die Aufgaben bleiben dann
  abonniert. In dieser Aufgabe wird nie `Clear()` benutzt; als Nachfrage
  taugt: Wie ließe sich das beheben (eigene Kopie der Elemente führen)?
- `ErledigteEntfernen`: Wer in `foreach` über `Aufgaben` entfernt, bekommt
  `InvalidOperationException` (Level 10). Der Test sieht nach, dass einzeln
  entfernt wird (zwei `Remove`-Meldungen).
- `INotifyDataErrorInfo`: `ErrorsChanged` nur bei geänderter Meldung. Wer
  bei jedem Tastendruck meldet, fällt bei `ErrorsChanged_kommt_nur_bei_geaenderter_Meldung`
  durch. `GetErrors` darf nie `null` liefern; eine leere Liste ist richtig.
- Der Startzustand (leerer Titel = Fehler, Hinzufügen gesperrt) ist eine
  Entwurfsentscheidung der Aufgabe: Die Oberfläche zeigt dann sofort eine
  Meldung. Eine Alternative (erst nach der ersten Eingabe prüfen) ist
  vertretbar, würde aber die Tests ändern.
- Das MVVM Community Toolkit bietet `ObservableValidator` mit Attributen
  (12.13.4.3, Seite 878); hier bewusst von Hand.

Modellantwort: `solution/` bzw. `samples/WPF/Validierung`,
`samples/WPF/Steuerelemente/Selector/AddRemoveItems`.
