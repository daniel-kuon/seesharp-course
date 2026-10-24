using System.Net;
using System.Net.Http.Json;

public record Vorhersage(string Tag, double Temperatur);

public class VorhersageClient
{
    public const int MaxVersuche = 3;

    private readonly HttpClient _http;

    public VorhersageClient(HttpClient http) => _http = http;

    // GET vorhersage?ort=<Ort>&tage=<anzahl>. 503: bis zu MaxVersuche Versuche insgesamt (ohne Wartezeit),
    // danach HttpRequestException. 404: leere Liste. Andere Fehlerstatus: HttpRequestException.
    public async Task<IReadOnlyList<Vorhersage>> TageAsync(string ort, int anzahl)
    {
        if (anzahl <= 0)
            throw new ArgumentOutOfRangeException(nameof(anzahl));

        var adresse = $"vorhersage?ort={Uri.EscapeDataString(ort)}&tage={anzahl}";
        for (var versuch = 1; ; versuch++)
        {
            using var antwort = await _http.GetAsync(adresse);
            if (antwort.StatusCode == HttpStatusCode.NotFound)
                return Array.Empty<Vorhersage>();
            if (antwort.StatusCode == HttpStatusCode.ServiceUnavailable && versuch < MaxVersuche)
                continue; // Hier ohne Wartezeit zwischen den Versuchen; ein echter Client würde mit Task.Delay eine wachsende Pause einlegen.

            antwort.EnsureSuccessStatusCode();
            return await antwort.Content.ReadFromJsonAsync<List<Vorhersage>>() ?? new List<Vorhersage>();
        }
    }
}
