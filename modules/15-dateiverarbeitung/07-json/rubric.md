# Rubrik — JSON-Serialisierung (nur für die Betreuung)

- Kern: Serialisiert werden öffentliche Eigenschaften; Namen, Enums und
  Einrückung steuert `JsonSerializerOptions`, einzelne Eigenschaften steuern
  Attribute (`[JsonPropertyName]`, `[JsonIgnore]`). Dieselben Optionen für
  Schreiben **und** Lesen: Wer beim Lesen die Optionen vergisst, bekommt leere
  Objekte (die Namen passen nicht zu `Vorname`) oder eine Ausnahme beim Enum
  (`"Aktiv"` statt Zahl).
- Das Passwort: `[JsonIgnore]` wirkt in beide Richtungen; der Test setzt
  `"passwort": "eingeschleust"` im JSON und erwartet `null`. Nachfrage: Wie
  speichert man Passwörter richtig? (Gar nicht im Klartext, Hash mit Salt;
  hier nur Beispiel für „nicht in die Datei“.)
- Zyklen: `IgnoreCycles` ersetzt nur den Rückverweis; ein JSON, das mit dieser
  Einstellung geschrieben wurde, lässt sich nicht zurück in einen Kreis
  einlesen. `Preserve` erhält die Struktur, erzeugt aber `$id`/`$ref`
  (nicht jeder JSON-Leser kennt sie). Das ist die Frage aus dem Quiz-Item.
- Die Standardeinstellung bei fehlenden Optionen ist case-sensitiv und
  schreibt PascalCase; wer `PropertyNameCaseInsensitive` benutzt, kann
  auch fremdes JSON lesen. Das ist eine gute Ergänzung, aber nicht gefordert.
- Standard-Encoder: Nicht-ASCII-Zeichen werden als `\uXXXX` geschrieben;
  wer `UnsafeRelaxedJsonEscaping` verwendet, muss die Konsequenzen für
  HTML-Einbettung kennen. Nicht Teil der Tests.
- Nicht graduiert: `[JsonInclude]`, Felder (16.5.3.4), Konverter für eigene Typen.

Modellantwort: `solution/` bzw. `samples/Ein- und Ausgabe über Datenströme/JSON-Serialisierung/{Standard,Zirkuläre Referenz}`.
