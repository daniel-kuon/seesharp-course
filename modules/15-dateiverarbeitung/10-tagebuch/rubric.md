# Rubrik — Zusatz: Tagebuch (nur für die Betreuung)

- Kern: Anhängen mit `StreamWriter(pfad, append: true)`, zeilenweises Lesen mit
  `ReadLine()` bis `null`, kleine Dateien mit `ReadAllLines`. Wiederholung von
  Aufgabe 1 und 3 an einem kleinen Format.
- Auf die Trennung achten: Erst das Präfix `yyyy-MM-dd;` abschneiden, nicht
  mit `Split(';')` alle Teile zerlegen (der Text darf `;` enthalten, der Test
  `Regen; aber warm` fängt das). `Split(';', 2)` ist ebenfalls richtig.
- Eingabeprüfung vor dem Schreiben: Die Ausnahme muss fliegen, bevor die Datei
  geöffnet wird; der Test prüft, dass die Datei nicht einmal angelegt wird.
- Das Datumsformat ist mit `CultureInfo.InvariantCulture` fest: Ein Datum mit der
  aktuellen Kultur kann je nach Kalender der Kultur anders aussehen.

Modellantwort: `solution/`.
