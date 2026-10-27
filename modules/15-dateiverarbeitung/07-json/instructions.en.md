# JSON Serialization

See the **section “16.5 Serializing Instances in JSON Format”** (page 1043) in the book, including **16.5.2 “Serialization”** (page 1045), **16.5.3 Controlling (De)serialization** (page 1048), **16.5.4 Deserializing** (page 1050), and **16.5.5 Circular References** (page 1050).

`System.Text.Json` is part of the framework. Open `Modell.cs` and `PersonJson.cs`.

1. **Settings**: Create a `JsonSerializerOptions` object once and use it in all methods (so that writing and reading are consistent): `WriteIndented = true`, `PropertyNamingPolicy = JsonNamingPolicy.CamelCase`, and `Converters = { new JsonStringEnumConverter() }` (the converter for enums as text is not in the book, given here).
2. `ZuJson(person)` and `AusJson(json)`: `JsonSerializer.Serialize` and `Deserialize<Person>`. The JSON spans multiple lines; the names are in camelCase (`vorname`), and `Status` is stored as text (`"status": "Aktiv"`). Unknown properties in the JSON are ignored during parsing.
3. **Attributes** in `Modell.cs`: The `Nachname` should be called `familienname` in the JSON (`[JsonPropertyName]`), and the `Passwort` must never appear in the JSON and is not set when the data is loaded (`[JsonIgnore]`). The book shows `[JsonIgnore]` in 16.5.3.2 (page 1048); `[JsonPropertyName("familienname")]` from the same namespace `System.Text.Json.Serialization` is written the same way, with the new name as its argument. Attributes in general only come in level 16.
4. `Speichern(person, pfad)` and `Laden(pfad)` using `File.WriteAllText(pfad, json)` and `File.ReadAllText(pfad)` (not in the book, given here: they write or read one whole string); the test uses a folder name containing spaces, commas, and umlauts.
5. `ZuJsonMitZyklen(abteilung)`: `Abteilung` and `Mitarbeiter` refer to each other. If left unhandled, `Serialize` throws a `JsonException`; `ReferenceHandler.IgnoreCycles` (not in the book) sets the back reference to `null`. `ZuJsonMitPreserve` shows the alternative `ReferenceHandler.Preserve` (metadata `$id` and `$ref`).

Note: The default `System.Text.Json` encoder writes non-ASCII characters as `\uXXXX` (`ß` becomes `\u00DF`). This is valid JSON and is converted back when the data is read.

The following tests must be passed:

- `PersonJsonTests.ZuJson_ist_mehrzeilig_und_schreibt_camelCase`
- `PersonJsonTests.ZuJson_schreibt_Enums_als_Text`
- `PersonJsonTests.Attribut_benennt_die_Eigenschaft_um`
- `PersonJsonTests.Das_Passwort_steht_nie_im_JSON`
- `PersonJsonTests.AusJson_liest_was_ZuJson_geschrieben_hat`
- `PersonJsonTests.AusJson_ignoriert_unbekannte_Eigenschaften_und_setzt_kein_Passwort`
- `PersonJsonTests.Speichern_und_Laden_in_einem_Ordner_mit_Sonderzeichen`
- `PersonJsonTests.ZuJsonMitZyklen_wirft_nicht_und_ersetzt_den_Rueckverweis_durch_null`
- `PersonJsonTests.ZuJsonMitPreserve_schreibt_id_und_ref`
