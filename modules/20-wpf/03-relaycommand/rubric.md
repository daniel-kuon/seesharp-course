# Rubrik — RelayCommand und CanExecute (nur für die Betreuung)

- Kern: Ein Befehl kapselt Aktion (`Execute`) und Bedingung (`CanExecute`) in
  einem Objekt; `RelayCommand` verallgemeinert das über zwei Delegaten, damit
  nicht für jeden Befehl eine eigene Klasse nötig ist (12.13.3.2 gegen 12.13.3.4).
- Typische Fehler: `CanExecuteChanged` ohne `?.` auslösen; `Execute` prüft
  selbst `CanExecute` (unnötig, WPF ruft Execute nur bei `true` auf); den
  Sender mit `null` belegen; vergessen, bei Wertänderung
  `RaiseCanExecuteChanged` aufzurufen (Test
  `Verringern_meldet_CanExecuteChanged_bei_jeder_Wertaenderung`); den
  `string`-Parameter nicht behandeln.
- Gesprächsanlass: Was macht `CommandManager.RequerySuggested` in WPF und
  warum arbeitet diese Aufgabe ohne? (Es ist WPF-spezifisch; ein ViewModel
  in einer reinen `net10.0`-Bibliothek kennt den `CommandManager` nicht.)
- `LiesZahl` mit `switch`-Ausdruck und Typmuster ist Stoff aus Level 14 und
  hier nur gegeben; Nachfrage genügt, was die drei Zweige tun.
- Das MVVM Community Toolkit generiert dasselbe per `[RelayCommand]`
  (12.13.4.4, Seite 880). Hier bewusst von Hand geschrieben.

Modellantwort: `solution/` bzw. `samples/WPF/MVVM/RelayCommand` und
`samples/WPF/MVVM/Separate ICommand-Implementationen`.
