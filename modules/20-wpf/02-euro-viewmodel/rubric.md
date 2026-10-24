# Rubrik — Euro-Konverter als ViewModel (nur für die Betreuung)

- Kern: `SetProperty` mit Gleichheitsprüfung, `[CallerMemberName]` und
  Rückgabewert; darauf bauen alle späteren ViewModels. Typische Fehler:
  `PropertyChanged` ohne `?.` aufrufen, bei gleichem Wert trotzdem melden,
  den Namen als String-Literal statt über `[CallerMemberName]`/`nameof`
  schreiben.
- Ping-Pong ist der Lehrinhalt dieser Aufgabe: Wer im `EuroText`-Setter
  `DmText = ...` schreibt, löst dessen Setter aus, der `EuroText` wieder setzt
  (aus `"10"` wird `"10,00"`). Der Test `Kein_Ping_Pong_...` fängt das ab.
  Nachfrage: Welche Alternativen gibt es (Flag `_aktualisiere`, Prüfung auf
  Gleichheit nach Rundung, gemeinsamer Betrag als `decimal`)?
- `decimal` statt `double` für Geld (Level 2). Kultur: Der Test verlässt sich
  nicht auf die Kultur des Rechners; die Vorgabe bringt ein eigenes
  `NumberFormatInfo` mit. Gesprächsanlass: Was änderte sich bei
  `CultureInfo.CurrentCulture`? (Test hinge von der Windows-Sprache ab.)
- `HatFehler` berechnet, ohne eigenes Feld: Wer es als Auto-Eigenschaft
  speichert, fällt durch den Reflexionstest. Wichtig ist das zusätzliche
  `OnPropertyChanged(nameof(HatFehler))` im Setter der Fehlermeldung (berechnete
  Eigenschaft meldet sich selbst nicht!).
- Das Quiz zu Modell, Ansicht und ViewModel: Ein ViewModel kennt nie die
  Ansicht. Die Tests ohne WPF sind der praktische Beweis.
- Bekannte Vereinfachung: Sehr große Zahlen (über etwa 4e28 Euro) lassen
  die Multiplikation überlaufen (`OverflowException`); das ist in der Aufgabe
  kein Thema.

Modellantwort: `solution/` bzw. `samples/WPF/Eurokonverter`, `samples/WPF/Datenbindung`,
`samples/WPF/MVVM/Ohne Kommandos` (nur die ViewModel-Teile).
