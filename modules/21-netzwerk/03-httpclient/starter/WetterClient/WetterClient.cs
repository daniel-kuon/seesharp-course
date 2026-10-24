using System.Net;
using System.Net.Http.Json;

// ---------------------------------------------------------------------------------------------------
// Mini-Einführung in async/await (nur das, was diese Aufgabe braucht)
//
// Netzwerkaufrufe dauern. Methoden von HttpClient geben deshalb sofort eine Task<T> zurück: das
// "Versprechen" eines Ergebnisses, das später eintrifft. Mit "await" wartest du auf dieses Ergebnis, ohne
// den Thread zu blockieren:
//
//     public async Task<string> HoleAsync(string pfad)     // "async" erlaubt "await" im Rumpf
//     {
//         string text = await _http.GetStringAsync(pfad);  // wartet; text ist danach ein normaler string
//         return text.Trim();                              // der Rückgabewert wird zur Task<string>
//     }
//
// Eine Methode mit "async" liefert Task<T> (statt T) bzw. Task (statt void). Fehler der Anforderung
// (HttpRequestException) werden beim await geworfen und lassen sich mit try/catch abfangen wie sonst auch.
// Mehr ist hier nicht nötig; das Wahlmodul Multithreading erklärt, was dahinter passiert.
// ---------------------------------------------------------------------------------------------------

// Fertig: die Antwort des Wetterdienstes im JSON-Format {"stadt":"Köln","temperatur":18.5}.
public record Wetter(string Stadt, double Temperatur);

public class WetterClient
{
    private readonly HttpClient _http;

    // Fertig: Den HttpClient bekommt der Konstruktor von außen (ein Client für das ganze Programm; die Tests
    // geben einen Client mit Test-Handler hinein). WetterClient legt keinen eigenen an und gibt ihn nicht frei.
    // Alle Adressen unten sind relativ zur BaseAddress des Clients.
    public WetterClient(HttpClient http) => _http = http;

    // TODO 1: Hole den Text unter dem Pfad per GET (GetStringAsync). Fehlerstatus lösen
    // HttpRequestException aus; sie werden nicht abgefangen.
    public Task<string> HoleTextAsync(string pfad) => throw new NotImplementedException();

    // TODO 2: GET auf "wetter?stadt=<Stadt kodiert mit Uri.EscapeDataString>", die Antwort als Wetter
    // deserialisiert (GetFromJsonAsync<Wetter>). Tipp: "async" davorschreiben und await benutzen.
    public Task<Wetter?> HoleWetterAsync(string stadt) => throw new NotImplementedException();

    // TODO 3: POST auf "meldung" mit new Wetter(stadt, temperatur) als JSON (PostAsJsonAsync).
    // Ergebnis: true bei Statuscode 2xx, sonst false (IsSuccessStatusCode), ohne Ausnahme für 4xx/5xx.
    // Die Antwort gibst du mit "using var" wieder frei.
    public Task<bool> MeldeAsync(string stadt, double temperatur) => throw new NotImplementedException();

    // TODO 4: Sende eine HEAD-Anforderung (new HttpRequestMessage(HttpMethod.Head, pfad) mit SendAsync):
    // true, wenn die Ressource existiert (Erfolgsstatus), false bei 404.
    public Task<bool> ExistiertAsync(string pfad) => throw new NotImplementedException();

    // TODO 5: GET auf den Pfad mit GetAsync, danach EnsureSuccessStatusCode(). Bei Erfolg den Text liefern.
    // Antwortet der Server mit 500 (HttpRequestException.StatusCode == HttpStatusCode.InternalServerError),
    // ist das Ergebnis null (catch ... when (...)); alle anderen Fehler (z. B. 404) werden weitergegeben.
    public Task<string?> HoleOderNullAsync(string pfad) => throw new NotImplementedException();
}
