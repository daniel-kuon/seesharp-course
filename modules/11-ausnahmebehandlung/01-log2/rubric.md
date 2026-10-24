# Rubrik: Log2 mit ArgumentOutOfRangeException (nur für die Betreuung)

- **Kernidee:** Eine Methode, die ihr Argument nicht verarbeiten kann, soll
  laut scheitern (`throw new ArgumentOutOfRangeException(nameof(x), x, "…")`),
  statt stillschweigend `NaN` zu liefern. Die Prüfung steht am Anfang der
  Methode, der Rest läuft nur mit gültigen Werten. `nameof(x)` statt
  `"x"` hält den Parameternamen beim Umbenennen aktuell.
- Typische Fehler: `ArgumentException` statt `ArgumentOutOfRangeException`
  (der Test erwartet genau den spezifischen Typ); `Exception` direkt werfen;
  die Ausnahme zurückgeben statt werfen (`return new …`); Parametername
  vergessen; die Prüfung `x < 0` statt `x <= 0` (0 hat keinen Logarithmus).
- Stack-Trace-Frage: Der oberste Eintrag ist der Ort des `throw`, der
  unterste `Main()`. Wer "Main" nennt, liest die Liste von unten. Nachfragen:
  Wer ist "schuld", Log2 oder Dezibel? (Log2 prüft zu Recht; die Ursache liegt
  im Aufrufer, der einen ungültigen Wert weitergibt.)
- Vorab prüfen statt abfangen (13.1): Der Test
  `Eine_Vorabpruefung_vermeidet_die_Ausnahme` zeigt den Stil des Aufrufers.
  Dennoch prüft die Methode selbst, weil sie dem Aufrufer nicht trauen darf.
- Modellantwort: `solution/`; Vorlagen `samples/Ausnahmebehandlung/DuaLog`
  (Varianten `ArgumentOutOfRangeException` und `NaN`) und `throw`.
