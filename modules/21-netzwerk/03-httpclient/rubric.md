# Rubrik — HttpClient gegen einen Test-Server (nur für die Betreuung)

- Kern: `HttpClient` wird eingespeist und nicht im Client erzeugt oder
  freigegeben (Test `Der_uebergebene_HttpClient_bleibt_...`); `async`/`await`
  als "warten ohne zu blockieren"; der Unterschied zwischen "kein
  Ausnahmefehler, aber Statuscode" (`GetAsync`, `PostAsJsonAsync`) und
  "Ausnahme bei Fehlerstatus" (`GetStringAsync`, `GetFromJsonAsync`,
  `EnsureSuccessStatusCode`).
- Typische Fehler: `.Result` oder `.Wait()` statt `await` (blockiert, in der
  GUI gefährlich); `new HttpClient()` pro Aufruf; Parameter ohne
  `EscapeDataString` in die Adresse schreiben (der Test mit `A&B=C` fängt
  das); `using` über dem eingespeisten Client; `async void`.
- Der Test-Handler (`StubHandler`) lohnt einen Blick: Er ist die übliche
  Technik, HttpClient-Code ohne Netzwerk zu prüfen; ein Handler ersetzt den
  Teil, der Verbindungen aufbaut. Nachfrage: Was wäre der Nachteil eines
  echten Servers im Test (Port, Timing, Netz)?
- JSON-Namen: `GetFromJsonAsync` und `PostAsJsonAsync` verwenden die
  Web-Voreinstellung (camelCase, Groß-/Kleinschreibung egal), deshalb passen
  `stadt` und `temperatur` zum Record `Wetter`.
- `ExistiertAsync` nutzt `IsSuccessStatusCode`; 500 ergibt ebenfalls
  `false`. Das ist eine Vereinfachung; in einem echten Programm würde man
  Serverfehler vermutlich als Fehler weitergeben.

Modellantwort: `solution/` bzw. `samples/Netzwerk/HTTPS/Anforderungsparameter/GET`
und `POST`, `HTML-Code abrufen`, `HttpMethod.Head`, `Datei herunterladen`.
