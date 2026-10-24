# Rubrik: Eigene Ausnahmeklasse (nur für die Betreuung)

- **Kernidee:** Eine eigene Ausnahmeklasse leitet von der passendsten
  vorhandenen Ausnahme ab (hier `ArgumentException`), sodass ein Aufrufer sie
  mit dem allgemeineren `catch (ArgumentException)` mit abfängt, und trägt
  Zusatzinformationen als Eigenschaften (`Argument`). Der Konstruktor mit
  `innerException` verpackt eine Ursache, ohne sie zu verlieren.
- Häufige Fehler: von `Exception` statt `ArgumentException` abgeleitet (der
  Test fragt den Basistyp ab); `Argument` im Konstruktor nicht gesetzt (der
  Auto-Property-Setter ist `get;` und lässt sich nur im Konstruktor schreiben);
  ohne `: base(...)` fehlt die Meldung; `Message` überschrieben statt die Meldung
  an den Basiskonstruktor zu geben.
- Zwei Wege vergleichen: Eigene Klasse (typisiert, Compiler hilft, mehr Code)
  gegen `Data` (ein Schlüssel-Wert-Paar an einer BCL-Ausnahme, ohne neue Klasse,
  aber ohne Typprüfung). Buch 13.7 schließt mit der Bemerkung, dass `Data` oft eine
  eigene Klasse überflüssig macht.
- `Fakultaet(21)`: Die checked-Rechnung löst die `OverflowException` aus; im
  `catch` wird eine neue Ausnahme mit `ex` als Ursache geworfen. Frage: Warum
  nicht einfach `throw;`? (Der Aufrufer soll eine fachlich passende Ausnahme
  bekommen und trotzdem die Ursache sehen.)
- Modellantwort: `solution/`; Vorlagen
  `samples/Ausnahmebehandlung/BadFaculArgException`.
