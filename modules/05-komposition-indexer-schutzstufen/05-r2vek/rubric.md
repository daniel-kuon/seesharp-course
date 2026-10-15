# Rubrik — R²-Vektor (nur für die Betreuung)

- `Laenge` als berechnete Eigenschaft ohne Feld: Wer ein Feld `laenge`
  einführt und pflegt, hat eine Fehlerquelle gebaut (Feld veraltet, sobald
  `X` sich ändert). Das ist der Lernpunkt der Übung.
- `Addiere` (verändert) gegen `Plus` (liefert neu): die Unterscheidung
  "mutierend vs. rein" besprechen; sie kehrt bei `operator +` und bei Records
  wieder.
- Klassischer Fehler in `Drehe`: `X` überschreiben und dann für `Y` das neue
  `X` verwenden. Der 90-Grad-Test fängt das.
- Bonus: Warum sind `X` und `Y` hier öffentliche Felder und keine
  Eigenschaften? (Das Buch begründet es mit dem freien Zugriff; diskutieren,
  ob man es heute so machen würde.)

Modellantwort: `solution/` bzw. `samples/Klassen und Objekte/R2Vek`.
