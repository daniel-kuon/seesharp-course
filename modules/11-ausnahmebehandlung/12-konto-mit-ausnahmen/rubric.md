# Rubrik: Zusatz Konto mit Ausnahmen (nur für die Betreuung)

- **Kernidee:** Die Wahl der Ausnahmeklasse drückt die Art des Fehlers aus: ein
  unzulässiger Wert (`ArgumentOutOfRangeException`), ein `null`
  (`ArgumentNullException`), ein im Moment unmöglicher Aufruf
  (`InvalidOperationException`, hier als `GuthabenZuNiedrigException` mit
  Zusatzinformation `Fehlbetrag`). Wer fehlerhafte Aufrufe verweigert,
  **verändert vorher nichts**: Prüfen, dann ändern.
- Häufige Fehler: `Ueberweisen` ruft `Abheben` und danach `ziel.Einzahlen` auf, ohne
  vorher `ziel` zu prüfen (dann ist bei `null` das Geld schon abgehoben); die
  Meldung nicht an den Basiskonstruktor weitergegeben; `Exception` statt der
  Klassen geworfen; `Abheben` wirft `ArgumentException`, obwohl der Betrag gültig
  ist und nur das Guthaben fehlt.
- Nachfragen: Warum ist `GuthabenZuNiedrigException` keine
  `ArgumentException`? (Der Fehler liegt im Zustand des Kontos, nicht im
  Argument; ein anderer Zustand ließe denselben Aufruf gelingen.) Warum nicht
  ein `bool` zurückgeben? (Fehler ist keine Normalsituation und darf nicht
  ignoriert werden; vgl. `ausnahmen-fehlerkommunikation`.)
- Modellantwort: `solution/`.
