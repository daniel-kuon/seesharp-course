# Extra: Typed Client for a Weather API

Extra exercise: optional; it unlocks nothing. For further reading: **21.3.2 GET Requests Without Request Parameters** (page 1509) and **21.3.3.1 GET** (page 1513).

A **Typed Client** is a class that takes an `HttpClient` as input and hides the addresses and JSON format of an interface from the rest of the program. Here, it is `VorhersageClient` for a service that returns a forecast as a JSON list, again tested using a test handler without a network connection. Open `VorhersageClient.cs`: The `TageAsync(ort, anzahl)` method calls `vorhersage?ort=<Ort>&tage=<anzahl>`.

- Answer 200: the JSON list as `Vorhersage` entries.
- Answer 404 (location unknown): an **empty list**, without exception.
- Response 503 (Service Overloaded): Attempt **up to three times**, including the first attempt, with no wait time. After the third failure, a `HttpRequestException` is thrown.
- Any other error status: `HttpRequestException`; no retry.
- `anzahl <= 0`: `ArgumentOutOfRangeException` before anything is sent.

The tests count the requirements in the handler.

The following tests must be passed:

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
