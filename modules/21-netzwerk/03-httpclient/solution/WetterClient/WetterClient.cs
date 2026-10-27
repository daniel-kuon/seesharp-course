using System.Net;
using System.Text;
using System.Text.Json;

public record Wetter(string Stadt, double Temperatur);

public class WetterClient
{
    private static readonly JsonSerializerOptions JsonOptionen = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private readonly HttpClient _http;

    // Den HttpClient bekommt der Konstruktor von außen (ein Client für das ganze Programm, in den Tests mit
    // einem Test-Handler). WetterClient gibt ihn deshalb nicht frei.
    public WetterClient(HttpClient http) => _http = http;

    public Task<string> HoleTextAsync(string pfad) => _http.GetStringAsync(pfad);

    // Buchweg (16.5, 21.3.3). Deep Dive: GetFromJsonAsync<Wetter>(...) und PostAsJsonAsync(...) aus
    // System.Net.Http.Json erledigen dasselbe kürzer (Web-Voreinstellung: camelCase).
    public async Task<Wetter?> HoleWetterAsync(string stadt)
    {
        string json = await _http.GetStringAsync($"wetter?stadt={Uri.EscapeDataString(stadt)}");
        return JsonSerializer.Deserialize<Wetter>(json, JsonOptionen);
    }

    public async Task<bool> MeldeAsync(string stadt, double temperatur)
    {
        using StringContent inhalt = new(JsonSerializer.Serialize(new Wetter(stadt, temperatur), JsonOptionen),
            Encoding.UTF8, "application/json");
        using var antwort = await _http.PostAsync("meldung", inhalt);
        return antwort.IsSuccessStatusCode;
    }

    public async Task<bool> ExistiertAsync(string pfad)
    {
        using var anfrage = new HttpRequestMessage(HttpMethod.Head, pfad);
        using var antwort = await _http.SendAsync(anfrage);
        return antwort.IsSuccessStatusCode;
    }

    public async Task<string?> HoleOderNullAsync(string pfad)
    {
        try
        {
            using var antwort = await _http.GetAsync(pfad);
            antwort.EnsureSuccessStatusCode();
            return await antwort.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.InternalServerError)
        {
            return null;
        }
    }
}
