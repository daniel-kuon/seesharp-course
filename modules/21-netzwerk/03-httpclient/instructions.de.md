# HttpClient gegen einen Test-Server

Lies im Buch **21.3.2 GET-Anforderungen ohne Anforderungsparameter**
(Seite 1509) mit **21.3.2.1 HTML-Code abrufen**, **21.3.2.3 Header zu einer
HTTP-Antwort anfordern** (Seite 1511) und **21.3.3 Anforderungsparameter**
(Seite 1512 bis 1516). Beispielprojekte: `Netzwerk/HTTPS/...` im Sample-Ordner.

Die Tests verbinden sich **nicht** mit dem Internet. Sie geben dem
`HttpClient` einen Test-`HttpMessageHandler` mit, der jede Anforderung
aufzeichnet und eine vorbereitete Antwort liefert. Deshalb bekommt
`WetterClient` seinen `HttpClient` vom Aufrufer (in einem echten Programm
legt man **einen** an und benutzt ihn überall). Die Methoden sind
asynchron; eine kurze Einführung in `async`/`await` steht am Anfang von
`WetterClient.cs`. Öffne die Datei:

1. `HoleTextAsync(pfad)` holt den Text per GET (`GetStringAsync`).
2. `HoleWetterAsync(stadt)` ruft `wetter?stadt=<Stadt>` mit `GetStringAsync` auf
   und verwandelt den JSON-Text mit `JsonSerializer.Deserialize<Wetter>(json,
   JsonOptionen)` in ein `Wetter` (16.5, Seite 1046; die Optionen mit
   camelCase-Namen stehen fertig in der Datei). Die Stadt kodierst du mit
   `Uri.EscapeDataString(stadt)` (nicht im Buch, hier vorgegeben): Aus `Köln`
   wird `K%C3%B6ln`, aus `A&B=C` wird `A%26B%3DC`.
3. `MeldeAsync(stadt, temperatur)` sendet per POST ein `Wetter` als JSON, wie
   in 21.3.3.2 (Seite 1515): `JsonSerializer.Serialize`, `StringContent` mit
   `Encoding.UTF8` und `"application/json"`, dann `PostAsync`. Ergebnis: `true`
   bei 2xx, `false` sonst, ohne Ausnahme; dafür gibt es
   `antwort.IsSuccessStatusCode` (nicht im Buch, hier vorgegeben: `true` genau
   für 200 bis 299).
4. `ExistiertAsync(pfad)` schickt eine HEAD-Anforderung: `true` bei Erfolg,
   `false` bei 404.
5. `HoleOderNullAsync(pfad)` liefert den Text, bei Status 500 aber `null`
   (`EnsureSuccessStatusCode` und `catch ... when`). Andere Fehler werden
   weitergegeben.

Die Tests prüfen auch, welche Methode, Adresse und welchen Inhalt der
Handler aufgezeichnet hat.

> **Deep Dive (optional):** Das Paket `System.Net.Http.Json` (im .NET-SDK
> enthalten, nicht im Buch) kürzt Schritt 2 und 3 ab:
> `await _http.GetFromJsonAsync<Wetter>(adresse)` holt und deserialisiert in
> einem Schritt, `await _http.PostAsJsonAsync("meldung", wetter)` serialisiert
> und sendet. Beide benutzen von selbst camelCase-Namen. Wer mag, schreibt die
> beiden Methoden danach so um; die Tests bleiben dieselben.

Diese Tests müssen bestehen:

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
