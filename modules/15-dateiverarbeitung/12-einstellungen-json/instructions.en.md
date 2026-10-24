# Extra: Settings as JSON

Extra exercise: optional; it unlocks nothing. For further reading: **16.5.2 Serialization** (page 1045), **16.5.3 Controlling (De)serialization** (page 1048), and **16.5.4 Deserialization** (page 1050).

A program stores its settings in a JSON file. The `Einstellungen(Sprache, Schriftgroesse, Dunkel)` record and the default values (`Speicher.Standard`) are defined in `Speicher.cs`:

1. Create the `JsonSerializerOptions`: indented (`WriteIndented`) and with camelCase names (`PropertyNamingPolicy`).
2. `Speichere(pfad, einstellungen)` writes the settings to the file as JSON (`"schriftgroesse": 14`).
3. `Lade(pfad)` reads it again. If the file is missing, its content is not valid JSON (in which case `Deserialize` throws a `JsonException`, even if the file is empty), or if it contains `null`, the program uses the default values. Be sure to catch the `JsonException` specifically; an incorrect file path is a different error.

The following tests must be passed:

- `SpeicherTests.Lade_ohne_Datei_liefert_die_Standardwerte`
- `SpeicherTests.Lade_mit_unbrauchbarem_Inhalt_liefert_die_Standardwerte`
- `SpeicherTests.Lade_liest_gueltiges_camelCase_JSON`
- `SpeicherTests.Speichere_schreibt_eingerueckt_und_in_camelCase`
- `SpeicherTests.Speichern_und_Laden_ergeben_dasselbe`
- `SpeicherTests.Speichere_ueberschreibt_eine_vorhandene_Datei`
