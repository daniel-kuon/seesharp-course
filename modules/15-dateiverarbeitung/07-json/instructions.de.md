# JSON-Serialisierung

Lies im Buch **16.5 Instanzen im JSON-Format serialisieren** (Seite 1043)
mit **16.5.2 Serialisieren** (Seite 1045), **16.5.3 Steuerung der
(De)serialisierung** (Seite 1048), **16.5.4 Deserialisieren** (Seite 1050)
und **16.5.5 Zirkuläre Referenzen** (Seite 1050).

`System.Text.Json` gehört zum Framework. Öffne `Modell.cs` und `PersonJson.cs`.

1. **Einstellungen**: Lege einmal `JsonSerializerOptions` an und verwende sie
   in allen Methoden (so passen Schreiben und Lesen zusammen): `WriteIndented
   = true`, `PropertyNamingPolicy = JsonNamingPolicy.CamelCase` und
   `Converters = { new JsonStringEnumConverter() }`.
2. `ZuJson(person)` und `AusJson(json)`: `JsonSerializer.Serialize` und
   `Deserialize<Person>`. Das JSON ist mehrzeilig, die Namen sind camelCase
   (`vorname`) und `Status` steht als Text (`"status": "Aktiv"`). Unbekannte
   Eigenschaften im JSON werden beim Einlesen ignoriert.
3. **Attribute** in `Modell.cs`: `Nachname` soll im JSON `familienname` heißen
   (`[JsonPropertyName]`), das `Passwort` darf nie im JSON stehen und wird
   beim Einlesen nicht gesetzt (`[JsonIgnore]`).
4. `Speichern(person, pfad)` und `Laden(pfad)` mit `File.WriteAllText` und
   `ReadAllText`; der Test benutzt einen Ordner mit Leerzeichen, Komma und
   Umlaut.
5. `ZuJsonMitZyklen(abteilung)`: `Abteilung` und `Mitarbeiter` verweisen
   aufeinander. Ohne Behandlung wirft `Serialize` eine `JsonException`;
   mit `ReferenceHandler.IgnoreCycles` wird der Rückverweis `null`.
   `ZuJsonMitPreserve` zeigt die Alternative `ReferenceHandler.Preserve`
   (Metadaten `$id` und `$ref`).

Hinweis: Der Standard-Encoder von `System.Text.Json` schreibt Zeichen
außerhalb von ASCII als `\uXXXX` (`ß` wird `\u00DF`). Das ist gültiges JSON
und wird beim Einlesen zurückverwandelt.

Diese Tests müssen bestehen:

- `PersonJsonTests.ZuJson_ist_mehrzeilig_und_schreibt_camelCase`
- `PersonJsonTests.ZuJson_schreibt_Enums_als_Text`
- `PersonJsonTests.Attribut_benennt_die_Eigenschaft_um`
- `PersonJsonTests.Das_Passwort_steht_nie_im_JSON`
- `PersonJsonTests.AusJson_liest_was_ZuJson_geschrieben_hat`
- `PersonJsonTests.AusJson_ignoriert_unbekannte_Eigenschaften_und_setzt_kein_Passwort`
- `PersonJsonTests.Speichern_und_Laden_in_einem_Ordner_mit_Sonderzeichen`
- `PersonJsonTests.ZuJsonMitZyklen_wirft_nicht_und_ersetzt_den_Rueckverweis_durch_null`
- `PersonJsonTests.ZuJsonMitPreserve_schreibt_id_und_ref`
