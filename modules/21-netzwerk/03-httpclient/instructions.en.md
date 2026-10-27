# HttpClient against a test server

Read section **21.3.2**, **“GET Requests Without Request Parameters**” (page 1509), including **21.3.2.1**, **“Retrieving HTML Code**,” **21.3.2.3 Requesting Headers in an HTTP Response** (page 1511), and **21.3.3 Request Parameters** (pages 1512–1516). Sample projects: `Netzwerk/HTTPS/...` in the Sample folder.

The tests do **not** connect to the Internet. They provide the `HttpClient` with a test `HttpMessageHandler` that logs every request and returns a predefined response. That is why `WetterClient` gets its `HttpClient` from the caller (in a real program, you create **one** and use it everywhere). The methods are asynchronous; a brief introduction to `async`/`await` is provided at the beginning of `WetterClient.cs`. Open the file:

1. `HoleTextAsync(pfad)` retrieves the text using a GET request (`GetStringAsync`).
2. `HoleWetterAsync(stadt)` calls `wetter?stadt=<Stadt>` with `GetStringAsync` and turns the JSON text into a `Wetter` with `JsonSerializer.Deserialize<Wetter>(json, JsonOptionen)` (16.5, page 1046; the options with camelCase names are already in the file). Encode the city with `Uri.EscapeDataString(stadt)` (not in the book, given here): `Köln` becomes `K%C3%B6ln`, `A&B=C` becomes `A%26B%3DC`.
3. `MeldeAsync(stadt, temperatur)` sends a `Wetter` as JSON via POST, as in 21.3.3.2 (page 1515): `JsonSerializer.Serialize`, `StringContent` with `Encoding.UTF8` and `"application/json"`, then `PostAsync`. It returns `true` for 2xx, `false` otherwise, without throwing an exception; use `antwort.IsSuccessStatusCode` for this (not in the book, given here: `true` exactly for 200 to 299).
4. `ExistiertAsync(pfad)` sends a HEAD request: returns `true` if successful, `false` if a 404 error occurs.
5. `HoleOderNullAsync(pfad)` returns the text, but returns `null` if the status is 500 (`EnsureSuccessStatusCode` and `catch ... when`). Other errors are propagated.

The tests also verify which method, address, and content the handler has logged.

> **Deep Dive (optional):** The package `System.Net.Http.Json` (part of the .NET SDK, not in the book) shortens steps 2 and 3: `await _http.GetFromJsonAsync<Wetter>(address)` fetches and deserializes in one step, `await _http.PostAsJsonAsync("meldung", wetter)` serializes and sends. Both use camelCase names on their own. If you like, rewrite the two methods this way afterwards; the tests stay the same.

The following tests must be passed:

- `WetterClientTests.HoleTextAsync_liefert_den_Text_per_GET`
- `WetterClientTests.HoleTextAsync_wirft_bei_404_HttpRequestException_mit_Statuscode`
- `WetterClientTests.HoleWetterAsync_deserialisiert_die_JSON_Antwort`
- `WetterClientTests.HoleWetterAsync_kodiert_den_Parameter_in_der_Adresse`
- `WetterClientTests.HoleWetterAsync_wirft_bei_Fehlerstatus`
- `WetterClientTests.MeldeAsync_sendet_JSON_per_POST`
- `WetterClientTests.MeldeAsync_meldet_Erfolg_ohne_Ausnahme`
- `WetterClientTests.ExistiertAsync_sendet_HEAD_und_liefert_true_bei_200`
- `WetterClientTests.ExistiertAsync_liefert_false_bei_404_ohne_Ausnahme`
- `WetterClientTests.HoleOderNullAsync_liefert_den_Text_bei_Erfolg`
- `WetterClientTests.HoleOderNullAsync_liefert_null_bei_500`
- `WetterClientTests.HoleOderNullAsync_gibt_andere_Fehler_weiter`
- `WetterClientTests.Der_uebergebene_HttpClient_bleibt_fuer_weitere_Aufrufe_nutzbar`
