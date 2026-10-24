# Rubrik — Zusatz Taschenrechner-ViewModel (nur für die Betreuung)

- Kern: Wenige Befehle mit `CommandParameter` statt vieler Einzelbefehle, und
  eine berechnete Eigenschaft, die sich aus dem Zustand ergibt. Wer
  `Anzeige` als gespeichertes Feld führt, muss es an jeder Stelle nachziehen
  und vergisst es; der Reflexionstest fängt das Feld `_anzeige` ab.
  Wichtig: Eine berechnete Eigenschaft meldet sich nicht von selbst, jede
  Zustandsänderung muss `OnPropertyChanged(nameof(Anzeige))` aufrufen.
- Der Zustand (`_eingabe`, `_links`, `_operator`, `_fehler`,
  `_ergebnisAngezeigt`) ist eine kleine Zustandsmaschine; ihre Übergänge
  besprechen lassen: Was passiert bei `5 + * 2 =`? Warum ersetzt der
  zweite Operator den ersten statt zu rechnen?
- Typische Fehler: `decimal.Parse` mit der Kultur des Rechners (Test
  hinge von der Windows-Sprache ab; die Vorgabe bringt `Deutsch` mit),
  `double` statt `decimal` (`0,1 + 0,2`), Division durch 0 nicht abfangen,
  Fehlerzustand nicht mit `C` verlassen.
- Die Grenze von 15 Zeichen schützt vor `OverflowException` beim Parsen;
  das Überlaufen von `*` fängt `TryBerechne` ab.

Modellantwort: `solution/`.
