# Zusatz: Einstellungen als JSON

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**16.5.2 Serialisieren** (Seite 1045), **16.5.3 Steuerung der
(De)serialisierung** (Seite 1048) und **16.5.4 Deserialisieren** (Seite 1050).

Ein Programm speichert seine Einstellungen in einer JSON-Datei. Der Record
`Einstellungen(Sprache, Schriftgroesse, Dunkel)` und die Standardwerte
(`Speicher.Standard`) stehen in `Speicher.cs`:

1. Lege die `JsonSerializerOptions` an: eingerückt (`WriteIndented`) und mit
   camelCase-Namen (`PropertyNamingPolicy`).
2. `Speichere(pfad, einstellungen)` schreibt die Einstellungen als JSON in die
   Datei (`"schriftgroesse": 14`).
3. `Lade(pfad)` liest sie wieder. Fehlt die Datei, ist ihr Inhalt kein gültiges
   JSON (dann wirft `Deserialize` eine `JsonException`, auch bei einer leeren
   Datei) oder steht dort `null`, bekommt das Programm die Standardwerte. Fange
   genau die `JsonException`; ein falscher Dateipfad ist ein anderer Fehler.

Diese Tests müssen bestehen:

- `SpeicherTests.Lade_ohne_Datei_liefert_die_Standardwerte`
- `SpeicherTests.Lade_mit_unbrauchbarem_Inhalt_liefert_die_Standardwerte`
- `SpeicherTests.Lade_liest_gueltiges_camelCase_JSON`
- `SpeicherTests.Speichere_schreibt_eingerueckt_und_in_camelCase`
- `SpeicherTests.Speichern_und_Laden_ergeben_dasselbe`
- `SpeicherTests.Speichere_ueberschreibt_eine_vorhandene_Datei`
