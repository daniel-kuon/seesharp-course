# Zusatz: Typed Client für eine Wetter-API

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**21.3.2 GET-Anforderungen ohne Anforderungsparameter** (Seite 1509) und
**21.3.3.1 GET** (Seite 1513).

Ein **Typed Client** ist eine Klasse, die einen `HttpClient` einspeist
bekommt und die Adressen und das JSON-Format einer Schnittstelle vor dem
restlichen Programm versteckt. Hier ist es `VorhersageClient` für einen
Dienst, der eine Vorhersage als JSON-Liste liefert, wieder getestet mit einem
Test-Handler ohne Netzwerk. Öffne `VorhersageClient.cs`: Die Methode
`TageAsync(ort, anzahl)` ruft `vorhersage?ort=<Ort>&tage=<anzahl>` auf.

- Antwort 200: die JSON-Liste als `Vorhersage`-Einträge, gelesen mit
  `await antwort.Content.ReadFromJsonAsync<List<Vorhersage>>()` (nicht im Buch,
  hier vorgegeben; der Buchweg mit `ReadAsStringAsync` und
  `JsonSerializer.Deserialize` samt camelCase-Optionen geht auch).
- Antwort 404 (Ort unbekannt): eine **leere Liste**, ohne Ausnahme.
- Antwort 503 (Dienst überlastet): **bis zu dreimal** versuchen, den ersten
  Versuch mitgezählt, ohne Wartezeit. Nach dem dritten Fehlschlag wird die
  `HttpRequestException` geworfen.
- Jeder andere Fehlerstatus: `HttpRequestException`, ohne Wiederholung.
- `anzahl <= 0`: `ArgumentOutOfRangeException`, bevor etwas gesendet wird.

Die Tests zählen die Anforderungen im Handler.

Diese Tests müssen bestehen:

- `VorhersageTests.TageAsync_liest_die_JSON_Liste`
- `VorhersageTests.TageAsync_baut_die_Adresse_mit_kodiertem_Ort`
- `VorhersageTests.TageAsync_liefert_bei_leerer_Liste_eine_leere_Liste`
- `VorhersageTests.Status_404_ergibt_eine_leere_Liste_ohne_Wiederholung`
- `VorhersageTests.Status_503_wird_wiederholt_bis_es_klappt`
- `VorhersageTests.Status_503_nach_dem_ersten_Versuch_kostet_nur_zwei_Anforderungen`
- `VorhersageTests.Dreimal_503_ergibt_HttpRequestException_nach_genau_drei_Versuchen`
- `VorhersageTests.Andere_Fehlerstatus_werden_nicht_wiederholt`
- `VorhersageTests.Anzahl_kleiner_1_wirft_vor_dem_Senden`
- `VorhersageTests.Der_Client_kann_mehrfach_benutzt_werden`
