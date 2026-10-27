using System.Net;
using System.Net.Http.Json;

// Fertig: ein Eintrag der Vorhersage, JSON: {"tag":"Mo","temperatur":12.5}
public record Vorhersage(string Tag, double Temperatur);

public class VorhersageClient
{
    public const int MaxVersuche = 3;

    private readonly HttpClient _http;

    // Den HttpClient bekommt der Konstruktor von außen; die Adresse unten ist relativ zu seiner BaseAddress.
    public VorhersageClient(HttpClient http) => _http = http;

    // TODO 1: Ist anzahl <= 0, wirf ArgumentOutOfRangeException (bevor etwas gesendet wird).
    // TODO 2: Sende GET auf "vorhersage?ort=<Ort kodiert>&tage=<anzahl>" (GetAsync, also mit Zugriff auf
    // den Statuscode).
    // TODO 3: Status 404: leere Liste zurückgeben.
    // TODO 4: Status 503: bis zu MaxVersuche Versuche INSGESAMT (der erste Versuch zählt mit). Gibt es nach
    // dem dritten Versuch noch 503, wirf die HttpRequestException (EnsureSuccessStatusCode). Es wird zwischen
    // den Versuchen nicht gewartet (die Tests zählen nur die Anforderungen).
    // TODO 5: Bei Erfolg die JSON-Liste lesen (await antwort.Content.ReadFromJsonAsync<List<Vorhersage>>(), nicht im Buch, hier vorgegeben). Jeder andere
    // Fehlerstatus (z. B. 500) wirft die HttpRequestException ohne Wiederholung.
    // Tipp: eine Schleife "for (var versuch = 1; ; versuch++)" mit await in der Schleife; die Antwort
    // gibst du mit "using var" frei.
    public Task<IReadOnlyList<Vorhersage>> TageAsync(string ort, int anzahl) => throw new NotImplementedException();
}
