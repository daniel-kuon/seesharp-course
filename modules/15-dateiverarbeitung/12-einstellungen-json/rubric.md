# Rubrik — Zusatz: Einstellungen als JSON (nur für die Betreuung)

- Kern: Serialisieren und Deserialisieren mit denselben Optionen, und der Umgang
  mit kaputten Eingaben: Dateien, die ein Mensch bearbeitet hat, sind nicht
  vertrauenswürdig. `Deserialize` kann `null` liefern (Inhalt `null`) und
  wirft `JsonException` bei ungültigem oder unpassendem JSON (leere Datei,
  Array statt Objekt).
- `catch (JsonException)`, nicht `catch (Exception)`: Wer alles fängt, versteckt
  auch Zugriffsfehler. Dass eine fehlende Datei per `File.Exists` abgefangen
  wird, ist eine Entscheidung; `catch (FileNotFoundException)` wäre gleichwertig.
- Records werden über ihren Konstruktor deserialisiert; fehlende Eigenschaften
  im JSON ergeben dort `null`/0/`false`. Wer teilweise Dateien mit
  Standardwerten auffüllen will, braucht Eigenschaften mit Vorgabewert;
  Gesprächsanlass, nicht gefordert.
- Der Aufruf `Speicher.Standard` ist ein statisches `record`-Objekt, unveränderlich;
  deshalb dürfen Aufrufer es ohne Kopie weitergeben.

Modellantwort: `solution/`.
